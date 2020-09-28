Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabLG_OtrasSalidas

#Region "Fields"
    Dim filter As New GridExcelFilter()
    Property cirreSA As New empresaCierreMensualSA
    Public Property Alert As Alert
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvMov, True, False)
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

    Private Sub EliminarEntrada()
        Dim compraSA As New DocumentoCompraSA
        Dim r As Record = dgvMov.Table.CurrentRecord
        If r IsNot Nothing Then
            compraSA.EliminarEntradainv(New documento With {.idDocumento = Integer.Parse(r.GetValue("idDocumento"))})
            Alert = New Alert("Entrada eliminada", alertType.info)
            Alert.TopMost = True
            Alert.Show()
            r.Delete()
            dgvMov.Refresh()
        End If
    End Sub

    Public Sub EliminarOtrasSalidas()
        Dim compraSA As New DocumentoCompraSA
        Dim r As Record = dgvMov.Table.CurrentRecord
        If r IsNot Nothing Then
            compraSA.AnularSalidaInv(New documento With {.idDocumento = Integer.Parse(r.GetValue("idDocumento"))})
            'compraSA.EliminarSalidaInv(New documento With {.idDocumento = Integer.Parse(r.GetValue("idDocumento"))})
            Alert = New Alert("Salida eliminada", alertType.info)
            Alert.TopMost = True
            Alert.Show()
            r.Delete()
            dgvMov.Refresh()
        End If
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

    Sub ValidarCierreActual()
        Dim valida As Boolean = cirreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = cboAnio.Text, .mes = CInt(cboMes.SelectedValue)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If
    End Sub

    Sub validarCierreAnterior()
        Dim fechaAnt = New Date(cboAnio.Text, CInt(cboMes.SelectedValue), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = cirreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

    End Sub

    Private Sub GetMovPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim dt As New DataTable("Sálidas de inventario")
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
        For Each i As documentocompra In DocumentoCompraSA.GetListarPorPeriodoEntradas(Gempresas.IdEmpresaRuc, intIdEstablecimiento, strPeriodo, TIPO_COMPRA.OTRAS_ENTRADAS, StatusTipoConsulta.XUNIDAD_ORGANICA).Where(Function(o) o.tipoCompra = TIPO_COMPRA.OTRAS_SALIDAS).ToList
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
            dr(13) = i.monedaDoc

            If i.estadoPago = TIPO_COMPRA.COMPRA_ANULADA Then
                dr(14) = "ANULADA"
            Else
                dr(14) = i.estadoPago
            End If
            dr(15) = If(i.aprobado = "S", "-SI-", "-NO-")
            dt.Rows.Add(dr)
        Next
        dgvMov.DataSource = dt

    End Sub
#End Region

#Region "Events"
    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        Cursor = Cursors.WaitCursor
        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.NUEVO_SALIDA_Botón___, AutorizacionRolList) Then
                If cboMes.Text.Trim.Length > 0 Then
                    'validarCierreAnterior()
                    'ValidarCierreActual()

                    Dim f As New FormOtrasSalidas ' frmOtrasSalidasDeAlmacen
                    f.lblPerido.Text = cboMes.SelectedValue & "/" & cboAnio.Text
                    f.cboOperacion.SelectedValue = "0001"
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterScreen
                    f.Show(Me)
                    ButtonAdv19_Click(sender, e)
                Else
                    MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cboMes.Select()
                    cboMes.DroppedDown = True
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_SALIDA_Botón___, AutorizacionRolList) Then
            If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
                Dim f As New FormOtrasSalidas ' frmOtrasSalidasDeAlmacen
                f.btGrabar.Enabled = False
                f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                f.UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                f.WindowState = FormWindowState.Normal
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LoadingAnimator.UnWire(Me.dgvMov.TableControl)
            End If
        Else
            MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        Try
            If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ANULAR_SALIDA_Botón___, AutorizacionRolList) Then
                If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
                    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        EliminarOtrasSalidas()
                    End If
                Else
                    MessageBox.Show("Debe seleccionar un registro válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    LoadingAnimator.UnWire(Me.dgvMov.TableControl)
                End If
            Else
                MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            Alert = New Alert(ex.Message, alertType.warning)
            Alert.TopMost = True
            Alert.Show()
        End Try

        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Cursor = Cursors.WaitCursor
        GetMovPorPeriodo(GEstableciento.IdEstablecimiento, cboMes.SelectedValue & "/" & cboAnio.Text)
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If ToolStripButton3.Tag = "Inactivo" Then
            dgvMov.TopLevelGroupOptions.ShowFilterBar = True
            dgvMov.NestedTableGroupOptions.ShowFilterBar = True
            dgvMov.ChildGroupOptions.ShowFilterBar = True
            For Each col As GridColumnDescriptor In dgvMov.TableDescriptor.Columns
                col.AllowFilter = True
            Next
            filter.AllowResize = True
            filter.AllowFilterByColor = True
            filter.EnableDateFilter = True
            filter.EnableNumberFilter = True

            dgvMov.OptimizeFilterPerformance = True
            dgvMov.ShowNavigationBar = True
            filter.WireGrid(dgvMov)
            ToolStripButton3.Tag = "activo"
        Else
            ToolStripButton3.Tag = "Inactivo"
            filter.ClearFilters(dgvMov)
            dgvMov.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click

    End Sub
#End Region

End Class
