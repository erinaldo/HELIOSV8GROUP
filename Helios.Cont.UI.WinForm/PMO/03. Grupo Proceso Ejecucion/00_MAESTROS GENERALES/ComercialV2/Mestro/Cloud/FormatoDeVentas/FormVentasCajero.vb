Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools

Public Class FormVentasCajero

#Region "Attributes"
    Public Property ListaEntidad As List(Of entidad)
    Public Property entidadSA As New entidadSA
#End Region

#Region "Methods"
    Private Sub GetClientes()
        ListaEntidad = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        TextBoxExt1.Visible = True
        TextBoxExt1.ReadOnly = False
        TextBoxExt1.Enabled = True
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub ReiniciarCombos()
        '   TextBoxExt1.Clear()
        'ComboMoneda.SelectedIndex = -1
        'ComboComprobante.SelectedIndex = -1
        TextSerie.Clear()
        TextNumero.Clear()
        TextSerie.Visible = True
        TextNumero.Visible = True
        TextSerie.ReadOnly = False
        TextNumero.ReadOnly = False
        TextSerie.Enabled = True
        TextNumero.Enabled = True
    End Sub
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgPedidos, True, False, 10.0F)
        dockingManager1.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.VS2010
        dockingManager1.ShowCaption = True
        dockingManager1.SetDockLabel(PanelfILTROS, "Búsqueda")
        dockingManager1.DockControlInAutoHideMode(PanelfILTROS, DockingStyle.Left, 343)
        GetClientes()
        ReiniciarCombos()
    End Sub


#End Region

#Region "Events"
    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If LsvProveedor.SelectedItems.Count > 0 Then
                    If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                        'Dim f As New frmCrearENtidades
                        'f.CaptionLabels(0).Text = "Nuevo proveedor"
                        'f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                        'f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        ''f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
                        'f.StartPosition = FormStartPosition.CenterParent
                        'f.ShowDialog()
                        'If Not IsNothing(f.Tag) Then
                        '    Dim c = CType(f.Tag, entidad)
                        '    ListaEntidad.Add(c)
                        '    TextBoxExt1.Text = c.nombreCompleto
                        '    'txtruc.Text = c.nrodoc
                        '    TextBoxExt1.Tag = c.idEntidad
                        '    'txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        '    'txtruc.Visible = True
                        '    TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        'End If
                    Else
                        TextBoxExt1.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                        TextBoxExt1.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                        TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        'txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                        'txtruc.Visible = True

                    End If
                    'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TextBoxExt1.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged
        TextBoxExt1.ForeColor = Color.Black
        TextBoxExt1.Tag = Nothing
        If TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            '    txtruc.Visible = True
        Else
            '    txtruc.Visible = False
        End If
    End Sub

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TextBoxExt1
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



            Dim consulta2 = (From n In ListaEntidad
                             Where n.nombreCompleto.StartsWith(TextBoxExt1.Text) Or n.nrodoc.StartsWith(TextBoxExt1.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TextBoxExt1
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            LsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub PanelfILTROS_Paint(sender As Object, e As PaintEventArgs) Handles PanelfILTROS.Paint

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        If RBComprobante.Checked = True Then
            GetConsultaVenta()
        ElseIf RBCliente.Checked = True Then
            If TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                If TextBoxExt1.Text.Trim.Length > 0 Then
                    GetVentasOP2()
                End If
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GetConsultaVenta()
        If TextSerie.Text.Trim.Length > 0 AndAlso TextNumero.Text.Trim.Length > 0 Then
            GetVentasOP1()
        End If
    End Sub

    Sub GetVentasOP1()
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim dt As New DataTable("Ventas")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))


        Dim tipodoc = String.Empty
        Select Case ComboComprobante.Text
            Case "FACTURA"
                tipodoc = "01"
            Case "BOLETA"
                tipodoc = "03"
            Case "NOTA DE VENTA"
                tipodoc = "9907"
        End Select
        Dim str As String
        For Each i As documentoventaAbarrotes In ventaSA.GetVentasFiltroComprobante(New documentoventaAbarrotes With {
                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                  .moneda = "1",
                                  .tipoDocumento = tipodoc,
                                  .serieVenta = TextSerie.Text.Trim,
                                  .numeroVenta = TextNumero.Text.Trim
                                                                                    })
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(6) = i.numeroDoc
                Case Else
                    dr(6) = i.numeroVenta
            End Select
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(3) = i.nombrePedido
                    dr(7) = "-"
                    dr(8) = i.nombrePedido
                Case Else
                    dr(3) = i.NombreEntidad
                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
            End Select

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"

                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    Select Case i.estadoCobro
                        Case Gimnasio_EstadoMembresiaPago.Completo
                            dr(14) = "Cobrado"
                        Case Gimnasio_EstadoMembresiaPago.IngresoLibre
                            dr(14) = "Libre"
                        Case Gimnasio_EstadoMembresiaPago.PagoParcial
                            dr(14) = "Parcial"
                        Case Gimnasio_EstadoMembresiaPago.Pendiente
                            dr(14) = "Pendiente"
                    End Select

                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If

            dr(17) = i.EnvioSunat

            dt.Rows.Add(dr)
        Next
        'setDatasource(dt)
        dgPedidos.DataSource = dt
    End Sub

    Sub GetVentasOP2()
        Dim ventaSA As New documentoVentaAbarrotesSA
        Dim dt As New DataTable("Ventas")
        dt.Columns.Add(New DataColumn("idDocumento", GetType(Integer)))
        dt.Columns.Add(New DataColumn("tipoCompra", GetType(String)))
        dt.Columns.Add(New DataColumn("fechaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("pedido", GetType(String)))
        dt.Columns.Add(New DataColumn("tipoDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("serie", GetType(String)))
        dt.Columns.Add(New DataColumn("numeroDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("NroDocEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("NombreEntidad", GetType(String)))
        dt.Columns.Add(New DataColumn("importeTotal", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("tcDolLoc", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("importeUS", GetType(Decimal)))
        dt.Columns.Add(New DataColumn("monedaDoc", GetType(String)))
        dt.Columns.Add(New DataColumn("usuarioActualizacion", GetType(String)))
        dt.Columns.Add(New DataColumn("estado", GetType(String)))
        dt.Columns.Add(New DataColumn("estadoPreparado", GetType(String)))
        dt.Columns.Add(New DataColumn("idPadre", GetType(Integer)))
        dt.Columns.Add(New DataColumn("enviosunat", GetType(String)))


        Dim tipodoc = String.Empty
        Select Case ComboComprobante.Text
            Case "FACTURA"
                tipodoc = "01"
            Case "BOLETA"
                tipodoc = "03"
            Case "NOTA DE VENTA"
                tipodoc = "9907"
        End Select
        Dim str As String
        For Each i As documentoventaAbarrotes In ventaSA.GetVentasFiltroComprobanteCliente(New documentoventaAbarrotes With {
                                  .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                  .idCliente = Integer.Parse(TextBoxExt1.Tag)
                                                                                    })
            Dim dr As DataRow = dt.NewRow()
            str = Nothing
            str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
            dr(0) = i.idDocumento
            dr(1) = i.tipoVenta
            dr(2) = str

            dr(4) = i.tipoDocumento
            dr(5) = i.serieVenta
            Select Case i.tipoVenta
                Case TIPO_VENTA.VENTA_AL_TICKET, TIPO_VENTA.VENTA_POS_DIRECTA
                    dr(6) = i.numeroVenta

                Case TIPO_VENTA.COTIZACION
                    dr(6) = i.numeroDoc

                Case TIPO_VENTA.VENTA_GENERAL
                    dr(6) = i.numeroVenta
                Case "NTC"
                    dr(6) = i.numeroVenta
                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    dr(6) = i.numeroDoc
                Case Else
                    dr(6) = i.numeroVenta
            End Select
            Select Case i.NroDocEntidad
                Case Is = Nothing
                    dr(3) = i.nombrePedido
                    dr(7) = "-"
                    dr(8) = i.nombrePedido
                Case Else
                    dr(3) = i.NombreEntidad
                    dr(7) = i.NroDocEntidad
                    dr(8) = i.NombreEntidad
            End Select

            dr(9) = FormatNumber(i.ImporteNacional, 2)
            dr(10) = i.tipoCambio
            dr(11) = FormatNumber(i.ImporteExtranjero, 2)
            dr(12) = i.moneda
            dr(13) = i.usuarioActualizacion

            Select Case i.tipoVenta
                Case "NTC"
                    dr(14) = "-"

                Case TIPO_VENTA.VENTA_MEMBRESIAS_GIMANSIO
                    Select Case i.estadoCobro
                        Case Gimnasio_EstadoMembresiaPago.Completo
                            dr(14) = "Cobrado"
                        Case Gimnasio_EstadoMembresiaPago.IngresoLibre
                            dr(14) = "Libre"
                        Case Gimnasio_EstadoMembresiaPago.PagoParcial
                            dr(14) = "Parcial"
                        Case Gimnasio_EstadoMembresiaPago.Pendiente
                            dr(14) = "Pendiente"
                    End Select

                Case Else
                    Select Case i.estadoCobro
                        Case "DC"
                            dr(14) = "Cobrado"
                        Case "ANU"
                            dr(14) = "Anulado"
                        Case TIPO_VENTA.AnuladaPorNotaCredito
                            dr(14) = "Anulado x NC."
                        Case Else
                            dr(14) = "Pendiente"
                    End Select
            End Select


            Select Case i.notaCredito
                Case StatusVentaMatizados.PorPreparar
                    dr(15) = "Pendiente"
                Case StatusVentaMatizados.TerminadaYentregada
                    dr(15) = "Entregada"
            End Select
            If i.tipoVenta = "NTC" Then
                dr(16) = i.idPadre
            End If

            dr(17) = i.EnvioSunat

            dt.Rows.Add(dr)
        Next
        'setDatasource(dt)
        dgPedidos.DataSource = dt
    End Sub


    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Cursor = Cursors.WaitCursor
        Try
            'If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.EDITAR_VENTA_SI_Botón___, AutorizacionRolList) Then
            If Not IsNothing(dgPedidos.Table.CurrentRecord) Then
                    Select Case dgPedidos.Table.CurrentRecord.GetValue("tipoCompra")
                        'Case TIPO_VENTA.VENTA_GENERAL
                        '    Dim f As New frmVenta(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                        '    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        '    f.ShowDialog()
                        'Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                        '    Dim f As New frmVentaPV(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                        '    f.StartPosition = FormStartPosition.CenterParent
                        '    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                        '    f.ShowDialog()
                        Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_ELECTRONICA, TIPO_VENTA.VENTA_NOTA_PEDIDO
                            'Dim f As New frmVentaPVdirecta(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                            'f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            'f.ShowDialog()
                            Dim f As New FormViewVentaGeneral(dgPedidos.Table.CurrentRecord.GetValue("idDocumento")) '
                            ' f.GroupBarMKT.Visible = True
                            f.btGrabar.Enabled = False
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()
                            'Case TIPO_VENTA.VENTA_AL_TICKET
                            '    Dim f As New frmVentaPV(dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                            '    f.ManipulacionEstado = ENTITY_ACTIONS.UPDATE
                            '    f.WindowState = FormWindowState.Maximized
                            '    f.ShowDialog()
                    End Select
                Else
                    MessageBox.Show("Debe seleccionar un pedido/venta!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            'Else
            '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Cursor = Cursors.Default
    End Sub

    Public Function ValidarStock(idDocVenta As Integer)
        Dim documentoventa As New documentoVentaAbarrotesSA

        Dim sintock As Integer = 0
        sintock = documentoventa.StockEliminarNotaVenta(idDocVenta)

        Return sintock
    End Function

    Public Sub EliminarNota(intIdDocumentoNota As Integer)
        Dim compraSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Dim notaCredito As documentoventaAbarrotes
        Try
            notaCredito = compraSA.GetUbicar_documentoventaAbarrotesPorID(intIdDocumentoNota)
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .IdDocumentoAfectado = notaCredito.idPadre ' venta
                .idDocumento = intIdDocumentoNota
            End With
            compraSA.EliminarNotaCreditoMetodoVenta(objDocumento)
            Me.dgPedidos.Table.CurrentRecord.Delete()
            lblEstado.Text = "Nota eliminada correctamente!"
            PanelError.Visible = True

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True

        End Try
    End Sub

    Public Sub EliminarPV(intIdDocumento As Integer)
        Dim documentoSA As New documentoVentaAbarrotesSA
        Dim objDocumento As New documento
        Try
            With objDocumento
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idCentroCosto = GEstableciento.IdEstablecimiento
                .idDocumento = intIdDocumento
            End With

            documentoSA.EliminarVenta(objDocumento)
            'documentoSA.EliminarVentaGeneralPV(objDocumento)
            dgPedidos.Table.CurrentRecord.Delete()
            lblEstado.Text = "Pedido eliminado!"
            PanelError.Visible = True

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True

        End Try
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        '   If AutorizacionRolSA.TienePermiso(AsegurablesSistemaPOS.ELIMINAR__ANULAR_SI_Botón___, AutorizacionRolList) Then
        If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
                If MessageBox.Show("Desea Eliminar el item seleccionado?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    Select Case Me.dgPedidos.Table.CurrentRecord.GetValue("tipoCompra")
                        Case TIPO_COMPRA.NOTA_CREDITO
                            Dim tiene As Integer = ValidarStock(Me.dgPedidos.Table.CurrentRecord.GetValue("idPadre"))
                            If tiene = 0 Then
                                EliminarNota(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                            Else
                                MessageBox.Show("No se puede eliminar por que no hay stock!", "Atención")
                            End If
                        'EliminarNota(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                        Case TIPO_COMPRA.NOTA_DEBITO
                    '    EliminarNotaDebito(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                        Case TIPO_VENTA.VENTA_NOTA_PEDIDO
                            EliminarPV(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento"))
                        Case TIPO_VENTA.VENTA_GENERAL
                            'se elimina atraves de las notas de credito
                            EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                        Case TIPO_VENTA.VENTA_POS_DIRECTA, TIPO_VENTA.VENTA_AL_TICKET
                            EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                        '   EliminarPVDirecta(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))

                        Case TIPO_VENTA.VENTA_ELECTRONICA
                            If Me.dgPedidos.Table.CurrentRecord.GetValue("tipoDoc") = "03" Then


                                Dim clas = (Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat"))

                                If clas.ToString.Trim.Length > 0 Then
                                    If Me.dgPedidos.Table.CurrentRecord.GetValue("enviosunat") = "SI" Then

                                        EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                                    Else
                                        MessageBox.Show("verifique el ticket de envio de la boleta para poder eliminar!", "Atención")
                                    End If
                                Else
                                    MessageBox.Show("La Boleta debe ser enviado a sunat para poder eliminar!", "Atención")
                                End If
                            Else
                                EliminarPV(Val(Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")))
                            End If

                    End Select
                End If
            Else
                MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            'Else
            '    MessageBox.Show("Usuario no autorizado", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
            Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Cursor = Cursors.WaitCursor
        If Not IsNothing(Me.dgPedidos.Table.CurrentRecord) Then
            'Dim f As New FormImpresionNuevo  ' frmVentaNuevoFormato
            'f.DocumentoID = Me.dgPedidos.Table.CurrentRecord.GetValue("idDocumento")
            'f.StartPosition = FormStartPosition.CenterScreen
            '' f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'f.Show(Me)
        Else
            MessageBox.Show("Debe seleccionar un item válido!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Cursor = Cursors.Default
    End Sub

#End Region

End Class