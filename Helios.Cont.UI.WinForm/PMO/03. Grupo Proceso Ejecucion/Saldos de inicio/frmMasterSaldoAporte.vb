Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmMasterSaldoAporte
    Dim filter As GridDynamicFilter = New GridDynamicFilter()
    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel

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
        ' Me.RibbonControlAdv1.Header.AddQuickItem(Me.ToolStripSeparator1)
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
    End Sub

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ConfiguracionInicio()
    End Sub

#Region "Método listas"
    Private Function getTableSaldoPorPeriodo() As DataTable
        Dim DocumentoCompraSA As New saldoInicioSA

        Dim dt As New DataTable("Aportes saldos - período " & PeriodoGeneral & " ")

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))

        Dim str As String
        For Each i As saldoInicio In DocumentoCompraSA.ListadoSaldosXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = i.tipoDoc
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.importeTotal
            dr(7) = 0
            dr(8) = i.importeUS
            dr(9) = i.monedaDoc
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Public Sub ListaSaldoAporteXperiodo()
        Try

            Dim parentTable As DataTable = getTableSaldoPorPeriodo()
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    
#End Region

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

#Region "Manipulación data"
    Private Sub EliminarSaldoAporte(intIdDocumento As Integer)
        Dim documentoBL As New documento
        Dim DocumentoSA As New saldoInicioSA
        Dim almacen As New almacen
        Dim almacenSA As New almacenSA
        Dim saldoDetalleSA As New saldoInicioDetalleSA
        Dim objNuevo As New totalesAlmacen
        Dim ProductoSA As New detalleitemsSA
        Dim Producto As New detalleitems
        Dim ListaTotales As New List(Of totalesAlmacen)

        With documentoBL
            .idDocumento = intIdDocumento
        End With
        For Each i In saldoDetalleSA.ListadoMercaderiaXidDocumento(intIdDocumento)
            If Not IsNothing(i.almacen) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.almacen)
                Producto = ProductoSA.InvocarProductoID(i.idModulo)
                If Not IsNothing(almacen) Then
                    objNuevo = New totalesAlmacen
                    objNuevo.SecuenciaDetalle = i.secuencia
                    objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                    objNuevo.idEstablecimiento = almacen.idEstablecimiento
                    objNuevo.idAlmacen = almacen.idAlmacen
                    objNuevo.origenRecaudo = Producto.origenProducto
                    objNuevo.idItem = Producto.codigodetalle
                    objNuevo.TipoDoc = "03" ' Me.dgvCompra.Table.CurrentRecord.GetValue("tipoDoc")
                    objNuevo.importeSoles = i.importe
                    objNuevo.importeDolares = i.importeUS

                    objNuevo.cantidad = i.cantidad
                    objNuevo.precioUnitarioCompra = i.precioUnitario

                    objNuevo.montoIsc = 0
                    objNuevo.montoIscUS = 0

                    ListaTotales.Add(objNuevo)
                End If
            End If
        Next
        DocumentoSA.DeleteSaldoAporte(documentoBL, ListaTotales)
    End Sub
#End Region

    Private Sub btnEliminarCompra_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarCompra.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                EliminarSaldoAporte(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                Me.dgvCompra.Table.CurrentRecord.Delete()
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(10)
                '    lblEstado.Image = My.Resources.ok4
                lblEstado.Text = "Registro eliminado!"
            End If
        End If
    End Sub
    Private Sub btnEditCompra_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCompra.Click
        Me.Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            With frmAportesInicio
                .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                .txtFechaComprobante.ShowUpDown = True
                .UbicarSaldoPorIdDocumento(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
        End If
      
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripDropDownButton1.Click
        Me.Cursor = Cursors.WaitCursor
        With frmAportesInicio
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .WindowState = FormWindowState.Maximized
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripDropDownButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripDropDownButton2.Click
        Me.Cursor = Cursors.WaitCursor
        lblPeriodo.Text = PeriodoGeneral
        ListaSaldoAporteXperiodo()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmMasterSaldoAporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub RibbonControlAdv1_Click(sender As Object, e As EventArgs) Handles RibbonControlAdv1.Click

    End Sub
End Class