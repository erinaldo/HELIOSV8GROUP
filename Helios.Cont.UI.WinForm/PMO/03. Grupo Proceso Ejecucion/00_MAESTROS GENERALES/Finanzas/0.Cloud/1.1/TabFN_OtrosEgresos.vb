Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabFN_OtrosEgresos

#Region "Fields"
    Dim cajaUsuarioSA As New cajaUsuarioSA
    Property empresaPeriodoSA As New empresaCierreMensualSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim filter As New GridExcelFilter()
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvOtrosMov, True, False)
        GetCombos()
    End Sub
#End Region

#Region "Methods"
    Private Sub GetAnularOperacion(idOperacion As Integer)
        Dim cajaSA As New DocumentoCajaSA
        Try
            cajaSA.AnularOtrosPagos(New documento With {.idDocumento = idOperacion})
            dgvOtrosMov.Table.CurrentRecord.Delete()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Verificar transacción")
        End Try
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

    Private Sub GetMovimientosPeriodo(intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim listaDocCaja As List(Of documentoCaja)
        Dim listaEstado As New List(Of String)
        Dim dt As New DataTable("Gastos - período ")
        Dim documentoCajaSA As New DocumentoCajaSA

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
        dt.Columns.Add(New DataColumn("idPersonal", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoPersona", GetType(String)))
        dt.Columns.Add(New DataColumn("movimientoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("movimientoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("usuariosys", GetType(String)))

        Dim str As String

        'listaEstado.Add(TIPO_ESTADO_CAJA.NO_USADO)
        'listaEstado.Add(TIPO_ESTADO_CAJA.USADO_PARCIAL)
        'listaEstado.Add(TIPO_ESTADO_CAJA.USADO_TOTAL)
        'listaEstado.Add(TIPO_ESTADO_cAJA.ANULADO)
        'listaEstado.Add(TIPO_ESTADO_cAJA.DEVOLUCION)

        listaDocCaja = documentoCajaSA.ObtenerMovimientosPorPeriodoFinanzas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, strMovimiento).Where(Function(o) o.estado = "1").ToList


        For Each i As documentoCaja In listaDocCaja
            Select Case i.movimientoCaja

                Case "OSC"

                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    dr(2) = "COMPROBANTE DE CAJA"
                    'Select Case i.movimientoCaja
                    '    Case "OSC"
                    '        dr(2) = "OTRAS SALIDA DE CAJA"
                    'End Select
                    dr(3) = str
                    dr(4) = i.numeroDoc
                    Select Case i.moneda
                        Case 1
                            dr(5) = "NACIONAL"
                        Case 2
                            dr(5) = "EXTRANJERA"
                    End Select
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = i.NomCajaOrigen
                    dr(10) = "-"
                    dr(11) = i.idPersonal
                    dr(12) = i.tipoPersona
                    dr(13) = i.MontoEgresosMN
                    dr(14) = i.MontoEgresosME
                    dr(15) = CDec(i.montoSoles - i.MontoEgresosMN)
                    dr(16) = CDec(i.montoUsd - i.MontoEgresosME)
                    Select Case i.estado
                        Case "1"
                            dr(17) = "Activo"
                        Case "0"
                            dr(17) = "Anulado"
                            'Case TIPO_ESTADO_CAJA.NO_USADO
                            '    dr(17) = "PENDIENTE DE USO"
                            'Case TIPO_ESTADO_CAJA.USADO_PARCIAL
                            '    dr(17) = "IMPUTADO PARCIALMENTE"
                            'Case TIPO_ESTADO_CAJA.USADO_TOTAL
                            '    dr(17) = "IMPUTADO TOTAL"
                            'Case TIPO_ESTADO_CAJA.ANULADO
                            '    dr(17) = "REVERTIDO-ANULADO"
                            'Case TIPO_ESTADO_CAJA.DEVOLUCION
                            '    dr(17) = "DEVOLUCION"
                    End Select
                    Dim usuarioSoftpack = Seguridad.General.ListaUsuariosSoftpack.Where(Function(o) o.IDUsuario = i.usuarioModificacion).SingleOrDefault
                    If usuarioSoftpack IsNot Nothing Then
                        dr(18) = usuarioSoftpack.Full_Name
                    Else
                        dr(18) = "NN"
                    End If
                    dt.Rows.Add(dr)
            End Select
        Next
        dgvOtrosMov.DataSource = dt
    End Sub

    Private Sub GetMovimientosPeriodoFull(intIdEstablecimiento As Integer, strPeriodo As String, strMovimiento As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim listaDocCaja As List(Of documentoCaja)
        Dim listaEstado As New List(Of String)
        Dim dt As New DataTable("Gastos - período ")
        Dim documentoCajaSA As New DocumentoCajaSA

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
        dt.Columns.Add(New DataColumn("idPersonal", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoPersona", GetType(String)))
        dt.Columns.Add(New DataColumn("movimientoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("movimientoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("saldoME", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("usuariosys", GetType(String)))

        Dim str As String

        'listaEstado.Add(TIPO_ESTADO_CAJA.NO_USADO)
        'listaEstado.Add(TIPO_ESTADO_CAJA.USADO_PARCIAL)
        'listaEstado.Add(TIPO_ESTADO_CAJA.USADO_TOTAL)
        'listaEstado.Add(TIPO_ESTADO_cAJA.ANULADO)
        'listaEstado.Add(TIPO_ESTADO_cAJA.DEVOLUCION)

        listaDocCaja = documentoCajaSA.ObtenerMovimientosPorPeriodoFinanzas(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo, strMovimiento)


        For Each i As documentoCaja In listaDocCaja
            Select Case i.movimientoCaja

                Case "OSC"

                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    dr(2) = "COMPROBANTE DE CAJA"
                    'Select Case i.movimientoCaja
                    '    Case "OSC"
                    '        dr(2) = "OTRAS SALIDA DE CAJA"
                    'End Select
                    dr(3) = str
                    dr(4) = i.numeroDoc
                    Select Case i.moneda
                        Case 1
                            dr(5) = "NACIONAL"
                        Case 2
                            dr(5) = "EXTRANJERA"
                    End Select
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = i.NomCajaOrigen
                    dr(10) = "-"
                    dr(11) = i.idPersonal
                    dr(12) = i.tipoPersona
                    dr(13) = i.MontoEgresosMN
                    dr(14) = i.MontoEgresosME
                    dr(15) = CDec(i.montoSoles - i.MontoEgresosMN)
                    dr(16) = CDec(i.montoUsd - i.MontoEgresosME)
                    Select Case i.estado
                        Case "1"
                            dr(17) = "Activo"
                        Case "0"
                            dr(17) = "Anulado"
                    End Select
                    Dim usuarioSoftpack = Seguridad.General.ListaUsuariosSoftpack.Where(Function(o) o.IDUsuario = i.usuarioModificacion).SingleOrDefault
                    If usuarioSoftpack IsNot Nothing Then
                        dr(18) = usuarioSoftpack.Full_Name
                    Else
                        dr(18) = "NN"
                    End If
                    dt.Rows.Add(dr)
            End Select
        Next
        dgvOtrosMov.DataSource = dt
    End Sub
#End Region

#Region "Events"
    Private Sub dgvOtrosMov_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvOtrosMov.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvOtrosMov.TableControl.Selections.Clear()
        End If
        If Not IsNothing(e.TableCellIdentity.Column) Then
            If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
                'Checks for the column name when the cellvalue is greater than 5.
                If e.TableCellIdentity.Column.MappingName = "estadoPago" AndAlso ((e.Style.CellValue)) = "Saldado" Then
                    e.Style.BackColor = Color.FromArgb(92, 184, 92)
                    e.Style.TextColor = Color.White
                ElseIf e.TableCellIdentity.Column.MappingName = "estadoPago" AndAlso ((e.Style.CellValue)) = "Pendiente" Then
                    e.Style.BackColor = Color.FromArgb(183, 16, 0)
                    e.Style.TextColor = Color.White
                End If
                'If e.TableCellIdentity.Column.MappingName = "importeMN" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                '    e.Style.BackColor = Color.LightYellow
                '    e.Style.Format = "S/.##.00"
                'End If
                'If e.TableCellIdentity.Column.MappingName = "almacenDestino" Then
                '    e.Style.BackColor = Color.LightYellow
                'End If
            End If
        End If
    End Sub

    Private Sub dgvOtrosMov_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvOtrosMov.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvOtrosMov)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Cursor = Cursors.WaitCursor
        Dim periodoG As String = cboMesCompra.SelectedValue & "/" & cboAnio.Text
        GetMovimientosPeriodo(GEstableciento.IdEstablecimiento, periodoG, "OSC")
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvOtrosMov.Table.CurrentRecord) Then
            Dim f As New FormVerPagos(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Else
            MessageBox.Show("Debe seleccionar un item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Cursor = Cursors.WaitCursor
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

        If Not IsNothing(Me.dgvOtrosMov.Table.CurrentRecord) Then
            If (TIPO_ESTADO_NOMBRE_CAJA.NO_USADO = Me.dgvOtrosMov.Table.CurrentRecord.GetValue("estado")) Then
                If (dgvOtrosMov.Table.CurrentRecord.GetValue("saldoMN") > 0) Then
                    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                    If Not IsNothing(cajaUsuario) Then
                        GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                        Dim f As New frmEntradaSalidaCaja(StatusTipoOperacion.OTRAS_SALIDAS_DE_DINERO)

                        f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        f.lblMovimiento.Tag = "OSC"
                        f.lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                        f.txtDescripcion.Text = "Por salida de dinero a cuenta financiera"
                        f.UbicarDocumentoEditar(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"))
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()

                    Else
                        MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("No puede editar el anticipo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No puede editar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Cursor = Cursors.WaitCursor

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

        If Not IsNothing(Me.dgvOtrosMov.Table.CurrentRecord) Then

            If (dgvOtrosMov.Table.CurrentRecord.GetValue("saldoMN") > 0) Then

                Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                If Not IsNothing(cajaUsuario) Then
                    GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)

                    Dim f As New frmConfirmarDevolucion(StatusTipoOperacion.ANTICIPOS_OTORGADOS)

                    f.txtAnioCompra.Text = CInt(cboAnio.Text)
                    f.txtPeriodo.Value = New Date(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), 1)
                    f.lblMovimiento.Tag = "OSC"
                    f.lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.cboMesCompra.SelectedValue = cboMesCompra.SelectedValue
                    f.cboMesCompra.Enabled = True
                    f.txtHora.Value = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), 1, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)
                    f.DigitalGauge2.Value = dgvOtrosMov.Table.CurrentRecord.GetValue("saldoMN")
                    f.idDocumentoPadre = dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento")
                    f.UbicarDocumentoEntradasSalidas(Me.dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento"), Me.dgvOtrosMov.Table.CurrentRecord.GetValue("tipoPersona"))
                    f.tipoEntidad = Me.dgvOtrosMov.Table.CurrentRecord.GetValue("tipoPersona")
                    f.txtDia.Value = New Date(CInt(cboAnio.Text), CInt(cboMesCompra.SelectedValue), 1)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                Else
                    MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Debe ser mayor a 0 el saldo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ANULAR_SALIDA_CAJA_Botón___, AutorizacionRolList) Then
            If Not IsNothing(Me.dgvOtrosMov.Table.CurrentRecord) Then
                If MessageBox.Show("Desea anular la transacción elegida?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                    If Not IsNothing(cajaUsuario) Then
                        GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                        GetAnularOperacion(Integer.Parse(dgvOtrosMov.Table.CurrentRecord.GetValue("idDocumento")))
                    Else
                        MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_SALIDA_CAJA_Botón___, AutorizacionRolList) Then
            Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
            If Not IsNothing(cajaUsuario) Then
                GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                Dim f As New FormPagoEgreso
                f.txtAnioCompra.Text = cboAnio.Text
                f.cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
                f.txtHora.Value = DateTime.Now
                f.TxtDia.Text = ""
                f.StartPosition = FormStartPosition.CenterParent
                f.txtTipoCambio.Value = TmpTipoCambio
                f.ShowDialog(Me)
            Else
                MessageBoxAdv.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ToolStripButton3.Tag = "Inactivo" Then
            dgvOtrosMov.TopLevelGroupOptions.ShowFilterBar = True
            dgvOtrosMov.NestedTableGroupOptions.ShowFilterBar = True
            dgvOtrosMov.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgvOtrosMov.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgvOtrosMov.OptimizeFilterPerformance = True
            dgvOtrosMov.ShowNavigationBar = True
            filter.WireGrid(dgvOtrosMov)
            ToolStripButton3.Tag = "activo"
        Else
            ToolStripButton3.Tag = "Inactivo"
            filter.ClearFilters(dgvOtrosMov)
            dgvOtrosMov.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click
        Cursor = Cursors.WaitCursor
        Dim periodoG As String = cboMesCompra.SelectedValue & "/" & cboAnio.Text
        GetMovimientosPeriodoFull(GEstableciento.IdEstablecimiento, periodoG, "OSC")
        Cursor = Cursors.Default
    End Sub
#End Region

End Class
