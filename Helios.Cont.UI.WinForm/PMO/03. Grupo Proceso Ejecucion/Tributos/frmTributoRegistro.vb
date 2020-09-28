Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class frmTributoRegistro
    Inherits frmMaster

    Public Property fecha As DateTime

    Public Property ManipulacionEstado() As String

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True
        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
     
        'INICIO PERIODO
        '   lblPerido.Text = PeriodoGeneral 'String.Format("{0:00}", Convert.ToInt32(cfecha.Month)) & "/" & PeriodoGeneral
        txtFechaComprobante.Select()
        dockingManager1.CloseEnabled = False
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

#Region "Métodos"
    

    Public Sub UbicarDOcumentoTirbuto(IntIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoObligacionTributariaSA
        Dim f As New documentoObligacionTributaria
        Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA

        f = documentoCompraSA.UbicarDocumentoObligacion(IntIdDocumento)

        'With documentoCompraSA.UbicarDocumentoObligacion(IntIdDocumento)
        lblIdDocumentoTributo.Text = f.idDocumento
        txtPeriodo.Text = f.periodo
        lblIdDocumento.Text = f.idDocumentoOrigen
        fecha = f.fechaDoc
        txtFechaComprobante.Value = f.fechaDoc
        Select Case f.tipoDoc
            Case "9904"
                cboTributo.Text = "DETRACCION"
            Case "9905"
                cboTributo.Text = "RETENCION"
            Case "9906"
                cboTributo.Text = "PERCEPCION"
        End Select
        txtSerie.Text = f.serieDoc
        txtNumero.Text = f.numeroDoc
        nudPorcentajeTributo.Value = CDec(f.porcTributario)
        nudImporteMN.Value = f.importeTotal
        nudImporteME.Value = f.importeUS
        UbicarCompra(f.idDocumentoOrigen)
        '     End With
    End Sub

    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim Celda As DataGridViewCell = Me.dgvDocumentoAfectos.CurrentCell()

        If Celda.ColumnIndex = 9 Then
            If e.KeyChar = "."c Or e.KeyChar = ","c Then

                If InStr(Celda.EditedFormattedValue.ToString, ".", CompareMethod.Text) > 0 Then

                    e.Handled = True
                Else

                    e.Handled = False
                End If
            Else

                If Len(Trim(Celda.EditedFormattedValue.ToString)) > 0 Then

                    If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                        e.Handled = False
                    Else

                        e.Handled = True
                    End If
                Else

                    If e.KeyChar = "0"c Then

                        e.Handled = True
                    Else

                        If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                            e.Handled = False
                        Else

                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub ConteoPercepcion()
        Dim SumaPorcentaje As Decimal = 0
        Dim sumTotalesMN As Decimal = 0
        Dim sumTotalesME As Decimal = 0
        Try
            For Each i As DataGridViewRow In dgvDocumentoAfectos.Rows
                SumaPorcentaje += CDec(i.Cells(9).Value)
                sumTotalesMN += CDec(i.Cells(10).Value)
                sumTotalesME += CDec(i.Cells(11).Value)
            Next
            nudPorcentajeTributo.Value = SumaPorcentaje.ToString("N2")
            nudImporteMN.Value = sumTotalesMN.ToString("N2")
            nudImporteME.Value = sumTotalesME.ToString("N2")
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try
    End Sub

    Sub CALCULO_TRIBUTOS_DGV(valProcentaje As Decimal)
        Dim valPorcentajeVariable As Decimal = 0
        Dim colImporteMN As Decimal = 0
        Dim colImporteME As Decimal = 0

        valPorcentajeVariable = valProcentaje / 100
        dgvDocumentoAfectos.Item(9, dgvDocumentoAfectos.CurrentRow.Index).Value = valProcentaje.ToString("N2")


        colImporteMN = CDec(dgvDocumentoAfectos.Item(7, dgvDocumentoAfectos.CurrentRow.Index).Value)
        colImporteME = CDec(dgvDocumentoAfectos.Item(8, dgvDocumentoAfectos.CurrentRow.Index).Value)

        If valPorcentajeVariable > 0 Then
            If CDec(txtImportemnCompra.Text) > 0 Then
                dgvDocumentoAfectos.Item(10, dgvDocumentoAfectos.CurrentRow.Index).Value = Math.Round(colImporteMN * valPorcentajeVariable, 2).ToString("N2")
                dgvDocumentoAfectos.Item(11, dgvDocumentoAfectos.CurrentRow.Index).Value = Math.Round(colImporteME * valPorcentajeVariable).ToString("N2")
            End If
        Else
            dgvDocumentoAfectos.Item(10, dgvDocumentoAfectos.CurrentRow.Index).Value = 0
            dgvDocumentoAfectos.Item(11, dgvDocumentoAfectos.CurrentRow.Index).Value = 0
        End If

    End Sub

    Sub CALCULO_TRIBUTOS()
        Dim valPorcentaje As Decimal = 0
        valPorcentaje = nudPorcentajeTributo.Value / 100

        If valPorcentaje > 0 Then
            If txtImportemnCompra.Text.Trim.Length > 0 Then
                If CDec(txtImportemnCompra.Text) > 0 Then
                    nudImporteMN.Value = Math.Round(CDec(txtImportemnCompra.Text) * valPorcentaje, 2)
                    nudImporteME.Value = Math.Round(CDec(txtImportemeCompra.Text) * valPorcentaje, 2)
                End If
            End If
        Else
            nudImporteMN.Value = 0
            nudImporteME.Value = 0
        End If

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

    Public Sub UbicarCompra(IntIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        With documentoCompraSA.UbicarDocumentoCompra(IntIdDocumento)
            lblIdDocumento.Text = .idDocumento
            txtFecha.Text = .fechaDoc
            txtFecha.ValueMember = .idDocumento
            txtCOmprobante.ValueMember = .tipoDoc
            txtCOmprobante.Text = tablaSA.GetUbicarTablaID(10, .tipoDoc).descripcion
            txtProveedor.ValueMember = .idProveedor
            txtProveedor.Text = entidadSA.UbicarEntidadPorID(.idProveedor).First.nombreCompleto
            txtSerieCompra.Text = .serie
            txtNumeroCompra.Text = .numeroDoc
            txtTipoCambio.Text = .tcDolLoc
            txtMoneda.ValueMember = .monedaDoc
            Select Case .monedaDoc
                Case 1
                    txtMoneda.Text = "NACIONAL"
                Case Else
                    txtMoneda.Text = "EXTRANJERA"
            End Select
            txtImportemnCompra.Text = .importeTotal
            txtImportemeCompra.Text = .importeUS
        End With


    End Sub
#End Region

#Region "Manipulación Data"
    Function GLOSA() As String
        Return "Por tributos con comprobante de " & cboTributo.Text & ", número: " & txtNumero.Text & "-" & _
            txtSerie.Text & " con Fecha:" & fecha
    End Function

    Function DocumentoObligacionTributo() As documento
        Dim documento As New documento
        Dim documentoObligacion As New documentoObligacionTributaria
        Dim documentoDetalle As New List(Of documentoObligacionDetalle)
        Dim objdocumentoDetalle As New documentoObligacionDetalle
        Dim docTributoSA As New DocumentoObligacionTributariaSA

        With documento
            .idDocumento = lblIdDocumentoTributo.Text
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            Select Case cboTributo.Text
                Case "DETRACCION"
                    .tipoDoc = "9904"
                Case "RETENCION"
                    .tipoDoc = "9905"
                Case "PERCEPCION"
                    .tipoDoc = "9906"
            End Select
            .fechaProceso = fecha
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With documentoObligacion
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .codigoLibro = "8"
            .fechaDoc = fecha
            .periodo = txtPeriodo.Text
            Select Case cboTributo.Text
                Case "DETRACCION"
                    .tipoTributo = "D"
                    .tipoDoc = "9904"
                Case "RETENCION"
                    .tipoTributo = "R"
                    .tipoDoc = "9905"
                Case "PERCEPCION"
                    .tipoTributo = "P"
                    .tipoDoc = "9906"
            End Select
            .idEntidad = txtProveedor.ValueMember
            .tipoOperacion = "02"
            .idEntidadFinanciera = Nothing
            .tipoDesposito = Nothing
            .serieDoc = txtSerie.Text
            .numeroDoc = txtNumero.Text
            .moneda = txtMoneda.ValueMember
            .porcTributario = nudPorcentajeTributo.Value
            .tipoCambio = txtTipoCambio.Text
            .importeTotal = nudImporteMN.Value
            .importeUS = nudImporteME.Value
            .glosa = GLOSA()
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        documento.documentoObligacionTributaria = documentoObligacion


        Select Case cboTributo.Text
            Case "DETRACCION", "RETENCION"
                objdocumentoDetalle = New documentoObligacionDetalle
                objdocumentoDetalle.idItem = Nothing
                objdocumentoDetalle.idDocumentoOrigen = lblIdDocumento.Text
                objdocumentoDetalle.descripcionItem = GLOSA()
                objdocumentoDetalle.destino = "0"
                objdocumentoDetalle.unidadMedida = Nothing
                objdocumentoDetalle.cantidad = Nothing
                objdocumentoDetalle.precioUnitario = Nothing
                objdocumentoDetalle.precioUnitarioUS = Nothing
                objdocumentoDetalle.porcTributo = nudPorcentajeTributo.Value
                objdocumentoDetalle.importeMN = nudImporteMN.Value
                objdocumentoDetalle.importeME = nudImporteME.Value
                objdocumentoDetalle.usuarioActualizacion = "Jiuni"
                objdocumentoDetalle.fechaActualizacion = DateTime.Now
                documentoDetalle.Add(objdocumentoDetalle)

                documento.documentoObligacionTributaria.documentoObligacionDetalle = documentoDetalle
            Case "PERCEPCION"
                Dim ItemSA As New detalleitemsSA
                For Each i As DataGridViewRow In dgvDocumentoAfectos.Rows
                    objdocumentoDetalle = New documentoObligacionDetalle
                    With ItemSA.InvocarProductoID(i.Cells(4).Value)
                        objdocumentoDetalle.idItem = i.Cells(4).Value
                        objdocumentoDetalle.idDocumentoOrigen = i.Cells(0).Value
                        objdocumentoDetalle.descripcionItem = .descripcionItem
                        objdocumentoDetalle.destino = .origenProducto
                        objdocumentoDetalle.unidadMedida = .unidad1
                        objdocumentoDetalle.cantidad = 0
                        objdocumentoDetalle.precioUnitario = 0
                        objdocumentoDetalle.precioUnitarioUS = 0
                        objdocumentoDetalle.porcTributo = i.Cells(9).Value
                        objdocumentoDetalle.importeMN = CDec(i.Cells(10).Value)
                        objdocumentoDetalle.importeME = CDec(i.Cells(11).Value)
                        objdocumentoDetalle.usuarioActualizacion = "Jiuni"
                        objdocumentoDetalle.fechaActualizacion = DateTime.Now
                        documentoDetalle.Add(objdocumentoDetalle)
                    End With
                Next
                documento.documentoObligacionTributaria.documentoObligacionDetalle = documentoDetalle
        End Select

        Return documento
    End Function

    Private Sub AgregaDocumentoACanstaDGV(intIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim tablaSA As New tablaDetalleSA
        Dim documentoCompra As New documentocompra
        documentoCompra = documentoCompraSA.UbicarDocumentoCompra(intIdDocumento)
        With documentoCompra
            dgvDocumentoAfectos.Rows.Add(.idDocumento, tablaSA.GetUbicarTablaID(10, .tipoDoc).descripcion, .serie, .numeroDoc,
                                         Nothing, "Elegir Item", Nothing, .importeTotal, .importeUS, 0, 0, 0)
        End With
    End Sub

    Public Sub GrabarDocumento()
        Dim documento As New documento
        Dim documentoTributoSA As New DocumentoObligacionTributariaSA
        documento = DocumentoObligacionTributo()
        documentoTributoSA.SaveObligacion(documento, lblIdDocumento.Text)
        lblEstado.Text = "Registro Grabado"
        Dispose()
    End Sub

    Public Sub UpdateDocumento()
        Dim documento As New documento
        Dim documentoTributoSA As New DocumentoObligacionTributariaSA
        documento = DocumentoObligacionTributo()
        documentoTributoSA.UpdateTributo(documento, lblIdDocumento.Text)
        lblEstado.Text = "Registro modificado"
        Dispose()
    End Sub
#End Region

    Private Sub frmTributoRegistro_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmTributoRegistro_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtPeriodo.Select()
    End Sub

    Private Sub ButtonAdv1_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        UbicarCompraNroSerie(String.Format("{0:00000}", Convert.ToInt32(txtBuscar.Text)), String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNUmFilter.Text)), txtFiltroProveedor.Text.Trim)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtBuscar_LostFocus(sender As Object, e As System.EventArgs) Handles txtBuscar.LostFocus
        If txtBuscar.Text.Trim.Length > 0 Then
            txtBuscar.Text = String.Format("{0:00000}", Convert.ToInt32(txtBuscar.Text))
        End If
    End Sub

    Private Sub txtNUmFilter_LostFocus(sender As Object, e As System.EventArgs) Handles txtNUmFilter.LostFocus
        If txtNUmFilter.Text.Trim.Length > 0 Then
            txtNUmFilter.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNUmFilter.Text))
        End If
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.White
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstCompras.SelectedItems.Count > 0 Then
                UbicarCompra(DirectCast(Me.lstCompras.SelectedItem, DocCompra).Id)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            '  Me.txtAlmacen.Focus()
        End If
    End Sub

    Private Sub dropDownBtn_Click(sender As System.Object, e As System.EventArgs) Handles dropDownBtn.Click
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(306, 277)
        Me.pcAlmacen.ParentControl = Me.txtCOmprobante
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub cboTributo_Click(sender As System.Object, e As System.EventArgs) Handles cboTributo.Click

    End Sub

    Private Sub cboTributo_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTributo.SelectedIndexChanged
        Select Case cboTributo.Text
            Case "DETRACCION", "RETENCION"
                nudPorcentajeTributo.Enabled = True
                nudImporteMN.ReadOnly = False
                nudImporteME.ReadOnly = False
                dropDownBtn.Enabled = False
            Case "PERCEPCION"
                nudPorcentajeTributo.Enabled = False
                nudImporteMN.ReadOnly = True
                nudImporteME.ReadOnly = True
                dropDownBtn.Enabled = True
                btnAddCanasta.Visible = True
                dockingManager1.DockControl(PanelPerecpcion, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Bottom, 153)
                dockingManager1.SetDockLabel(PanelPerecpcion, "Documentos de compra relacionados")
        End Select
    End Sub

    Private Sub nudPorcentajeTributo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles nudPorcentajeTributo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            CALCULO_TRIBUTOS()
        End If
    End Sub

    Private Sub nudPorcentajeTributo_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudPorcentajeTributo.ValueChanged
        CALCULO_TRIBUTOS()
    End Sub

    Private Sub ToolStrip3_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip3.ItemClicked

    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            cmMenu.Enabled = True
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            cmMenu.Enabled = False
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        If Not txtSerie.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe indicar el número de serie del comprobante"
            Exit Sub
        End If

        If Not txtNumero.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe indicar el número del comprobante"
            Exit Sub
        End If

        If Not nudPorcentajeTributo.Value > 0 Then
            lblEstado.Text = "Debe indicar el porcentaje del comprobante"
            Exit Sub
        End If

        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            GrabarDocumento()
        ElseIf ManipulacionEstado = ENTITY_ACTIONS.UPDATE Then
            UpdateDocumento()
        End If
    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged

    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtNumero.Select()
        End If
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerie.LostFocus
        If txtSerie.Text.Trim.Length > 0 Then
            txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
        End If
    End Sub

    Private Sub txtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtNUmFilter_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNUmFilter.TextChanged

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumero.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtSerie.Select()
        End If
    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumero.LostFocus
        If txtNumero.Text.Trim.Length > 0 Then
            txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))
        End If
    End Sub

    Private Sub txtNumero_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumero.TextChanged

    End Sub

    Private Sub lstCompras_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstCompras.MouseDoubleClick
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lstCompras_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstCompras.SelectedIndexChanged

    End Sub

    Private Sub dgvDocumentoAfectos_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocumentoAfectos.CellClick
        Dim tablaSA As New tablaDetalleSA
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 5 Then
                If cboTributo.Text.Trim.Length > 0 Then
                    Dim objInsumo As GInsumo = GInsumo.InstanceSingle()
                    objInsumo.Clear()
                    With frmCanastaCompraDetalle
                        .UbicarDetalle(dgvDocumentoAfectos.Item(0, dgvDocumentoAfectos.CurrentRow.Index).Value)
                        .StartPosition = FormStartPosition.CenterParent
                        .ShowDialog()
                        If Not IsNothing(objInsumo.descripcionItem) Then

                            dgvDocumentoAfectos.Item(4, dgvDocumentoAfectos.CurrentRow.Index).Value = objInsumo.IdInsumo
                            dgvDocumentoAfectos.Item(5, dgvDocumentoAfectos.CurrentRow.Index).Value = objInsumo.descripcionItem
                            dgvDocumentoAfectos.Item(6, dgvDocumentoAfectos.CurrentRow.Index).Value = tablaSA.GetUbicarTablaID(6, objInsumo.unidad1).descripcion
                            dgvDocumentoAfectos.Item(7, dgvDocumentoAfectos.CurrentRow.Index).Value = objInsumo.Total
                            dgvDocumentoAfectos.Item(8, dgvDocumentoAfectos.CurrentRow.Index).Value = objInsumo.TotalUS
                            dgvDocumentoAfectos.Item(9, dgvDocumentoAfectos.CurrentRow.Index).Value = 0
                            dgvDocumentoAfectos.Item(10, dgvDocumentoAfectos.CurrentRow.Index).Value = 0
                            dgvDocumentoAfectos.Item(11, dgvDocumentoAfectos.CurrentRow.Index).Value = 0

                        End If
                        'If dgvNuevoDoc.Rows.Count > 0 Then
                        '    CellEndEditRefresh()
                        'End If
                    End With
                End If
            End If
        End If
    End Sub

    Private Sub dgvDocumentoAfectos_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocumentoAfectos.CellContentClick

    End Sub

    Private Sub dgvDocumentoAfectos_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocumentoAfectos.CellEndEdit
        If e.ColumnIndex = 9 Then
            If Not CStr(dgvDocumentoAfectos.Item(9, dgvDocumentoAfectos.CurrentRow.Index).Value).Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un porcentaje válido!"
                lblEstado.Image = My.Resources.warning2

                Exit Sub
            Else
                CALCULO_TRIBUTOS_DGV(CDec(dgvDocumentoAfectos.Rows(e.RowIndex).Cells(9).Value))
                ConteoPercepcion()
            End If
        End If
    End Sub

    Private Sub dgvDocumentoAfectos_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDocumentoAfectos.CellMouseClick
        If dgvDocumentoAfectos.Rows.Count > 0 Then
            If e.Button <> MouseButtons.Right Then
                Return
            End If

            If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then
                Return
            End If

            'enviamos el valor de la celda a la variable _cellValue
            '   _cellValue = dgvNuevoDoc(e.ColumnIndex, e.RowIndex).Value.ToString()

            'Definimos el lugar donde aparecera el scontextMenuStrip
            cmMenu.Show(MousePosition)
        End If
    End Sub

    Private Sub dgvDocumentoAfectos_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvDocumentoAfectos.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub

    Private Sub btnAddCanasta_Click(sender As System.Object, e As System.EventArgs) Handles btnAddCanasta.Click
        If txtCOmprobante.Text.Trim.Length > 0 Then
            AgregaDocumentoACanstaDGV(CInt(lblIdDocumento.Text))
        End If
    End Sub

    Private Sub EliminarFilaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EliminarFilaToolStripMenuItem.Click
        If dgvDocumentoAfectos.Rows.Count > 0 Then
            dgvDocumentoAfectos.Rows.RemoveAt(dgvDocumentoAfectos.CurrentRow.Index)
        End If
    End Sub

    Private Sub txtPeriodo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPeriodo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            txtSerie.Select()
        End If

    End Sub

    Private Sub txtPeriodo_TextChanged(sender As Object, e As EventArgs) Handles txtPeriodo.TextChanged

    End Sub
End Class