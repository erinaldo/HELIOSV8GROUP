Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabLG_Transferencias

#Region "Fields"
    Dim filter As New GridExcelFilter()
    Property cirreSA As New empresaCierreMensualSA
    Public Property Alert As Alert
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Private ventanaSel As FormMaestroLogistica
#End Region

#Region "Constructors"
    Public Sub New(Ventana As FormMaestroLogistica)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ventanaSel = Ventana
        FormatoGridAvanzado(dgvMov, True, False)
        GetCombos()
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

    Private Sub GetMovPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim dt As New DataTable("Movimientos")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("destino", GetType(String)))
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
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("tieneAsiento", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarPorPeriodoEntradas(Gempresas.IdEmpresaRuc, intIdEstablecimiento, strPeriodo, TIPO_COMPRA.OTRAS_ENTRADAS, StatusTipoConsulta.XUNIDAD_ORGANICA).Where(Function(o) o.tipoCompra = TIPO_COMPRA.TRANSFERENCIA_ENTRE_ALMACEN).ToList
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            Select Case i.destino
                Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
                    dr(1) = "TRANSFERENCIA ENTRE ALMACENES"
                Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
                    dr(1) = "ENTRADA DE EXISTENCIAS"
                Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.SALIDA_EXISTENCIAS
                    dr(1) = "SALIDA DE EXISTENCIAS"
            End Select

            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.TipoPersona
            dr(10) = i.importeTotal
            dr(11) = i.tcDolLoc
            dr(12) = i.importeUS
            dr(13) = If(i.estadoEntrega = EstadoTransferenciaAlmacen.EntregaConExito, "Entregado", "Pendiente")

            'If i.estadoPago = TIPO_COMPRA.COMPRA_ANULADA Then
            '    dr(14) = "ANULADA"
            'Else
            dr(14) = If(i.estadoEntrega = EstadoTransferenciaAlmacen.EntregaConExito, "Entregado", "Pendiente")
            ' End If
            dr(15) = If(i.aprobado = "S", "-SI-", "-NO-")
            dt.Rows.Add(dr)
        Next
        dgvMov.DataSource = dt

    End Sub

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
#End Region

#Region "Events"
    Private Sub dgvCompras_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvMov.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.DisplayElement.IsRecord() AndAlso selectionColl IsNot Nothing Then
            ' && selectionColl.Count > 0)
            Dim key As Integer = e.TableCellIdentity.DisplayElement.GetRecord().Id
            If selectionColl.Contains(key) AndAlso CBool(selectionColl(key)) OrElse hoveredIndex = e.TableCellIdentity.RowIndex Then
                e.Style.BackColor = Color.FromArgb(60, 128, 128, 128)
                '.DeepSkyBlue;
                e.Style.TextColor = Color.Gray
                e.Style.CurrencyEdit.PositiveColor = Color.Gray
            End If

            dgvMov.TableControl.Selections.Clear()
        End If
    End Sub

    Private Sub dgvCompras_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvMov.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvMov)
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Cursor = Cursors.WaitCursor
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVA_TRANSFERENCIA_Botón___, AutorizacionRolList) Then
            If cboMes.Text.Trim.Length > 0 Then

                'Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMes.SelectedValue), 1)
                'fechaAnt = fechaAnt.AddMonths(-1)
                'Dim periodoAnteriorEstaCerrado = cirreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                'If periodoAnteriorEstaCerrado = False Then
                '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                '    Cursor = Cursors.Default
                '    Exit Sub
                'End If

                'Dim valida As Boolean = cirreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = cboAnio.Text, .mes = CInt(cboMes.SelectedValue)})
                'If Not IsNothing(valida) Then
                '    If valida = True Then
                '        MessageBox.Show("No puede realizar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        Cursor = Cursors.Default
                '        Exit Sub
                '    End If
                'End If

                'Dim f As New frmMovimientoAlmacen
                'f.lblPerido.Text = cboMes.SelectedValue & "/" & cboAnio.Text
                'f.lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
                'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                'f.StartPosition = FormStartPosition.CenterScreen
                'f.Show(Me)

                Dim f As New FormTransferenciaDeInventario ' frmMovimientoAlmacen
                f.lblPerido.Text = cboMes.SelectedValue & "/" & cboAnio.Text
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterScreen
                f.Show(Me)
                ventanaSel.ThreadTransitoTransferencia()
            Else
                MessageBox.Show("Debe indícar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cboMes.Select()
                cboMes.DroppedDown = True
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Cursor = Cursors.WaitCursor
        GetMovPorPeriodo(GEstableciento.IdEstablecimiento, cboMes.SelectedValue & "/" & AnioGeneral)
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_TRANSFERENCIA_Botón___, AutorizacionRolList) Then
            If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
                If Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "TRANSFERENCIA ENTRE ALMACENES" Then ' TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES Then
                    With FormTransferenciaDeInventario ' frmMovimientoAlmacen
                        .btGrabar.Enabled = False
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        '.UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                        .StartPosition = FormStartPosition.CenterParent
                        .WindowState = FormWindowState.Normal
                        .ShowDialog()
                    End With '
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LoadingAnimator.UnWire(Me.dgvMov.TableControl)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_TRANSFERENCIA_Botón___, AutorizacionRolList) Then
                If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then

                    Dim f As New FormTransferenciaDeInventario ' frmMovimientoAlmacen
                    f.btGrabar.Enabled = False
                    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    f.UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    f.StartPosition = FormStartPosition.CenterParent
                    f.WindowState = FormWindowState.Normal
                    f.ShowDialog()

                Else
                    MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    LoadingAnimator.UnWire(Me.dgvMov.TableControl)
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub
#End Region

End Class
