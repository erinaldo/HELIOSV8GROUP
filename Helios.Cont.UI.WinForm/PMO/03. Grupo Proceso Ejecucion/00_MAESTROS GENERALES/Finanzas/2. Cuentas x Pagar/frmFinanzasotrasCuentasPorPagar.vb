Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid

Public Class frmFinanzasotrasCuentasPorPagar

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFGC(dgvPagosV)
    End Sub
#End Region

#Region "Métodos"
    Sub GridCFGC(GGC As GridGroupingControl)
        GGC.TableOptions.ShowRowHeader = False
        GGC.TopLevelGroupOptions.ShowCaption = False
        GGC.ShowColumnHeaders = True

        Dim colorx As New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        GGC.SetMetroStyle(colorx)
        GGC.BorderStyle = System.Windows.Forms.BorderStyle.None

        '  GGC.BrowseOnly = True
        GGC.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        GGC.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        GGC.TableOptions.ListBoxSelectionMode = SelectionMode.One
        GGC.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        GGC.AllowProportionalColumnSizing = False
        GGC.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        GGC.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        GGC.Table.DefaultColumnHeaderRowHeight = 27
        GGC.Table.DefaultRecordRowHeight = 20
        GGC.TableDescriptor.Appearance.AnyCell.Font.Size = 8.0F

    End Sub

    Private Sub UbicarVentaNroSerieMNME(RucCliente As Integer, moneda As String)
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
        dt.Columns.Add("montoProg", GetType(Integer))


        documentoVenta = documentoVentaSA.UbicarPagosPorAsientoManualRazon(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucCliente, moneda)
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
                dr(21) = i.conteoCuota



                dt.Rows.Add(dr)
            Next

            dgvPagosV.DataSource = dt
            Me.dgvPagosV.TableOptions.ListBoxSelectionMode = SelectionMode.One
        Else

        End If
    End Sub

    Public Sub CargarTrabajadoresXnivel(strNivel As String, strBusqueda As String)
        '   Dim personaSA As New PersonaSA
        Dim personalSA As New Planilla.WCFService.ServiceAccess.PersonalSA

        Try
            ListView5.Items.Clear()
            For Each i In personalSA.PersonalSelStartwithNombres(New Helios.Planilla.Business.Entity.Personal With {.Nombre = strBusqueda})
                Dim n As New ListViewItem(i.IDPersonal)
                n.SubItems.Add(i.FullName)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.IDPersonal)
                ListView5.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CargarEntidadesXtipo2(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try
            ListView5.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                ListView5.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Events"
    Private Sub txtProveedorAsiento_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedorAsiento.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Me.PopupControlContainer10.ParentControl = Me.txtProveedorAsiento
            Me.PopupControlContainer10.ShowPopup(Point.Empty)
            If chProve.Checked = True Then
                CargarEntidadesXtipo2(TIPO_ENTIDAD.PROVEEDOR, txtProveedorAsiento.Text.Trim)
            ElseIf chTraba.Checked = True Then
                CargarTrabajadoresXnivel("TR", txtProveedorAsiento.Text.Trim)
            ElseIf chClien.Checked = True Then

                CargarEntidadesXtipo2(TIPO_ENTIDAD.CLIENTE, txtProveedorAsiento.Text.Trim)
            End If
        End If
    End Sub

    Private Sub txtProveedorAsiento_TextChanged(sender As Object, e As EventArgs) Handles txtProveedorAsiento.TextChanged

    End Sub

    Private Sub ButtonAdv33_Click(sender As Object, e As EventArgs) Handles ButtonAdv33.Click
        Me.Cursor = Cursors.WaitCursor
        If txtProveedorAsiento.Text.Trim.Length > 0 Then
            If Not IsNothing(txtProveedorAsiento.Tag) Then

            Else
                MessageBox.Show("Ingrese una Identificacion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtProveedorAsiento.Focus()
                Exit Sub
            End If
            If ComboBoxAdv5.Text = "NACIONAL" Then
                UbicarVentaNroSerieMNME(txtProveedorAsiento.Tag, "1")
            ElseIf ComboBoxAdv5.Text = "EXTRANJERA" Then
                UbicarVentaNroSerieMNME(txtProveedorAsiento.Tag, "2")
            End If
        Else
            MessageBox.Show("Ingrese una Identificacion ", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv29_Click(sender As Object, e As EventArgs) Handles ButtonAdv29.Click
        Dim lista As New List(Of documentoLibroDiarioDetalle)
        Dim docCompra As New documentoLibroDiarioDetalle
        'Dim montopago As Decimal
        'Dim montopagome As Decimal
        'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = txtPeriodo.Value.Year, .mes = CInt(txtPeriodo.Value.Month)})
        'If Not IsNothing(valida) Then
        '    If valida = True Then
        '        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Me.Cursor = Cursors.Default
        '        Exit Sub
        '    End If
        'End If
        For Each i As Record In dgvPagosV.Table.Records
            If i.GetValue("montoProg") = 0 Then
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
            End If
        Next

        If Not lista.Count > 0 Then
            MessageBox.Show("Seleccione al menos 1 item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim f As New frmPagosAsiento
        f.ListaMontosAsiento = lista
        f.txtGlosa.Text = "POR ASIENTO MANUAL"
        f.txtProveedor.Text = txtProveedorAsiento.Text
        f.txtProveedor.Tag = txtProveedorAsiento.Tag
        f.txtNumIdent.Text = txtRucAsiento.Text


        If ComboBoxAdv5.Text = "NACIONAL" Then
            f.txtmonedaprog.Text = "NACIONAL"
        ElseIf f.txtmonedaprog.Text = "EXTRANJERA" Then
            f.txtmonedaprog.Text = "EXTRANJERO"
        End If



        f.manipulacionEstado = ENTITY_ACTIONS.INSERT
        If chProve.Checked = True Then

            f.txttipoProveedor.Text = TIPO_ENTIDAD.PROVEEDOR
        ElseIf chTraba.Checked = True Then

            f.txttipoProveedor.Text = "TR"
        ElseIf chClien.Checked = True Then

            f.txttipoProveedor.Text = TIPO_ENTIDAD.CLIENTE
        End If
        f.listaAsientosPorPagar(lista)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ButtonAdv87_Click(sender As Object, e As EventArgs) Handles ButtonAdv87.Click
        If Not IsNothing(Me.dgvPagosV.Table.CurrentRecord) Then
            If dgvPagosV.Table.SelectedRecords.Count > 0 Then


                If dgvPagosV.Table.CurrentRecord.GetValue("montoProg") > 0 Then
                    'btnNuevoPagoPago(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))


                    Dim f As New frmDetalleNegociación
                    f.UbicarDocumentoDetalleCobros(dgvPagosV.Table.CurrentRecord.GetValue("idDocumento"))
                    f.lblIdDocumento.Text = dgvPagosV.Table.CurrentRecord.GetValue("idDocumento")
                    f.txtProveedor.Text = txtProveedorAsiento.Text
                    f.txtProveedor.Tag = txtProveedorAsiento.Tag
                    f.txtSerie.Text = " "
                    f.txtNumero.Text = dgvPagosV.Table.CurrentRecord.GetValue("numero")
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                    If ComboBoxAdv5.Text = "NACIONAL" Then
                        UbicarVentaNroSerieMNME(txtProveedorAsiento.Tag, "1")
                    ElseIf ComboBoxAdv5.Text = "EXTRANJERA" Then
                        UbicarVentaNroSerieMNME(txtProveedorAsiento.Tag, "2")
                    End If

                Else
                    MessageBox.Show("Este Documento No Tiene Cuotas Programadas")
                End If

            End If
        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ToolStripButton82_Click(sender As Object, e As EventArgs) Handles ToolStripButton82.Click
        Dim lista As New List(Of documentoLibroDiarioDetalle)
        Dim docCompra As New documentoLibroDiarioDetalle
        'Dim montopago As Decimal
        'Dim montopagome As Decimal

        For Each i As Record In dgvPagosV.Table.Records
            If i.GetValue("montoProg") = 0 Then
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
            End If
        Next

        If Not lista.Count > 0 Then
            MessageBox.Show("Seleccione al menos 1 item para desembolsar!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim f As New frmPagosAsiento


        f.ListaMontosAsiento = lista
        f.txtGlosa.Text = "POR ASIENTO MANUAL"
        f.txtProveedor.Text = txtProveedorAsiento.Text
        f.txtProveedor.Tag = txtProveedorAsiento.Tag



        If ComboBoxAdv5.Text = "NACIONAL" Then
            f.txtmonedaprog.Text = "NACIONAL"
        ElseIf f.txtmonedaprog.Text = "EXTRANJERA" Then
            f.txtmonedaprog.Text = "EXTRANJERO"
        End If



        f.manipulacionEstado = ENTITY_ACTIONS.INSERT
        If chProve.Checked = True Then

            f.txttipoProveedor.Text = TIPO_ENTIDAD.PROVEEDOR
        ElseIf chTraba.Checked = True Then

            f.txttipoProveedor.Text = "TR"
        ElseIf chClien.Checked = True Then

            f.txttipoProveedor.Text = TIPO_ENTIDAD.CLIENTE
        End If
        f.listaAsientosPorPagar(lista)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub ToolStripButton81_Click(sender As Object, e As EventArgs) Handles ToolStripButton81.Click
        If Not IsNothing(Me.dgvPagosV.Table.CurrentRecord) Then
            If dgvPagosV.Table.SelectedRecords.Count > 0 Then


                If dgvPagosV.Table.CurrentRecord.GetValue("montoProg") > 0 Then
                    'btnNuevoPagoPago(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))


                    Dim f As New frmDetalleNegociación
                    f.UbicarDocumentoDetalleCobros(dgvPagosV.Table.CurrentRecord.GetValue("idDocumento"))
                    f.lblIdDocumento.Text = dgvPagosV.Table.CurrentRecord.GetValue("idDocumento")
                    f.txtProveedor.Text = txtProveedorAsiento.Text
                    f.txtProveedor.Tag = txtProveedorAsiento.Tag
                    f.txtSerie.Text = " "
                    f.txtNumero.Text = dgvPagosV.Table.CurrentRecord.GetValue("numero")
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                    If ComboBoxAdv5.Text = "NACIONAL" Then
                        UbicarVentaNroSerieMNME(txtProveedorAsiento.Tag, "1")
                    ElseIf ComboBoxAdv5.Text = "EXTRANJERA" Then
                        UbicarVentaNroSerieMNME(txtProveedorAsiento.Tag, "2")
                    End If

                Else
                    MessageBox.Show("Este Documento No Tiene Cuotas Programadas")
                End If

            End If
        Else
            MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub chProve_Click(sender As Object, e As EventArgs) Handles chProve.Click
        chTraba.Checked = False
        chClien.Checked = False
        chProve.Checked = True
    End Sub

    Private Sub chTraba_Click(sender As Object, e As EventArgs) Handles chTraba.Click
        chTraba.Checked = True
        chClien.Checked = False
        chProve.Checked = False
    End Sub

    Private Sub chClien_Click(sender As Object, e As EventArgs)
        chTraba.Checked = False
        chClien.Checked = True
        chProve.Checked = False
    End Sub

    Private Sub ListView5_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView5.MouseDoubleClick
        If ListView5.SelectedItems.Count > 0 Then
            Me.PopupControlContainer10.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PopupControlContainer10_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer10.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If ListView5.SelectedItems.Count > 0 Then
                Me.txtProveedorAsiento.Text = ListView5.SelectedItems(0).SubItems(1).Text
                txtProveedorAsiento.Tag = ListView5.SelectedItems(0).SubItems(0).Text
                txtRucAsiento.Text = ListView5.SelectedItems(0).SubItems(3).Text
                'txtCuenta = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedorAsiento.Focus()
        End If
    End Sub
#End Region

  
End Class