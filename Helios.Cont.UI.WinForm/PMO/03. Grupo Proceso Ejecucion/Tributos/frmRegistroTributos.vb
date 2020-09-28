Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Public Class frmRegistroTributos


    Public Property ManipulacionEstado() As String
    Public fecha As DateTime
#Region "Métodos"



    Sub ListaSeriesCompraProveedor(intIdProveedor As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoCompra As New List(Of documentocompra)
        documentoCompra = documentoCompraSA.UbicarCompraPorProveedor(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intIdProveedor)
        cboSerie.DisplayMember = "tipoDoc"
        cboSerie.ValueMember = "serie"
        cboSerie.DataSource = documentoCompra
    End Sub

    Sub ListaSeriesCompraProveedorNumero(intIdProveedor As Integer, strSerie As String)
        Dim documentoCompraSA As New DocumentoCompraSA

        cboNumero.DisplayMember = "numeroDoc"
        cboNumero.ValueMember = "idDocumento"
        cboNumero.DataSource = documentoCompraSA.UbicarCompraPorProveedorSerie(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, intIdProveedor, strSerie)

    End Sub

    Public Sub BuscarEntidades()
        ' Dim objService = HeliosSEProxy.CrearProxyHELIOS()
        Dim entidadSA As New entidadSA
        Dim objLista As New List(Of entidad)
        Try
            objLista = entidadSA.ListarEntidadesPorRuc(TIPO_ENTIDAD.PROVEEDOR, Gempresas.IdEmpresaRuc, "")
            CboProveedores.DisplayMember = "nombreCompleto"
            CboProveedores.ValueMember = "idEntidad"
            CboProveedores.DataSource = objLista
        Catch ex As Exception
            MsgBox("No se pudo cargar la información requerida.!" & vbCrLf & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Function GLOSA() As String
        Return "Por tributos con comprobante de " & cboOT.Text & ", número: " & txtNumeroTri.Text & "-" & _
            txtSerieTri.Text & " con Fecha:" & fecha
    End Function
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
            Select Case cboOT.Text
                Case "DETRACCION"
                    .tipoDoc = "9904"
                Case "RETENCION"
                    .tipoDoc = "9905"
                Case "PERCEPCION"
                    .tipoDoc = "9906"
            End Select
            .fechaProceso = fecha
            .nroDoc = txtSerieTri.Text.Trim & "-" & txtNumeroTri.Text.Trim
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
            .periodo = lblPeriodo.Text
            Select Case cboOT.Text
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
            .serieDoc = txtSerieTri.Text
            .numeroDoc = txtNumeroTri.Text
            .moneda = txtMoneda.ValueMember
            .porcTributario = nudPorcentajeTributo.Value
            .tipoCambio = nudTipoCambio.Value
            .importeTotal = nudImporteMN.Value
            .importeUS = nudImporteME.Value
            .glosa = GLOSA()
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        documento.documentoObligacionTributaria = documentoObligacion


        Select Case cboOT.Text
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
                objdocumentoDetalle.porcTributo = Nothing
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

    Public Sub UbicarCompra(IntIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        With documentoCompraSA.UbicarDocumentoCompra(IntIdDocumento)
            lblIdDocumento.Text = .idDocumento
            txtFechaCompra.Value = .fechaDoc
            txtComprobanteCompra.ValueMember = .tipoDoc
            txtComprobanteCompra.Text = tablaSA.GetUbicarTablaID(10, .tipoDoc).descripcion
            txtProveedor.ValueMember = .idProveedor
            txtProveedor.Text = entidadSA.UbicarEntidadPorID(.idProveedor).First.nombreCompleto
            txtSerieCompra.Text = .serie
            txtNumeroCompra.Text = .numeroDoc
            nudTipoCambio.Value = .tcDolLoc
            txtMoneda.ValueMember = .monedaDoc
            Select Case .monedaDoc
                Case 1
                    txtMoneda.Text = "NACIONAL"
                Case Else
                    txtMoneda.Text = "EXTRANJERA"
            End Select

            txtImportemnO.Value = .importeTotal
            txtImportemeO.Value = .importeUS
        End With


    End Sub

    Public Sub UbicarDOcumentoTirbuto(IntIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoObligacionTributariaSA
        Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        With documentoCompraSA.UbicarDocumentoObligacion(IntIdDocumento)
            lblIdDocumentoTributo.Text = .idDocumento
            lblPeriodo.Text = .periodo
            lblIdDocumento.Text = .idDocumentoOrigen
            fecha = .fechaDoc
            txtFechaTributo.Value = .fechaDoc
            Select Case .tipoDoc
                Case "9904"
                    cboOT.Text = "DETRACCION"
                Case "9905"
                    cboOT.Text = "RETENCION"
                Case "9906"
                    cboOT.Text = "PERCEPCION"
            End Select
            txtSerieTri.Text = .serieDoc
            txtNumeroTri.Text = .numeroDoc
            nudPorcentajeTributo.Value = .porcTributario
            nudImporteMN.Value = .importeTotal
            nudImporteME.Value = .importeUS
            UbicarCompra(.idDocumentoOrigen)
        End With
    End Sub
#End Region

    Private Sub frmRegistroTributos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmRegistroTributos_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmRegistroTributos_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        KryptonHeaderGroup1.Text = "Información del tributo"
        KryptonHeaderGroup1.ValuesPrimary.Image = My.Resources.info2
        KryptonHeaderGroup2.Text = "Información de la compra"
        KryptonHeaderGroup2.ValuesPrimary.Image = My.Resources.info2
    End Sub

    Private Sub txtSerieTri_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerieTri.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumeroTri.Select()
        End If
    End Sub

    Private Sub txtSerieTri_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerieTri.LostFocus
        Try
            Select Case "99"
                Case "01", "02", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99", "00"
                    If Not txtSerieTri.Text = "" Or Not String.IsNullOrEmpty(txtSerieTri.Text) Then
                        If IsNumeric(txtSerieTri.Text) Then
                            txtSerieTri.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieTri.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerieTri.Clear()
                            txtSerieTri.Focus()
                            txtSerieTri.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtSerieTri.Text = "" Or Not String.IsNullOrEmpty(txtSerieTri.Text) Then
                        If IsNumeric(txtSerieTri.Text) Then
                            '        txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                        Else
                            MessageBox.Show("Serie inválida", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtSerieTri.Clear()
                            txtSerieTri.Focus()
                            txtSerieTri.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"

                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select
        Catch ex As Exception
            MsgBox("Formato Incorrecto " + vbCrLf + ex.Message)
        End Try
    End Sub

    Private Sub txtSerieTri_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerieTri.TextChanged

    End Sub

    Private Sub txtNumeroTri_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroTri.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            nudPorcentajeTributo.Select()
            nudPorcentajeTributo.Select(0, nudPorcentajeTributo.Text.Length)
        End If
    End Sub

    Private Sub txtNumeroTri_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumeroTri.LostFocus
        Try
            Select Case "99"
                Case "01", "02", "03", "04", "07", "08", "23", "34", "35", "37", "55", "99", "00"
                    If Not txtNumeroTri.Text = "" Or Not String.IsNullOrEmpty(txtNumeroTri.Text) Then
                        If IsNumeric(txtNumeroTri.Text) Then
                            If txtNumeroTri.Text.Length = 20 Then

                            Else
                                txtNumeroTri.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroTri.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumeroTri.Clear()
                            txtNumeroTri.Focus()
                            txtNumeroTri.SelectAll()
                        End If
                    End If
                Case "05", "06", "11", "13", "15", "16", "17", "18", "21", "22", "24", "25", "26", "27", "28",
                    "29", "30", "32"

                    If Not txtNumeroTri.Text = "" Or Not String.IsNullOrEmpty(txtNumeroTri.Text) Then
                        If IsNumeric(txtNumeroTri.Text) Then
                            If txtNumeroTri.Text.Length = 20 Then

                            Else
                                '     txtNumeroDoc.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroDoc.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumeroTri.Clear()
                            txtNumeroTri.Focus()
                            txtNumeroTri.SelectAll()
                        End If
                    End If
                    ' SOLO NUMEROS
                Case "10"
                    If Not txtNumeroTri.Text = "" Or Not String.IsNullOrEmpty(txtNumeroTri.Text) Then
                        If IsNumeric(txtNumeroTri.Text) Then
                            If txtNumeroTri.Text.Length = 20 Then

                            Else
                                '     txtNumeroDoc.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroDoc.Text))
                            End If
                        Else
                            MessageBox.Show("Número inválido", "Ingresa otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtNumeroTri.Clear()
                            txtNumeroTri.Focus()
                            txtNumeroTri.SelectAll()
                        End If
                    End If
                Case "12", "14", "36", "87", "88" ' maquina registradora
                    ' SOLO NUMEROS Y FALANUMERICOS

            End Select
        Catch ex As Exception
            MsgBox("Formato Incorrecto..!" + vbCrLf + ex.Message)
            txtNumeroTri.Clear()
        End Try
    End Sub

    Private Sub txtNumeroTri_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroTri.TextChanged

    End Sub

    Private Sub txtFechaTributo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFechaTributo.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtFechaTributo.Value = New DateTime(fecha.Year, fecha.Month, txtFechaTributo.Value.Day, txtFechaTributo.Value.Hour, txtFechaTributo.Value.Minute, txtFechaTributo.Value.Second)
            cboOT.Select()
            cboOT.DroppedDown = True
        End If
    End Sub

    Private Sub txtFechaTributo_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtFechaTributo.ValueChanged
        txtFechaTributo.Value = New DateTime(fecha.Year, fecha.Month, txtFechaTributo.Value.Day, txtFechaTributo.Value.Hour, txtFechaTributo.Value.Minute, txtFechaTributo.Value.Second)
    End Sub

    Private Sub cboOT_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboOT.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtSerieTri.Select()
        End If
    End Sub
    Sub CALCULO_TRIBUTOS()
        Dim valPorcentaje As Decimal = 0
        valPorcentaje = nudPorcentajeTributo.Value / 100

        If valPorcentaje > 0 Then
            If CDec(txtImportemnO.Text) > 0 Then
                nudImporteMN.Value = CDec(txtImportemnO.Text) * valPorcentaje
                nudImporteME.Value = CDec(txtImportemeO.Text) * valPorcentaje
            End If
        Else
            nudImporteMN.Value = 0
            nudImporteME.Value = 0
        End If

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
            If CDec(txtImportemnO.Text) > 0 Then
                dgvDocumentoAfectos.Item(10, dgvDocumentoAfectos.CurrentRow.Index).Value = Math.Round(colImporteMN * valPorcentajeVariable, 2).ToString("N2")
                dgvDocumentoAfectos.Item(11, dgvDocumentoAfectos.CurrentRow.Index).Value = Math.Round(colImporteME * valPorcentajeVariable).ToString("N2")
            End If
        Else
            dgvDocumentoAfectos.Item(10, dgvDocumentoAfectos.CurrentRow.Index).Value = 0
            dgvDocumentoAfectos.Item(11, dgvDocumentoAfectos.CurrentRow.Index).Value = 0
        End If

    End Sub

    Private Sub cboOT_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboOT.SelectedIndexChanged
        Select Case cboOT.Text
            Case "DETRACCION", "RETENCION"
                nudPorcentajeTributo.Enabled = True
                nudImporteMN.ReadOnly = False
                nudImporteME.ReadOnly = False
                EXPDetalle.Visible = False
                KryptonHeaderGroup2.Visible = True
            Case "PERCEPCION"
                nudPorcentajeTributo.Enabled = False
                nudImporteMN.ReadOnly = True
                nudImporteME.ReadOnly = True
                EXPDetalle.Visible = True
                KryptonHeaderGroup2.Visible = False
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

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaTributo.Value.Year, txtFechaTributo.Value.Month, txtFechaTributo.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaTributo.Value.Day, txtFechaTributo.Value.Hour, txtFechaTributo.Value.Minute, txtFechaTributo.Value.Second)
        End If
    End Sub

    Private Sub QRibbonApplicationButton1_ItemActivating(sender As System.Object, e As Qios.DevSuite.Components.QCompositeCancelEventArgs) Handles QRibbonApplicationButton1.ItemActivating
        If Not txtSerieTri.Text.Trim.Length > 0 Then
            lblEstado.Text = "Debe indicar el número de serie del comprobante"
            Exit Sub
        End If

        If Not txtNumeroTri.Text.Trim.Length > 0 Then
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

    Private Sub cboFiltro_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboFiltro.SelectedIndexChanged
        Select Case cboFiltro.Text
            Case "POR PROVEEDOR"
                BuscarEntidades()
        End Select
    End Sub

    Private Sub CboProveedores_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CboProveedores.KeyDown

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            ListaSeriesCompraProveedor(CboProveedores.SelectedValue)

        End If

    End Sub

    Private Sub CboProveedores_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboProveedores.SelectedIndexChanged
        ListaSeriesCompraProveedor(CboProveedores.SelectedValue)
    End Sub

    Private Sub cboSerie_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboSerie.SelectedIndexChanged
        ListaSeriesCompraProveedorNumero(CboProveedores.SelectedValue, cboSerie.SelectedValue)
    End Sub

    Private Sub cboNumero_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboNumero.SelectedIndexChanged

    End Sub
    Private Sub AgregaDocumento(intIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim tablaSA As New tablaDetalleSA
        Dim documentoCompra As New documentocompra
        documentoCompra = documentoCompraSA.UbicarDocumentoCompra(intIdDocumento)
        With documentoCompra
            dgvDocumentoAfectos.Rows.Add(.idDocumento, tablaSA.GetUbicarTablaID(10, .tipoDoc).descripcion, .serie, .numeroDoc,
                                         Nothing, "Elegir Item", Nothing, .importeTotal, .importeUS, 0, 0, 0)
        End With
    End Sub
    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        AgregaDocumento(cboNumero.SelectedValue)
        cboSerie.SelectedIndex = -1
        cboNumero.DataSource = Nothing
    End Sub

    Private Sub dgvDocumentoAfectos_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocumentoAfectos.CellClick
        Dim tablaSA As New tablaDetalleSA
        If e.RowIndex > -1 Then
            If e.ColumnIndex = 5 Then
                If cboOT.Text.Trim.Length > 0 Then
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

    Private Sub kcmMenu_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub cmMenu_ItemClicked(sender As Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles cmMenu.ItemClicked
        Me.Cursor = Cursors.WaitCursor
        Select Case e.ClickedItem.Text
            Case "Eliminar fila"

                Dim row As DataGridViewRow = dgvDocumentoAfectos.CurrentRow
                dgvDocumentoAfectos.Rows.RemoveAt(row.Index)

        End Select
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub EliminarFilaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EliminarFilaToolStripMenuItem.Click

    End Sub
End Class