Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Public Class FrmSoliCompra
    Inherits frmMaster

    Sub ControlsHide()
       
    End Sub


#Region "Manipulación Data"

    Private Sub UbicarDocumentos(intIdDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoDetalleSA As New DocumentoCompraDetalleSA
        Dim entidadSA As New PersonaSA
        Dim tablaDetalleSA As New tablaDetalleSA
        With documentoCompraSA.UbicarDocumentoCompra(intIdDocumento)
            With entidadSA.ObtenerPersonaNumDoc(Gempresas.IdEmpresaRuc, .idPersona)
                txtProveedor.Text = .nombreCompleto
                txtProveedor.ValueMember = .idPersona
                txtRuc.Text = .idPersona
            End With
            lblTotalAdquisiones.Text = .importeTotal
            lblTotalUS.Text = .importeUS
            If (.monedaDoc = "1") Then
                cboMoneda.DisplayMember = "NACIONAL"
                cboMoneda.SelectedValue = CInt(1)
            ElseIf (.monedaDoc = "2") Then
                cboMoneda.DisplayMember = "EXTRANJERA"
                cboMoneda.SelectedValue = CInt(2)
            End If
            With tablaDetalleSA.GetUbicarTablaID("10", .tipoDoc)
                cboTipoDoc.DisplayMember = .descripcion
                cboTipoDoc.SelectedValue = .codigoDetalle
            End With
            txtFechaComprobante.Value = .fechaDoc
            txtTipoCambio.Value = .tcDolLoc
        End With
        dgvCompra.Rows.Clear()
        For Each i In documentoDetalleSA.UbicarDocumentoCompraDetalle(intIdDocumento)
            dgvCompra.Rows.Add(i.secuencia, "1", "1", i.descripcionItem, "1", "1", i.unidad1, i.monto1, i.precioUnitario, i.precioUnitarioUS, i.importe, i.importeUS,
                                   "1", "1", "1", "1", "1", "1", "1", "1", Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia, "1")
        Next
    End Sub

    Public Sub ObtenerListaControlesLoad()
        Dim personaSA As New PersonaSA
        Dim tablaSA As New tablaDetalleSA
        Dim categoriaSA As New itemSA
        lsvProveedor.Items.Clear()
        For Each i As Persona In personaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .tipoPersona = "T"}).ToList
            Dim n As New ListViewItem(i.idPersona)
            n.SubItems.Add(i.nombreCompleto)
            lsvProveedor.Items.Add(n)
        Next
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0

        'COMPROBANTE TIPO DOCUMENTOS
        cboTipoDoc.DisplayMember = "descripcion"
        cboTipoDoc.ValueMember = "codigoDetalle"
        cboTipoDoc.DataSource = tablaSA.GetListaTablaDetalle(10, "1")
        'TIPO DE EXISTENCIA
        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")
        'UNIDAD DE MEDIDA
        CboUM.ValueMember = "codigoDetalle"
        CboUM.DisplayMember = "descripcion"
        CboUM.DataSource = tablaSA.GetListaTablaDetalle(6, "1")
    End Sub

    Sub UpdateDoc()
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompra
        For i = 0 To dgvCompra.Rows.Count - 1
            nRecurso = New documentocompra With {
            .Action = Business.Entity.BaseBE.EntityAction.UPDATE,
            .idDocumento = CInt(lblIdDocumento.Text),
            .fechaDoc = txtFechaComprobante.Value,
            .tipoDoc = cboTipoDoc.SelectedValue,
            .idProveedor = txtProveedor.ValueMember,
            .monedaDoc = cboMoneda.SelectedValue,
            .importeTotal = lblTotalAdquisiones.Text,
            .tcDolLoc = CDec(txtTipoCambio.Value),
            .importeUS = lblTotalUS.Text}
            If (nRecursoSA.UpdateDoc(nRecurso)) Then
                lblEstado.Text = " editado!"
                lblEstado.Image = My.Resources.ok4
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If
        Next
    End Sub

    Sub UpdateCompra()
        Dim nRecursoSA As New DocumentoCompraSA
        Dim nRecurso As New documentocompradetalle
        For i = 0 To dgvCompra.Rows.Count - 1
            Dim a As Integer
            If dgvCompra.Item(20, i).Value = Business.Entity.BaseBE.EntityAction.UPDATE Then
                a = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvCompra.Item(20, i).Value = Business.Entity.BaseBE.EntityAction.INSERT Then
                a = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvCompra.Item(20, i).Value = Business.Entity.BaseBE.EntityAction.DELETE Then
                a = Business.Entity.BaseBE.EntityAction.DELETE
            End If
            nRecurso = New documentocompradetalle With {
            .usuarioModificacion = "jiuni",
            .fechaModificacion = DateTime.Now,
            .Action = a,
            .descripcionItem = dgvCompra.Item(3, i).Value.ToString,
            .idDocumento = CInt(lblIdDocumento.Text),
            .secuencia = dgvCompra.Item(0, i).Value.ToString,
            .unidad1 = dgvCompra.Item(6, i).Value.ToString,
            .monto1 = dgvCompra.Item(7, i).Value.ToString,
            .precioUnitario = dgvCompra.Item(8, i).Value.ToString,
            .precioUnitarioUS = dgvCompra.Item(9, i).Value.ToString,
            .importe = dgvCompra.Item(10, i).Value.ToString,
            .importeUS = dgvCompra.Item(11, i).Value.ToString,
            .tipoExistencia = dgvCompra.Item(21, i).Value.ToString}
            If dgvCompra.Item(7, i).Value.ToString = 0 Then
                lblEstado.Text = "debe ingresar cantidades mayor a cero"
                Exit Sub
            End If
            If (nRecursoSA.UpdateOrdenCompra(nRecurso, "tipo")) Then
                lblEstado.Text = " editado!"
                lblEstado.Image = My.Resources.ok4
                UpdateDoc()
            Else
                lblEstado.Text = "Error al grabar Cadena!"
                lblEstado.Image = My.Resources.cross
            End If

        Next
    End Sub



    Sub GrabarSolicitud()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim g As New ListViewGroup
        Dim ListaDetalle As New List(Of documentocompradetalle)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .tipoDoc = cboTipoDoc.SelectedValue
            .fechaProceso = txtFechaComprobante.Value
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "02"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With
        With nDocumentoCompra
            .codigoLibro = "1"
            .tipoDoc = "00"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFechaComprobante.Value
            .idProveedor = txtProveedor.ValueMember
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tcDolLoc = txtTipoCambio.Value
            .monedaDoc = cboMoneda.SelectedValue
            .tipoDoc = cboTipoDoc.SelectedValue
            .fechaContable = lblPerido.Text
            .nroRegimen = Nothing
            .importeTotal = lblTotalAdquisiones.Text
            .importeUS = lblTotalUS.Text
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            .referenciaDestino = Nothing
            .tipoCompra = TIPO_COMPRA.SOLICITUD_ESPERA
            .estadoPago = "P"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        Dim S As Integer = 0
        For Each i As DataGridViewRow In dgvCompra.Rows
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.descripcionItem = i.Cells(3).Value()
            objDocumentoCompraDet.tipoExistencia = i.Cells(21).Value()
            objDocumentoCompraDet.unidad1 = i.Cells(6).Value()
            If CDec(CDec(i.Cells(7).Value())) > 0 Then
                objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value())
            Else
                lblEstado.Text = "ingrese una cantidad mayor a cero"
                Exit Sub
            End If
            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(9).Value())
            objDocumentoCompraDet.importeUS = CDec(i.Cells(11).Value())
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing
            ListaDetalle.Add(objDocumentoCompraDet)
        Next
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        CompraSA.SaveDocumentoCompraSolicitud(ndocumento)
    End Sub


#End Region

#Region "Variables DetalleCompra"
    Public Property nudBase4 As Decimal = 0
    Public Property nudBase1 As Decimal = 0
    Public Property nudBase2 As Decimal = 0
    Public Property nudBase3 As Decimal = 0

    Public Property nudMontoIgv1 As Decimal = 0
    Public Property nudMontoIgv2 As Decimal = 0
    Public Property nudMontoIgv3 As Decimal = 0

    Public Property nudBaseus4 As Decimal = 0
    Public Property nudBaseus1 As Decimal = 0
    Public Property nudBaseus2 As Decimal = 0
    Public Property nudBaseus3 As Decimal = 0

    Public Property nudMontoIgvus1 As Decimal = 0
    Public Property nudMontoIgvus2 As Decimal = 0
    Public Property nudMontoIgvus3 As Decimal = 0

    Public Property nudIsc1 As Decimal = 0
    Public Property nudIsc2 As Decimal = 0
    Public Property nudIsc3 As Decimal = 0
    Public Property nudIscus1 As Decimal = 0
    Public Property nudIscus2 As Decimal = 0
    Public Property nudIscus3 As Decimal = 0

    Public Property nudOtrosTributosus1 As Decimal = 0
    Public Property nudOtrosTributosus2 As Decimal = 0
    Public Property nudOtrosTributosus3 As Decimal = 0
    Public Property nudOtrosTributosus4 As Decimal = 0

    Public Property nudOtrosTributos1 As Decimal = 0
    Public Property nudOtrosTributos2 As Decimal = 0
    Public Property nudOtrosTributos3 As Decimal = 0
    Public Property nudOtrosTributos4 As Decimal = 0

    Public Property txtIdComprobanteCaja As Integer
    Public Property txtComprobanteCaja As String
    Public Property txtNumCaja As String
    Public Property txtIdEstablecimientoCaja As Integer
    Public Property txtEstablecimientoCaja As String
    Public Property txtIdCaja As Integer
    Public Property txtCaja As String
    Public Property txtCuentaEF As String

    '   Public Property GlosaCompra As String = Nothing
#End Region

    Public Property Flag() As String
    Dim UserControl1 As New ucConfiguracion
    Dim toolTip As Popup
    Public ManipulacionEstado As String
    Private CheckBoxClicked As Boolean = False
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public fecha As DateTime

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        SelecIDEstable = Nothing
        SelecNombreEstable = Nothing
        SelectIdAlmacen = Nothing
        SelectNombreAlmacen = Nothing
        IdAlmacenBack = Nothing

        GConfiguracion = New GConfiguracionModulo
        ObtenerListaControlesLoad()
        CargarCMBGastos()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName

        Me.dockingManager1.DockControl(Me.Panel2, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)

        dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
       
        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True

        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D

        dockingManager1.SetDockLabel(Panel2, "Existencias")
        lblPerido.Text = PeriodoGeneral
        ControlsHide()
        txtFechaComprobante.Select()
    End Sub


#Region "CESTO SERVICIOS"
    Public Sub CargarGastoCuentaPAdreLIke()
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Try
            'lsvServicios.Columns.Clear()
            'lsvServicios.Items.Clear()
            'lsvServicios.Columns.Add("Cuenta", 75)
            'lsvServicios.Columns.Add("Descripcion", 318)
            '  lsvServicios.Columns.Add("Cuenta Padre", 0)
            For Each i As cuentaplanContableEmpresa In cuentaSA.ListarCuentasPorPadre(Gempresas.IdEmpresaRuc, "18")
                Dim n As New ListViewItem(i.cuenta)
                n.SubItems.Add(i.descripcion)
                'lsvServicios.Items.Add(n)
            Next
        Catch ex As Exception
            lblEstado.Text = "Error al obtener Cuentas." & vbCrLf & ex.Message
        End Try
    End Sub

    'Public Sub CargarListaGasto()
    '    Dim cuentaSA As New mascaraGastosEmpresaSA
    '    Try

    '        '  lsvServicios.Columns.Add("Cuenta Padre", 0)
    '        For Each i As mascaraGastosEmpresa In cuentaSA.ObtenerMascaraGastos(Gempresas.IdEmpresaRuc, txtServicio.Text)
    '            Dim n As New ListViewItem(i.cuentaCompra)
    '            n.SubItems.Add(i.descripcionCompra)
    '            lsvServicios.Items.Add(n)
    '        Next
    '    Catch ex As Exception
    '        lblEstado.Text = ("Error al cargar datos. " & vbCrLf & ex.Message)
    '    End Try
    'End Sub

    Public Sub CargarCMBGastos()
        Dim planContableSA As New cuentaplanContableEmpresaSA
        Try
            cboCuentas.DataSource = Nothing
            cboCuentas.DisplayMember = "descripcion"
            cboCuentas.ValueMember = "cuenta"
            cboCuentas.DataSource = planContableSA.LoadCuentasGastos(Gempresas.IdEmpresaRuc)
        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

    End Sub
#End Region

#Region "Métodos DGV"
    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim Celda As DataGridViewCell = Me.dgvCompra.CurrentCell()

        If Celda.ColumnIndex = 7 Or Celda.ColumnIndex = 8 Then

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

    Public Sub Bonificacion()
        '    Dim i As Integer
        Dim base1 As Decimal = 0
        Dim base2 As Decimal = 0
        Dim base3 As Decimal = 0
        Dim base4 As Decimal = 0
        Dim baseus1 As Decimal = 0
        Dim baseus2 As Decimal = 0
        Dim baseus3 As Decimal = 0
        Dim baseus4 As Decimal = 0
        Dim otc1 As Decimal = 0
        Dim otc2 As Decimal = 0
        Dim otc3 As Decimal = 0
        Dim otc4 As Decimal = 0
        Dim otc1US As Decimal = 0
        Dim otc2US As Decimal = 0
        Dim otc3US As Decimal = 0
        Dim otc4US As Decimal = 0
        Dim total As Decimal = 0
        Dim totalbase2 As Decimal = 0
        Dim totalbase3 As Decimal = 0
        Dim totalbase4 As Decimal = 0
        Dim igv As Decimal = 0
        Dim IGVUS As Decimal = 0
        Dim tus1 As Decimal = 0
        Dim tus2 As Decimal = 0
        Dim tus3 As Decimal = 0
        Dim tus4 As Decimal = 0


        'COLUMNAS
        Dim colCantidad As Decimal = 0
        Dim colPU As Decimal = 0
        Dim colPU_ME As Decimal = 0
        Dim colMN As Decimal = 0
        Dim colME As Decimal = 0


        For Each i As DataGridViewRow In dgvCompra.Rows
            colCantidad = i.Cells(7).Value
            colMN = i.Cells(10).Value
            colME = Math.Round(CDec(i.Cells(10).Value) / CDec(txtTipoCambio.Value), 2)
            colPU = Math.Round(CDec(i.Cells(10).Value) / colCantidad, 2)
            colPU_ME = Math.Round(colME / colCantidad, 2)
            '  If Not dgvCompra.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
            If colCantidad > 0 Then

                If i.Cells(27).Value = "S" Then





                    totalbase4 += CDec(i.Cells(10).Value())
                    tus4 += CDec(i.Cells(11).Value()) ' total base 01
                    If cboMoneda.SelectedValue = 1 Then
                        ' DATOS SOLES

                        Select Case i.Cells(1).Value
                            Case "4"
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2") ' PRECIO UNITARIO SOLES
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(11).Value = colME ' Math.Round(CDec(i.Cells(10).Value / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES
                                i.Cells(10).Value = colMN

                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                            Case Else
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2") ' PRECIO UNITARIO SOLES
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(10).Value = colMN
                                i.Cells(11).Value = colME ' Math.Round(CDec(i.Cells(10).Value / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES


                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                        End Select

                    Else 'If 'txtMoneda.Text = "2" Then
                        ' DATOS DOLARES

                        Select Case i.Cells(1).Value
                            Case "4"
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2")  ' PRECIO UNITARIO DOLARES
                                i.Cells(10).Value = colMN ' Math.Round(CDec(i.Cells(11).Value * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                i.Cells(11).Value = colME

                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                            Case Else
                                i.Cells(8).Value = colPU ' Math.Round(CDec(i.Cells(10).Value / i.Cells(7).Value), 2).ToString("N2")
                                i.Cells(9).Value = colPU_ME ' Math.Round(CDec(i.Cells(11).Value / i.Cells(7).Value), 2).ToString("N2") ' PRECIO UNITARIO DOLARES
                                i.Cells(10).Value = colMN ' Math.Round(CDec(i.Cells(11).Value * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                i.Cells(11).Value = colME

                                i.Cells(12).Value = "0.00"
                                i.Cells(13).Value = "0.00"
                                i.Cells(14).Value = "0.00"
                                i.Cells(15).Value = "0.00"
                                i.Cells(16).Value = "0.00"
                                i.Cells(17).Value = "0.00"
                                i.Cells(18).Value = "0.00"
                                i.Cells(19).Value = "0.00"
                        End Select
                    End If
                Else

                End If
            End If
        Next


        Dim NUDVALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)

        '*********************** SOLES ***********************************************
        '****************IMPUESTO 4*******************
        base4 = totalbase4
        nudBase4 = Math.Round(base4, NumDigitos)
        nudBase1 = 0
        nudBase2 = 0
        nudBase3 = 0

        nudMontoIgv1 = 0
        nudMontoIgv2 = 0
        nudMontoIgv3 = 0

        nudBaseus4 = Math.Round(tus4, NumDigitos)
        nudBaseus1 = 0
        nudBaseus2 = 0
        nudBaseus3 = 0

        nudMontoIgvus1 = 0
        nudMontoIgvus2 = 0
        nudMontoIgvus3 = 0
        '***********IMPORTE GRAVADO******************
        'subTotales("All")

        '  totales()
        totales_xx()
        TotalesCabeceras()

    End Sub

    Private Sub MyMethodOnCheckBoxes()
        'DO WHAT EVER WHEN THE SELECTED CHECKBOX IS CHECKED
        If CheckBoxClicked Then
            'DO WHAT DO YOU WANT TO, WHEN CHECKBOX IS NOT CHECKED!!
            '  MsgBox(True)
            Bonificacion()
            dgvCompra.Item(29, dgvCompra.CurrentRow.Index).Value = "S"

        ElseIf Not CheckBoxClicked Then

            CellEndEditRefresh()
            dgvCompra.Item(29, dgvCompra.CurrentRow.Index).Value = "N"

        End If
    End Sub

    Public Sub TotalesCabeceras()

    End Sub

    Public Sub totales_xx()
        
        Dim i As Integer
        Dim total, totalbase2 As Decimal ' igv, IGVUS As Decimal ' totalp As Decimal , totalbase3, totalbase4,
        Dim tus1, tus2 As Decimal 'tus3, tus4 
        Dim totalIgv1 As Decimal = 0
        Dim totalIgv1_ME As Decimal = 0
        Dim totalIgv2 As Decimal = 0
        Dim totalIgv2_ME As Decimal = 0
        Dim totalIgv3 As Decimal = 0
        Dim totalIgv3_ME As Decimal = 0
        Dim totalIgv4 As Decimal = 0
        Dim totalIgv4_ME As Decimal = 0



        Dim totalBI3 As Decimal = 0
        Dim totalBI3_ME As Decimal = 0
        Dim totalBI4 As Decimal = 0
        Dim totalBI4_ME As Decimal = 0


        Dim NUDVALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
        For i = 0 To dgvCompra.Rows.Count - 1
            If dgvCompra.Rows(i).Cells(20).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                'total += carrito.Rows(i)(5)
                If Not dgvCompra.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
                    If dgvCompra.Rows(i).Cells(1).Value() = "1" Then

                        total += dgvCompra.Rows(i).Cells(12).Value() ' total base 01 soles
                        tus1 += dgvCompra.Rows(i).Cells(16).Value() ' total base 01 dolares
                        totalIgv1 += dgvCompra.Rows(i).Cells(14).Value()
                        totalIgv1_ME += dgvCompra.Rows(i).Cells(18).Value()

                    ElseIf dgvCompra.Rows(i).Cells(1).Value() = "2" Then

                        totalbase2 += dgvCompra.Rows(i).Cells(12).Value()
                        tus2 += dgvCompra.Rows(i).Cells(16).Value() ' total base 01
                        totalIgv2 += dgvCompra.Rows(i).Cells(14).Value()
                        totalIgv2_ME += dgvCompra.Rows(i).Cells(18).Value()

                    ElseIf dgvCompra.Rows(i).Cells(1).Value() = "3" Then
                        totalBI3 += dgvCompra.Rows(i).Cells(12).Value()
                        totalBI3_ME += dgvCompra.Rows(i).Cells(16).Value() ' total base 01
                        totalIgv3 += dgvCompra.Rows(i).Cells(14).Value()
                        totalIgv3_ME += dgvCompra.Rows(i).Cells(18).Value()

                    ElseIf dgvCompra.Rows(i).Cells(1).Value() = "4" Then
                        totalBI4 += dgvCompra.Rows(i).Cells(12).Value()
                        totalBI4_ME += dgvCompra.Rows(i).Cells(16).Value() ' total base 01
                        totalIgv4 += dgvCompra.Rows(i).Cells(14).Value()
                        totalIgv4_ME += dgvCompra.Rows(i).Cells(18).Value()
                    End If
                End If
            End If

        Next
        nudBase1 = total.ToString("N2")
        nudBaseus1 = tus1.ToString("N2")
        nudBase2 = totalbase2.ToString("N2")
        nudBaseus2 = tus2.ToString("N2")

        nudBase3 = totalBI3.ToString("N2")
        nudBaseus3 = totalBI3_ME.ToString("N2")
        nudBase4 = totalBI4.ToString("N2")
        nudBaseus4 = totalBI4_ME.ToString("N2")

        nudMontoIgv1 = totalIgv1.ToString("N2")
        nudMontoIgvus1 = totalIgv1_ME.ToString("N2")
        nudMontoIgv2 = totalIgv2.ToString("N2")
        nudMontoIgvus2 = totalIgv2_ME.ToString("N2")

        nudMontoIgv3 = totalIgv3.ToString("N2")
        nudMontoIgvus3 = totalIgv3_ME.ToString("N2")
        nudMontoIgv3 = totalIgv3.ToString("N2")
        nudMontoIgvus3 = totalIgv3_ME.ToString("N2")

    End Sub

    Private Sub CellEndEditRefresh()
        '**************************************************************

        If dgvCompra.Rows.Count > 0 Then
            'DECLARANDO VARIABLES

            For Each i As DataGridViewRow In dgvCompra.Rows
                If i.Cells(20).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                    Dim colDestinoGravado As String = 0
                    colDestinoGravado = i.Cells(1).Value

                    Dim colCantidad As Decimal = CDec(i.Cells(7).Value)


                    Dim colBI As Decimal = 0
                    Dim colBI_ME As Decimal = 0
                    Dim colIGV_ME As Decimal = 0
                    Dim colIGV As Decimal = 0
                    Dim colMN As Decimal = i.Cells(10).Value
                    Dim colME As Decimal = Math.Round(CDec(i.Cells(10).Value) / CDec(txtTipoCambio.Value), 2)
                    Dim colPrecUnit As Decimal = 0
                    Dim colPrecUnitUSD As Decimal = 0


                    If colMN > 0 Then

                        colPrecUnit = Math.Round(colMN / colCantidad, 2)

                        colPrecUnitUSD = Math.Round(colME / colCantidad, 2)

                        colBI = Math.Round(colMN / 1.18, 2)
                        colBI_ME = Math.Round(colME / 1.18, 2)
                        colIGV = Math.Round((colMN / 1.18) * 0.18, 2)
                        colIGV_ME = Math.Round((colME / 1.18) * 0.18, 2)


                    Else
                        colPrecUnit = 0

                        colPrecUnitUSD = 0

                        colBI = 0
                        colBI_ME = 0
                        colIGV = 0
                        colIGV_ME = 0
                    End If
                    Select Case cboTipoDoc.SelectedValue   ' cboTipoDoc.SelectedValue
                        Case "08"
                            
                        Case "03", "02"
                            '   If dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoSolessc" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "Can1" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoUsdsc" Then 'Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvDetalleCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                            If txtTipoCambio.Value = 0.0 Then
                                MsgBox("Ingrese Tipo de Cambio..!")
                                txtTipoCambio.Focus()
                                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                                Exit Sub
                            End If
                            Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                            If colCantidad = 0 And colMN = 0 And colME = 0 Then
                                i.Cells(8).Value() = "0.00"
                                i.Cells(9).Value() = "0.00"
                                Exit Sub
                            Else 'If colCantidad = 0 Then

                                If cboMoneda.SelectedValue = 1 Then
                                    ' DATOS SOLES
                                    Select Case colDestinoGravado
                                        Case "4"
                                            i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2")  ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value() = colMN
                                            i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)

                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                        Case Else
                                            i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value = colMN
                                            i.Cells(9).Value = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                    End Select

                                ElseIf cboMoneda.SelectedValue = 2 Then
                                    ' DATOS DOLARES
                                    Select Case colDestinoGravado
                                        Case "4"
                                            i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                            i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                            i.Cells(10).Value() = colMN
                                            i.Cells(11).Value() = colME
                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                        Case Else
                                            i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                    End Select

                                    '      End If
                                ElseIf colCantidad > 0 Then
                                    If cboMoneda.SelectedValue = 1 Then
                                        ' DATOS SOLES
                                        If i.Cells(1).Value = "4" Then
                                            i.Cells(7).Value() = colCantidad
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / colCantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / colCantidad), NumDigitos).ToString("N2")
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value() = colMN 'CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")

                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                        Else
                                            i.Cells(7).Value() = colCantidad 'CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                            i.Cells(12).Value() = "0.00"
                                            i.Cells(13).Value() = "0.00"
                                            i.Cells(14).Value() = "0.00"
                                            i.Cells(15).Value() = "0.00"
                                            i.Cells(16).Value() = "0.00"
                                            i.Cells(17).Value() = "0.00"
                                            i.Cells(18).Value() = "0.00"
                                            i.Cells(19).Value() = "0.00"
                                        End If

                                    ElseIf cboMoneda.SelectedValue = 2 Then

                                        Select Case colDestinoGravado
                                            Case "4"
                                                ' DATOS DOLARES

                                                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                                i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                                i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                                i.Cells(12).Value() = "0.00"
                                                i.Cells(13).Value() = "0.00"
                                                i.Cells(14).Value() = "0.00"
                                                i.Cells(15).Value() = "0.00"
                                                i.Cells(16).Value() = "0.00"
                                                i.Cells(17).Value() = "0.00"
                                                i.Cells(18).Value() = "0.00"
                                                i.Cells(19).Value() = "0.00"
                                            Case Else
                                                ' DATOS DOLARES
                                                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                                i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                                i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")


                                                i.Cells(12).Value() = "0.00"
                                                i.Cells(13).Value() = "0.00"
                                                i.Cells(14).Value() = "0.00"
                                                i.Cells(15).Value() = "0.00"
                                                i.Cells(16).Value() = "0.00"
                                                i.Cells(17).Value() = "0.00"
                                                i.Cells(18).Value() = "0.00"
                                                i.Cells(19).Value() = "0.00"
                                        End Select

                                    End If
                                End If

                                totales_xx()
                                TotalesCabeceras()

                            End If

                            '**********************************************************************************************************************************************************************************
                        Case Else
                            '       If dgvDetalleCompra.Columns(e.ColumnIndex).Name = "montoSolessc" Then
                            If txtTipoCambio.Value = 0.0 Then
                                MsgBox("Ingrese Tipo de Cambio..!")
                                txtTipoCambio.Focus()
                                txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                                Exit Sub
                            End If

                            Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                            If colCantidad = 0 And colMN = 0 And colME = 0 Then
                                i.Cells(8).Value() = "0.00"
                                i.Cells(9).Value() = "0.00"
                                Exit Sub

                            ElseIf colCantidad = 0 Then

                                If cboMoneda.SelectedValue = 1 Then
                                    ' DATOS SOLES
                                    Select Case colDestinoGravado
                                        Case "4"
                                            i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

                                        Case Else

                                            
                                            i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                            i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(12).Value() = colBI ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            i.Cells(14).Value() = colIGV  ' Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                            i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                            i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                            
                                    End Select

                                ElseIf cboMoneda.SelectedValue = 2 Then
                                    ' DATOS DOLARES
                                    Select Case colDestinoGravado
                                        Case "4"
                                            i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                            i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(11).Value() = colME

                                           
                                        Case Else

                                           
                                            i.Cells(8).Value() = "0.00"
                                            i.Cells(9).Value() = "0.00"
                                            i.Cells(10).Value() = colMN
                                            i.Cells(11).Value() = colME

                                            i.Cells(12).Value() = colBI ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            i.Cells(14).Value() = colIGV ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                            i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                          
                                    End Select

                                End If
                            ElseIf colCantidad > 0 Then
                                If cboMoneda.SelectedValue = 1 Then
                                    ' DATOS SOLES
                                    If colDestinoGravado = "4" Then
                                        i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                        i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                        i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                        
                                    Else
                                        If i.Cells(27).Value() = "S" Then
                                            i.Cells(7).Value() = colCantidad '  CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                            i.Cells(12).Value() = "0.00" ' monto para el kardex
                                            i.Cells(14).Value() = "0.00" ' monto igv del item

                                            i.Cells(16).Value() = "0.00" ' monto para el kardex USD
                                            i.Cells(18).Value() = "0.00" ' monto para el IGV USD


                                            i.Cells(19).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                        Else
                                            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                            i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                            i.Cells(12).Value() = colBI ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                            i.Cells(14).Value() = colIGV ' Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                            i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                            i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                            '        i.Cells(19).Value() = Math.Round(CDec(i.Cells(15).Value() / nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES

                                        End If

                                    End If

                                ElseIf cboMoneda.SelectedValue = 2 Then

                                    Select Case colDestinoGravado
                                        Case "4"
                                            ' DATOS DOLARES
                                            i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                            i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                            i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                            i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                            i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                            '  dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                            '  dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' igv del item

                                            ' dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                            ' dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

                                            ' dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
                                        Case Else
                                            ' DATOS DOLARES
                                            If i.Cells(27).Value() = "S" Then
                                                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                                i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                                i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                                i.Cells(12).Value() = "0.00" ' monto para el kardex
                                                i.Cells(14).Value() = "0.00" ' igv del item

                                                i.Cells(16).Value() = "0.00" ' monto para el kardex
                                                i.Cells(18).Value() = "0.00" ' monto para el IGV

                                                i.Cells(15).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                            Else
                                                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                                i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                                i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                                i.Cells(12).Value() = colBI ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                                i.Cells(14).Value() = colIGV ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                                i.Cells(16).Value() = colBI_ME ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                                i.Cells(18).Value() = colIGV_ME ' Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                                '        i.Cells(15).Value() = Math.Round(CDec(i.Cells(19).Value() * nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                            End If

                                    End Select

                                End If
                            End If
                            totales_xx()
                            TotalesCabeceras()


                    End Select
                End If

            Next
        End If

    End Sub


#End Region

#Region "Manipulación Data"

    Enum Sys
        Inicio
        Proceso
    End Enum

#End Region


    Private Sub frmCompraCreditoSinRecepcion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmCompraCreditoSinRecepcion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblPerido.Text = PeriodoGeneral
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        toolTip = New Popup(UserControl1)
        toolTip.AutoClose = False
        toolTip.FocusOnOpen = False
        toolTip.ShowingAnimation = PopupAnimations.Blend
        cboTipoDoc.SelectedIndex = 0
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            cboMoneda.SelectedValue = 1
        ElseIf IsNothing(ManipulacionEstado) Then
            cboMoneda.SelectedValue = 1
            ManipulacionEstado = ENTITY_ACTIONS.INSERT
            txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        Else
            If DocumentoCompraSA.TieneItemsEnAV(CInt(lblIdDocumento.Text)) = True Then
            Else
            End If

        End If

        If lblIdDocumento.Text > 0 Then
            UbicarDocumentos(lblIdDocumento.Text)
        End If
    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub


    Private Sub btnVer_Click(sender As System.Object, e As System.EventArgs) Handles btnVer.Click
        dockingManager1.SetDockVisibility(Panel2, True)

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        If dgvCompra.Rows.Count > 0 Then

            If Not IsNothing(dgvCompra.CurrentRow) Then

                If dgvCompra.Item(20, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
                    dgvCompra.Rows.RemoveAt(dgvCompra.CurrentCell.RowIndex)
                ElseIf dgvCompra.Item(20, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then
                    dgvCompra.Item(20, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
                    Dim pos As Integer = Me.dgvCompra.CurrentRow.Index

                    dgvCompra.CurrentCell = Nothing
                    Me.dgvCompra.Rows(pos).Visible = False
                End If
                If dgvCompra.Rows.Count > 0 Then
                    For Each i As DataGridViewRow In dgvCompra.Rows
                        If i.Cells(10).Visible = True Then
                            Dim a As Decimal
                            Dim g As Decimal
                            a += Math.Round(CDec(i.Cells(10).Value), 2)
                            lblTotalAdquisiones.Text = a.ToString("N2")
                            g += Math.Round(CDec(i.Cells(11).Value), 2)
                            lblTotalUS.Text = g.ToString("N2")
                        End If

                    Next
                End If
            End If
        End If
    End Sub

    Private Sub nudPorcentajeTributo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dropDownBtn_Click_1(sender As System.Object, e As System.EventArgs) Handles dropDownBtn.Click
        Me.popupControlContainer1.ParentControl = Me.txtProveedor
        Me.popupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(0).Text

            End If
        End If
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub OK_Click(sender As System.Object, e As System.EventArgs) Handles OK.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub cancel_Click(sender As System.Object, e As System.EventArgs) Handles cancel.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoCambio.ValueChanged
        If dgvCompra.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            cboMoneda.Select()
        End If
    End Sub

    Private Sub cboMoneda_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cboMoneda.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            dropDownBtn.Focus()
        End If
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtTipoCambio.Select()
        End If
    End Sub

    Private Sub dgvCompra_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvCompra.CellFormatting
        If e.RowIndex > -1 Then
            If e.ColumnIndex = Me.dgvCompra.Columns("Gravado").Index _
AndAlso (e.Value IsNot Nothing) Then
                With Me.dgvCompra.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    If e.Value.Equals("1") Then
                        .ToolTipText = "1: ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES"
                    ElseIf e.Value.Equals("2") Then
                        .ToolTipText = "2: ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV"
                    ElseIf e.Value.Equals("3") Then
                        .ToolTipText = "3: ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS"
                    ElseIf e.Value.Equals("4") Then
                        .ToolTipText = "4: ADQUISICIONES NO GRAVADAS"
                    End If

                End With

            End If
        End If
    End Sub

    Private Sub dgvCompra_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompra.CellValueChanged
        If dgvCompra.Rows.Count > 0 Then
            Dim b As Decimal
            Dim c As Decimal
            Dim d As Decimal
            Dim h As Decimal
            Dim f As Decimal
            Dim g As Decimal
            b = Math.Round(((dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value) * CDec(dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value)), 2)
            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = b.ToString("N2")
            c = Math.Round(CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value), 2)
            dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = c.ToString("N2")
            d = Math.Round(CDec(dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value), 2)
            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = d.ToString("N2")
            h = Math.Round(((dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value) * CDec(txtTipoCambio.Value)), 2)
            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = h.ToString("N2")
            f = Math.Round(((dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value) * CDec(dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value)), 2)
            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = f.ToString("N2")
            For Each i As DataGridViewRow In dgvCompra.Rows
                Dim a As Decimal
                a += Math.Round(CDec(i.Cells(10).Value), 2)
                lblTotalAdquisiones.Text = a.ToString("N2")
                g += Math.Round(CDec(i.Cells(11).Value), 2)
                lblTotalUS.Text = g.ToString("N2")
            Next


        End If
    End Sub

    Private Sub dgvCompra_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvCompra.CurrentCellDirtyStateChanged
        Try
            If dgvCompra.IsCurrentCellDirty Then
                dgvCompra.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If

            If TypeOf dgvCompra.CurrentCell Is DataGridViewCheckBoxCell Then
                dgvCompra.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        Catch
        End Try
    End Sub

    Private Sub dgvCompra_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvCompra.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub

    Private Sub dgvCompra_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvCompra.KeyDown
        Dim conteo As Integer = dgvCompra.Rows.Count
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case (dgvCompra.CurrentCell.ColumnIndex)
                    Case 7
                        If cboMoneda.SelectedValue = 1 Then
                            If conteo = 1 Then
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(10, Me.dgvCompra.CurrentCell.RowIndex)
                            Else
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(10, Me.dgvCompra.CurrentCell.RowIndex)
                            End If
                        Else
                            If conteo = 1 Then
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(11, Me.dgvCompra.CurrentCell.RowIndex)
                            Else
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(11, Me.dgvCompra.CurrentCell.RowIndex)
                            End If
                        End If
                    Case 3
                        Me.dgvCompra.CurrentCell = Me.dgvCompra(0, Me.dgvCompra.CurrentCell.RowIndex)
                    Case 10 Or 11
                        Me.dgvCompra.CurrentCell = Me.dgvCompra(23, Me.dgvCompra.CurrentCell.RowIndex)
                End Select
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvCompra_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvCompra.RowPostPaint
        Dim grid As DataGridView = TryCast(sender, DataGridView)

        If Not grid.RowHeadersVisible Then
            Return
        End If

        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        While strRowNumber.Length < grid.RowCount.ToString().Length
            strRowNumber = Convert.ToString("0") & strRowNumber
        End While

        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, grid.Font)
        If grid.RowHeadersWidth < CInt(size.Width + 20) Then
            grid.RowHeadersWidth = CInt(size.Width + 20)
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, grid.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs)
        If e.PopupCloseType = PopupCloseType.Done Then
        End If
    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        If cboTipoExistencia.SelectedIndex > -1 Then

        End If
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click

        Me.Cursor = Cursors.WaitCursor
        Try
            If Not txtProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"
                lblEstado.Image = My.Resources.warning2
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"
                lblEstado.Image = My.Resources.ok4
            End If

            If Not IsNothing(GConfiguracion.NomModulo) Then
                Select Case GConfiguracion.TipoConfiguracion
                    Case "M"
                    Case "P"
                End Select
            End If
           
            If dgvCompra.Rows.Count > 0 Then
                Me.lblEstado.Image = My.Resources.ok4
                Me.lblEstado.Text = "Done!"
                If lblIdDocumento.Text = "00" Then

                    GrabarSolicitud()
                    Dispose()

                ElseIf lblIdDocumento.Text > 0 Then
                    Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                    If Filas > 0 Then

                        UpdateCompra()
                        Dispose()

                Else
                        Me.lblEstado.Image = My.Resources.warning2
                    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                End If
                End If
            Else
                Me.lblEstado.Image = My.Resources.warning2
                Me.lblEstado.Text = "Ingrese items a la canasta de compra!"

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnConfiguracion_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnConfiguracion.MouseLeave
        toolTip.Close()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub

    Private Sub cboTipoDoc_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboTipoDoc.SelectedIndexChanged
        If dgvCompra.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        If txtBuscarProducto.Text.Trim.Length > 0 Then
            dgvCompra.Rows.Add(0, "0", "00", txtBuscarProducto.Text,
                                 Nothing,
                                    Nothing, CboUM.SelectedValue, 0, 0, 0, 0, 0, 0,
                                  0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                  cboTipoExistencia.SelectedValue, Nothing, Nothing)
        End If
    End Sub


End Class