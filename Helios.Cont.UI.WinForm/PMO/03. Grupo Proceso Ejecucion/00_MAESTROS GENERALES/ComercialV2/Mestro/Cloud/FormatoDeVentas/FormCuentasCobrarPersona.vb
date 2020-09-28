Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms
Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Public Class FormCuentasCobrarPersona

#Region "Attributes"
    Public Property ListaEntidad As List(Of entidad)
    Public Property compraSA As New documentoVentaAbarrotesSA
    Public Property entidadSA As New entidadSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCobranzaCli, True, False, 10.0F)
        TextBoxExt1.Visible = True
        GetClientes()
    End Sub
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

    Private Sub CuentasPorPagarCliente()
        Dim dt As New DataTable
        Dim cuentasList = compraSA.GetCobroPorCliente(New documentoventaAbarrotes With
                                                      {
                                                      .idEmpresa = Gempresas.IdEmpresaRuc,
                                                      .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                      .fechaDoc = Date.Now,
                                                      .moneda = 1,
                                                      .idCliente = Integer.Parse(TextBoxExt1.Tag)
                                                      })


        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("fecha", GetType(String))
        dt.Columns.Add("tipoVenta", GetType(String))
        dt.Columns.Add("tipoDoc", GetType(String))
        dt.Columns.Add("serie", GetType(String))
        dt.Columns.Add("numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("importeMN", GetType(Decimal))
        dt.Columns.Add("tipoCambio", GetType(Decimal))
        dt.Columns.Add("importeME", GetType(Decimal))
        dt.Columns.Add("abonoMN", GetType(Decimal))
        dt.Columns.Add("abonoME", GetType(Decimal))
        dt.Columns.Add("saldoMN", GetType(Decimal))
        dt.Columns.Add("saldoME", GetType(Decimal))
        dt.Columns.Add("estadoPago", GetType(String))

        dt.Columns.Add("idCliente")
        dt.Columns.Add("cliente")
        dt.Columns.Add("nroDocEntidad")

        Dim str As String
        If cuentasList.Count > 0 Then
            Dim SaldoPagosMN As Decimal = 0
            Dim SaldoPagosME As Decimal = 0
            For Each i In cuentasList


                SaldoPagosMN = 0
                SaldoPagosME = 0

                SaldoPagosMN = i.ImporteNacional - i.PagoSumaMN
                SaldoPagosME = i.ImporteExtranjero - i.PagoSumaME

                'nota de credito
                SaldoPagosMN = SaldoPagosMN - i.PagoNotaCreditoMN + i.PagoNotaDebitoMN
                SaldoPagosME = SaldoPagosME - i.PagoNotaCreditoME + i.PagoNotaDebitoME





                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = str
                dr(2) = i.tipoVenta
                dr(3) = i.tipoDocumento
                dr(4) = i.serie
                dr(5) = i.numeroDoc
                Select Case i.moneda
                    Case CStr(1)
                        dr(6) = "NAC"
                    Case Else
                        dr(6) = "EXT"
                End Select
                dr(7) = i.ImporteNacional
                dr(8) = i.tipoCambio
                dr(9) = i.ImporteExtranjero
                dr(10) = i.PagoSumaMN + i.PagoNotaCreditoMN
                dr(11) = i.PagoSumaME + i.PagoNotaCreditoME
                'dr(12) = CDec(i.ImporteNacional - i.PagoSumaMN).ToString("N2")
                'dr(13) = CDec(i.ImporteExtranjero - i.PagoSumaME).ToString("N2")
                dr(12) = CDec(SaldoPagosMN).ToString("N2")
                dr(13) = CDec(SaldoPagosME).ToString("N2")

                Select Case i.estadoCobro
                    Case TIPO_VENTA.PAGO.COBRADO
                        dr(14) = "Saldado"
                    Case TIPO_VENTA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select

                Select Case i.estadoCobro
                    Case TIPO_COMPRA.PAGO.PAGADO
                        dr(14) = "Saldado"
                    Case TIPO_COMPRA.PAGO.PENDIENTE_PAGO
                        dr(14) = "Pendiente"
                End Select
                dr(15) = (i.idCliente)
                dr(16) = (i.NombreEntidad)
                dr(17) = (i.NroDocEntidad)
                dt.Rows.Add(dr)
            Next
            dgvCobranzaCli.DataSource = dt
            Me.dgvCobranzaCli.TableOptions.ListBoxSelectionMode = SelectionMode.One

            'Select Case cboMonedaCobro.Text
            '    Case "NACIONAL"
            dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 70
            dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 0
            dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 0
            'Case "EXTRANJERA"
            '    dgvCobranzaCli.TableDescriptor.Columns("tipoCambio").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("importeME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("abonoME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("saldoME").Width = 70
            '    dgvCobranzaCli.TableDescriptor.Columns("importeMN").Width = 0
            '    dgvCobranzaCli.TableDescriptor.Columns("abonoMN").Width = 0
            '    dgvCobranzaCli.TableDescriptor.Columns("saldoMN").Width = 0
            'End Select


        Else

        End If
    End Sub
#End Region

#Region "Events"
    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged
        TextBoxExt1.ForeColor = Color.Black
        TextBoxExt1.Tag = Nothing
        If TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            '    txtruc.Visible = True
        Else
            '    txtruc.Visible = False
        End If
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

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
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

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Me.Cursor = Cursors.WaitCursor
        dgvCobranzaCli.Table.Records.DeleteAll()

        If TextBoxExt1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            If TextBoxExt1.Text.Trim.Length > 0 Then
                CuentasPorPagarCliente()
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        Dim cajaUsuarioSA As New cajaUsuarioSA
        Try
            If Not IsNothing(Me.dgvCobranzaCli.Table.CurrentRecord) Then

                'Dim fechaAnt = New Date(txtPeriodo.Value.Year, CInt(txtPeriodo.Value.Month), 1)
                'fechaAnt = fechaAnt.AddMonths(-1)
                'Dim periodoAnteriorEstaCerrado = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = fechaAnt.Year, .mes = fechaAnt.Month})
                'If periodoAnteriorEstaCerrado = False Then
                '    MessageBox.Show("Debe cerrar el período anterior: " & fechaAnt.Month & "/" & fechaAnt.Year)
                '    Cursor = Cursors.Default
                '    Exit Sub
                'End If

                'Dim valida As Boolean = empresaPeriodoSA.EstadoMesCerrado(New empresaCierreMensual With {.idEmpresa = Gempresas.IdEmpresaRuc, .anio = txtPeriodo.Value.Year, .mes = CInt(txtPeriodo.Value.Month)})
                'If Not IsNothing(valida) Then
                '    If valida = True Then
                '        MessageBox.Show("No puede realiar esta operación" & vbCrLf & "el período ha sido cerrado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                '        Me.Cursor = Cursors.Default
                '        Exit Sub
                '    End If
                'End If

                If dgvCobranzaCli.Table.SelectedRecords.Count > 0 Then

                    Dim cajaUsuario = cajaUsuarioSA.UbicarCajaAsignadaUser(usuario.IDUsuario, "A", "S", Nothing)
                    If Not IsNothing(cajaUsuario) Then
                        GetGlobalMappingCajaUsuario(cajaUsuario, usuario.IDUsuario, usuario.CustomUsuario.Full_Name)
                        'btnNuevoPagoPago(dgvPagosVarios.Table.CurrentRecord.GetValue("moneda"), dgvPagosVarios.Table.CurrentRecord.GetValue("idDocumento"))
                        Dim f As New FormCobrarDoc(dgvCobranzaCli.Table.CurrentRecord.GetValue("idDocumento"))
                        f.Saldo = CDec(dgvCobranzaCli.Table.CurrentRecord.GetValue("saldoMN"))
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog(Me)
                        ToolStripButton5_Click(sender, e)
                    Else
                        MessageBox.Show("No registra una caja activa!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If
            Else
                MessageBox.Show("Debe seleccionar una item!", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region


End Class