Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class frmListadoProveedoresXpagar

    Public Property CompraSA As New DocumentoCompraSA
    Public Property empresaPeriodoSA As New empresaCierreMensualSA
    Public Sub New(lista As List(Of usp_GetProveedoresXpagar_Result))


        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgPagos, True, False)
        GetCuentasXpagar(lista)
        '    txtPeriodo.Value = New Date(AnioGeneral, MesGeneral, 1)
        Tag = lista
    End Sub

    Private Sub GetCuentasXpagar(lista As List(Of usp_GetProveedoresXpagar_Result))
        Dim dSet As New DataSet()

        Dim dtChild As New DataTable("Compras del año")
        dtChild.Columns.Add("idProveedor").Caption = "ID"
        dtChild.Columns.Add("idDocumento").Caption = "IDD"
        dtChild.Columns.Add("fechaDoc").Caption = "Fecha"
        dtChild.Columns.Add("tipoDoc").Caption = "Tip doc."
        dtChild.Columns.Add("serie").Caption = "Serie"
        dtChild.Columns.Add("numeroDoc").Caption = "Número"
        dtChild.Columns.Add("importeTotal").Caption = "Importe"
        dtChild.Columns.Add("Pagos").Caption = "Pagos realizados"
        dtChild.Columns.Add("Xpagar").Caption = "X pagar"

        'GetPagosPendienteXproveedor
        Dim dt As New DataTable
        dt.Columns.Add("idProveedor").Caption = "ID"
        dt.Columns.Add("nombreCompleto").Caption = "Proveedor"
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("telefono")
        dt.Columns.Add("deudaXentidad")
        dt.Columns.Add("Pagos")
        dt.Columns.Add("Xpagar")

        For Each i In lista
            dt.Rows.Add(i.idProveedor,
                        i.nombreCompleto,
                        i.nrodoc,
                        i.telefono,
                        i.deudaXentidad,
                        i.Pagos,
                        i.Xpagar)

            For Each b In CompraSA.GetPagosPendienteXproveedor(i.idProveedor, AnioGeneral)
                dtChild.Rows.Add(b.idProveedor,
                                 b.idDocumento,
                                 b.fechaDoc,
                                 b.tipoDoc,
                                 b.serie,
                                 b.numeroDoc,
                                 b.importeTotal,
                                 b.Pagos,
                                 b.Xpagar)
            Next
        Next

        dSet.Tables.AddRange(New DataTable() {dt, dtChild})
        Dim parentColumn As DataColumn = dt.Columns("idProveedor")
        Dim childColumn As DataColumn = dtChild.Columns("idProveedor")
        dSet.Relations.Add("Compras del año", parentColumn, childColumn)

        dgPagos.DataSource = dt
        dgPagos.Engine.BindToCurrencyManager = False
        dgPagos.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        dgPagos.TopLevelGroupOptions.ShowCaption = False

        dgPagos.Table.ParentTableDescriptor.VisibleColumns.Remove("idProveedor")
        dgPagos.Table.ParentTableDescriptor.VisibleColumns.Remove("idDocumento")
    End Sub

    Private Sub btnNuevoPagoPago(strMoneda As String)
        Me.Cursor = Cursors.WaitCursor
        Dim objLista As New DocumentoCajaDetalleSA
        Dim objLista2 As New documentoAnticipoDetalleSA
        Dim entidadSA As New entidadSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0
        Dim detalle As New documentocompradetalle
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim tablaSA As New tablaDetalleSA
        Dim tablaBL As New tabladetalle
        Dim el As Element = Me.dgPagos.Table.GetInnerMostCurrentElement()
        Try
            If el IsNot Nothing Then
                Dim f As New frmModalPagos
                Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                Dim tableControl As GridTableControl = Me.dgPagos.GetTableControl(table.TableDescriptor.Name)
                Dim cc As GridCurrentCell = tableControl.CurrentCell
                Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                Dim rec As GridRecord = TryCast(el, GridRecord)
                If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                    rec = TryCast(el.ParentRecord, GridRecord)
                Else

                    'Cursor = Cursors.Default
                    'Exit Sub
                End If
                If rec IsNot Nothing Then
                    If IsNothing(dgPagos.Table.CurrentRecord) Then

                        Dim compra = CompraSA.UbicarDocumentoCompra(rec.GetValue("idDocumento"))
                        Dim entidad = entidadSA.UbicarEntidadPorID(compra.idProveedor).FirstOrDefault

                        f = New frmModalPagos
                        f.dgvDetalleItems.Rows.Clear()
                        f.manipulacionEstado = ENTITY_ACTIONS.INSERT
                        f.CaptionLabels(0).Text = "PAGOS - " & entidad.nombreCompleto
                        f.txtPeriodo.Value = New Date(AnioGeneral, MesGeneral, 1)
                        f.lblIdProveedor = compra.idProveedor
                        f.lblNomProveedor = entidad.nombreCompleto
                        f.lblCuentaProveedor = "4212"
                        f.lblIdDocumento.Text = compra.idDocumento

                        f.txtProveedor.Text = entidad.nombreCompleto
                        f.txtProveedor.Tag = compra.idProveedor
                        f.txtEntidad.Text = entidad.nombreCompleto
                        f.txtEntidad.Tag = compra.idProveedor
                        f.txtNroDocEntidad.Text = entidad.nrodoc
                        f.txtTipoEntidad.Text = "PR"

                        Dim listaPago As List(Of documentoAnticipoDetalle)
                        listaPago = objLista2.ObtenerCuentasPagadasAnticipo(rec.GetValue("idDocumento"))

                        For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(rec.GetValue("idDocumento"))
                            If i.bonificacion <> "S" Then
                                If Not i.EstadoCobro = "PG" Then
                                    detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)

                                    'martin
                                    Dim consulta = (From c In listaPago
                                                    Where c.secuencia = i.secuencia).FirstOrDefault


                                    cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN - detalle.ImporteAJmn - consulta.MontoPagadoSoles)
                                    cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME - detalle.ImporteAJme - consulta.MontoPagadoUSD)

                                    If cTotalmn < 0 Then
                                        cTotalmn = 0
                                    End If
                                    If cTotalme < 0 Then
                                        cTotalme = 0
                                    End If
                                    saldomn += cTotalmn
                                    saldome += cTotalme
                                    If cTotalmn > 0 Or cTotalme > 0 Then
                                        f.dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                                       Nothing, cTotalmn, (cTotalmn / TmpTipoCambioTransaccionVenta).ToString("N2"),
                                                                       "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                                    End If
                                End If
                            End If

                        Next
                        f.lblDeudaPendienteme.Text = CStr(saldome)
                        f.DigitalGauge2.Value = CDec(saldomn)
                        f.txtSaldoPorPagar.Text = CDec(saldomn)
                        f.lblMonedaCobro.Text = "NACIONAL"
                        '---------------------------------------------------------------------

                        tablaBL = tablaSA.GetUbicarTablaID(10, CStr(rec.GetValue("tipoDoc")))
                        f.txtComprobante.Text = tablaBL.descripcion
                        f.txtComprobante.Tag = tablaBL.codigoDetalle
                        f.txtNumeroCompr.Text = rec.GetValue("numeroDoc")
                        f.txtSerieCompr.Text = rec.GetValue("serie")
                        f.txtTipoCambio.DoubleValue = compra.tcDolLoc
                        f.lblTipoCambio.Text = compra.tcDolLoc
                        f.txtFechaComprobante.Text = rec.GetValue("fechaDoc")
                        f.tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        f.cargarDatosCompra(0)
                    Else
                        MessageBox.Show("Debe seleccionar una compra válida", "Seleccionar deuda", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub

                    End If
                End If

                If CDec(saldomn) <= 0 Then
                    '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                    MessageBox.Show("El documento ya se encuentra pagado.")
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                Else
                    f.lblPerido.Text = PeriodoGeneral
                    f.cboTipoDoc.Enabled = True
                    f.cboTipoDoc.ReadOnly = False
                    f.PanelDetallePagos.Enabled = False
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'End Select
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        LoadingAnimator.Wire(dgPagos.TableControl)

        'Dim fechaAnt = New Date(txtPeriodo.Value.Year, CInt(txtPeriodo.Value.Month), 1)
        '    fechaAnt = fechaAnt.AddMonths(-1)
        '    Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
        '    If periodoAnteriorEstaCerrado = False Then
        '        MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
        '        Cursor = Cursors.Default
        '        Exit Sub
        '    End If

        '    Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.anio = txtPeriodo.Value.Year, .mes = CInt(txtPeriodo.Value.Month)})
        '    If Not IsNothing(valida) Then
        '        If valida = True Then
        '            MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Me.Cursor = Cursors.Default
        '            Exit Sub
        '        End If
        '    End If

        If dgPagos.Table.Records.Count > 0 Then
            'If dgPagos.Table.CurrentRecord.GetValue("montoProg") = 0 Then
            btnNuevoPagoPago("1")
            ToolStripButton13_Click(sender, e)
            'Else
            '    MessageBox.Show("Este Documento Tiene Cuotas Programadas")
            'End If

        End If
        LoadingAnimator.UnWire(dgPagos.TableControl)
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        LoadingAnimator.Wire(dgPagos.TableControl)
        GetCuentasXpagar(Tag)
        LoadingAnimator.UnWire(dgPagos.TableControl)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        LoadingAnimator.Wire(dgPagos.TableControl)
        Try
            Dim el As Element = Me.dgPagos.Table.GetInnerMostCurrentElement()
            Dim table As GridTable = TryCast(el.ParentTable, GridTable)
            Dim tableControl As GridTableControl = Me.dgPagos.GetTableControl(table.TableDescriptor.Name)
            Dim cc As GridCurrentCell = tableControl.CurrentCell
            Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
            Dim rec As GridRecord = TryCast(el, GridRecord)
            If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                rec = TryCast(el.ParentRecord, GridRecord)
            End If

            If rec IsNot Nothing Then
                If IsNothing(dgPagos.Table.CurrentRecord) Then
                    With frmHistorial
                        .IdDocumentoCompra = rec.GetValue("idDocumento")
                        .lbltipoanticipo.Text = "ANTICIPO"
                        .LoadHistorialCajasXcompra()
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        LoadingAnimator.UnWire(dgPagos.TableControl)
    End Sub
End Class