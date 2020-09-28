Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmMovimientosInventario

#Region "Attributes"
    Public Property Alert As Alert
    Dim DocumentoCompraSA As New DocumentoCompraSA
    Public Property cirreSA As New empresaCierreMensualSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
    Dim asientoSA As New MovimientoSA
    Dim nuevoAsientoSA As New AsientoSA

    Private hitinfo As ListViewHitTestInfo
    Private editbox As New TextBox
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvMov, True, False)
        Meses()
        txtAnioCompra.Text = AnioGeneral

        SalidaAProducciónToolStripMenuItem.Visible = False
        RetornoAProducciónToolStripMenuItem.Visible = False
        IngresoDeProductosTerminadosToolStripMenuItem.Visible = False

        editbox.Parent = ListView1
        editbox.Hide()
        AddHandler editbox.LostFocus, AddressOf TextBox42_LostFocus
        AddHandler editbox.KeyPress, AddressOf TextBox42_KeyPress
        ListView1.FullRowSelect = True

        ValidandoModulos()
    End Sub
#End Region

#Region "Methods"

    Private Sub ValidandoModulos()

        If Gempresas.IDProducto = "23" Then ' PosV00
            'entradas
            ConsignacioneToolStripMenuItem.Visible = False
            PromociónToolStripMenuItem.Visible = False
            PremioToolStripMenuItem.Visible = False
            DonaciónToolStripMenuItem.Visible = False
            ProductosTerminadosToolStripMenuItem.Visible = False
            SubProductosDesechosYDesperdiciosToolStripMenuItem.Visible = False
            ProductosEnProcesoToolStripMenuItem.Visible = False
            DevolucionesToolStripMenuItem.Visible = False
            'salidas
            ConsignacionesToolStripMenuItem.Visible = False
            PremioToolStripMenuItem1.Visible = False
            DonaciónToolStripMenuItem1.Visible = False
            RetiroToolStripMenuItem.Visible = False
            MermasToolStripMenuItem.Visible = False
            DesmedorsToolStripMenuItem.Visible = False
            DestrucciónToolStripMenuItem.Visible = False
            ToolStripMenuItem2.Visible = False
            DevolucionesToolStripMenuItem1.Visible = False

            ToolStripButton3.Visible = False
        Else

        End If
    End Sub

    Private Sub GrabarAsiento(r As Record)
        Dim entidadSA As New entidadSA
        Dim compra = DocumentoCompraSA.UbicarDocumentoCompra(Integer.Parse(r.GetValue("idDocumento")))

        Dim asiento As New asiento
        asiento.idAsiento = Integer.Parse(ListView1.Items(0).SubItems(5).Text)
        asiento.idDocumento = compra.idDocumento
        asiento.idEmpresa = Gempresas.IdEmpresaRuc
        asiento.idCentroCostos = GEstableciento.IdEstablecimiento
        asiento.idDocumentoRef = compra.idDocumento
        If IsNothing(compra.idProveedor) Then
            asiento.idEntidad = compra.idPersona
            asiento.tipoEntidad = "TR"
        Else
            asiento.idEntidad = compra.idProveedor
            Dim entidad = entidadSA.UbicarEntidadPorID(compra.idProveedor).FirstOrDefault
            If entidad IsNot Nothing Then
                asiento.tipoEntidad = entidad.tipoEntidad
            End If
        End If

        asiento.nombreEntidad = r.GetValue("NombreEntidad")
        asiento.fechaProceso = compra.fechaDoc
        asiento.periodo = compra.fechaContable
        asiento.codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_INVENTARIO_PERMANENTE_VALORIZADO
        asiento.tipo = "D"
        asiento.tipoAsiento = ASIENTO_CONTABLE.Inventario
        asiento.importeMN = 0
        asiento.importeME = 0
        asiento.glosa = txtGlosaAsiento.Text
        asiento.usuarioActualizacion = usuario.IDUsuario
        asiento.fechaActualizacion = Date.Now

        For Each i As ListViewItem In ListView1.Items
            Dim n As New movimiento
            n.cuenta = i.SubItems(1).Text
            n.descripcion = i.SubItems(2).Text
            n.tipo = i.SubItems(6).Text
            Select Case i.SubItems(6).Text
                Case "D"
                    n.monto = Decimal.Parse(i.SubItems(3).Text)
                    n.montoUSD = Decimal.Parse(i.SubItems(3).Text) / TmpTipoCambio
                Case "H"
                    n.monto = Decimal.Parse(i.SubItems(4).Text)
                    n.montoUSD = Decimal.Parse(i.SubItems(4).Text) / TmpTipoCambio
            End Select
            n.usuarioActualizacion = usuario.IDUsuario
            n.fechaActualizacion = Date.Now
            asiento.movimiento.Add(n)
        Next
        Dim sumaDebe = asiento.movimiento.Where(Function(o) o.tipo = "D").Sum(Function(o) o.monto).GetValueOrDefault
        Dim sumaHaber = asiento.movimiento.Where(Function(o) o.tipo = "H").Sum(Function(o) o.monto).GetValueOrDefault
        asiento.importeMN = sumaDebe
        asiento.importeME = sumaDebe / TmpTipoCambio
        If sumaDebe = sumaHaber Then
            nuevoAsientoSA.ReingresarAsientoContable(asiento)
            MessageBox.Show("Asiento modificado!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Verificar que el debe y el haber seas iguales!", "Verificar montos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub TextBox42_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        'call LostFocus Sub in the event user pressed RETURN
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            TextBox42_LostFocus(sender, Nothing)
        End If
    End Sub

    Private Sub TextBox42_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If editbox.Text.Trim.Length > 0 Then
            hitinfo.SubItem.Text = editbox.Text
            editbox.Hide()

            'Dim lsv As New ListViewItem
            'lsv = ListView1.SelectedItems(0)
            'Dim movimiento As New movimiento
            'movimiento.idmovimiento = Integer.Parse(lsv.SubItems(0).Text)
            'movimiento.idAsiento = Integer.Parse(lsv.SubItems(5).Text)
            'movimiento.cuenta = lsv.SubItems(1).Text
            'movimiento.descripcion = lsv.SubItems(2).Text
            'Select Case lsv.SubItems(6).Text
            '    Case "D"
            '        movimiento.monto = Decimal.Parse(lsv.SubItems(3).Text)
            '        movimiento.montoUSD = 0
            '    Case "H"
            '        movimiento.monto = Decimal.Parse(lsv.SubItems(4).Text)
            '        movimiento.montoUSD = 0
            'End Select
            'movimiento.usuarioActualizacion = usuario.IDUsuario
            'movimiento.fechaActualizacion = Date.Now


            'asientoSA.EditarMovimientosContablesByAsiento(movimiento)
        End If
    End Sub

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

    Private Sub UbicarAsientoByDocumento(idDocumento As Integer)
        Dim movimientos = asientoSA.UbicarAsientoXidDocumento(idDocumento)
        ListView1.Items.Clear()
        txtGlosaAsiento.Clear()
        For Each i In movimientos
            Dim n As New ListViewItem
            n.Text = i.idmovimiento
            n.SubItems.Add(i.cuenta).Tag = "cuenta"
            n.SubItems.Add(i.descripcion).Tag = "detalle"
            Select Case i.tipo
                Case "D"
                    n.SubItems.Add(i.monto).Tag = "debe"
                    n.SubItems.Add(0).Tag = "haber"
                Case "H"
                    n.SubItems.Add(0).Tag = "debe"
                    n.SubItems.Add(i.monto).Tag = "haber"
            End Select
            n.SubItems.Add(i.idAsiento).Tag = "idasiento"
            n.SubItems.Add(i.tipo).Tag = "tipo"
            ListView1.Items.Add(n)
        Next
        If movimientos.Count > 0 Then
            txtGlosaAsiento.Text = movimientos(0).asiento.glosa
        End If
    End Sub

    Sub ValidarCierreActual()
        Dim valida As Boolean = cirreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(cboMes.SelectedValue)})
        If Not IsNothing(valida) Then
            If valida = True Then
                MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If
    End Sub

    Sub validarCierreAnterior()
        Dim fechaAnt = New Date(AnioGeneral, CInt(cboMes.SelectedValue), 1)
        fechaAnt = fechaAnt.AddMonths(-1)
        Dim periodoAnteriorEstaCerrado = cirreSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        If periodoAnteriorEstaCerrado = False Then
            MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
            Cursor = Cursors.Default
            Exit Sub
        End If

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
            compraSA.EliminarSalidaInv(New documento With {.idDocumento = Integer.Parse(r.GetValue("idDocumento"))})
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

    Private Sub GetMovPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim dt As New DataTable("Movimientos")
        Dim documentoCajaSA As New DocumentoCajaSA

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
        For Each i As documentocompra In DocumentoCompraSA.GetListarPorPeriodoEntradas(Gempresas.IdEmpresaRuc, intIdEstablecimiento, strPeriodo, TIPO_COMPRA.OTRAS_ENTRADAS, StatusTipoConsulta.XUNIDAD_ORGANICA)
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
#End Region

#Region "Events"
    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            TextBox42_LostFocus(sender, Nothing)
        End If
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        hitinfo = ListView1.HitTest(e.X, e.Y)
        editbox.Bounds = hitinfo.SubItem.Bounds
        editbox.Text = hitinfo.SubItem.Text
        editbox.Focus()
        editbox.Show()
        Dim t = hitinfo.SubItem.Tag
        Select Case t
            Case "cuenta"
                Dim f As New frmcatalogoCuentas
                f.Button1.Visible = True
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
                If f.Tag IsNot Nothing Then
                    Dim c = CType(f.Tag, cuentaplanContableEmpresa)
                    editbox.Text = c.cuenta
                    'ListView1.SelectedItems(0).SubItems(1).Text = c.cuenta
                    ListView1.SelectedItems(0).SubItems(2).Text = c.descripcion
                Else
                    Exit Sub
                End If
            Case Else

        End Select

    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Cursor = Cursors.WaitCursor
        GetMovPorPeriodo(GEstableciento.IdEstablecimiento, cboMes.SelectedValue & "/" & AnioGeneral)
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
        Dim r As Record = dgvMov.Table.CurrentRecord
        If Not IsNothing(r) Then
            Dim valida As Boolean = cirreSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = AnioGeneral, .mes = CInt(cboMes.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If
            Dim f As New frmCambiarPeriodo2(New documentocompra With {.idDocumento = Val(r.GetValue("idDocumento"))})
            f.operacion = StatusTipoOperacion.COMPRA
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            ButtonAdv19_Click(sender, e)
        End If
    End Sub

    Private Sub dgvMov_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvMov.QueryCellStyleInfo
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

    Private Sub dgvMov_TableControlCellMouseHoverEnter(sender As Object, e As GridTableControlCellMouseEventArgs) Handles dgvMov.TableControlCellMouseHoverEnter
        IsMouseHover(e.Inner.RowIndex, e.Inner.ColIndex, True, dgvMov)
    End Sub

    Private Sub ConsignacioneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsignacioneToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmMovOtrasEntradas
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "03.01"
                .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub PromociónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PromociónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmMovOtrasEntradas
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "07.01"
                .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub PremioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PremioToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmMovOtrasEntradas
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "08.01"
                .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DonaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DonaciónToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmMovOtrasEntradas
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "09.01"
                .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ProductosTerminadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosTerminadosToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmMovOtrasEntradas
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "10.03"
                .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub SubProductosDesechosYDesperdiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubProductosDesechosYDesperdiciosToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmMovOtrasEntradas
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "9904"
                .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ProductosEnProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosEnProcesoToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmMovOtrasEntradas
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "10.07"
                .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DevolucionesToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmMovOtrasEntradas
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "05"
                .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub OtrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtrosToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmMovOtrasEntradas
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "0000"
                .lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
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

    Private Sub ConsignacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsignacionesToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then

            validarCierreAnterior()
            ValidarCierreActual()
            
            With frmOtrasSalidasDeAlmacen
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "04.01"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub PremioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PremioToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmOtrasSalidasDeAlmacen
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "08.02"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DonaciónToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DonaciónToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmOtrasSalidasDeAlmacen
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "09.02"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub RetiroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetiroToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmOtrasSalidasDeAlmacen
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "12"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub MermasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MermasToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmOtrasSalidasDeAlmacen
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "13"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DesmedorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesmedorsToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            
            With frmOtrasSalidasDeAlmacen
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "14"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DestrucciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DestrucciónToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmOtrasSalidasDeAlmacen
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "15"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual
            With frmOtrasSalidasDeAlmacen
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .GroupBox2.Visible = True
                .cboOperacion.SelectedValue = "10.01"
                .rbCosto.Checked = True
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DevolucionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DevolucionesToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual()
            With frmOtrasSalidasDeAlmacen
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "06"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub OtrosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OtrosToolStripMenuItem1.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            validarCierreAnterior()
            ValidarCierreActual
            With frmOtrasSalidasDeAlmacen
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "0001"
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

    Private Sub RegistroDeHonorariosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            With frmMovimientoAlmacen
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CambioDeExistenciaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            With frmCambioInventario
                .lblMovimiento.Text = "CAMBIO TIPO INVENTARIO"
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
            End With
        Else
            MessageBox.Show("Debe indicar el período", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMes.Select()
            cboMes.DroppedDown = True
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            If Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "TRANSFERENCIA ENTRE ALMACENES" Then ' TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES Then
                With frmMovimientoAlmacen
                    .btGrabar.Enabled = False
                    .ToolStripButton1.Enabled = False
                    .GuardarToolStripButton.Enabled = False
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    '.UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    .StartPosition = FormStartPosition.CenterParent
                    .WindowState = FormWindowState.Normal
                    .ShowDialog()
                End With '
            ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "ENTRADA DE EXISTENCIAS" Then
                With frmMovOtrasEntradas
                    .btGrabar.Enabled = True
                    .GuardarToolStripButton.Enabled = True
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    .WindowState = FormWindowState.Normal
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "SALIDA DE EXISTENCIAS" Then
                With frmOtrasSalidasDeAlmacen
                    .btGrabar.Enabled = True
                    .GuardarToolStripButton.Enabled = True
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    .WindowState = FormWindowState.Normal
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LoadingAnimator.UnWire(Me.dgvMov.TableControl)
        End If
        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        LoadingAnimator.Wire(Me.dgvMov.TableControl)
        Try
            If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
                '    If MessageBox.Show("eliminar el item seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                If Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "TRANSFERENCIA ENTRE ALMACENES" Then
                    MessageBox.Show("No se puede eliminar una transferencia!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    '    EliminarTransferenciaAlmacen(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    '    Me.dgvMov.Table.CurrentRecord.Delete()
                    '    PanelError.Visible = True
                    '    lblEstado.Text = "entrada eliminada!"
                    '    Timer1.Enabled = True
                    '    TiempoEjecutar(10)
                    'End If
                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "ENTRADA DE EXISTENCIAS" Then
                    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        EliminarEntrada()
                    End If
                ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "SALIDA DE EXISTENCIAS" Then
                    If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                        EliminarOtrasSalidas()
                    End If
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                LoadingAnimator.UnWire(Me.dgvMov.TableControl)
            End If
        Catch ex As Exception
            Alert = New Alert(ex.Message, alertType.warning)
            Alert.TopMost = True
            Alert.Show()
        End Try

        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim r As Record = dgvMov.Table.CurrentRecord
        If Not IsNothing(r) Then
            validarCierreAnterior()
            ValidarCierreActual()
            Select Case r.GetValue("destino")

                Case "SALIDA DE EXISTENCIAS"

                    If r.GetValue("estado") = "ANULADA" Then
                        MessageBox.Show("Este Documento ya fue anulado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    Else
                        Dim f As New frmReversionesOtrasSalidas(CInt(r.GetValue("idDocumento")))
                        f.lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                        f.ShowDialog()
                    End If

                Case "ENTRADA DE EXISTENCIAS"
                    If r.GetValue("estado") = "ANULADA" Then
                        MessageBox.Show("Este Documento ya fue anulado", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    Else
                        Dim f As New frmReversionesOtrasEntradas(CInt(r.GetValue("idDocumento")))
                        f.lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                        f.ShowDialog()
                    End If
                Case Else
                    MessageBox.Show("Debe seleccionar una venta", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Select
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub dgvMov_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvMov.TableControlCellClick
        If PanelAsientos.Visible = True Then
            Cursor = Cursors.WaitCursor
            If e.TableControl.Table.CurrentRecord IsNot Nothing Then
                UbicarAsientoByDocumento(Integer.Parse(e.TableControl.Table.CurrentRecord.GetValue("idDocumento")))
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub dgvMov_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvMov.SelectedRecordsChanged
        Cursor = Cursors.WaitCursor
        If PanelAsientos.Visible = True Then
            If e.SelectedRecord IsNot Nothing Then
                UbicarAsientoByDocumento(Integer.Parse(e.SelectedRecord.Record.GetValue("idDocumento")))
            End If
        End If

        If e.SelectedRecord IsNot Nothing Then
            btAsignarGasto.Enabled = True
        Else
            btAsignarGasto.Enabled = False
        End If

        Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If PanelAsientos.Visible = False Then
            PanelAsientos.Visible = True
        Else
            PanelAsientos.Visible = False
        End If
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        If ListView1.Items.Count > 0 Then
            Dim r As Record = dgvMov.Table.CurrentRecord
            If r IsNot Nothing Then
                GrabarAsiento(r)
            End If
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dim r As Record = dgvMov.Table.CurrentRecord
        Try
            If r IsNot Nothing Then
                DocumentoCompraSA.EliminarAsigancionDeAsientoInventario(New documentocompra With {.idDocumento = Integer.Parse(r.GetValue("idDocumento"))})
                UbicarAsientoByDocumento(Integer.Parse(dgvMov.TableControl.Table.CurrentRecord.GetValue("idDocumento")))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btAsignarGasto_Click(sender As Object, e As EventArgs) Handles btAsignarGasto.Click
        Cursor = Cursors.WaitCursor
        Dim empresaPeriodoSA As New empresaCierreMensualSA
        Dim CompraDetSA As New DocumentoCompraDetalleSA
        Dim r As Record = dgvMov.Table.CurrentRecord
        If r IsNot Nothing Then

            Select Case r.GetValue("destino")
                Case "ENTRADA DE EXISTENCIAS"
                    validarCierreAnterior()
                    ValidarCierreActual()
                    Dim ListaCompra = CompraDetSA.GetUbicarDetalleCompraLote(Integer.Parse(r.GetValue("idDocumento")))
                    Dim f As New frmMovOtrasEntradas(ListaCompra)
                    f.lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                    f.cboOperacion.SelectedValue = "0000"
                    f.lblMovimiento.Text = "OTRAS ENTRADAS DE EXISTENCIAS"
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                Case Else

            End Select


        End If
        Cursor = Cursors.Default
    End Sub

#End Region




End Class