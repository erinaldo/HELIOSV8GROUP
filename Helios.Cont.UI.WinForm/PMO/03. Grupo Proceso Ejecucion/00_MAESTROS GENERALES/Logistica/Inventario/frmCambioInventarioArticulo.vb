Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmCambioInventarioArticulo

#Region "Attributes"
    Dim DocumentoCompraSA As New DocumentoCompraSA
    Dim hoveredIndex As Integer = 0
    Dim selectionColl As New Hashtable()
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridPequeño(dgvCambioInventario, True)
        Meses()
        txtAnioCompra.Text = AnioGeneral
    End Sub
#End Region

#Region "Methods"
    Private Sub getTableComprasPorPeriodoCambioTipoInventario(strTipo As String)

        Dim objCompra As New List(Of documentocompra)

        Dim dt As New DataTable("Compras - período " & cboMes.SelectedValue & "/" & AnioGeneral)

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("situacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("Aprobado", GetType(String)))
        dt.Columns.Add(New DataColumn("ant", GetType(Integer)))
        dt.Columns.Add(New DataColumn("estadoEntrega", GetType(String)))

        dt.Columns.Add(New DataColumn("idEstablecimiento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombreEstablecimiento", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("almacenDestino", GetType(String)))

        Dim str As String


        objCompra = DocumentoCompraSA.GetListarComprasPorPeriodoCambioGeneral(GEstableciento.IdEstablecimiento, cboMes.SelectedValue & "/" & AnioGeneral)

        For Each i As documentocompra In objCompra

            If (strTipo = i.estadoEntrega) Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.tipoDoc
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                dr(6) = i.tipoDocEntidad
                dr(7) = i.NroDocEntidad
                dr(8) = i.NombreEntidad
                dr(9) = i.TipoPersona

                If i.tipoCompra = "BOFR" Then
                    dr(10) = CDec(0.0)
                    dr(11) = CDec(0.0)
                    dr(12) = CDec(0.0)
                Else
                    dr(10) = i.importeTotal
                    dr(11) = i.tcDolLoc
                    dr(12) = i.importeUS
                End If

                'dr(11) = i.tcDolLoc
                'dr(12) = i.importeUS
                dr(13) = i.monedaDoc
                dr(14) = i.usuarioActualizacion
                dr(15) = i.situacion
                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(16) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(16) = "Pendiente"
                End Select

                Select Case i.aprobado
                    Case "S"
                        dr(17) = "Aprobado"
                    Case Else
                        dr(17) = "Pendiente"
                End Select
                dr(18) = i.Atraso

                Select Case i.estadoEntrega
                    Case "DC"
                        dr(19) = "ENTREGADO"
                    Case "PN"
                        dr(19) = "POR ENTREGAR"
                End Select
                dr(20) = GEstableciento.IdEstablecimiento
                dr(21) = GEstableciento.NombreEstablecimiento
                dr(22) = i.NomAlmacenDestino
                dr(23) = i.NomAlmacenOrigen

                dt.Rows.Add(dr)

            ElseIf (strTipo = i.estadoEntrega) Then
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.tipoDoc
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                dr(6) = i.tipoDocEntidad
                dr(7) = i.NroDocEntidad
                dr(8) = i.NombreEntidad
                dr(9) = i.TipoPersona

                If i.tipoCompra = "BOFR" Then
                    dr(10) = CDec(0.0)
                    dr(11) = CDec(0.0)
                    dr(12) = CDec(0.0)
                Else
                    dr(10) = i.importeTotal
                    dr(11) = i.tcDolLoc
                    dr(12) = i.importeUS
                End If

                'dr(11) = i.tcDolLoc
                'dr(12) = i.importeUS
                dr(13) = i.monedaDoc
                dr(14) = i.usuarioActualizacion
                dr(15) = i.situacion
                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(16) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(16) = "Pendiente"
                End Select

                Select Case i.aprobado
                    Case "S"
                        dr(17) = "Aprobado"
                    Case Else
                        dr(17) = "Pendiente"
                End Select
                dr(18) = i.Atraso

                Select Case i.estadoEntrega
                    Case "DC"
                        dr(19) = "ENTREGADO"
                    Case "PN"
                        dr(19) = "POR ENTREGAR"
                End Select
                dr(20) = GEstableciento.IdEstablecimiento
                dr(21) = GEstableciento.NombreEstablecimiento
                dr(22) = i.NomAlmacenDestino
                dr(23) = i.NomAlmacenOrigen

                dt.Rows.Add(dr)

            End If
        Next
        dgvCambioInventario.DataSource = dt
        dgvCambioInventario.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub

    Private Sub Meses()
        Dim listaMeses As New List(Of MesesAnio)
        Dim obj As New MesesAnio

        For x = 1 To 12
            obj = New MesesAnio
            obj.Codigo = String.Format("{0:00}", CInt(x))
            obj.Mes = New DateTime(AnioGeneral, x, 1).ToString("MMMM")
            listaMeses.Add(obj)
        Next x

        cboMes.DisplayMember = "Mes"
        cboMes.ValueMember = "Codigo"
        cboMes.DataSource = listaMeses
        cboMes.SelectedValue = MesGeneral
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
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            With frmCambioInventario
                .lblMovimiento.Text = "CAMBIO TIPO INVENTARIO"
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                ButtonAdv19_Click(sender, e)
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Cursor = Cursors.WaitCursor
        getTableComprasPorPeriodoCambioTipoInventario("DC")
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvCambioInventario_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCambioInventario.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvCambioInventario.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvCambioInventario_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvCambioInventario.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvCambioInventario)
    End Sub
#End Region

End Class