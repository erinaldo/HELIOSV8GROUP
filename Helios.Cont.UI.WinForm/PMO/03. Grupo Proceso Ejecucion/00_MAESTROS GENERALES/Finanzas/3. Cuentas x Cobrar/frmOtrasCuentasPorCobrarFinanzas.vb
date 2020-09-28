Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping

Public Class frmOtrasCuentasPorCobrarFinanzas

#Region "Attributes"
    Public Property empresaPeriodoSA As New empresaCierreMensualSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG(GridGroupingControl6)
    End Sub
#End Region

#Region "Métodos"
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

    Sub GridCFG(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()

        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center

        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub
    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        '   Dim personaSA As New PersonaSA
        Dim personalSA As New Planilla.WCFService.ServiceAccess.PersonalSA

        Try
            ListView6.Items.Clear()
            For Each i In personalSA.PersonalSelStartwithNombres(New Helios.Planilla.Business.Entity.Personal With {.Nombre = strBusqueda})
                Dim n As New ListViewItem(i.IDPersonal)
                n.SubItems.Add(i.FullName)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.IDPersonal)
                ListView6.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Public Sub CargarEntidadesXtipo3(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            ListView6.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                ListView6.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UbicarCobrosPorAsientoManualRazon(RucCliente As Integer, moneda As String)
        Dim documentoVentaSA As New documentoLibroDiarioSA
        Dim documentoVenta As New List(Of documentoLibroDiarioDetalle)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        'Dim strPeriodo As String = String.Format("{0:00}", Convert.ToInt32(txtPeriodo.Value.Month)) & "/" & txtPeriodo.Value.Year

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))
        dt.Columns.Add("fechaVcto", GetType(String))
        dt.Columns.Add("cuenta", GetType(String))
        dt.Columns.Add("idsecuencia", GetType(Integer))
        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))


        documentoVenta = documentoVentaSA.UbicarCobrosPorAsientoManualRazon(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, moneda)
        Dim str As String
        Dim str2 As String
        If Not IsNothing(documentoVenta) Then
            For Each i In documentoVenta
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.FechaDoc).ToString("dd-MMM hh:mm tt ")
                str2 = Nothing
                str2 = CDate(i.fechaVcto).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.descripcion
                dr(3) = ""
                dr(4) = i.tipoDocumento
                dr(5) = ""
                dr(6) = i.numeroDoc
                dr(11) = i.PagoSumaMN
                dr(12) = i.PagoSumaME

                Select Case i.moneda
                    Case 1
                        dr(7) = "NAC"
                        dr(8) = i.importeMN
                        dr(9) = i.tipoCambio
                        dr(10) = CDec(0.0)
                        dr(13) = CDec(i.importeMN - i.PagoSumaMN).ToString("N2")
                        dr(14) = CDec(0.0)
                    Case Else
                        dr(7) = "EXT"
                        dr(8) = CDec(0.0)
                        dr(9) = i.tipoCambio
                        dr(10) = i.importeME
                        dr(13) = CDec(0.0)
                        dr(14) = CDec(i.importeME - i.PagoSumaME).ToString("N2")
                End Select

                Select Case i.estadoPago
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(15) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(15) = "Pendiente"
                End Select

                dr(16) = str2

                dr(17) = i.cuenta
                dr(18) = i.secuencia
                dr(19) = True
                dr(20) = "S"



                dt.Rows.Add(dr)
            Next

            GridGroupingControl6.DataSource = dt
            Me.GridGroupingControl6.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub
#End Region

#Region "Events"
    Private Sub ToolStripButton70_Click(sender As Object, e As EventArgs) Handles ToolStripButton70.Click
        Me.Cursor = Cursors.WaitCursor
        If txtClienteAsiento.Text.Trim.Length > 0 Then

            If Not IsNothing(txtClienteAsiento.Tag) Then

            Else
                MessageBox.Show("Ingrese una Identificacion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtClienteAsiento.Focus()
                Exit Sub
            End If
            If ComboBoxAdv6.Text = "NACIONAL" Then

                UbicarCobrosPorAsientoManualRazon(txtClienteAsiento.Tag, "1")
            ElseIf ComboBoxAdv6.Text = "EXTRANJERA" Then
                UbicarCobrosPorAsientoManualRazon(txtClienteAsiento.Tag, "2")
            End If

        Else
            MessageBox.Show("Ingrese una Identificacion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton98_Click(sender As Object, e As EventArgs) Handles ToolStripButton98.Click
        If Not IsNothing(Me.GridGroupingControl6.Table.CurrentRecord) Then

            If GridGroupingControl6.Table.CurrentRecord.GetValue("estadoPago") = "Pendiente" Then

                If GridGroupingControl6.Table.CurrentRecord.GetValue("moneda") = "NAC" Then

                    With frmCompensacionDeDocumentos
                        .txtProveedor.Text = txtClienteAsiento.Text
                        .txtProveedor.Tag = txtClienteAsiento.Tag
                        .txtRuc.Text = txtRucAsientoCobro.Text
                        ' sdgfsdgsdg



                        Dim tablaSA As New tablaDetalleSA
                        Dim tablaBL As New tabladetalle

                        tablaBL = tablaSA.GetUbicarTablaID(10, CStr(GridGroupingControl6.Table.CurrentRecord.GetValue("tipoDoc")))

                        .txtComprobante.Text = tablaBL.descripcion
                        .txtComprobante.Tag = tablaBL.codigoDetalle
                        .txtNumeroCompr.Text = CStr(GridGroupingControl6.Table.CurrentRecord.GetValue("numero"))
                        .txtSerieCompr.Text = CStr(GridGroupingControl6.Table.CurrentRecord.GetValue("serie"))
                        .txtTipoCambio.Text = CDec(GridGroupingControl6.Table.CurrentRecord.GetValue("tipoCambio"))

                        .txtFechaComprobante.Text = CStr(GridGroupingControl6.Table.CurrentRecord.GetValue("fecha"))
                        .lblIdDocumento.Text = GridGroupingControl6.Table.CurrentRecord.GetValue("idDocumento")

                        .txtImporteMN.Text = CDec(GridGroupingControl6.Table.CurrentRecord.GetValue("importeMN") - GridGroupingControl6.Table.CurrentRecord.GetValue("abonoMN"))
                        .txtImporteME.Text = CDec(GridGroupingControl6.Table.CurrentRecord.GetValue("importeME") - GridGroupingControl6.Table.CurrentRecord.GetValue("abonoME"))
                        .txtMoneda.Text = CStr(GridGroupingControl6.Table.CurrentRecord.GetValue("moneda"))

                        .btnNuevoPago(GridGroupingControl6.Table.CurrentRecord.GetValue("moneda"), GridGroupingControl6.Table.CurrentRecord.GetValue("idDocumento"))

                        'Select Case dgvPagosVarios.Table.CurrentRecord.GetValue("moneda")
                        '    Case "NAC"
                        '        .tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        '    Case "EXT"
                        '        .tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                        'End Select


                        .ShowDialog()
                    End With



                    'btnNuevoPagoAnticipoPagos(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))
                Else
                    MessageBox.Show("Solo Se puede Compensar Documentos en Soles")
                End If


            Else
                MessageBox.Show("El Documento esta cancelado")
            End If
        Else
            MessageBox.Show("Seleccione uan compra")
        End If
    End Sub

    Private Sub ButtonAdv74_Click(sender As Object, e As EventArgs) Handles ButtonAdv74.Click
        Me.Cursor = Cursors.WaitCursor
        If txtClienteAsiento.Text.Trim.Length > 0 Then

            If Not IsNothing(txtClienteAsiento.Tag) Then

            Else
                MessageBox.Show("Ingrese una Identificacion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtClienteAsiento.Focus()
                Exit Sub
            End If
            If ComboBoxAdv6.Text = "NACIONAL" Then

                UbicarCobrosPorAsientoManualRazon(txtClienteAsiento.Tag, "1")
            ElseIf ComboBoxAdv6.Text = "EXTRANJERA" Then
                UbicarCobrosPorAsientoManualRazon(txtClienteAsiento.Tag, "2")
            End If

        Else
            MessageBox.Show("Ingrese una Identificacion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv73_Click(sender As Object, e As EventArgs) Handles ButtonAdv73.Click
        Dim lista As New List(Of documentoLibroDiarioDetalle)
        Dim docCompra As New documentoLibroDiarioDetalle
        'Dim montopago As Decimal
        'Dim montopagome As Decimal

        For Each i As Record In GridGroupingControl6.Table.Records
            'If i.GetValue("montoProg") = 0 Then
            If i.GetValue("valBonif") = "S" Then
                docCompra = New documentoLibroDiarioDetalle
                docCompra.idEstablecimiento = 1
                docCompra.idDocumento = i.GetValue("idDocumento")
                docCompra.secuencia = i.GetValue("idsecuencia")
                docCompra.importeMN = i.GetValue("saldoMN")
                docCompra.importeME = i.GetValue("saldoME")
                docCompra.descripcion = i.GetValue("descripcion")
                docCompra.cuenta = i.GetValue("cuenta")
                docCompra.tipoCambio = i.GetValue("tipoCambio")
                docCompra.numeroDoc = i.GetValue("numero")
                'montopago += i.GetValue("monto")
                'montopagome += i.GetValue("montome")
                lista.Add(docCompra)
            End If
            ' End If
        Next

        If Not lista.Count > 0 Then
            MessageBox.Show("Seleccione al menos 1 item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim f As New frmCobrosAsiento
        f.ListaMontosAsiento = lista
        f.txtGlosa.Text = "POR ASIENTO MANUAL"
        f.txtProveedor.Text = txtClienteAsiento.Text
        f.txtProveedor.Tag = txtClienteAsiento.Tag
        If ComboBoxAdv6.Text = "NACIONAL" Then
            f.txtmonedaprog.Text = "NACIONAL"
        ElseIf f.txtmonedaprog.Text = "EXTRANJERA" Then
            f.txtmonedaprog.Text = "EXTRANJERO"
        End If

        f.manipulacionEstado = ENTITY_ACTIONS.INSERT
        If chProveCobro.Checked = True Then

            f.txttipoProveedor.Text = TIPO_ENTIDAD.PROVEEDOR
        ElseIf chTrabCobro.Checked = True Then

            f.txttipoProveedor.Text = "TR"
        ElseIf chClieCobro.Checked = True Then

            f.txttipoProveedor.Text = TIPO_ENTIDAD.CLIENTE
        End If
        f.listaAsientosPorPagar(lista)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        UbicarCobrosPorAsientoManualRazon(txtClienteAsiento.Tag, "1")
    End Sub

    Private Sub ToolStripButton69_Click(sender As Object, e As EventArgs) Handles ToolStripButton69.Click
        Dim lista As New List(Of documentoLibroDiarioDetalle)
        Dim docCompra As New documentoLibroDiarioDetalle
        'Dim montopago As Decimal
        'Dim montopagome As Decimal

        'Dim fechaAnt = New Date(txtPeriodo2.Value.Year, CInt(txtPeriodo2.Value.Month), 1)
        'fechaAnt = fechaAnt.AddMonths(-1)
        'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        'If periodoAnteriorEstaCerrado = False Then
        '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
        '    Cursor = Cursors.Default
        '    Exit Sub
        'End If

        'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = txtPeriodo2.Value.Year, .mes = CInt(txtPeriodo2.Value.Month)})
        'If Not IsNothing(valida) Then
        '    If valida = True Then
        '        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Me.Cursor = Cursors.Default
        '        Exit Sub
        '    End If
        'End If


        For Each i As Record In GridGroupingControl6.Table.Records
            'If i.GetValue("montoProg") = 0 Then
            If i.GetValue("valBonif") = "S" Then
                docCompra = New documentoLibroDiarioDetalle
                docCompra.idEstablecimiento = 1
                docCompra.idDocumento = i.GetValue("idDocumento")
                docCompra.secuencia = i.GetValue("idsecuencia")
                docCompra.importeMN = i.GetValue("saldoMN")
                docCompra.importeME = i.GetValue("saldoME")
                docCompra.descripcion = i.GetValue("descripcion")
                docCompra.cuenta = i.GetValue("cuenta")
                docCompra.tipoCambio = i.GetValue("tipoCambio")
                docCompra.numeroDoc = i.GetValue("numero")
                'montopago += i.GetValue("monto")
                'montopagome += i.GetValue("montome")
                lista.Add(docCompra)
            End If
            ' End If
        Next

        If Not lista.Count > 0 Then
            MessageBox.Show("Seleccione al menos 1 item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim f As New frmCobrosAsiento
        f.ListaMontosAsiento = lista
        f.txtGlosa.Text = "POR ASIENTO MANUAL"
        f.txtProveedor.Text = txtClienteAsiento.Text
        f.txtProveedor.Tag = txtClienteAsiento.Tag
        f.TXTRUC.Text = txtRucAsientoCobro.Text


        If ComboBoxAdv6.Text = "NACIONAL" Then
            f.txtmonedaprog.Text = "NACIONAL"
        ElseIf f.txtmonedaprog.Text = "EXTRANJERA" Then
            f.txtmonedaprog.Text = "EXTRANJERO"
        End If

        f.manipulacionEstado = ENTITY_ACTIONS.INSERT
        If chProveCobro.Checked = True Then

            f.txttipoProveedor.Text = TIPO_ENTIDAD.PROVEEDOR
        ElseIf chTrabCobro.Checked = True Then

            f.txttipoProveedor.Text = "TR"
        ElseIf chClieCobro.Checked = True Then

            f.txttipoProveedor.Text = TIPO_ENTIDAD.CLIENTE
        End If
        f.listaAsientosPorPagar(lista)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        UbicarCobrosPorAsientoManualRazon(txtClienteAsiento.Tag, "1")
    End Sub

    Private Sub txtClienteAsiento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClienteAsiento.KeyDown
        If e.KeyCode = Keys.Enter Then

            e.SuppressKeyPress = True
            Me.PopupControlContainer11.ParentControl = Me.txtClienteAsiento
            Me.PopupControlContainer11.ShowPopup(Point.Empty)
            If chProveCobro.Checked = True Then
                CargarEntidadesXtipo3(TIPO_ENTIDAD.PROVEEDOR, txtClienteAsiento.Text.Trim)
            ElseIf chTrabCobro.Checked = True Then
                CargarTrabajadoresXnivel("TR", txtClienteAsiento.Text.Trim)
            ElseIf chClieCobro.Checked = True Then

                CargarEntidadesXtipo3(TIPO_ENTIDAD.CLIENTE, txtClienteAsiento.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtClienteAsiento_TextChanged(sender As Object, e As EventArgs) Handles txtClienteAsiento.TextChanged

    End Sub

    Private Sub PopupControlContainer11_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer11.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If ListView6.SelectedItems.Count > 0 Then
                Me.txtClienteAsiento.Text = ListView6.SelectedItems(0).SubItems(1).Text
                txtClienteAsiento.Tag = ListView6.SelectedItems(0).SubItems(0).Text
                txtRucAsientoCobro.Text = ListView6.SelectedItems(0).SubItems(3).Text
                'txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text

            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtClienteAsiento.Focus()
        End If
    End Sub

    Private Sub ListView6_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView6.MouseDoubleClick
        If ListView6.SelectedItems.Count > 0 Then
            Me.PopupControlContainer11.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ListView6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView6.SelectedIndexChanged

    End Sub
#End Region
  
End Class