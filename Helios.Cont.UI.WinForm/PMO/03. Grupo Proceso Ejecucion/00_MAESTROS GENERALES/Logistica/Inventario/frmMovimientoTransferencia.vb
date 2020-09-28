Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmMovimientoTransferencia

#Region "Attributes"
    Dim empresaPeriodoSA As New empresaCierreMensualSA
    Dim DocumentoCompraSA As New DocumentoCompraSA
    Dim selectionColl As New Hashtable()
    Dim hoveredIndex As Integer = 0
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGrid(dgvMov)
        Meses()
        txtAnioCompra.Text = AnioGeneral
    End Sub
#End Region

#Region "Methods"
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

    Public Sub RemoveCompra(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvMov.Table.CurrentRecord.GetValue("tipoDoc")

                        objNuevo.importeSoles = i.importe
                        objNuevo.importeDolares = i.importeUS

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteOtrasEntradas(objDocumento, ListaTotales)
    End Sub

    Public Sub EliminarOtrasSalidas(IntIdDocumento As Integer)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
        End With
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(IntIdDocumento)
            If Not IsNothing(i.almacenRef) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacenRef)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvMov.Table.CurrentRecord.GetValue("tipoDoc")

                        objNuevo.importeSoles = i.importe
                        objNuevo.importeDolares = i.importeUS

                        objNuevo.cantidad = i.monto1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc
                        objNuevo.montoIscUS = i.montoIscUS

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteOtrasSalidasDeAlmacen(objDocumento, ListaTotales)
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

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarPorPeriodoEntradasTransferencia(Gempresas.IdEmpresaRuc, intIdEstablecimiento, strPeriodo, TIPO_COMPRA.OTRAS_ENTRADAS, StatusTipoConsulta.XUNIDAD_ORGANICA)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            Select Case i.destino
                Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES
                    dr(1) = "TRANSFERENCIA ENTRE ALMACENES"
                    'Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.ENTRADA_EXISTENCIAS
                    '    dr(1) = "ENTRADA DE EXISTENCIAS"
                    'Case TIPO_COMPRA.MOVIMIENTO_ALMACEN.SALIDA_EXISTENCIAS
                    '    dr(1) = "SALIDA DE EXISTENCIAS"

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
                    dt.Rows.Add(dr)
            End Select
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
    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        Cursor = Cursors.WaitCursor
        GetMovPorPeriodo(GEstableciento.IdEstablecimiento, cboMes.SelectedValue & "/" & AnioGeneral)
        Cursor = Cursors.Default
    End Sub

    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
        Dim r As Record = dgvMov.Table.CurrentRecord
        If Not IsNothing(r) Then
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

    Private Sub ConsignacioneToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub PromociónToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub PremioToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub DonaciónToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub ProductosTerminadosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub SubProductosDesechosYDesperdiciosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub ProductosEnProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub DevolucionesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub OtrosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            With frmMovOtrasEntradas
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "0000"
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

    Private Sub ConsignacionesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub PremioToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub DonaciónToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub RetiroToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub MermasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub DesmedorsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub DestrucciónToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub DevolucionesToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
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

    Private Sub OtrosToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then
            With frmOtrasSalidasDeAlmacen
                .lblPerido.Text = cboMes.SelectedValue & "/" & AnioGeneral
                .cboOperacion.SelectedValue = "0001"
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
                    .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    .StartPosition = FormStartPosition.CenterParent
                    .WindowState = FormWindowState.Normal
                    .ShowDialog()
                End With '
            ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "ENTRADA DE EXISTENCIAS" Then
                With frmMovOtrasEntradas
                    .btGrabar.Enabled = False
                    .GuardarToolStripButton.Enabled = True
                    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    .UbicarDocumento(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    .WindowState = FormWindowState.Normal
                    .StartPosition = FormStartPosition.CenterParent
                    .ShowDialog()
                End With
            ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "SALIDA DE EXISTENCIAS" Then
                With frmOtrasSalidasDeAlmacen
                    .btGrabar.Enabled = False
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
                    RemoveCompra(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    dgvMov.Table.CurrentRecord.Delete()
                    PanelError.Visible = True
                    lblEstado.Text = "entrada eliminada!"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            ElseIf Me.dgvMov.Table.CurrentRecord.GetValue("destino") = "SALIDA DE EXISTENCIAS" Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarOtrasSalidas(Me.dgvMov.Table.CurrentRecord.GetValue("idDocumento"))
                    dgvMov.Table.CurrentRecord.Delete()
                    PanelError.Visible = True
                    lblEstado.Text = "Registro eliminado!"
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                End If
            End If
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            LoadingAnimator.UnWire(Me.dgvMov.TableControl)
        End If
        LoadingAnimator.UnWire(Me.dgvMov.TableControl)
    End Sub
#End Region

    Private Sub SalidaAProducciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalidaAProducciónToolStripMenuItem.Click
        Cursor = Cursors.WaitCursor
        If cboMes.Text.Trim.Length > 0 Then

            Dim fechaAnt = New Date(AnioGeneral, CInt(cboMes.SelectedValue), 1)
            fechaAnt = fechaAnt.AddMonths(-1)
            Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
            If periodoAnteriorEstaCerrado = False Then
                MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                Cursor = Cursors.Default
                Exit Sub
            End If

            Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = AnioGeneral, .mes = CInt(cboMes.SelectedValue)})
            If Not IsNothing(valida) Then
                If valida = True Then
                    MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

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
End Class