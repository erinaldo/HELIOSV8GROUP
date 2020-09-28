Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Public Class frmListadoClientesXpagar

#Region "Attributes"
    Public Property CompraSA As New DocumentoCompraSA
    Public Property empresaPeriodoSA As New empresaCierreMensualSA
    Public Property ventaSA As New documentoVentaAbarrotesSA
#End Region

#Region "Constructors"
    Public Sub New(lista As List(Of usp_GetClientesXcobrar_Result))

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgPagos, True, False)
        GetCuentasXcobrar(lista)
        '    txtPeriodo.Value = New Date(AnioGeneral, MesGeneral, 1)
        Tag = lista
    End Sub
#End Region

#Region "Methods"
    Private Sub GetCuentasXcobrar(lista As List(Of usp_GetClientesXcobrar_Result))
        Dim dSet As New DataSet()

        Dim dtChild As New DataTable("Ventas del año")
        dtChild.Columns.Add("idProveedor").Caption = "ID"
        dtChild.Columns.Add("idDocumento").Caption = "IDD"
        dtChild.Columns.Add("fechaDoc").Caption = "Fecha"
        dtChild.Columns.Add("tipoDoc").Caption = "Tip doc."
        dtChild.Columns.Add("serie").Caption = "Serie"
        dtChild.Columns.Add("numeroDoc").Caption = "Número"
        dtChild.Columns.Add("importeTotal").Caption = "Importe"
        dtChild.Columns.Add("Pagos").Caption = "Cobros realizados"
        dtChild.Columns.Add("Xpagar").Caption = "X cobrar"

        'GetPagosPendienteXproveedor
        Dim dt As New DataTable
        dt.Columns.Add("idProveedor").Caption = "ID"
        dt.Columns.Add("nombreCompleto").Caption = "Cliente"
        dt.Columns.Add("nrodoc")
        dt.Columns.Add("telefono")
        dt.Columns.Add("deudaXentidad")
        dt.Columns.Add("Pagos")
        dt.Columns.Add("Xpagar")

        For Each i In lista
            dt.Rows.Add(i.idCliente,
                        i.nombreCompleto,
                        i.nrodoc,
                        i.telefono,
                        i.deudaXentidad,
                        i.Pagos,
                        i.Xpagar)


            For Each b In CompraSA.GetCobrosPendienteXcliente(i.idCliente, AnioGeneral)
                dtChild.Rows.Add(b.idCliente,
                                 b.idDocumento,
                                 b.fechaDoc,
                                 b.tipoDocumento,
                                 b.serieVenta,
                                 b.numeroVenta,
                                 b.ImporteNacional,
                                 b.Pagos,
                                 b.Xpagar)
            Next
        Next

        dSet.Tables.AddRange(New DataTable() {dt, dtChild})
        Dim parentColumn As DataColumn = dt.Columns("idProveedor")
        Dim childColumn As DataColumn = dtChild.Columns("idProveedor")
        dSet.Relations.Add("Ventas del año", parentColumn, childColumn)

        dgPagos.DataSource = dt
        dgPagos.Engine.BindToCurrencyManager = False
        dgPagos.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        dgPagos.TopLevelGroupOptions.ShowCaption = False

        dgPagos.Table.ParentTableDescriptor.VisibleColumns.Remove("idProveedor")
        dgPagos.Table.ParentTableDescriptor.VisibleColumns.Remove("idDocumento")
    End Sub

    Private Sub CobrarVenta(strMoneda As String)
        Me.Cursor = Cursors.WaitCursor
        Dim objLista As New DocumentoCajaDetalleSA
        Dim entidadSA As New entidadSA
        Dim tablaBL As New tabladetalle
        Dim tablaSA As New tablaDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0
        Dim detalle As New documentoventaAbarrotesDet
        Dim detalleSA As New documentoVentaAbarrotesDetSA
        Dim el As Element = Me.dgPagos.Table.GetInnerMostCurrentElement()

        Try
            If el IsNot Nothing Then
                Dim f As New frmCobrosModal
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

                        Dim venta = ventaSA.GetUbicar_documentoventaAbarrotesPorID(rec.GetValue("idDocumento"))
                        Dim entidad = entidadSA.UbicarEntidadPorID(venta.idCliente).FirstOrDefault

                        f = New frmCobrosModal()
                        f.dgvDetalleItems.Rows.Clear()
                        f.manipulacionEstado = ENTITY_ACTIONS.INSERT
                        f.CaptionLabels(0).Text = "COBROS - " & entidad.nombreCompleto
                        f.txtPeriodo.Value = New Date(AnioGeneral, MesGeneral, 1)
                        f.lblIdProveedor = venta.idCliente
                        f.lblNomProveedor = entidad.nombreCompleto
                        f.lblCuentaProveedor = "1213"
                        f.lblIdDocumento.Text = venta.idDocumento

                        f.txtProveedor.Text = entidad.nombreCompleto
                        f.txtProveedor.Tag = venta.idCliente
                        f.txtEntidad.Text = entidad.nombreCompleto
                        f.txtEntidad.Tag = venta.idCliente
                        f.txtNroDocEntidad.Text = entidad.nrodoc
                        f.txtTipoEntidad.Text = "CL"

                        For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorCobrarPorDetails(rec.GetValue("idDocumento"))
                            If Not i.EstadoCobro = "DC" Then
                                detalle = detalleSA.SumaNotasXidPadreItemVentas(i.secuencia)
                                'cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe + detalle.ImporteDBMN - CDec(i.MontoPagadoSoles)
                                'cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS + detalle.ImporteDBME - CDec(i.MontoPagadoUSD)
                                cTotalmn = CDec(CDec(i.MontoDeudaSoles) - detalle.importeMN - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN)
                                cTotalme = CDec(CDec(i.MontoDeudaUSD) - detalle.importeME - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME)
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
                                                           Nothing, cTotalmn, cTotalme,
                                                           "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT, i.secuencia)
                                End If
                            End If

                        Next
                        f.lblDeudaPendiente.Text = CStr(CDec(saldomn))
                        f.lblDeudaPendienteme.Text = CStr(CDec(saldome))
                        f.btnSaldoCobro.Text = CDec(saldomn)
                        f.DigitalGauge2.Value = CDec(saldomn)
                        f.lblMonedaCobro.Text = "NACIONAL:"
                        f.lblMonedaCobro.Tag = 1
                        '---------------------------------------------------------------------

                        tablaBL = TablaSA.GetUbicarTablaID(10, CStr(rec.GetValue("tipoDoc")))
                        f.txtComprobante.Text = tablaBL.descripcion
                        f.txtComprobante.Tag = tablaBL.codigoDetalle
                        f.txtNumeroCompr.Text = rec.GetValue("numeroDoc")
                        f.txtSerieCompr.Text = rec.GetValue("serie")
                        f.txtTipoCambio.Value = venta.tipoCambio
                        f.lblTipoCambio.Text = venta.tipoCambio
                        f.txtFechaComprobante.Text = rec.GetValue("fechaDoc")
                        f.tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                        '   f.cargarDatosCompra(0)
                    Else
                        MessageBox.Show("Debe seleccionar una venta válida", "Seleccionar deuda", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                    f.txtPeriodo.Text = PeriodoGeneral
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

        Me.Cursor = Cursors.Arrow
    End Sub
#End Region

#Region "Events"
    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        LoadingAnimator.Wire(dgPagos.TableControl)
        GetCuentasXcobrar(Tag)
        LoadingAnimator.UnWire(dgPagos.TableControl)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        LoadingAnimator.Wire(dgPagos.TableControl)
        If dgPagos.Table.Records.Count > 0 Then
            CobrarVenta("1")
            ToolStripButton13_Click(sender, e)
        End If
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
#End Region

End Class