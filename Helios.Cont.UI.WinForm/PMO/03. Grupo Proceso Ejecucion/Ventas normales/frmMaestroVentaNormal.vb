Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess

Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Grouping
Public Class frmMaestroVentaNormal
    Inherits frmMaster

    Dim filter As GridDynamicFilter = New GridDynamicFilter()
    Private lblPeriodo As System.Windows.Forms.ToolStripLabel
    Private lblPeriodoLabel As System.Windows.Forms.ToolStripLabel

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ConfiguracionInicio()
        configDockingManger()
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

    Public Sub EliminarVentaAlCredito(IntIdDocumento As Integer, strTipoVenta As String)
        Dim almacenSA As New almacenSA
        Dim almacen As New almacen
        Dim documentoSA As New DocumentoSA
        Dim documentoDetalleSA As New documentoVentaAbarrotesDetSA
        Dim objDocumento As New documento
        Dim objNuevo As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        With objDocumento
            .idDocumento = IntIdDocumento
            .tipoDoc = strTipoVenta ' TIPO_VENTA.VENTA_AL_TICKET
        End With
        For Each i In documentoDetalleSA.GetUbicar_documentoventaAbarrotesDetPorIDocumento(IntIdDocumento)
            If Not IsNothing(i.idAlmacenOrigen) Then

                almacen = almacenSA.GetUbicar_almacenPorID(i.idAlmacenOrigen)
                If Not IsNothing(almacen) Then
                    If Not almacen.tipo = "AV" Then
                        objNuevo = New totalesAlmacen
                        objNuevo.SecuenciaDetalle = i.secuencia
                        objNuevo.idEmpresa = Gempresas.IdEmpresaRuc
                        objNuevo.idEstablecimiento = almacen.idEstablecimiento
                        objNuevo.idAlmacen = almacen.idAlmacen
                        objNuevo.origenRecaudo = i.destino
                        objNuevo.idItem = i.idItem
                        objNuevo.TipoDoc = Me.dgvVenta.Table.CurrentRecord.GetValue("tipoDocumento")

                        objNuevo.importeSoles = i.salidaCostoMN * -1
                        objNuevo.importeDolares = i.salidaCostoME * -1
                        'Select Case lsvListaPedidos.SelectedItems(0).SubItems(3).Text
                        '    Case "03", "02"
                        '        objNuevo.importeSoles = i.importeMN * -1
                        '        objNuevo.importeDolares = i.importeME * -1
                        '    Case Else
                        '        Select Case i.destino
                        '            Case "1"
                        '                objNuevo.importeSoles = i.montokardex * -1
                        '                objNuevo.importeDolares = i.montokardexUS * -1
                        '            Case Else
                        '                objNuevo.importeSoles = i.importeMN * -1
                        '                objNuevo.importeDolares = i.importeME * -1
                        '        End Select
                        'End Select

                        objNuevo.cantidad = i.monto1 * -1
                        objNuevo.precioUnitarioCompra = i.precioUnitario

                        objNuevo.montoIsc = i.montoIsc * -1
                        objNuevo.montoIscUS = i.montoIscUS * -1

                        ListaTotales.Add(objNuevo)

                    End If
                End If

            End If

        Next
        documentoSA.DeleteVentaNormalAlCredito(objDocumento, ListaTotales)
    End Sub

    Private Function getParentTableVentasPorPeriodo() As DataTable
        Dim DocumentoVentaSA As New documentoVentaAbarrotesSA

        Dim dt As New DataTable("Ventas ticket - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoVenta", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("tipoDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("nombrePedido", GetType(String)))
        dt.Columns.Add(New DataColumn("TipoPersona ", GetType(String)))

        dt.Columns.Add(New DataColumn("ImporteNacional", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteExtranjero", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))

        Dim str As String
        For Each i As documentoventaAbarrotes In DocumentoVentaSA.GetListarVentasNormalPorPeriodo(GEstableciento.IdEstablecimiento, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str
            dr(3) = i.tipoDocumento
            dr(4) = i.serie
            dr(5) = i.numeroDoc
            dr(6) = i.tipoDocEntidad
            dr(7) = i.NroDocEntidad
            dr(8) = i.NombreEntidad
            dr(9) = i.nombrePedido
            dr(10) = i.ImporteNacional
            dr(11) = i.tipoCambio
            dr(12) = i.ImporteExtranjero
            dr(13) = i.moneda
            Select Case i.estadoCobro
                Case TIPO_VENTA.PAGO.COBRADO
                    dr(14) = "Venta"
                Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                    dr(14) = "Pedido"
                Case TIPO_VENTA.VENTA_NOTA_CREDITO
                    dr(14) = "(DA) nota crédito"
                Case TIPO_VENTA.VENTA_NORMAL_CONTADO
                    dr(14) = "(DC) cobrado"
                Case TIPO_VENTA.VENTA_NORMAL_SERVICIO
                    dr(14) = "(DC) cobrado"
                Case TIPO_VENTA.VENTA_ANULADA
                    dr(14) = "(VA) Anulado"
            End Select
            'Select Case i.estadoCobro
            '    Case "PN"
            '        dr(14) = "PEDIDO"
            '    Case Else
            '        dr(14) = "VENTA"
            'End Select
            dr(15) = i.usuarioActualizacion
            dt.Rows.Add(dr)
        Next
        Return dt

    End Function

    Public Sub ListaVentas()
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim grupoActual As String = String.Empty
        Dim g As New ListViewGroup
        Try

            Dim parentTable As DataTable = getParentTableVentasPorPeriodo()
            Me.dgvVenta.DataSource = parentTable
            dgvVenta.TableDescriptor.Relations.Clear()
            dgvVenta.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvVenta.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvVenta.Appearance.AnyRecordFieldCell.Enabled = False
            dgvVenta.GroupDropPanel.Visible = True
            dgvVenta.TableDescriptor.GroupedColumns.Clear()


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "CONFIGURACION DOCKING CONTROL"
    Sub configDockingManger()
        Me.dockingManager1.DockControl(Me.PanelGuiaRemision, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 100)
        Me.dockingManager1.DockControl(Me.PanelNotas, Me.PanelGuiaRemision, Syncfusion.Windows.Forms.Tools.DockingStyle.Tabbed, 100)
        Me.dockingManager1.DockControl(Me.PanelTributo, Me.PanelGuiaRemision, Syncfusion.Windows.Forms.Tools.DockingStyle.Tabbed, 100)

        dockingManager1.SetDockLabel(PanelGuiaRemision, "Guía de remisión")
        dockingManager1.SetDockLabel(PanelNotas, "Notas interactivas")
        dockingManager1.SetDockLabel(PanelTributo, "Tributos")

        dockingManager1.SetDockVisibility(PanelGuiaRemision, False)
        dockingManager1.SetDockVisibility(PanelNotas, False)
        dockingManager1.SetDockVisibility(PanelTributo, False)

        dockingManager1.CloseEnabled = False
    End Sub
#End Region

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
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
    End Sub

    Private Sub CompCreditCRecepExistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompCreditCRecepExistToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmVentaNormal
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub frmMaestroVentaNormal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'comentario
    End Sub

    Private Sub VentasDelEstablecimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasDelEstablecimientoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        lblPeriodo.Text = PeriodoGeneral
        ListaVentas()
        lblEstado.Text = "Lista de ventas período: " & PeriodoGeneral
        Timer1.Enabled = True
        PanelError.Visible = True
        TiempoEjecutar(10)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub btnEliminarCompra_Click(sender As Object, e As EventArgs) Handles btnEliminarCompra.Click
        Dim ventaSA As New documentoVentaAbarrotesSA

        Try
            If Not IsNothing(Me.dgvVenta.Table.CurrentRecord) Then

                Select Case Me.dgvVenta.Table.CurrentRecord.GetValue("tipoVenta")

                    Case TIPO_VENTA.VENTA_NORMAL_CREDITO
                        If MessageBox.Show("Desea eliminar registro seleccionado?   ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                            '   If Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = "PN" Then
                            EliminarVentaAlCredito(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")), TIPO_VENTA.VENTA_NORMAL_CREDITO)
                            Me.dgvVenta.Table.CurrentRecord.Delete()
                            'ElseIf Me.dgvVenta.Table.CurrentRecord.GetValue("estadoCobro") = "DC" Then
                            '    EliminarVentaCobrada(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
                            'End If
                            '      lsvListaPedidos.SelectedItems(0).SubItems(15).Text = TIPO_VENTA.VENTA_ANULADA
                            lblEstado.Text = "Pedido eliminado!"
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If

                    Case TIPO_VENTA.VENTA_AL_TICKET_DIRECTA

                End Select


            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub btnEditCompra_Click(sender As Object, e As EventArgs) Handles btnEditCompra.Click
        
        If Not IsNothing(Me.dgvVenta.Table.CurrentRecord) Then
            Select Case Me.dgvVenta.Table.CurrentRecord.GetValue("tipoVenta")

                Case TIPO_VENTA.VENTA_NORMAL_CREDITO
                    With frmVentaNormal
                     
                        .txtFechaComprobante.ShowUpDown = True
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        .UbicarDocumento(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
                        .lblIdDocumento.Text = (CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With

                Case TIPO_VENTA.VENTA_NORMAL_CONTADO


                    With frmVentaNormalDirecta
                        .GuardarToolStripButton.Enabled = True
                        .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        If .TieneCuentaFinanciera = True Then
                            .txtFechaComprobante.ShowUpDown = True
                            .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            .UbicarDocumento(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
                            .lblIdDocumento.Text = (CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
                            .StartPosition = FormStartPosition.CenterParent
                            .ShowDialog()
                        Else
                            lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                        End If
                    End With


                Case TIPO_VENTA.VENTA_NORMAL_SERVICIO
                    With frmVentaNormalServicio

                        .txtFechaComprobante.ShowUpDown = True
                        .ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        .UbicarDocumento(CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
                        .lblIdDocumento.Text = (CInt(Me.dgvVenta.Table.CurrentRecord.GetValue("idDocumento")))
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                    End With



            End Select


        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub VentaAlContadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaAlContadoToolStripMenuItem.Click
      
        Me.Cursor = Cursors.WaitCursor

        With frmVentaNormalDirecta

            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            ' .GuardarToolStripButton.Enabled = True
            If .TieneCuentaFinanciera = True Then
                .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                .lblPerido.Text = lblPeriodo.Text
                .StartPosition = FormStartPosition.CenterParent
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
                '.txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
                '.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                '.lblPerido.Text = PeriodoGeneral
                '.StartPosition = FormStartPosition.CenterParent
                '.ShowDialog()
            Else
                lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                PanelError.Visible = True
                Timer1.Enabled = True
                TiempoEjecutar(5)
                'lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                'PanelError.Visible = True
                'Timer1.Enabled = True
                'TiempoEjecutar(5)
            End If
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripPanelItem1_Click(sender As Object, e As EventArgs) Handles ToolStripPanelItem1.Click

    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click

    End Sub

    Private Sub VentaDeServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaDeServiciosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        With frmVentaNormalServicio
            .ManipulacionEstado = ENTITY_ACTIONS.INSERT
            .txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DiaLaboral.Day)
            .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
            .lblPerido.Text = PeriodoGeneral
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub
End Class