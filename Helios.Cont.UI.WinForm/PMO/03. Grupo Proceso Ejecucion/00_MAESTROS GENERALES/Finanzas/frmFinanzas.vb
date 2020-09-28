Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Tools
Public Class frmFinanzas
    Inherits frmMaster

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GridCFG2(dgvMovPeriodo)
        GetMovimientosPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)
        cargarDatos()
    End Sub


#Region "Métodos"
    Sub Inicio()
        lblDiaLab.Text = DiaLaboral
        lblFechaContable.Text = PeriodoGeneral
    End Sub

    Sub GridCFG2(grid As GridGroupingControl)
        grid.TableOptions.ShowRowHeader = False
        grid.TopLevelGroupOptions.ShowCaption = False

        Dim colorx As New GridMetroColors()
        colorx = New GridMetroColors()
        colorx.HeaderColor.HoverColor = Color.FromArgb(20, 128, 128, 128)
        colorx.HeaderTextColor.HoverTextColor = Color.Gray
        colorx.HeaderBottomBorderColor = Color.FromArgb(168, 178, 189)
        grid.SetMetroStyle(colorx)
        grid.BorderStyle = System.Windows.Forms.BorderStyle.None

        'Me.gridGroupingControl1.BrowseOnly = true
        'Me.gridGroupingControl1.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionCurrentCellOptions = Syncfusion.Windows.Forms.Grid.Grouping.GridListBoxSelectionCurrentCellOptions.HideCurrentCell
        'Me.gridGroupingControl1.TableOptions.ListBoxSelectionMode = SelectionMode.One
        grid.TableOptions.SelectionBackColor = Color.Gray
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.Format = "MMM dd yyyy"
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.Hide
        'Me.gridGroupingControl1.TableDescriptor.Columns(0).HeaderText = "Date"
        'Me.gridGroupingControl1.TableDescriptor.Columns(1).HeaderText = "Category"
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.Currency
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.CurrencyEdit.PositiveColor = Color.FromArgb(168, 178, 189)
        'Me.gridGroupingControl1.TableDescriptor.Columns("Amount").Appearance.AnyRecordFieldCell.TextAlign = GridTextAlign.Left

        'this.gridGroupingControl1.TableDescriptor.Columns["Amount"].Width = (this.tableLayoutPanel3.Width / 5) - 50;
        grid.AllowProportionalColumnSizing = False
        grid.TableDescriptor.Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
        grid.TableDescriptor.Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Center
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Move(5, 3)
        'Me.gridGroupingControl1.TableDescriptor.VisibleColumns.Remove("AccountType")

        grid.Table.DefaultColumnHeaderRowHeight = 25
        grid.Table.DefaultRecordRowHeight = 20
        grid.TableDescriptor.Appearance.AnyCell.Font.Size = 7.5F

    End Sub

    Public Sub cargarDatos()
        Dim DocumentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim objDocumentoCajaDetalle As New documentoCajaDetalle

        objDocumentoCajaDetalle = DocumentoCajaDetalleSA.ConsultaCajaXEmpresa(Gempresas.IdEmpresaRuc)

        With objDocumentoCajaDetalle
            lblEfectivo.Text = "Efectivo" & vbCrLf & .montoSoles
            Label11.Text = "Banco" & vbCrLf & .montoUsd
            lblTarjeta.Text = "Tarjeta de crédito" & vbCrLf & .ImporteNacional
            Label4.Text = "Anticipos otorgados" & vbCrLf & .salidaCostoMN
            Label13.Text = "Anticipos recibidos" & vbCrLf & .salidaCostoME
        End With

    End Sub

    Private Sub GetMovimientosPeriodo(intIdEstablecimiento As Integer, strPeriodo As String)
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("movimiento", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))

        dt.Columns.Add(New DataColumn("numeroOperacion", GetType(String)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("NomCajaOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("NomCajaDestino", GetType(String)))

        Dim str As String
        For Each i As documentoCaja In documentoCajaSA.ObtenerMovimientosPorPeriodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strPeriodo)

            Select Case i.tipoOperacion
                Case "9911"
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
                        dr(6) = i.montoSoles
                        dr(7) = i.tipoCambio
                        dr(8) = i.montoUsd
                        dr(9) = i.NomCajaOrigen
                        dr(10) = i.NomCajaDestino
                        dt.Rows.Add(dr)
                    End If
                Case "17"
                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion

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
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = "-"
                    dr(10) = i.NomCajaOrigen
                    dt.Rows.Add(dr)
                Case "17"
                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    Select Case i.movimientoCaja
                        Case "OEC"
                            dr(2) = "OTRAS ENTRADA DE CAJA"
                        Case "OSC"
                            dr(2) = "OTRAS SALIDA DE CAJA"
                        Case "TEC"
                            dr(2) = "TRANSFERENCIA ENTRE CAJAS"
                    End Select
                    dr(3) = str
                    dr(4) = i.movimientoCaja
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
                    dt.Rows.Add(dr)
            End Select

        Next
        dgvMovPeriodo.DataSource = dt

    End Sub



    Public Sub EliminarTransferencia(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documento As New documento

        With documento
            .idDocumento = intIdDocumento
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .usuarioActualizacion = "Maykol"
            .fechaProceso = Date.Now
            .tipoDoc = 9901
            .tipoOperacion = "01"
            .fechaActualizacion = Date.Now
        End With

        documentoSA.EliminarTransferenciaCaja(documento)
        Me.dgvMovPeriodo.Table.CurrentRecord.Delete()
        MessageBox.Show("Transferencia eliminada!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
  
    End Sub

    Public Sub EliminarOtrosMovimientos(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documento As New documento

        With documento
            .idDocumento = intIdDocumento
        End With

        documentoSA.EliminarOtrosMovimientosCaja(documento)
        Me.dgvMovPeriodo.Table.CurrentRecord.Delete()
        MessageBox.Show("Movimiento eliminado!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

    Private Sub frmFinanzas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub HubTile3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        GetMovimientosPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub NuevaEntradaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaEntradaToolStripMenuItem.Click
        'With frmEntradaSalidaCaja
        '    .lblMovimiento.Tag = "OEC"
        '    .lblMovimiento.Text = "OTRAS ENTRADAS A CAJA"
        '    .CaptionLabels(0).Text = "OTRAS ENTRADAS A CAJA"
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    .txtTipoCambio.Value = TmpTipoCambio
        '    '.txtFechaTrans.Value = Date.Now
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub NuevaSálidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaSálidaToolStripMenuItem.Click
        'With frmEntradaSalidaCaja
        '    .lblMovimiento.Tag = "OSC"
        '    .lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
        '    .CaptionLabels(0).Text = "OTRAS SALIDAS DE CAJA"
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    '.txtFechaTrans.Value = Date.Now
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
    End Sub

    Private Sub TransferenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TransferenciaToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmTransferenciaCaja
            .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        If Not IsNothing(Me.dgvMovPeriodo.Table.CurrentRecord) Then
            Select Case Me.dgvMovPeriodo.Table.CurrentRecord.GetValue("movimiento")
                Case "9911"

                Case "17"
                    'With frmEntradaSalidaCaja
                    '    '       .Panel6.Visible = False
                    '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    '    '       .UbicarDocumento(Me.dgvMovPeriodo.Table.CurrentRecord.GetValue("idDocumento"))
                    '    .StartPosition = FormStartPosition.CenterParent
                    '    .ShowDialog()
                    'End With
            End Select

        End If
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        If Not IsNothing(Me.dgvMovPeriodo.Table.CurrentRecord) Then
            If Me.dgvMovPeriodo.Table.CurrentRecord.GetValue("movimiento") = "TEC" Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarTransferencia(Me.dgvMovPeriodo.Table.CurrentRecord.GetValue("idDocumento"))
                End If
            Else
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Try
                        EliminarOtrosMovimientos(Me.dgvMovPeriodo.Table.CurrentRecord.GetValue("idDocumento"))
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub Panel3_Click(sender As Object, e As EventArgs) Handles Panel3.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmUsuariosFinanza
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel6_Click(sender As Object, e As EventArgs) Handles Panel6.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New FrmPagosGeneral
        f.StartPosition = FormStartPosition.CenterParent
        f.WindowState = FormWindowState.Maximized
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel8_Click(sender As Object, e As EventArgs) Handles Panel8.Click
        Me.Cursor = Cursors.WaitCursor
        Dim f As New frmCobrosGeneral
        f.StartPosition = FormStartPosition.CenterParent
        f.Show()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Panel4_Click(sender As Object, e As EventArgs) Handles Panel4.Click
        Dim f As New frmFlujoCaja
        f.Show()
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Panel5_Click(sender As Object, e As EventArgs) Handles Panel5.Click
        Dim f As New FrmAnticiposGeneral
        f.Show()
    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub
End Class