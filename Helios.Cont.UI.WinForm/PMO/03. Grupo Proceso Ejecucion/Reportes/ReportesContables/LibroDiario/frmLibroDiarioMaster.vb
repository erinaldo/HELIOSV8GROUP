Imports Helios.Cont.Business.Entity
Imports Helios.General
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class frmLibroDiarioMaster
    Sub vaciarCajas()
        txtidProveedor.Clear()
        txtProveedor.Clear()
        txtDocumento.Clear()
        txtIdComprobante.Clear()
        txtComprobante.Clear()
        txtFechaInicio.Value = Date.Now
        txtFechaFin.Value = Date.Now
    End Sub

    Public Sub BuscarLibroDiarioIdDocumento(intIdDocumento As Integer)
        Dim asientoSA As New AsientoSA
        dgvLibroAsiento.Rows.Clear()
        dgvMovimiento.Rows.Clear()
        For Each i In asientoSA.UbicarAsientoPorDocumento(intIdDocumento)
            dgvLibroAsiento.Rows.Add(i.idAsiento, i.idDocumento, i.idAlmacen, i.nombreAlmacen,
                                  i.idEntidad, i.nombreEntidad, i.fechaProceso, i.tipoAsiento,
                                  i.importeMN, i.importeME, i.glosa)
        Next
    End Sub

    Public Sub BuscarLibroDiarioIdEntidad(intidEntidad As Integer)
        Dim asientoSA As New AsientoSA
        dgvLibroAsiento.Rows.Clear()
        dgvMovimiento.Rows.Clear()
        For Each i In asientoSA.UbicarAsientoPorEntidad(intidEntidad)
            dgvLibroAsiento.Rows.Add(i.idAsiento, i.idDocumento, i.idAlmacen, i.nombreAlmacen,
                                  i.idEntidad, i.nombreEntidad, i.fechaProceso, i.tipoAsiento,
                                  i.importeMN, i.importeME, i.glosa)
        Next
    End Sub

    Public Sub BuscarLibroDiarioIdTipo(intidTipo As String)
        Dim asientoSA As New AsientoSA
        dgvLibroAsiento.Rows.Clear()
        dgvMovimiento.Rows.Clear()
        For Each i In asientoSA.UbicarAsientoPorTipo(intidTipo)
            dgvLibroAsiento.Rows.Add(i.idAsiento, i.idDocumento, i.idAlmacen, i.nombreAlmacen,
                                    i.idEntidad, i.nombreEntidad, i.fechaProceso, i.tipoAsiento,
                                    i.importeMN, i.importeME, i.glosa)
        Next
    End Sub

    Public Sub BuscarLibroDiarioFecha(srtFechaInicio As Date, srtFechaFin As Date, strCodigoDetalle As String)
        Dim asientoSA As New AsientoSA
        dgvLibroAsiento.Rows.Clear()
        dgvMovimiento.Rows.Clear()
        For Each i In asientoSA.UbicarAsientoPorFecha(srtFechaInicio, srtFechaFin, strCodigoDetalle)
            dgvLibroAsiento.Rows.Add(i.idAsiento, i.idDocumento, i.idAlmacen, i.nombreAlmacen,
                                    i.idEntidad, i.nombreEntidad, i.fechaProceso, i.tipoAsiento,
                                    i.importeMN, i.importeME, i.glosa)
        Next
    End Sub

    'Public Sub BuscarLibroDiarioPeriodo(srtFechaMes As String, srtFechaAnio As Date)
    '    Dim asientoSA As New AsientoSA
    '    dgvLibroAsiento.Rows.Clear()
    '    dgvMovimiento.Rows.Clear()
    '    For Each i In asientoSA.UbicarAsientoPorPeriodo(srtFechaMes, srtFechaAnio)
    '        dgvLibroAsiento.Rows.Add(i.idAsiento, i.idDocumento, i.idAlmacen, i.nombreAlmacen,
    '                                i.idEntidad, i.nombreEntidad, i.fechaProceso, i.tipoAsiento,
    '                                i.importeMN, i.importeME, i.glosa)
    '    Next
    'End Sub

    Public Sub BuscarLibroDiarioFull()
        Dim asientoSA As New AsientoSA
        dgvLibroAsiento.Rows.Clear()
        For Each i In asientoSA.ObtenerListaAsientos()
            dgvLibroAsiento.Rows.Add(i.idAsiento, i.idDocumento, i.idAlmacen, i.nombreAlmacen,
                                     i.idEntidad, i.nombreEntidad, i.fechaProceso, i.tipoAsiento,
                                     i.importeMN, i.importeME, i.glosa)
        Next
    End Sub

    Public Sub BuscarLibroDiarioMovimiento(idAsiento As Integer)
        Me.Cursor = Cursors.WaitCursor
        Dim movimientoSA As New MovimientoSA
        For Each ix In movimientoSA.UbicarMovimientoPorAsiento(idAsiento)
            If ix.tipo = "D" Then
                dgvMovimiento.Rows.Add(ix.idmovimiento, ix.cuenta, ix.descripcion, ix.tipo, ix.monto, ix.montoUSD, "0.00", "0.00", ix.idmovimiento)
            ElseIf ix.tipo = "H" Then
                dgvMovimiento.Rows.Add(ix.idmovimiento, ix.cuenta, ix.descripcion, ix.tipo, "0.00", "0.00", ix.monto, ix.montoUSD, ix.idmovimiento)
            End If
        Next
        Me.Cursor = Cursors.Arrow
    End Sub

    Sub ProveedoresShows()
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'With frmModalEntidades
        '    .lblTipo.Text = "PR"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtidProveedor.Text = datos(0).ID
        '        txtProveedor.Text = datos(0).NombreEntidad
        '        txtProveedor.Focus()
        '    Else
        '        txtidProveedor.Text = String.Empty
        '        txtProveedor.Text = String.Empty
        '        txtProveedor.Focus()
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub QComboBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles QComboBox1.TextChanged
        Me.Cursor = Cursors.WaitCursor
        vaciarCajas()
        If (QComboBox1.Text = "Entidad") Then
            GroupBox3.Visible = False
            Label6.Visible = True
            txtidProveedor.Visible = True
            txtProveedor.Visible = True
            Label1.Visible = False
            LinkProveedor.Visible = True
            txtDocumento.Visible = False
            Label3.Visible = False
            txtIdComprobante.Visible = False
            txtComprobante.Visible = False
            LinkTipoDoc.Visible = False
            Label8.Visible = False
            dtpPeriodoMes.Visible = False
            dtpPeriodoAnio.Visible = False
            btnBuscar.Location = New Point(468, 22)

        ElseIf (QComboBox1.Text = "Documento") Then
            GroupBox3.Visible = False
            Label6.Visible = False
            txtidProveedor.Visible = False
            txtProveedor.Visible = False
            LinkProveedor.Visible = False
            Label1.Visible = True
            txtDocumento.Visible = True
            Label3.Visible = False
            txtIdComprobante.Visible = False
            txtComprobante.Visible = False
            LinkTipoDoc.Visible = False
            Label8.Visible = False
            dtpPeriodoMes.Visible = False
            dtpPeriodoAnio.Visible = False
            btnBuscar.Location = New Point(332, 22)
        ElseIf (QComboBox1.Text = "Código Libro") Then
            Label6.Visible = False
            txtidProveedor.Visible = False
            txtProveedor.Visible = False
            LinkProveedor.Visible = False
            Label1.Visible = False
            txtDocumento.Visible = False
            Label3.Visible = True
            txtIdComprobante.Visible = True
            txtComprobante.Visible = True
            LinkTipoDoc.Visible = True
            GroupBox3.Visible = False
            Label8.Visible = False
            dtpPeriodoMes.Visible = False
            dtpPeriodoAnio.Visible = False
            btnBuscar.Location = New Point(416, 22)
        ElseIf (QComboBox1.Text = "Fecha Progreso") Then
            Label6.Visible = False
            txtidProveedor.Visible = False
            txtProveedor.Visible = False
            LinkProveedor.Visible = False
            Label1.Visible = False
            txtDocumento.Visible = False
            Label3.Visible = True
            txtIdComprobante.Visible = True
            txtComprobante.Visible = True
            LinkTipoDoc.Visible = True
            GroupBox3.Visible = True
            Label8.Visible = False
            dtpPeriodoMes.Visible = False
            dtpPeriodoAnio.Visible = False
            btnBuscar.Location = New Point(416, 22)
        ElseIf (QComboBox1.Text = "Período") Then
            Label6.Visible = False
            txtidProveedor.Visible = False
            txtProveedor.Visible = False
            LinkProveedor.Visible = False
            Label1.Visible = False
            txtDocumento.Visible = False
            Label3.Visible = True
            txtIdComprobante.Visible = False
            txtComprobante.Visible = False
            LinkTipoDoc.Visible = False
            GroupBox3.Visible = False
            Label8.Visible = True
            dtpPeriodoMes.Visible = True
            dtpPeriodoAnio.Visible = True
            btnBuscar.Location = New Point(332, 22)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Me.Cursor = Cursors.WaitCursor
        Select Case QComboBox1.Text
            Case "Documento"
                If (txtDocumento.Text.Length > 0) Then
                    BuscarLibroDiarioIdDocumento(txtDocumento.Text)
                End If
            Case "Entidad"
                If (txtidProveedor.Text.Length > 0) Then
                    BuscarLibroDiarioIdEntidad(txtidProveedor.Text)
                End If
            Case "Código Libro"
                If (txtComprobante.Text.Length > 0) Then
                    BuscarLibroDiarioIdTipo(txtIdComprobante.Text)
                End If
            Case "Fecha Progreso"
                If (txtComprobante.Text.Length > 0) Then
                    BuscarLibroDiarioFecha(CDate(txtFechaInicio.Value).Date, CDate(txtFechaFin.Value).Date, txtIdComprobante.Text)
                End If
            Case "Período"
                If (dtpPeriodoMes.Text.Length > 0) Then
                    'BuscarLibroDiarioPeriodo(CDate(dtpPeriodoMes.Value), CDate(dtpPeriodoAnio.Value))
                End If
        End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkProveedor_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkProveedor.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        ProveedoresShows()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub LinkTipoDoc_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkTipoDoc.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        'With frmModalComprobantesTabla
        '    .lblTipo.Text = "8"
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        '    If datos.Count > 0 Then
        '        txtIdComprobante.Text = datos(0).ID
        '        txtComprobante.Text = datos(0).NombreCampo
        '    Else
        '        txtIdComprobante.Text = String.Empty
        '        txtComprobante.Text = String.Empty
        '        MsgBox("Debe ingresar un comprobante.", MsgBoxStyle.Information, "Atención!")
        '    End If
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvLibroAsiento_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLibroAsiento.CellContentClick
        Me.Cursor = Cursors.WaitCursor
        If (dgvLibroAsiento.SelectedRows.Count > 0) Then
            dgvMovimiento.Rows.Clear()
            BuscarLibroDiarioMovimiento(CInt(dgvLibroAsiento.Item(0, dgvLibroAsiento.CurrentRow.Index).Value))
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        With frmModalReportesLibroDiario
            Select Case QComboBox1.Text
                Case "Documento"
                    If (txtDocumento.Text.Length > 0) Then
                        .Tag = "Documento"
                        .ConsultaReporte(txtDocumento.Text, txtIdComprobante.Text, txtidProveedor.Text, CDate(txtFechaInicio.Value).Date, CDate(txtFechaFin.Value).Date, (dtpPeriodoMes.Value), (dtpPeriodoAnio.Value), 2014)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                    End If
                Case "Entidad"
                    If (txtidProveedor.Text.Length > 0) Then
                        .Tag = "Entidad"
                        .ConsultaReporte(txtDocumento.Text, txtIdComprobante.Text, txtidProveedor.Text, CDate(txtFechaInicio.Value).Date, CDate(txtFechaFin.Value).Date, (dtpPeriodoMes.Value), (dtpPeriodoAnio.Value), 2014)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                    End If
                Case "Código Libro"
                    If (txtComprobante.Text.Length > 0) Then
                        .Tag = "Código Libro"
                        .ConsultaReporte(txtDocumento.Text, txtIdComprobante.Text, txtidProveedor.Text, CDate(txtFechaInicio.Value).Date, CDate(txtFechaFin.Value).Date, (dtpPeriodoMes.Value), (dtpPeriodoAnio.Value), 2014)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                    End If
                Case "Fecha Progreso"
                    If (txtComprobante.Text.Length > 0) Then
                        .Tag = "Fecha Progreso"
                        .ConsultaReporte(txtDocumento.Text, txtIdComprobante.Text, txtidProveedor.Text, CDate(txtFechaInicio.Value).Date, CDate(txtFechaFin.Value).Date, (dtpPeriodoMes.Value), (dtpPeriodoAnio.Value), 2014)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                    End If
                Case "Período"
                    If (dtpPeriodoMes.Text.Length > 0) Then
                        .Tag = "Período"
                        .ConsultaReporte(txtDocumento.Text, txtIdComprobante.Text, txtidProveedor.Text, CDate(txtFechaInicio.Value).Date, CDate(txtFechaFin.Value).Date, (dtpPeriodoMes.Value), (dtpPeriodoAnio.Value), 2014)
                        .StartPosition = FormStartPosition.CenterScreen
                        .Show()
                    End If
            End Select
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
End Class