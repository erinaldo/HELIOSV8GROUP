Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Syncfusion.GridHelperClasses
Imports PopupControl
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid

Public Class frmCuentasAPagar
    Inherits frmMaster

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        QGlobalColorSchemeManager1 = New Qios.DevSuite.Components.QGlobalColorSchemeManager
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ConfiguracionInicio()
        '  dockingManager1.DockToFill = True
        configDockingManger()
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing

        '  AddHandler dgvCheckes.TableControlCheckBoxClick, AddressOf gridGroupingControl1_TableControlCheckBoxClick
    End Sub

    '  Private CheckBoxClicked As Boolean = False
    Private dt As DataTable
    'Dim RowIndex As Integer ' = e.Inner.RowIndex
    'Dim ColIndex As Integer '= e.Inner.ColIndex
    'Private str() As Boolean = {True, False}
    'Private CheckBoxValue As Boolean = False

    'Private Sub gridGroupingControl1_TableControlCheckBoxClick(ByVal sender As Object, ByVal e As GridTableControlCellClickEventArgs)
    '    Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
    '    If style.Enabled Then
    '        Dim column As Integer = Me.dgvCheckes.TableModel.NameToColIndex("Estado")
    '        Console.WriteLine("CheckBoxClicked")
    '        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
    '            chk = CBool(Me.dgvCheckes.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

    '            e.TableControl.BeginUpdate()

    '            e.TableControl.EndUpdate(True)
    '        End If
    '        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "Estado" Then
    '            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
    '            Dim curStatus As Boolean = Boolean.Parse(style.Text)
    '            e.TableControl.BeginUpdate()

    '            If curStatus Then
    '                CheckBoxValue = False
    '            End If
    '            If curStatus = True Then
    '                'Dim RowIndex As Integer = e.Inner.RowIndex
    '                'Dim ColIndex As Integer = e.Inner.ColIndex

    '                'Dim docCaja As New documentoCaja
    '                'Dim documentoCajaSA As New DocumentoCajaSA
    '                'Try
    '                '    '   If Not IsNothing(Me.dgvCheckes.Table.CurrentRecord) Then
    '                '    docCaja.idDocumento = CInt(Me.dgvCheckes.TableModel(RowIndex, 1).CellValue)
    '                '    docCaja.entregado = "NO"
    '                '    If documentoCajaSA.VerificarConciliarCheque(docCaja) = True Then
    '                '        DeshacerConciliacion(CInt(Me.dgvCheckes.TableModel(RowIndex, 1).CellValue))
    '                '    End If
    '                '    '   End If
    '                'Catch ex As Exception
    '                '    PanelError.Visible = True
    '                '    lblEstado.Text = ex.Message
    '                '    Timer1.Enabled = True
    '                '    TiempoEjecutar(10)
    '                'End Try

    '            Else
    '                Dim RowIndex As Integer = e.Inner.RowIndex
    '                Dim ColIndex As Integer = e.Inner.ColIndex

    '                '    MsgBox(True)

    '                Dim docCaja As New documentoCaja
    '                Dim documentoCajaSA As New DocumentoCajaSA
    '                Try
    '                    '   If Not IsNothing(Me.dgvCheckes.Table.CurrentRecord) Then
    '                    docCaja.idDocumento = CInt(Me.dgvCheckes.TableModel(RowIndex, 1).CellValue)
    '                    docCaja.entregado = "SI"
    '                    If documentoCajaSA.VerificarConciliarCheque(docCaja) = True Then
    '                        With documentoCajaSA.GetUbicar_documentoCajaPorID(CInt(Me.dgvCheckes.TableModel(RowIndex, 1).CellValue))
    '                            Dim form As New frmConciliarCheque
    '                            form.lblIdDocumento.Text = CInt(Me.dgvCheckes.TableModel(RowIndex, 1).CellValue)
    '                            If form.TieneCuentaFinanciera(CInt(Me.dgvCheckes.TableModel(RowIndex, 1).CellValue)) = True Then
    '                                form.txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
    '                                form.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
    '                                form.txtTipoDoc.Text = "CHEQUE"
    '                                form.txtNumeroDoc.Text = .numeroDoc
    '                                form.txtMoneda.Text = IIf(.moneda = 1, "NAC", "USD")
    '                                form.StartPosition = FormStartPosition.CenterParent
    '                                form.ShowDialog()
    '                            Else
    '                                PanelError.Visible = True
    '                                lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
    '                                Timer1.Enabled = True
    '                                TiempoEjecutar(10)
    '                            End If
    '                        End With
    '                    End If


    '                    '  End If
    '                Catch ex As Exception
    '                    PanelError.Visible = True
    '                    lblEstado.Text = ex.Message
    '                    Timer1.Enabled = True
    '                    TiempoEjecutar(10)
    '                End Try

    '            End If

    '        End If
    '    End If

    '    Me.dgvCheckes.TableControl.Refresh()
    'End Sub

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
        '  Me.RibbonControlAdv1.Header.AddQuickItem(Me.ToolStripSeparator1)
        RibbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.Birds
        'Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        'Me.rbnPrincipal.Header.AddQuickItem(cboAnio)
        TabPageAdv1.Parent = TabControlAdv1
        TabPageAdv2.Parent = Nothing
    End Sub

#Region "CONFIGURACION DOCKING CONTROL"
    Sub configDockingManger()
        Me.dockingManager1.DockControlInAutoHideMode(Me.PanelHistorialPago, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 180)
        dockingManager1.SetDockLabel(PanelHistorialPago, "Historial de Pago")
        dockingManager1.CloseEnabled = False
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

#Region "Métodos"

    Private Sub DeshacerConciliacion(intIdDocumento As Integer)
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim documentoCaja As New documentoCaja
        Dim documentoCaja2 As New documentoCaja
        Dim documento As New documento
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim cajaUsarioBE As New cajaUsuario
        Dim cajaUsariodetalleBE As New cajaUsuariodetalle
        Dim cajaUsariodetalleListaBE As New List(Of cajaUsuariodetalle)


        Dim codCompra As String = documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(intIdDocumento).First.documentoAfectado
        documentoCaja2 = documentoCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento)

        documento.idDocumento = intIdDocumento
        documento.IdDocumentoAfectado = codCompra
        documento.usuarioActualizacion = documentoCaja2.usuarioModificacion



        With documentoCaja
            .idDocumento = intIdDocumento
            .fechaCobro = Nothing
            .numeroOperacion = Nothing
            .entregado = "NO"
        End With

        'With cajaUsarioBE
        '    .idcajaUsuario = documentoCaja2.usuarioModificacion
        '    .otrosEgresosMN = CDec(txtImporteCompramn.Value)
        '    .otrosEgresosME = CDec(txtImporteComprame.Value)
        'End With
        'cajaUsariodetalleBE = New cajaUsuariodetalle
        'cajaUsariodetalleBE.idcajaUsuario = documentoCaja2.usuarioModificacion
        'cajaUsariodetalleBE.tipoDoc = DocumentoCompraSA.UbicarDocumentoCompra(codCompra).tipoDoc
        'cajaUsariodetalleBE.tipoVenta = TIPO_COMPRA.COMPRA_AL_CREDITO
        'cajaUsariodetalleBE.importeMN = CDec(txtImporteCompramn.Value)
        'cajaUsariodetalleBE.importeME = CDec(txtImporteComprame.Value)
        'cajaUsariodetalleListaBE.Add(cajaUsariodetalleBE)
        'cajaUsarioBE.cajaUsuariodetalle = cajaUsariodetalleListaBE


        '  Dim codCompra As String = documentoCajaDetalleSA.GetUbicar_DetallePorIdDocumento(lblIdDocumento.Text).First.documentoAfectado


        documentoCajaSA.ConciliarCheque(documentoCaja, documento, Nothing)
        PanelError.Visible = True
        lblEstado.Text = "Conciliación eliminada!"
        Timer1.Enabled = True
        TiempoEjecutar(10)
    End Sub

    Private Sub btnNuevoPago(strFormPago As String)
        Me.Cursor = Cursors.WaitCursor
        Dim objLista As New DocumentoCajaDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then

            Select Case txtTipoCompra.ValueMember

                Case TIPO_COMPRA.COMPRA_AL_CREDITO, TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION
                    With frmPagos
                        '   .tbFormaPago.ToggleState = Tools.ToggleButtonState.Inactive
                        .dgvDetalleItems.Rows.Clear()
                        .manipulacionEstado = ENTITY_ACTIONS.INSERT
                        Select Case txtMonedaCompra.ValueMember
                            Case 1
                                .lblIdProveedor = txtProveedor.ValueMember
                                .lblNomProveedor = txtProveedor.Text
                                .lblCuentaProveedor = txtCuenta.Text
                                .lblIdDocumento.Text = txtFechaCompra.ValueMember

                                For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(txtFechaCompra.ValueMember)
                                    cTotalmn = Math.Round(CDec(i.MontoDeudaSoles) - CDec(i.notaCreditoMN) + CDec(i.notaDebitoMN) - CDec(i.MontoPagadoSoles), 2)
                                    cTotalme = Math.Round(CDec(i.MontoDeudaUSD) - CDec(i.notaCreditoME) + CDec(i.notaDebitoME) - CDec(i.MontoPagadoUSD), 2)
                                    saldomn += cTotalmn
                                    saldome += cTotalme
                                    If cTotalmn > 0 Or cTotalme > 0 Then
                                        .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                                   Nothing, cTotalmn, cTotalme,
                                                                   "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                                    End If

                                Next
                                lblPagoMN.Text = saldomn.ToString("N2")
                                lblPagoME.Text = saldome.ToString("N2")

                                '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                                .txtSaldoPorPagar.DecimalValue = CDec(lblPagoMN.Text)
                                .lblDeudaPendienteme.Text = CDec(lblPagoME.Text)
                        End Select

                        If CDec(lblPagoMN.Text) <= 0 Then
                            '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                            lblEstado.Text = "El documento ya se encuentra pagado."
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Me.Cursor = Cursors.Arrow
                            Exit Sub
                        Else
                            'If .TieneCuentaFinanciera = True Then
                            '    .txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                            '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                            '    .txtFechaComprobante.Enabled = False
                            '    .lblPerido.Text = lblPeriodo.Text
                            '    'If strFormPago = "EFECTIVO" Then
                            '    '    .rbEfectivo.Checked = True
                            '    '    .LoadEfectivo()
                            '    '    .txtNumero.Visible = False
                            '    '    .txtNumero.Clear()
                            '    'ElseIf strFormPago = "OTROS" Then
                            '    '    .rbOtros.Checked = True
                            '    '    .LoadOtros()
                            '    '    .txtNumero.Visible = True
                            '    '    .txtNumero.Clear()
                            '    'End If
                            '    .cboTipoDoc.Enabled = True
                            '    .cboTipoDoc.ReadOnly = False
                            '    .StartPosition = FormStartPosition.CenterParent
                            '    .ShowDialog()
                            'Else
                            '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                            '    PanelError.Visible = True
                            '    Timer1.Enabled = True
                            '    TiempoEjecutar(10)
                            'End If
                        End If
                    End With
                Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION, TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
                    lblEstado.Text = "La compra está pagada."
                    PanelError.Visible = True
                    Timer1.Enabled = True
                    TiempoEjecutar(10)
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
            End Select
        ElseIf TabControlAdv1.SelectedTab Is TabPageAdv3 Then

            If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
                Select Case Me.dgvCompra.Table.CurrentRecord.GetValue("tipoCompra")

                    Case TIPO_COMPRA.COMPRA_AL_CREDITO, TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION
                        With frmPagos
                            '          .tbFormaPago.ToggleState = Tools.ToggleButtonState.Active
                            .dgvDetalleItems.Rows.Clear()
                            .manipulacionEstado = ENTITY_ACTIONS.INSERT
                            '   Select Case txtMonedaCompra.ValueMember
                            '    Case 1
                            .lblIdProveedor = txtProveedorFilter.ValueMember
                            .lblNomProveedor = txtProveedorFilter.Text
                            .lblCuentaProveedor = txtCuentaProvFilter.Text
                            .lblIdDocumento.Text = Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento")

                            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(Me.dgvCompra.Table.CurrentRecord.GetValue("idDocumento"))
                                cTotalmn = Math.Round(CDec(i.MontoDeudaSoles) - CDec(i.notaCreditoMN) + CDec(i.notaDebitoMN) - CDec(i.MontoPagadoSoles), 2)
                                cTotalme = Math.Round(CDec(i.MontoDeudaUSD) - CDec(i.notaCreditoME) + CDec(i.notaDebitoME) - CDec(i.MontoPagadoUSD), 2)
                                saldomn += cTotalmn
                                saldome += cTotalme
                                If cTotalmn > 0 Or cTotalme > 0 Then
                                    .dgvDetalleItems.Rows.Add(i.idItem, i.DetalleItem, Nothing,
                                                               Nothing, cTotalmn, cTotalme,
                                                               "0.00", "0.00", "0.00", "0.00", Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT)
                                End If

                            Next
                            lblPagoMN.Text = saldomn.ToString("N2")
                            lblPagoME.Text = saldome.ToString("N2")

                            '.nudImporteNac.Maximum = CDec(lblPagoMN.Text)
                            .txtSaldoPorPagar.DecimalValue = CDec(lblPagoMN.Text)
                            .lblDeudaPendienteme.Text = CDec(lblPagoME.Text)
                            '    End Select

                            If CDec(lblPagoMN.Text) <= 0 Then
                                '    MsgBox("El documento ya se encuentra pagado.", MsgBoxStyle.Information, "Aviso del Sistema")
                                lblEstado.Text = "El documento ya se encuentra pagado."
                                PanelError.Visible = True
                                Timer1.Enabled = True
                                TiempoEjecutar(10)
                                Me.Cursor = Cursors.Arrow
                                Exit Sub
                            Else
                                'If .TieneCuentaFinanciera = True Then
                                '    .txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                                '    .txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                                '    .txtFechaComprobante.Enabled = False
                                '    .lblPerido.Text = lblPeriodo.Text
                                '    'If strFormPago = "EFECTIVO" Then
                                '    '    .rbEfectivo.Checked = True
                                '    '    .LoadEfectivo()
                                '    '    .txtNumero.Visible = False
                                '    '    .txtNumero.Clear()
                                '    'ElseIf strFormPago = "OTROS" Then
                                '    '    .rbOtros.Checked = True
                                '    '    .LoadOtros()
                                '    '    .txtNumero.Visible = True
                                '    '    .txtNumero.Clear()
                                '    'End If
                                '    .cboTipoDoc.Enabled = True
                                '    .cboTipoDoc.ReadOnly = False
                                '    .StartPosition = FormStartPosition.CenterParent
                                '    .ShowDialog()
                                'Else
                                '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                                '    PanelError.Visible = True
                                '    Timer1.Enabled = True
                                '    TiempoEjecutar(10)
                                'End If
                            End If
                        End With
                    Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION, TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
                        lblEstado.Text = "La compra está pagada."
                        PanelError.Visible = True
                        Timer1.Enabled = True
                        TiempoEjecutar(10)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                End Select
            End If


        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Function getParentTableChequesPorPeriodo() As DataTable
    '    Dim tablaSA As New tablaDetalleSA
    '    Dim personaSA As New PersonaSA
    '    Dim dt As New DataTable("Cheques - período " & PeriodoGeneral & " ")
    '    Dim documentoCajaSA As New DocumentoCajaSA
    '    Dim usuarioSA As New cajaUsuarioSA

    '    dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
    '    'dt.Columns.Add(New DataColumn("fechaProceso", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("NombreCaja", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("moneda", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
    '    'dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
    '    'dt.Columns.Add(New DataColumn("entregado", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("usuarioModificacion", GetType(String)))
    '    'dt.Columns.Add(New DataColumn("nomUser", GetType(String)))
    '    dt.Columns.Add(New DataColumn("Estado", GetType(Boolean)))

    '    Dim str As String
    '    For Each i As documentoCaja In documentoCajaSA.ListaChequesPorProveedor(GEstableciento.IdEstablecimiento, txtProvedorFilter2.ValueMember, PeriodoGeneral)
    '        Dim dr As DataRow = dt.NewRow()
    '        'str = Nothing
    '        'str = CDate(i.fechaProceso).ToString("dd-MMM hh:mm tt ")
    '        dr(0) = i.idDocumento
    '        'dr(1) = str
    '        'dr(2) = i.NombreCaja
    '        'dr(3) = i.tipoDocPago
    '        'dr(4) = i.numeroDoc
    '        'dr(5) = IIf(i.moneda = "1", "NAC", "USD")
    '        'dr(6) = i.montoSoles
    '        'dr(7) = i.montoUsd
    '        'dr(8) = i.entregado
    '        'With usuarioSA.UbicarCajaUsuarioPorID(i.usuarioModificacion)
    '        '    dr(9) = i.usuarioModificacion
    '        '    dr(10) = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, .idPersona).nombreCompleto.ToLower
    '        'End With
    '        If i.entregado = "SI" Then
    '            dr(1) = True
    '        ElseIf i.entregado = "NO" Then
    '            dr(1) = False
    '        End If
    '        dt.Rows.Add(dr)
    '    Next
    '    Return dt
    'End Function

#Region "CHECBOX USING"
    'Private Sub TableControl_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
    '    Dim row, col As Integer
    '    Me.dgvCheckes.TableControl.PointToRowCol(New Point(e.X, e.Y), row, col)
    '    Dim style As GridTableCellStyleInfo = Me.dgvCheckes.TableControl.Model(row, col)

    '    Dim controller As IMouseController
    '    Me.dgvCheckes.TableControl.MouseControllerDispatcher.HitTest(New Point(e.X, e.Y), e.Button, e.Clicks, controller)

    '    If controller IsNot Nothing AndAlso controller.Name = "DragGroupHeader" Then
    '        If Me.dgvCheckes.TableDescriptor.GroupedColumns.Count > 0 AndAlso col = Me.dgvCheckes.TableDescriptor.GroupedColumns.Count + 1 Then
    '            Me.dgvCheckes.TableControl.GetCellRenderer(row, col - Me.dgvCheckes.TableDescriptor.GroupedColumns.Count).RaiseMouseUp(row, col - Me.dgvCheckes.TableDescriptor.GroupedColumns.Count, e)
    '        Else
    '            Me.dgvCheckes.TableControl.GetCellRenderer(row, col).RaiseMouseUp(row, col, e)
    '        End If

    '    End If
    'End Sub

    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()
    Dim GroupCheckValue As New Hashtable()
    '   Dim el As Element = Style.TableCellIdentity.DisplayElement
    Private Sub SetCheckStatus(g As Group, ColumnName As String, bvalue As Boolean)
        For Each group As Group In g.Groups
            SetCheckStatus(group, ColumnName, bvalue)
        Next
        For Each rec As Record In g.Records
            rec.SetValue(ColumnName, bvalue)
        Next

    End Sub
#End Region

    Public Sub ListaChequesPeriodo()
        Dim personaSA As New PersonaSA
        '  Dim dt As New DataTable("Cheques - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim usuarioSA As New cajaUsuarioSA

        dt = New DataTable("Cheques - período " & PeriodoGeneral & " ")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("fechaProceso", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocPago", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("usuarioModificacion", GetType(String)))
        dt.Columns.Add(New DataColumn("nomUser", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaCobro", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroOperacion", GetType(String)))
        dt.Columns.Add(New DataColumn("entregado", GetType(String)))
        Dim str As String
        For Each row As documentoCaja In documentoCajaSA.ListaChequesPorProveedor(GEstableciento.IdEstablecimiento, txtProvedorFilter2.ValueMember, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(row.fechaProceso).ToString("dd-MMM hh:mm tt ")
            dr(0) = row.idDocumento
            dr(1) = str
            dr(2) = row.NombreCaja
            dr(3) = row.tipoDocPago
            dr(4) = row.numeroDoc
            dr(5) = IIf(row.moneda = "1", "NAC", "USD")
            dr(6) = row.montoSoles
            dr(7) = row.montoUsd
            With usuarioSA.UbicarCajaUsuarioPorID(row.usuarioModificacion)
                dr(8) = row.usuarioModificacion
                dr(9) = personaSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, .idPersona).nombreCompleto.ToLower
            End With
            If Not IsNothing(row.fechaCobro) Then
                dr(10) = CStr(row.fechaCobro)
            Else

            End If

            dr(11) = row.numeroOperacion
            dr(12) = row.entregado
            dt.Rows.Add(dr)
        Next

        'Dim parentTable As DataTable = getParentTableChequesPorPeriodo()
        'Me.dgvProforma.DataSource = parentTable
        dgvCheckes.DataSource = dt
        ' Me.dgvCheckes.TopLevelGroupOptions.ShowAddNewRecordBeforeDetails = False
        dgvCheckes.TableDescriptor.Relations.Clear()
        dgvCheckes.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvCheckes.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvCheckes.Appearance.AnyRecordFieldCell.Enabled = False
        dgvCheckes.GroupDropPanel.Visible = True
        dgvCheckes.TableDescriptor.GroupedColumns.Clear()
        dgvCheckes.TableDescriptor.GroupedColumns.Add("entregado")
        '   AddHandler dgvCheckes.TableControlCheckBoxClick, AddressOf gridGroupingControl1_TableControlCheckBoxClick
        '    dgvCheckes.TableDescriptor.GroupedColumns.Add("tipoDoc")
    End Sub


    Private Function getParentTableComprasPorPeriodo() As DataTable
        Dim DocumentoCompraSA As New DocumentoCompraSA
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable("Compras - período " & PeriodoGeneral & " ")
        Dim documentoCajaSA As New DocumentoCajaSA

        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("DetalleItem", GetType(String)))
        '   dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))

        '   dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))

        dt.Columns.Add(New DataColumn("ImporteCompraDetalleMN", GetType(Decimal)))
        'dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImporteCompraDetalleME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("NombreCajaPago", GetType(String)))
        dt.Columns.Add(New DataColumn("ImportePagoMN", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("ImportePagoME", GetType(Decimal)))

        dt.Columns.Add(New DataColumn("TipoDocPagoCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("NumeroTipoDocCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("NumDocOperCaja", GetType(String)))
        dt.Columns.Add(New DataColumn("BancoDeposito", GetType(String)))
        dt.Columns.Add(New DataColumn("CtaCorrienteDeposito", GetType(String)))

        Dim str As String
        For Each i As documentocompra In DocumentoCompraSA.GetListarComprasPorProveedorCaja(GEstableciento.IdEstablecimiento, txtProveedorFilter.ValueMember, PeriodoGeneral)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoCompra
            dr(2) = str
            dr(3) = tablaSA.GetUbicarTablaID(10, i.tipoDoc).descripcion.Substring(0, 3) & ", " & CInt(i.serie) & "-" & CInt(i.numeroDoc)
            dr(4) = i.DetalleItemCaja
            dr(5) = i.ImporteCompraDetalleMN
            dr(6) = i.ImporteCompraDetalleME
            dr(7) = i.NombreCajaPago
            dr(8) = i.ImportePagoMN
            dr(9) = i.ImportePagoME

            Select Case i.TipoDocPagoCaja
                Case "003"
                    dr(10) = New String("TRAN")
                Case "109"
                    dr(10) = New String("EFE")
                Case "007"
                    dr(10) = New String("CHE")
            End Select
            dr(11) = i.NumeroTipoDocCaja
            dr(12) = i.NumDocOperCaja
            Select Case i.TipoDocPagoCaja
                Case "003"
                    dr(13) = tablaSA.GetUbicarTablaID(3, i.BancoDeposito).descripcion.Substring(0, 10)
                Case "109"
                    dr(13) = "-"
                Case "007"
                    dr(13) = "-"
            End Select
            dr(14) = i.CtaCorrienteDeposito
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function


    Public Sub ListaComprasProveedor()
        Try
            Dim parentTable As DataTable = getParentTableComprasPorPeriodo()
            Me.dgvCompra.DataSource = parentTable
            dgvCompra.TableDescriptor.Relations.Clear()
            dgvCompra.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
            dgvCompra.TableOptions.ListBoxSelectionMode = SelectionMode.One
            dgvCompra.Appearance.AnyRecordFieldCell.Enabled = False
            dgvCompra.GroupDropPanel.Visible = True
            dgvCompra.TableDescriptor.GroupedColumns.Clear()
            dgvCompra.TableDescriptor.GroupedColumns.Add("tipoDoc")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoadProveedores()
        Dim entidadSA As New entidadSA

        lsvProveedor.Items.Clear()

        For Each i As entidad In entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim n As New ListViewItem(i.idEntidad)
            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.cuentaAsiento)
            n.SubItems.Add(i.nrodoc)
            lsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub LoadProveedores2()
        Dim entidadSA As New entidadSA

        ListView1.Items.Clear()

        For Each i As entidad In entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim n As New ListViewItem(i.idEntidad)
            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.cuentaAsiento)
            n.SubItems.Add(i.nrodoc)
            ListView1.Items.Add(n)
        Next
    End Sub

    Public Sub EliminarDocumento(intIdDocumento As Integer)
        Dim documentoSA As New DocumentoSA
        Dim docCajaSA As New DocumentoCajaSA
        Dim nDocumento As New documento()
        With nDocumento
            .IdDocumentoAfectado = txtFechaCompra.ValueMember
            .idDocumento = intIdDocumento
            .usuarioActualizacion = docCajaSA.GetUbicar_documentoCajaPorID(intIdDocumento).usuarioModificacion
        End With
        documentoSA.EliminarDocumentoCaja(nDocumento)
        Me.dgvHistorial.Table.CurrentRecord.Delete()
        lblEstado.Text = "Pago eliminado correctamente"
        PanelError.Visible = True
        Timer1.Enabled = True
        TiempoEjecutar(10)
        '  HistorialCompra(txtFechaCompra.ValueMember)
    End Sub

    Private Function getParentTableHistorial(intIdCompra As Integer) As DataTable
        Dim objLista As New DocumentoCajaDetalleSA()

        Dim dt As New DataTable("Historial de pagos ")

        dt.Columns.Add(New DataColumn("documentoAfectado", GetType(Integer)))
        dt.Columns.Add(New DataColumn("nomDocumento", GetType(String)))
        'lower case p
        dt.Columns.Add(New DataColumn("numeroDocNormal", GetType(String)))
        dt.Columns.Add(New DataColumn("idCliente", GetType(String)))
        dt.Columns.Add(New DataColumn("nomEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))

        dt.Columns.Add(New DataColumn("moneda", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDocumento", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoCambio", GetType(String)))
        dt.Columns.Add(New DataColumn("idDocumento", GetType(String)))

        dt.Columns.Add(New DataColumn("montoSoles", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("montoUsd", GetType(Decimal)))

        Dim str As String
        For Each i As documentoCajaDetalle In objLista.ObtenerHistorialPagos(intIdCompra)
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.documentoAfectado
            dr(1) = i.nomDocumento
            dr(2) = i.numeroDocNormal
            dr(3) = i.idCliente
            dr(4) = i.nomEntidad
            dr(5) = str

            dr(6) = i.moneda
            dr(7) = i.tipoDocumento
            dr(8) = i.tipoCambioTransacc
            dr(9) = i.idDocumento
            dr(10) = i.montoSoles
            dr(11) = i.montoUsd
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function

    Private Sub HistorialCompra(intIdCompra As Integer)
        Dim objLista As New DocumentoCajaDetalleSA()
        dgvHistorial.TableDescriptor.Name = ("Historial compra")
        dgvHistorial.DataSource = getParentTableHistorial(intIdCompra) ' objLista.ObtenerHistorialPagos(intIdCompra)
        dgvHistorial.TableDescriptor.Relations.Clear()
        dgvHistorial.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvHistorial.TableOptions.ListBoxSelectionMode = SelectionMode.One
        dgvHistorial.ShowColumnHeaders = False
        dgvHistorial.GroupDropPanel.Visible = False
        Me.dgvHistorial.TopLevelGroupOptions.ShowCaption = False
        '  dgvPagos.TableOptions.ShowRowHeader = False
        dgvHistorial.Appearance.AnyRecordFieldCell.Enabled = False
        dgvHistorial.TableDescriptor.GroupedColumns.Clear()
        dgvHistorial.TableDescriptor.GroupedColumns.Add("nomDocumento")
    End Sub

    Public Sub ObtenerPagosDelDia()
        Dim objLista As New DocumentoCajaDetalleSA()
        dgvPagos.TableDescriptor.Name = ("Pagos del día")
        dgvPagos.DataSource = objLista.ObtenerPagosDelDiaPorEstablecimiento(GEstableciento.IdEstablecimiento)
        '   dgvPagos.TableDescriptor.Relations.Clear()
        dgvPagos.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvPagos.TableOptions.ListBoxSelectionMode = SelectionMode.One
        '  dgvPagos.TableOptions.ShowRowHeader = False
        dgvPagos.Appearance.AnyRecordFieldCell.Enabled = False
        dgvPagos.TableDescriptor.GroupedColumns.Clear()
        dgvPagos.TableDescriptor.GroupedColumns.Add("nomEntidad")
        '    DockingClientPanel1.Visible = True

    End Sub

    Public Sub ObtenerPagosPorPeriodo()
        Dim objLista As New DocumentoCajaDetalleSA()
        dgvPagos.TableDescriptor.Name = ("Pagos por período")
        dgvPagos.DataSource = objLista.ObtenerPagosPorPeriodoporEstablecimiento(GEstableciento.IdEstablecimiento, PeriodoGeneral)
        '   dgvPagos.TableDescriptor.Relations.Clear()
        dgvPagos.TableOptions.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.None
        dgvPagos.TableOptions.ListBoxSelectionMode = SelectionMode.One
        '  dgvPagos.TableOptions.ShowRowHeader = False
        dgvPagos.Appearance.AnyRecordFieldCell.Enabled = False
        dgvPagos.TableDescriptor.GroupedColumns.Clear()
        dgvPagos.TableDescriptor.GroupedColumns.Add("nomEntidad")
        '    DockingClientPanel1.Visible = True

    End Sub

    Public Class DocCompra
        Private _name As String
        Private _id As Integer
        Public Sub New(ByVal name As String, ByVal id As Integer)
            _name = name
            _id = id
        End Sub

        Sub New()
            ' TODO: Complete member initialization 
        End Sub

        Public Property Name() As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property
        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property
    End Class

    Private Sub UbicarCompraNroSerie(strSerie As String, strNumero As String, strRuc As String)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoCompra As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        lstCompras.Items.Clear()
        documentoCompra = documentoCompraSA.UbicarCompraPorSerieNro(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strSerie, strNumero, strRuc)
        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
                lstCompras.Items.Add(New DocCompra(i.numeroDoc, i.idDocumento))
            Next
            '  lstCompras.DataSource = tablaSA.GetListaTablaDetalle(5, "1")
            lstCompras.DisplayMember = "Name"
            lstCompras.ValueMember = "Id"
        Else
            lstCompras.DataSource = Nothing
            lstCompras.Items.Clear()
        End If


    End Sub

    Private Sub ObtenerPorDetails(strDocumentoAfectado As Integer, lsvDetalleItems As ListView)

        Dim objLista As New DocumentoCajaDetalleSA
        Dim saldomn As Decimal = 0
        Dim saldome As Decimal = 0

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        Try
            lsvDetalleItems.Columns.Clear()
            lsvDetalleItems.Items.Clear()
            lsvDetalleItems.Columns.Add("ID", 0) '0
            lsvDetalleItems.Columns.Add("Descripción", 220) '01
            lsvDetalleItems.Columns.Add("Compra", 75, HorizontalAlignment.Right) '02
            lsvDetalleItems.Columns.Add("Deuda M.E.", 0, HorizontalAlignment.Right) '03

            lsvDetalleItems.Columns.Add("N.C.", 80, HorizontalAlignment.Right) '04
            lsvDetalleItems.Columns.Add("Nota CR.me.", 0, HorizontalAlignment.Right) '05

            lsvDetalleItems.Columns.Add("N.D.", 80, HorizontalAlignment.Right) '06
            lsvDetalleItems.Columns.Add("Nota DB.me.", 0, HorizontalAlignment.Right) '07

            lsvDetalleItems.Columns.Add("A Cuenta", 80, HorizontalAlignment.Right) '08
            lsvDetalleItems.Columns.Add("A cuenta M.E.", 0, HorizontalAlignment.Right) '09
            lsvDetalleItems.Columns.Add("Saldo M.N.", 100, HorizontalAlignment.Right) '10
            lsvDetalleItems.Columns.Add("Saldo M.E.", 0, HorizontalAlignment.Right) '11
            lsvDetalleItems.Columns.Add("Cancelado", 0, HorizontalAlignment.Center) '12
            For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(strDocumentoAfectado)
                'saldomn = Math.Round(i.MontoDeudaSoles - i.MontoPagadoSoles, 2)
                'saldome = Math.Round(i.MontoDeudaUSD - i.MontoPagadoUSD, 2)

                cTotalmn = Math.Round(CDec(i.MontoDeudaSoles) - CDec(i.notaCreditoMN) + CDec(i.notaDebitoMN) - CDec(i.MontoPagadoSoles), 2)
                cTotalme = Math.Round(CDec(i.MontoDeudaUSD) - CDec(i.notaCreditoME) + CDec(i.notaDebitoME) - CDec(i.MontoPagadoUSD), 2)
                saldomn += cTotalmn
                saldome += cTotalme
                Dim n As New ListViewItem(i.idItem)
                n.UseItemStyleForSubItems = False
                With n.SubItems.Add(i.DetalleItem)
                    .ForeColor = Color.FromArgb(0, 114, 198)
                End With
                With n.SubItems.Add(i.MontoDeudaSoles.ToString("N2"))
                    .ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    .Font = New Font("Segoe UI", 8, FontStyle.Bold)
                End With
                n.SubItems.Add(i.MontoDeudaUSD.ToString("N2"))
                With n.SubItems.Add(i.notaCreditoMN.ToString("N2"))
                    .BackColor = Color.LightYellow
                    .ForeColor = Color.DarkRed
                    .Font = New Font("Segoe UI", 8, FontStyle.Bold)
                End With
                n.SubItems.Add(i.notaCreditoME.ToString("N2"))
                n.SubItems.Add(i.notaDebitoMN.ToString("N2"))
                n.SubItems.Add(i.notaDebitoME.ToString("N2"))

                'If TabControl1.SelectedTab Is TabPage2 Then

                '    If txtTipoCompra.Text = "Compra Pagada" Then
                '        n.SubItems.Add(cTotalmn.ToString("N2"))
                '        n.SubItems.Add(cTotalme.ToString("N2"))
                '        n.SubItems.Add(0)
                '        n.SubItems.Add(0)
                '        n.SubItems.Add("S")
                '    ElseIf txtTipoCompra.Text = "Compra Al crédito" Then
                '        n.SubItems.Add(i.MontoPagadoSoles.ToString("N2"))
                '        n.SubItems.Add(i.MontoPagadoUSD.ToString("N2"))
                '        n.SubItems.Add(cTotalmn.ToString("N2"))
                '        n.SubItems.Add(cTotalme.ToString("N2"))
                '        n.SubItems.Add(IIf(Mid(cTotalmn, 1, 1) = 0, "S", "N"))
                '    End If

                '     ElseIf TabControl1.SelectedTab Is TabPage1 Then
                If txtTipoCompra.ValueMember = TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION Or txtTipoCompra.ValueMember = TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION Then
                    n.SubItems.Add(cTotalmn.ToString("N2"))
                    n.SubItems.Add(cTotalme.ToString("N2"))
                    n.SubItems.Add(0)
                    n.SubItems.Add(0)
                    n.SubItems.Add("S")
                ElseIf txtTipoCompra.ValueMember = TIPO_COMPRA.COMPRA_AL_CREDITO Or txtTipoCompra.ValueMember = TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION Then
                    With n.SubItems.Add(i.MontoPagadoSoles.ToString("N2"))
                        .ForeColor = Color.DimGray
                        .Font = New Font("Segoe UI", 8, FontStyle.Bold)
                    End With
                    n.SubItems.Add(i.MontoPagadoUSD.ToString("N2"))
                    With n.SubItems.Add(cTotalmn.ToString("N2"))
                        .BackColor = Color.FromArgb(0, 114, 198)
                        .ForeColor = Color.White
                        .Font = New Font("Segoe UI", 8, FontStyle.Bold)
                    End With
                    n.SubItems.Add(cTotalme.ToString("N2"))
                    n.SubItems.Add(IIf(cTotalmn <= 0, "S", "N"))
                End If
                '  End If
                lsvDetalleItems.Items.Add(n)
            Next
            lblPagoMN.Text = saldomn.ToString("N2")
            lblPagoME.Text = saldome.ToString("N2")
            'lblSaldo.Text = saldomn.ToString("N2")
            'lblSaldome.Text = saldome.ToString("N2")
        Catch ex As Exception
            MsgBox("Error al obtener datos.!" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Aviso del Sistema.!")
        End Try
    End Sub

    Public Sub UbicarCompra(IntIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        With documentoCompraSA.UbicarDocumentoCompra(IntIdDocumento)
            txtFechaCompra.ValueMember = .idDocumento
            txtFechaCompra.Text = .fechaDoc
            txtComprobante.ValueMember = .tipoDoc
            txtComprobante.Text = tablaSA.GetUbicarTablaID(10, .tipoDoc).descripcion
            With entidadSA.UbicarEntidadPorID(.idProveedor).First
                txtProveedor.ValueMember = .idEntidad
                txtProveedor.Text = .nombreCompleto
                txtRuc.Text = .nrodoc
                txtCuenta.Text = .cuentaAsiento
            End With

            txtSerie.Text = .serie
            txtNumero.Text = .numeroDoc
            txtTipoCambio.Text = .tcDolLoc
            txtMonedaCompra.ValueMember = .monedaDoc
            Select Case .monedaDoc
                Case 1
                    txtMonedaCompra.Text = "NACIONAL"
                Case Else
                    txtMonedaCompra.Text = "EXTRANJERA"
            End Select
            txtTipoCompra.ValueMember = .tipoCompra
            Select Case .tipoCompra
                Case TIPO_COMPRA.COMPRA_AL_CREDITO
                    txtTipoCompra.Text = "Compra al crédito en tránsito"

                Case TIPO_COMPRA.COMPRA_AL_CREDITO_CON_RECEPCION

                    txtTipoCompra.Text = "Compra al crédito con recepción de existencias"
                Case TIPO_COMPRA.COMPRA_DIRECTA_SIN_RECEPCION
                    txtTipoCompra.Text = "Compra directa sin recepción"

                Case TIPO_COMPRA.COMPRA_DIRECTA_CON_RECEPCION
                    txtTipoCompra.Text = "Compra directa con recepción"
            End Select
            txtEstadoPago.Text = .estadoPago
            txtImporteCompramn.Text = .importeTotal
            txtImporteComprame.Text = .importeUS
            ObtenerPorDetails(txtFechaCompra.ValueMember, lsvCanasta)
            HistorialCompra(txtFechaCompra.ValueMember)
        End With


    End Sub
#End Region



    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            UbicarCompraNroSerie(String.Format("{0:00000}", Convert.ToInt32(txtBuscar.Text)), String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNUmFilter.Text)), txtFiltroProveedor.Text.Trim)
        Catch ex As Exception
            lblEstado.Text = ex.Message & ", verifique que los campos sean correctos!!"
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscar.KeyDown

    End Sub

    Private Sub txtBuscar_LostFocus(sender As Object, e As System.EventArgs) Handles txtBuscar.LostFocus
        Try
            If txtBuscar.Text.Trim.Length > 0 Then
                txtBuscar.Text = String.Format("{0:00000}", Convert.ToInt32(txtBuscar.Text))
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
      
    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged

    End Sub

    Private Sub txtNUmFilter_LostFocus(sender As Object, e As System.EventArgs) Handles txtNUmFilter.LostFocus
        If txtNUmFilter.Text.Trim.Length > 0 Then
            txtNUmFilter.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNUmFilter.Text))
        End If
    End Sub

    Private Sub txtNUmFilter_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNUmFilter.TextChanged

    End Sub

    Private Sub lstCompras_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lstCompras.MouseDoubleClick
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstCompras.SelectedItems.Count > 0 Then
                UbicarCompra(DirectCast(Me.lstCompras.SelectedItem, DocCompra).Id)
                TabControlAdv1.Visible = True
                TabPageAdv1.Parent = TabControlAdv1
                TabPageAdv2.Parent = Nothing
                TabPageAdv3.Parent = Nothing
                TabPageAdv4.Parent = Nothing
                dockingManager1.SetDockVisibility(PanelHistorialPago, True)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            '  Me.txtAlmacen.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs)
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(306, 277)
        Me.pcAlmacen.ParentControl = Me.txtComprobante
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub frmCuentasAPagar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If filter IsNot Nothing Then
        '    filter.SaveCompareOperator()
        'End If
        Dispose()
    End Sub

    Private Sub frmCuentasAPagar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If filter IsNot Nothing Then
            filter.LoadCompareOperator()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(306, 277)
        Me.pcAlmacen.ParentControl = Me.RibbonControlAdv1
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub lstCompras_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstCompras.SelectedIndexChanged

    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.White
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dim datos As List(Of RecolectarDatos) = RecolectarDatos.Instance()
        datos.Clear()
        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        btnNuevoPago("EFECTIVO")
        If datos.Count > 0 Then
            Dim str As String = Nothing
            With documentoCajaDetalleSA.ObtenerHistorialPagosPorIdPago(datos(0).IdAlmacen)
                Me.dgvHistorial.Table.AddNewRecord.SetCurrent()
                Me.dgvHistorial.Table.AddNewRecord.BeginEdit()
                str = CDate(.fechaDoc).ToString("dd-MMM hh:mm tt ")
                Me.dgvHistorial.Table.CurrentRecord.SetValue("documentoAfectado", .documentoAfectado)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("nomDocumento", .nomDocumento)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("numeroDocNormal", .numeroDocNormal)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("idCliente", .idCliente)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("nomEntidad", .nomEntidad)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("fechaDoc", str)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("moneda", .moneda)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("tipoDocumento", .tipoDocumento)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("tipoCambio", .tipoCambioTransacc)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("idDocumento", .idDocumento)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("montoSoles", .montoSoles)
                Me.dgvHistorial.Table.CurrentRecord.SetValue("montoUsd", .montoUsd)
                Me.dgvHistorial.Table.AddNewRecord.EndEdit()
            End With

        End If
      
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = Cursors.WaitCursor
        ObtenerPagosDelDia()
        TabPageAdv2.Parent = TabControlAdv1
        TabPageAdv1.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        dockingManager1.SetDockVisibility(PanelHistorialPago, False)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvPagos_QueryCoveredRange(sender As System.Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableQueryCoveredRangeEventArgs) Handles dgvPagos.QueryCoveredRange
        'Dim thisTable As GridTable = Me.dgvPagos.Table
        'If e.RowIndex < thisTable.DisplayElements.Count Then
        '    Dim el As Element = thisTable.DisplayElements(e.RowIndex)

        '    Select Case el.Kind
        '        Case DisplayElementKind.Caption
        '            If True Then
        '                ' Cover some cells of the caption bar (specified with captionCover)
        '                Dim gs As IGridGroupOptionsSource = TryCast(el.ParentGroup, IGridGroupOptionsSource)
        '                If gs IsNot Nothing AndAlso gs.GroupOptions.ShowCaptionSummaryCells Then
        '                    Dim startCol As Integer = el.GroupLevel + 1
        '                    If Not gs.GroupOptions.ShowCaptionPlusMinus Then
        '                        startCol -= 1
        '                    End If
        '                    If e.ColIndex >= startCol AndAlso e.ColIndex <= startCol + Me.captionCoverCols Then
        '                        e.Range = GridRangeInfo.Cells(e.RowIndex, startCol, e.RowIndex, startCol + Me.captionCoverCols)
        '                        e.Handled = True
        '                    End If
        '                End If
        '                Exit Select

        '            End If
        '    End Select
        'End If
    End Sub

    Private Sub btnConsultaPeriodo_Click(sender As Object, e As EventArgs) Handles btnConsultaPeriodo.Click
        Me.Cursor = Cursors.WaitCursor
        ObtenerPagosPorPeriodo()
        TabPageAdv2.Parent = TabControlAdv1
        TabPageAdv1.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        dockingManager1.SetDockVisibility(PanelHistorialPago, False)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnHistorialPago_Click(sender As Object, e As EventArgs) Handles btnHistorialPago.Click
        If TabControlAdv1.SelectedTab Is TabPageAdv1 Then
            configDockingManger()
        End If
    End Sub

    Private Sub btnEliminarCompra_Click(sender As Object, e As EventArgs) Handles btnEliminarCompra.Click
        Try
            If Not IsNothing(Me.dgvHistorial.Table.CurrentRecord) Then
                EliminarDocumento(CInt(Me.dgvHistorial.Table.CurrentRecord.GetValue("idDocumento")))
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Private Sub btnEditCompra_Click(sender As System.Object, e As System.EventArgs) Handles btnEditCompra.Click
        If Not IsNothing(Me.dgvHistorial.Table.CurrentRecord) Then
            With frmPagos
                .manipulacionEstado = ENTITY_ACTIONS.UPDATE
                'If .TieneCuentaFinanciera(CInt(Me.dgvHistorial.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                '    .txtFechaComprobante.ShowUpDown = True
                '    .UbicarDocumento(CInt(Me.dgvHistorial.Table.CurrentRecord.GetValue("idDocumento")))
                '    .StartPosition = FormStartPosition.CenterParent
                '    .ShowDialog()
                'Else
                '    lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                '    'Timer1.Enabled = True
                '    'TiempoEjecutar(5)
                'End If
            End With
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub dgvHistorial_TableControlCheckBoxClick(sender As Object, e As Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs) Handles dgvHistorial.TableControlCheckBoxClick

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.White
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedorFilter.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedorFilter.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtNumProvFilter.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuentaProvFilter.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
                ListaComprasProveedor()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedorFilter.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dropDownBtn_Click(sender As Object, e As EventArgs) Handles dropDownBtn.Click
        popupControlContainer1.Font = New Font("Segoe UI", 8)
        popupControlContainer1.Size = New Size(334, 150)
        Me.popupControlContainer1.ParentControl = Me.txtProveedorFilter
        Me.popupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click

    End Sub

    Private Sub ToolStripButton1_ButtonClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub PagoEnEfectivoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub OtrasFormasDePagoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        '  0 btnNuevoPago("OTROS")
    End Sub

    Private Sub PagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PagoToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        LoadProveedores()
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv4.Parent = Nothing
        TabPageAdv3.Parent = TabControlAdv1
        If Not IsNothing(dockingManager1.ActiveControl) Then
            dockingManager1.SetDockVisibility(PanelHistorialPago, False)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv10_Click(sender As Object, e As EventArgs) Handles ButtonAdv10.Click
        Me.PopupControlContainer3.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        Me.PopupControlContainer3.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub PopupControlContainer3_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer3.BeforePopup
        Me.PopupControlContainer3.BackColor = Color.White
    End Sub

    Private Sub PopupControlContainer3_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer3.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If ListView1.SelectedItems.Count > 0 Then
                Me.txtProvedorFilter2.Text = ListView1.SelectedItems(0).SubItems(1).Text
                txtProvedorFilter2.ValueMember = ListView1.SelectedItems(0).SubItems(0).Text
                txtNroProv2.Text = ListView1.SelectedItems(0).SubItems(3).Text
                txtCuentaPro2.Text = ListView1.SelectedItems(0).SubItems(2).Text
                ListaChequesPeriodo()

            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProvedorFilter2.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv11_Click(sender As Object, e As EventArgs) Handles ButtonAdv11.Click
        PopupControlContainer3.Font = New Font("Segoe UI", 8)
        PopupControlContainer3.Size = New Size(334, 150)
        Me.PopupControlContainer3.ParentControl = Me.txtProvedorFilter2
        Me.PopupControlContainer3.ShowPopup(Point.Empty)
    End Sub

    Private Sub CheckesUOtrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckesUOtrosToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        LoadProveedores2()
        TabPageAdv1.Parent = Nothing
        TabPageAdv2.Parent = Nothing
        TabPageAdv3.Parent = Nothing
        TabPageAdv4.Parent = TabControlAdv1
        dockingManager1.SetDockVisibility(PanelHistorialPago, False)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCheckes_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCheckes.TableControlCellClick

    End Sub


    Private Sub dgvCheckes_TableControlMouseDown(sender As Object, e As GridTableControlMouseEventArgs) Handles dgvCheckes.TableControlMouseDown
        If True Then
            If e.Inner.Button = System.Windows.Forms.MouseButtons.Right Then

                Me.ContextMenuStripEx1.Show(Control.MousePosition.X, Control.MousePosition.Y)
                '      Dim columnDescriptor As Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor = gridGroupingControl1.TableControl.GetHeaderColumnDescriptorAt(e.Inner.Location)

                'If columnDescriptor IsNot Nothing Then

                'End If
            End If
        End If
    End Sub

    Private Sub ToolStripEx2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStripEx2.ItemClicked

    End Sub

    Private Sub ConciliarChuqueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConciliarChuqueToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim docCaja As New documentoCaja
        Dim entidadSA As New entidadSA
        Dim documentoCajaSA As New DocumentoCajaSA

        Dim datos As List(Of RecuperarTablas) = RecuperarTablas.Instance()
        datos.Clear()
        Try
            If Not IsNothing(Me.dgvCheckes.Table.CurrentRecord) Then
                docCaja.idDocumento = CInt(Me.dgvCheckes.Table.CurrentRecord.GetValue("idDocumento"))
                docCaja.entregado = "SI"
                If documentoCajaSA.VerificarConciliarCheque(docCaja) = True Then
                    With documentoCajaSA.GetUbicar_documentoCajaPorID(Me.dgvCheckes.Table.CurrentRecord.GetValue("idDocumento"))
                        Dim form As New frmConciliarCheque
                        form.lblIdDocumento.Text = CInt(Me.dgvCheckes.Table.CurrentRecord.GetValue("idDocumento"))
                        If form.TieneCuentaFinanciera(CInt(Me.dgvCheckes.Table.CurrentRecord.GetValue("idDocumento"))) = True Then
                            form.txtFechaComprobante.Value = New Date(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                            form.txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
                            form.txtTipoDoc.Text = "CHEQUE"
                            form.txtNumeroDoc.Text = .numeroDoc
                            form.txtMoneda.Text = IIf(.moneda = 1, "NAC", "USD")
                            form.lblIdProveedor = Nothing
                            form.lblNomProveedor = Nothing
                            form.lblCuentaProveedor = Nothing
                            With entidadSA.UbicarEntidadPorID(.codigoProveedor).First
                                form.lblIdProveedor = .idEntidad
                                form.lblNomProveedor = .nombreCompleto
                                form.lblCuentaProveedor = .cuentaAsiento
                            End With
                            form.txtImporteCompramn.Value = .montoSoles
                            form.txtImporteComprame.Value = .montoUsd
                            form.StartPosition = FormStartPosition.CenterParent
                            form.ShowDialog()
                            If Not IsNothing(Me.dgvCheckes.Table.CurrentRecord) Then
                                If datos.Count > 0 Then
                                    Me.dgvCheckes.TableModel(Me.dgvCheckes.Table.CurrentRecord.GetRowIndex, 11).CellValue = datos(0).Codigo ' num operacion
                                    Me.dgvCheckes.TableModel(Me.dgvCheckes.Table.CurrentRecord.GetRowIndex, 10).CellValue = datos(0).NombreCampo 'fecha cobro
                                    Me.dgvCheckes.TableModel(Me.dgvCheckes.Table.CurrentRecord.GetRowIndex, 12).CellValue = "SI"
                                End If
                            End If
                        Else
                            PanelError.Visible = True
                            lblEstado.Text = "Debe indicar una caja activa para realizar esta acción!"
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                        End If
                    End With
                End If


            End If
        Catch ex As Exception
            PanelError.Visible = True
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub QuitarConciliaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitarConciliaciónToolStripMenuItem.Click
        Me.Cursor = Cursors.WaitCursor
        Dim docCaja As New documentoCaja
        Dim documentoCajaSA As New DocumentoCajaSA
        Try
            If Not IsNothing(Me.dgvCheckes.Table.CurrentRecord) Then
                docCaja.idDocumento = CInt(Me.dgvCheckes.Table.CurrentRecord.GetValue("idDocumento"))
                docCaja.entregado = "NO"
                If documentoCajaSA.VerificarConciliarCheque(docCaja) = True Then
                    DeshacerConciliacion(CInt(Me.dgvCheckes.Table.CurrentRecord.GetValue("idDocumento")))
                    If Not IsNothing(Me.dgvCheckes.Table.CurrentRecord) Then
                        Me.dgvCheckes.TableModel(Me.dgvCheckes.Table.CurrentRecord.GetRowIndex, 11).CellValue = String.Empty
                        Me.dgvCheckes.TableModel(Me.dgvCheckes.Table.CurrentRecord.GetRowIndex, 10).CellValue = String.Empty
                        Me.dgvCheckes.TableModel(Me.dgvCheckes.Table.CurrentRecord.GetRowIndex, 12).CellValue = "NO"
                    End If
                End If
            End If
        Catch ex As Exception
            PanelError.Visible = True
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub dgvCheckes_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCheckes.QueryCellStyleInfo
        If e.TableCellIdentity.Column IsNot Nothing AndAlso e.TableCellIdentity.Column.Name = "fechaCobro" Then
            e.Style.CellType = "DateTimeCell"
            e.Style.CellValueType = GetType(DateTime)
            e.Style.Format = "dd/MM/yyyy mm:hh"
        End If
    End Sub
    Dim filter As GridDynamicFilter = New GridDynamicFilter()
    Private Sub chFiltro_CheckStateChanged(sender As Object, e As EventArgs) Handles chFiltro.CheckStateChanged
        If chFiltro.Checked = True Then
            Me.dgvCompra.TopLevelGroupOptions.ShowFilterBar = True
            'Enable the filter for each columns 
            For i As Integer = 0 To dgvCompra.TableDescriptor.Columns.Count - 1
                dgvCompra.TableDescriptor.Columns(i).AllowFilter = True
            Next
        Else
            Me.dgvCompra.TopLevelGroupOptions.ShowFilterBar = False
        End If
        '  dgvCompra.TopLevelGroupOptions.ShowFilterBar = chFiltro.Checked
    End Sub

    'Private Sub chFiltroDinamico_CheckStateChanged(sender As Object, e As EventArgs) Handles chFiltroDinamico.CheckStateChanged
    '    If chFiltroDinamico.Checked Then
    '        Me.dgvCompra.TableModel.EnableLegacyStyle = False
    '        filter.WireGrid(dgvCompra)
    '        Me.DropShadow = True

    '    Else
    '        filter.UnWireGrid(dgvCompra)
    '    End If
    'End Sub

    Private Sub chFiltroDinamico_CheckStateChanged(sender As Object, e As EventArgs) Handles chFiltroDinamico.CheckStateChanged
        If chFiltroDinamico.Checked Then
            filter.WireGrid(dgvCompra)
        Else
            filter.UnWireGrid(dgvCompra)
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lsvProveedor_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvProveedor.SelectedIndexChanged

    End Sub
End Class