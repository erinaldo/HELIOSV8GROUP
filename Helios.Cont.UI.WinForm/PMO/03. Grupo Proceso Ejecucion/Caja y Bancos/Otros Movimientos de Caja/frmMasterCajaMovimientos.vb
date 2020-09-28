Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmMasterCajaMovimientos
    Inherits frmMaster
    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel
    Dim filter As GridDynamicFilter = New GridDynamicFilter()

    Private Sub ConfiguracionInicio()
        Me.RibbonControlAdv1.QuickPanelVisible = True
        Me.lblPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel = New System.Windows.Forms.ToolStripLabel()
        Me.lblPeriodoLabel.Text = "Período:"
        Me.lblPeriodoLabel.Font = New Font("Segoe UI", 8.25, FontStyle.Bold)
        lblPeriodoLabel.Enabled = False

        Me.lblPeriodo.Font = New Font("Segoe UI", 8.25)
        ' Set the text and DisplayStyle property.
        Me.lblPeriodo.Text = PeriodoGeneral
        lblPeriodo.Enabled = False
        Me.lblPeriodo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text

        ' Add the toolstripbutton in the header of the RibbonControlAdv.
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodoLabel)
        Me.RibbonControlAdv1.Header.AddQuickItem(Me.lblPeriodo) 'ToolStripSeparator1
        '    Me.RibbonControlAdv1.Header.AddQuickItem(Me.ToolStripSeparator1)
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ConfiguracionInicio()
        ' Add any initialization after the InitializeComponent() call.

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

#Region "Métodos"
    Private Function getParentTableComprasPorPeriodo(intIdEstablecimiento As Integer, strPeriodo As String) As DataTable
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Movimientos - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("movimiento", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
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
                Case "TEC"
                    If i.tipoMovimiento = "PG" Then
                        Dim dr As DataRow = dt.NewRow()
                        str = Nothing
                        str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                        dr(0) = i.idDocumento
                        dr(1) = i.tipoOperacion
                        dr(2) = str
                        dr(3) = i.tipoDocPago
                        dr(4) = i.numeroOperacion
                        dr(5) = i.moneda
                        dr(6) = i.montoSoles
                        dr(7) = i.tipoCambio
                        dr(8) = i.montoUsd
                        dr(9) = i.NomCajaOrigen
                        dr(10) = i.NomCajaDestino
                        dt.Rows.Add(dr)
                    End If
                Case "OEC"
                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    dr(2) = str
                    dr(3) = i.tipoDocPago
                    dr(4) = i.numeroOperacion
                    dr(5) = i.moneda
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = "-"
                    dr(10) = i.NomCajaOrigen
                    dt.Rows.Add(dr)
                Case "OSC"
                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    dr(2) = str
                    dr(3) = i.tipoDocPago
                    dr(4) = i.numeroOperacion
                    dr(5) = i.moneda
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = i.NomCajaOrigen
                    dr(10) = "-"
                    dt.Rows.Add(dr)
            End Select
           
        Next
        Return dt



    End Function

    Private Function getParentTableComprasPorDia(intIdEstablecimiento As Integer) As DataTable
        Dim DocumentoCompraSA As New DocumentoCompraSA

        Dim dt As New DataTable("Movimientos - día " & DateTime.Now.Date & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("movimiento", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroOperacion", GetType(String)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("NomCajaOrigen", GetType(String)))
        dt.Columns.Add(New DataColumn("NomCajaDestino", GetType(String)))

        Dim str As String
        For Each i As documentoCaja In documentoCajaSA.ObtenerMovimientosPorDia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)

            Select Case i.tipoOperacion
                Case "TEC"
                    If i.tipoMovimiento = "PG" Then
                        Dim dr As DataRow = dt.NewRow()
                        str = Nothing
                        str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                        dr(0) = i.idDocumento
                        dr(1) = i.tipoOperacion
                        dr(2) = str
                        dr(3) = i.tipoDocPago
                        dr(4) = i.numeroOperacion
                        dr(5) = i.moneda
                        dr(6) = i.montoSoles
                        dr(7) = i.tipoCambio
                        dr(8) = i.montoUsd
                        dr(9) = i.NomCajaOrigen
                        dr(10) = i.NomCajaDestino
                        dt.Rows.Add(dr)
                    End If
                Case "OEC"
                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    dr(2) = str
                    dr(3) = i.tipoDocPago
                    dr(4) = i.numeroOperacion
                    dr(5) = i.moneda
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = "-"
                    dr(10) = i.NomCajaOrigen
                    dt.Rows.Add(dr)
                Case "OSC"
                    Dim dr As DataRow = dt.NewRow()
                    str = Nothing
                    str = CDate(i.fechaCobro).ToString("dd-MMM hh:mm tt ")
                    dr(0) = i.idDocumento
                    dr(1) = i.tipoOperacion
                    dr(2) = str
                    dr(3) = i.tipoDocPago
                    dr(4) = i.numeroOperacion
                    dr(5) = i.moneda
                    dr(6) = i.montoSoles
                    dr(7) = i.tipoCambio
                    dr(8) = i.montoUsd
                    dr(9) = i.NomCajaOrigen
                    dr(10) = "-"
                    dt.Rows.Add(dr)
            End Select

        Next
        Return dt



    End Function

    Public Sub ListaMovimientiosPeriodo()
        Try
            Dim parentTable As DataTable = getParentTableComprasPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()

            PanelError.Visible = True
            lblEstado.Text = "Lista de movimientos período: - " & PeriodoGeneral
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ListaMovimientiosPorDia()
        Try
            Dim parentTable As DataTable = getParentTableComprasPorDia(GEstableciento.IdEstablecimiento)
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()

            PanelError.Visible = True
            lblEstado.Text = "Lista de movimientos día: - " & DateTime.Now.Date
            Timer1.Enabled = True
            TiempoEjecutar(10)
        Catch ex As Exception
            Throw ex
        End Try
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
        Me.dgvCompra.Table.CurrentRecord.Delete()
        lblEstado.Text = "Transferencia eliminada!"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
    End Sub

    Public Sub EliminarOtrosMovimientos(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim documento As New documento

        With documento
            .idDocumento = intIdDocumento
        End With

        documentoSA.EliminarOtrosMovimientosCaja(documento)
        Me.dgvCompra.Table.CurrentRecord.Delete()
        lblEstado.Text = "Movimiento eliminado!"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
    End Sub
#End Region

    Private Sub frmMasterCajaMovimientos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If filter IsNot Nothing Then
            filter.SaveCompareOperator()
        End If
        Dispose()
    End Sub

    Private Sub frmMasterCajaMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If filter IsNot Nothing Then
            filter.LoadCompareOperator()
        End If
    End Sub


    Private Sub CompraDirectaConRecepciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompraDirectaConRecepciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmTransferenciaCaja
            .lblMovimiento.Text = "TRANSFERENCIA ENTRE ALMACENES"
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            '  .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEditCompra_Click(sender As Object, e As EventArgs) Handles btnEditCompra.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Select Case Me.dgvCompra.Table.CurrentRecord.GetValue("movimiento")
                Case "TEC"

                Case "OEC", "OSC"
                    'With frmEntradaSalidaCaja
                    '    .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                    '    '    .UbicarDocumento(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                    '    .StartPosition = FormStartPosition.CenterParent
                    '    .ShowDialog()
                    'End With
            End Select

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Cursor = Cursors.WaitCursor
        ListaMovimientiosPorDia()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        ListaMovimientiosPeriodo()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub OtrasSálidasDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtrasSálidasDeCajaToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        'With frmEntradaSalidaCaja
        '    ' .lblCaja.Text = "Caja de origen:"
        '    .lblMovimiento.Text = "OTRAS SALIDAS DE CAJA"
        '    .ManipulacionEstado = ENTITY_ACTIONS.INSERT
        '    '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
        '    '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        '    '.txtFechaTrans.Value = Date.Now
        '    '.lblPerido.Text = PeriodoGeneral
        '    .StartPosition = FormStartPosition.CenterParent
        '    .ShowDialog()
        'End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnEliminarCompra_Click(sender As Object, e As EventArgs) Handles btnEliminarCompra.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If Me.dgvCompra.Table.CurrentRecord.GetValue("movimiento") = "TEC" Then
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarTransferencia(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                End If
            Else
                If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    EliminarOtrosMovimientos(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub chFilter1_Click_1(sender As Object, e As EventArgs) Handles chFilter1.Click
        If chFilter1.Checked = True Then
            Me.dgvCompra.TopLevelGroupOptions.ShowFilterBar = True
            'Enable the filter for each columns 
            For i As Integer = 0 To dgvCompra.TableDescriptor.Columns.Count - 1
                dgvCompra.TableDescriptor.Columns(i).AllowFilter = True
            Next
        Else
            Me.dgvCompra.TopLevelGroupOptions.ShowFilterBar = False
        End If
    End Sub

    Private Sub chFilter2_Click(sender As Object, e As EventArgs) Handles chFilter2.Click
        If chFilter2.Checked Then
            filter.WireGrid(dgvCompra)
        Else
            filter.UnWireGrid(dgvCompra)
        End If
    End Sub

    Private Sub chAgrupa_Click(sender As Object, e As EventArgs) Handles chAgrupa.Click
        If chAgrupa.Checked Then
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            dgvCompra.ShowGroupDropArea = True
        Else
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            dgvCompra.ShowGroupDropArea = False
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        With frmReporteMovimientoCaja
            .ConsultaReporteTotalesPorDia()
            .lblPerido.Text = lblPeriodo.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = Cursors.WaitCursor
        With frmReporteMovimientoCaja
            .ConsultaReporteTotalesPorPeriodo(lblPeriodo.Text)
            .lblPerido.Text = lblPeriodo.Text
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
End Class