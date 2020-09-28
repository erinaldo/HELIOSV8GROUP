Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class TabLG_TransferenciasPendientes
#Region "Fields"
    Dim DocumentoCompraSA As New DocumentoCompraSA
    Dim empresaPeriodoSA As New empresaCierreMensualSA
    Property VentanaSel As FormMaestroLogistica
#End Region

#Region "Constructors"
    Public Sub New(Ventana As FormMaestroLogistica)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        VentanaSel = Ventana
        FormatoGridAvanzado(dgvTransferencia, True, False)
        FormatoGridAvanzado(dgvDetalleTransferencia, True, False)
        GetCombos()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetCombos()
        Dim empresaAnioSA As New empresaPeriodoSA
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year

        cboMes.DisplayMember = "Mes"
        cboMes.ValueMember = "Codigo"
        cboMes.DataSource = ListaDeMeses()
        cboMes.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
    End Sub

    Private Sub getTableComprasPorPeriodoContado(intIdEstablecimiento As Integer, strPeriodo As String)

        Dim dt As New DataTable("Transferencias pendientes ")

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
        Dim documentocompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneralTransferencia(GEstableciento.IdEstablecimiento, strPeriodo)
        For Each i As documentocompra In documentocompra
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
                    dr(19) = "RECEPCIONADO"
                Case "PN"
                    dr(19) = "POR RECEPCIONAR"
            End Select
            dr(20) = GEstableciento.IdEstablecimiento
            dr(21) = GEstableciento.NombreEstablecimiento
            dr(22) = i.NomAlmacenDestino
            dr(23) = i.NomAlmacenOrigen
            dt.Rows.Add(dr)
        Next
        dgvTransferencia.DataSource = dt
        dgvTransferencia.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub

    Private Sub getTableComprasPorPeriodoContadoTipo(strTipo As String, periodo As String)
        Dim dt As New DataTable("Comprobantes pendientes")

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

        Dim documentocompra = DocumentoCompraSA.GetListarComprasPorPeriodoGeneralTransferencia(GEstableciento.IdEstablecimiento, periodo)

        For Each i As documentocompra In documentocompra

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
                        dr(19) = "RECEPCIONADO"
                    Case "PN"
                        dr(19) = "POR RECEPCIONAR"
                End Select
                dr(20) = GEstableciento.IdEstablecimiento
                dr(21) = GEstableciento.NombreEstablecimiento
                dr(22) = i.NomAlmacenDestino
                dr(23) = i.NomAlmacenOrigen

                dt.Rows.Add(dr)

            End If
        Next
        dgvTransferencia.DataSource = dt
        dgvTransferencia.TableOptions.ListBoxSelectionMode = SelectionMode.MultiExtended
    End Sub

    Public Sub ObtenerListaGuiaRemision(iddocumento As Integer)
        Dim rec As Record = dgvTransferencia.Table.CurrentRecord
        Dim DocumentoGuiaSA As New DocumentoGuiaSA

        Dim documentoGuia As New List(Of documentoGuia)

        documentoGuia = DocumentoGuiaSA.ListaGuiasPorCompra(iddocumento)

        Dim dt As New DataTable("Detalle transferencias")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer))) '0
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaTraslado", GetType(String)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String))) '3
        dt.Columns.Add(New DataColumn("direccionPartida", GetType(String)))
        dt.Columns.Add(New DataColumn("idEntidadTransporte", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nombrentidad", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String))) '7

        For Each i In documentoGuia
            Dim dr As DataRow = dt.NewRow()

            dr(0) = i.idDocumento
            dr(1) = i.fechaDoc
            dr(2) = i.fechaTraslado
            Select Case i.monedaDoc
                Case 1
                    dr(3) = "NACIONAL"
                Case 2
                    dr(3) = "EXTRANJERA"
            End Select


            dr(4) = i.direccionPartida
            dr(5) = i.idEntidad
            dr(6) = rec.GetValue("NombreEntidad") ' i.usuarioActualizacion

            Select Case i.estado
                Case TipoGuia.Pendiente
                    dr(7) = "POR CONFIRMAR"
                Case TipoGuia.Transito
                    dr(7) = "PARCIAL"
                Case TipoGuia.Entregado
                    dr(7) = "CONFORME"
            End Select



            dt.Rows.Add(dr)

        Next
        dgvDetalleTransferencia.DataSource = dt

    End Sub
#End Region

#Region "Events"
    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        dgvTransferencia.Table.Records.DeleteAll()
        dgvDetalleTransferencia.Table.Records.DeleteAll()
        getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, cboMes.SelectedValue & "/" & cboAnio.Text)
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If cboMes.Text.Trim.Length > 0 Then
            If (txtBuscar.Text.Length > 0) Then
                dgvDetalleTransferencia.Table.Records.DeleteAll()
                getTableComprasPorPeriodoContadoTipo("DC", cboMes.SelectedValue & "/" & cboAnio.Text)
            End If
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If (CheckBox4.Checked = True) Then
            Panel39.Enabled = False
            txtBuscar.Clear()
            rbTodo.Checked = True
            dgvDetalleTransferencia.Table.Records.DeleteAll()
        Else
            Panel39.Enabled = True
            txtBuscar.Clear()
            rbTodo.Checked = True
            dgvDetalleTransferencia.Table.Records.DeleteAll()
        End If
    End Sub

    Private Sub rbConfirmado_CheckedChanged(sender As Object, e As EventArgs) Handles rbConfirmado.CheckedChanged
        If cboMes.Text.Trim.Length > 0 Then
            If (rbConfirmado.Checked = True) Then
                rbTransito.Checked = False
                rbTodo.Checked = False
                getTableComprasPorPeriodoContadoTipo("DC", cboMes.SelectedValue & "/" & cboAnio.Text)
                txtBuscar.Clear()
                Panel39.Enabled = False
                dgvDetalleTransferencia.Table.Records.DeleteAll()
            End If
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
    End Sub

    Private Sub rbTransito_CheckedChanged(sender As Object, e As EventArgs) Handles rbTransito.CheckedChanged
        If cboMes.Text.Trim.Length > 0 Then
            If (rbConfirmado.Checked = True) Then
                rbTodo.Checked = False
                rbConfirmado.Checked = False
                getTableComprasPorPeriodoContadoTipo("DC", cboMes.SelectedValue & "/" & cboAnio.Text)
                txtBuscar.Clear()
                Panel39.Enabled = False
                dgvDetalleTransferencia.Table.Records.DeleteAll()
            End If
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
    End Sub

    Private Sub rbTodo_CheckedChanged(sender As Object, e As EventArgs) Handles rbTodo.CheckedChanged
        If (rbTodo.Checked = True) Then
            rbTransito.Checked = False
            rbConfirmado.Checked = False
            getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            dgvDetalleTransferencia.Table.Records.DeleteAll()
        End If
    End Sub

    Private Sub dgvTransferencia_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvTransferencia.SelectedRecordsChanged
        Me.Cursor = Cursors.WaitCursor
        dgvDetalleTransferencia.Table.Records.DeleteAll()
        If Not IsNothing(e.SelectedRecord) Then
            ObtenerListaGuiaRemision(e.SelectedRecord.Record.GetValue("idDocumento"))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgvDetalleTransferencia.Table.CurrentRecord
        If Not IsNothing(r) Then

            Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMes.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMes.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If (r.GetValue("estado") = "PARCIAL") Then
                Dim f As New frmControlEntregableTransferencia((dgvDetalleTransferencia.Table.CurrentRecord.GetValue("idDocumento")),
                                                               dgvTransferencia.Table.CurrentRecord, dgvDetalleTransferencia.Table.CurrentRecord)
                f.lblPerido.Text = cboMes.SelectedValue & "/" & cboAnio.Text
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                VentanaSel.ThreadTransitoTransferencia()
                getTableComprasPorPeriodoContado(Nothing, Nothing)
                dgvDetalleTransferencia.Table.Records.DeleteAll()
            ElseIf (r.GetValue("estado") = "POR CONFIRMAR") Then

                If cboMes.Text.Trim.Length > 0 Then
                    Dim objActualizar As New documentoVentaAbarrotesSA
                    Dim f As New frmControlEntregableTransferencia((dgvDetalleTransferencia.Table.CurrentRecord.GetValue("idDocumento")),
                                                                   dgvTransferencia.Table.CurrentRecord, dgvDetalleTransferencia.Table.CurrentRecord)
                    f.lblPerido.Text = cboMes.SelectedValue & "/" & cboAnio.Text
                    f.strTipo = "TRANSFERENCIA"
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog(Me)
                    VentanaSel.ThreadTransitoTransferencia()
                    getTableComprasPorPeriodoContado(GEstableciento.IdEstablecimiento, cboMes.SelectedValue & "/" & cboAnio.Text)
                    'getTableComprasPorPeriodoContadoTipo("DC", cboMes.SelectedValue & "/" & cboanio.text)
                    dgvDetalleTransferencia.Table.Records.DeleteAll()
                Else
                    MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboMes.Select()
                    cboMes.DroppedDown = True
                End If
            Else
                MessageBox.Show("Se realizó la entrega total", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe elegir un registro", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton19_Click(sender As Object, e As EventArgs) Handles ToolStripButton19.Click
        Cursor = Cursors.WaitCursor
        Dim r As Record = dgvDetalleTransferencia.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim f As New frmHistorialRecepcion(dgvDetalleTransferencia.Table.CurrentRecord.GetValue("idDocumento"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Debe elegir una venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub dgvTransferencia_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvTransferencia.TableControlCellClick

    End Sub

#End Region
End Class
