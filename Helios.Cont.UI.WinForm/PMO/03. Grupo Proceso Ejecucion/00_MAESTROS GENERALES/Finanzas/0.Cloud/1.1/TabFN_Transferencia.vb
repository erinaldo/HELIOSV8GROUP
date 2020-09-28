Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class TabFN_Transferencia

#Region "Fields"
    Property empresaPeriodoSA As New empresaCierreMensualSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvMovPeriodo, True, False)
        GetCombos()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetMovimientosPeriodo(intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim listaEstado As New List(Of String)
        Dim dt As New DataTable("Transferencias - período " & strPeriodo & " ")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("movimiento", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))

        dt.Columns.Add(New DataColumn("numeroOperacion", GetType(String)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles"))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd"))

        dt.Columns.Add(New DataColumn("NomCajaOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("NomCajaDestino", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))

        Dim str As String

        'listaEstado.Add(TIPO_ESTADO_CAJA.NO_USADO)
        'listaEstado.Add(TIPO_ESTADO_CAJA.USADO_PARCIAL)
        'listaEstado.Add(TIPO_ESTADO_CAJA.USADO_TOTAL)

        For Each i As documentoCaja In documentoCajaSA.ObtenerMovimientosPorPeriodoFinanzas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, strMovimiento)

            Select Case i.movimientoCaja
                Case "TEC"
                    If i.tipoMovimiento = "PG" Then
                        Dim dr As DataRow = dt.NewRow()
                        str = Nothing
                        str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                        dr(0) = i.idDocumento
                        dr(1) = i.tipoOperacion
                        dr(3) = str
                        Select Case i.movimientoCaja
                            Case "OEC"
                                dr(2) = "OTRAS ENTRADA DE CAJA"
                            Case "OSC"
                                dr(2) = "OTRAS SALIDA DE CAJA"
                            Case "TEC"
                                dr(2) = "TRANSFERENCIA ENTRE CAJAS"
                        End Select
                        dr(3) = str

                        dr(4) = i.numeroOperacion
                        Select Case i.moneda
                            Case 1
                                dr(5) = "NACIONAL"
                            Case 2
                                dr(5) = "EXTRANJERA"
                        End Select
                        dr(6) = FormatNumber(i.montoSoles, 2)
                        dr(7) = i.tipoCambio
                        dr(8) = FormatNumber(i.montoUsd, 2)
                        dr(9) = i.NomCajaOrigen
                        dr(10) = i.NomCajaDestino
                        Select Case i.estado
                            Case TIPO_ESTADO_CAJA.NO_USADO
                                dr(11) = "PENDIENTE DE USO"
                            Case TIPO_ESTADO_CAJA.USADO_PARCIAL
                                dr(11) = "IMPUTADO PARCIALMENTE"
                            Case TIPO_ESTADO_CAJA.USADO_TOTAL
                                dr(11) = "IMPUTADO TOTAL"
                            Case TIPO_ESTADO_CAJA.ANULADO
                                dr(11) = "REVERTIDO-ANULADO"
                            Case TIPO_ESTADO_CAJA.DEVOLUCION
                                dr(11) = "DEVOLUCION"
                        End Select
                        dt.Rows.Add(dr)
                    End If
                Case "OEC"

                    'If (i.moneda = "1") Then
                    If (i.moneda = 1) Then


                        Dim dr As DataRow = dt.NewRow()
                        str = Nothing
                        str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                        dr(0) = i.idDocumento
                        dr(1) = i.tipoOperacion
                        Select Case i.movimientoCaja
                            Case "OEC"
                                dr(2) = "OTRAS ENTRADA DE CAJA"
                        End Select
                        dr(3) = str
                        dr(4) = i.numeroOperacion
                        Select Case i.moneda
                            Case 1
                                dr(5) = "NACIONAL"
                        End Select
                        dr(6) = CDec(i.montoSoles).ToString("N2")
                        dr(7) = i.tipoCambio
                        dr(8) = CDec(i.montoUsd).ToString("N2")
                        dr(9) = "-"
                        dr(10) = i.NomCajaOrigen
                        Select Case i.estado
                            Case TIPO_ESTADO_CAJA.NO_USADO
                                dr(11) = "PENDIENTE DE USO"
                            Case TIPO_ESTADO_CAJA.USADO_PARCIAL
                                dr(11) = "IMPUTADO PARCIALMENTE"
                            Case TIPO_ESTADO_CAJA.USADO_TOTAL
                                dr(11) = "IMPUTADO TOTAL"
                            Case TIPO_ESTADO_CAJA.ANULADO
                                dr(11) = "REVERTIDO-ANULADO"
                            Case TIPO_ESTADO_CAJA.DEVOLUCION
                                dr(11) = "DEVOLUCION"
                        End Select
                        dt.Rows.Add(dr)

                    ElseIf (i.moneda = 2) Then
                        Dim dr As DataRow = dt.NewRow()
                        str = Nothing
                        str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                        dr(0) = i.idDocumento
                        dr(1) = i.tipoOperacion
                        Select Case i.movimientoCaja
                            Case "OEC"
                                dr(2) = "OTRAS ENTRADA DE CAJA"
                        End Select
                        dr(3) = str
                        dr(4) = i.numeroOperacion
                        Select Case i.moneda
                            Case 2
                                dr(5) = "EXTRANJERA"
                        End Select
                        dr(6) = CDec(i.montoSoles).ToString("N2")
                        dr(7) = i.tipoCambio
                        dr(8) = CDec(i.montoUsd).ToString("N2")
                        dr(9) = "-"
                        dr(10) = i.NomCajaOrigen
                        Select Case i.estado
                            Case TIPO_ESTADO_CAJA.NO_USADO
                                dr(11) = "PENDIENTE DE USO"
                            Case TIPO_ESTADO_CAJA.USADO_PARCIAL
                                dr(11) = "IMPUTADO PARCIALMENTE"
                            Case TIPO_ESTADO_CAJA.USADO_TOTAL
                                dr(11) = "IMPUTADO TOTAL"
                            Case TIPO_ESTADO_CAJA.ANULADO
                                dr(11) = "REVERTIDO-ANULADO"
                            Case TIPO_ESTADO_CAJA.DEVOLUCION
                                dr(11) = "DEVOLUCION"
                        End Select
                        dt.Rows.Add(dr)
                    End If
                    'End If

            End Select

        Next
        dgvMovPeriodo.DataSource = dt

    End Sub

    Private Sub GetCombos()
        Dim empresaAnioSA As New empresaPeriodoSA
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = empresaAnioSA.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
    End Sub
#End Region

#Region "Events"
    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Me.Cursor = Cursors.WaitCursor

        'Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
        'fechaAnt = fechaAnt.AddMonths(-1)
        'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        'If periodoAnteriorEstaCerrado = False Then
        '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
        '    Cursor = Cursors.Default
        '    Exit Sub
        'End If

        'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
        'If Not IsNothing(valida) Then
        '    If valida = True Then
        '        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Me.Cursor = Cursors.Default
        '        Exit Sub
        '    End If
        'End If
        Dim f As New frmModalTransferenciaCaja
        f.txtPeriodo.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
        f.lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.txtTipoCambio.Value = TmpTipoCambio
        f.tipoPersona = "PR"
        f.cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
        f.cboMesCompra.Enabled = True
        f.TxtDia.Text = ""
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        'With frmTransferenciaCaja
        'End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        LoadingAnimator.Wire(dgvMovPeriodo.TableControl)
        If Not IsNothing(Me.dgvMovPeriodo.Table.CurrentRecord) Then

            'Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            'fechaAnt = fechaAnt.AddMonths(-1)
            'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            'If periodoAnteriorEstaCerrado = False Then
            '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            '    Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMesCompra.SelectedValue)})
            'If Not IsNothing(valida) Then
            '    If valida = True Then
            '        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '        Exit Sub
            '    End If
            'End If

            'With frmModalTransferenciaCaja
            '    .txtPeriodo.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            '    .lblMovimiento.Tag = "RV"
            '    .lblMovimiento.Text = "REVERSION"
            '    .CaptionLabels(0).Text = "REVERSION"
            '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
            '    .txtTipoCambio.Value = TmpTipoCambio
            '    .cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
            '    .cboMesCompra.Enabled = True
            '    .Tag = 1
            '    .idDocumento = dgvMovPeriodo.Table.CurrentRecord.GetValue("idDocumento")
            '    .UbicarDocumento(dgvMovPeriodo.Table.CurrentRecord.GetValue("idDocumento"))
            '    .txtDia.Value = New Date(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1)
            '    .StartPosition = FormStartPosition.CenterParent
            '    .ShowDialog()
            'End With

        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        LoadingAnimator.UnWire(dgvMovPeriodo.TableControl)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        GetMovimientosPeriodo(GEstableciento.IdEstablecimiento, cboMesCompra.SelectedValue + "/" + cboAnio.Text, "TEC")
        Cursor = Cursors.Default
    End Sub
#End Region

End Class
