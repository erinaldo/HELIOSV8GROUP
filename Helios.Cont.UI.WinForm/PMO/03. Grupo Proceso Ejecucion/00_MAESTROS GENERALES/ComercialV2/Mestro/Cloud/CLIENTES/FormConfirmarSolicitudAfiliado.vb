Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Grouping
Imports Helios.Cont.Presentation.WinForm
Imports Syncfusion.Windows.Forms

Public Class FormConfirmarSolicitudAfiliado
    Implements IExistencias

    Public Property beneficioSA As New beneficioSA
    Public Property entidadSA As New entidadSA
    Public Property ListaInventario As List(Of totalesAlmacen)
    Public Property TotalesAlmacenSA As New TotalesAlmacenSA
    Public Sub New(r As Record)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetProveedor(r)
        GetAlmacenes()
        txtVigencia.Value = DateTime.Now
    End Sub

    Public Sub New(idCLiente As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        GetProveedor(idCLiente)
        GetAlmacenes()
        txtVigencia.Value = DateTime.Now
    End Sub

    Private Sub GetAlmacenes()
        Dim almacenSA As New almacenSA

        CboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        CboAlmacen.DisplayMember = "descripcionAlmacen"
        CboAlmacen.ValueMember = "idAlmacen"
    End Sub


    Private Sub GetProveedor(r As Record)
        Dim cliente = entidadSA.UbicarEntidadPorID(Integer.Parse(r.GetValue("idcliente"))).FirstOrDefault

        If cliente IsNot Nothing Then
            TextEntidad.Text = cliente.nombreCompleto
            TextEntidad.Tag = cliente.idEntidad
            TextNroDocEntidad.Text = cliente.nrodoc
        End If

    End Sub

    Private Sub GetProveedor(id As Integer)
        Dim cliente = entidadSA.UbicarEntidadPorID(id).FirstOrDefault

        If cliente IsNot Nothing Then
            TextEntidad.Text = cliente.nombreCompleto
            TextEntidad.Tag = cliente.idEntidad
            TextNroDocEntidad.Text = cliente.nrodoc
        End If

    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click

        Dim codigoTipoTabla As Integer = 0
        Dim codigoTipoBeneficio As Integer = 0
        Dim productoRegalo As String = String.Empty
        Try
            If TextDetalleBeneficio.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe ingresar un producto afecto al beneficio!", "validar producto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextDetalleBeneficio.Select()
                Exit Sub
            End If


            If Not TextDetalleBeneficio.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                MessageBox.Show("Debe ingresar un producto afecto al beneficio!", "validar producto", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextDetalleBeneficio.Select()
                Exit Sub
            End If

            If TextImporteBase.DecimalValue = 0 Then
                MessageBox.Show("Debe ingresar un monto base mayor a cero!", "validar monto a evaluar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextImporteBase.Select()
                Exit Sub
            End If

            If TextValorConvertido.DecimalValue = 0 Then
                MessageBox.Show("Debe ingresar un monto ganado mayor a cero!", "validar monto ganado a evaluar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextValorConvertido.Select()
                Exit Sub
            End If


            Select Case CboTipoTabla.Text
                Case "REGALO"
                    codigoTipoTabla = General.TipoTabla.regalo
                    productoRegalo = TextDetalleBeneficio.Tag
                Case "BONIFICACION"
                    codigoTipoTabla = General.TipoTabla.Bonificacion
                    productoRegalo = TextDetalleBeneficio.Tag
                Case "DESCUENTO REBAJA"
                    codigoTipoTabla = General.TipoTabla.DescuentoRebaja
                    productoRegalo = TextDetalleBeneficio.Tag
                Case ""

            End Select

            Select Case CboTipoBeneficio.Text
                Case "DOCUMENTO"
                    codigoTipoBeneficio = General.TipoBeneficio.Documento
                Case "ITEM"
                    codigoTipoBeneficio = General.TipoBeneficio.Item
                Case "LINEA DE PRODUCTO"
                    codigoTipoBeneficio = General.TipoBeneficio.LineaDeProducto
                Case ""

            End Select

            Dim beneficio As New Business.Entity.beneficio With
            {
            .Action = BaseBE.EntityAction.INSERT,
            .tipoTabla = codigoTipoTabla,
            .detalleBeneficio = productoRegalo,
            .tipoBeneficio = codigoTipoBeneficio,
            .beneficioReferencia = If(TextProductoRef.Text.Trim.Length > 0, TextProductoRef.Tag, 0),
            .beneficioReferenciaCantidad = TextCantidadRef.DecimalValue,
            .afectoComprobante = chAfectoComprobante.Checked,
            .tipoAfectacion = If(CbotipoAfectacion.Text = "IMPORTE", "I", "C"),
            .importeBase = TextImporteBase.DecimalValue,
            .valorConvertido = TextValorConvertido.DecimalValue,
            .vigencia = txtVigencia.Value,
            .esPremioRegaloBonif = False,
            .idCliente = TextEntidad.Tag,
            .produccion_id = If(TextProduccion.Text.Trim.Length > 0, TextProduccion.Tag, 0),
            .estado = StatusBeneficio.Activo
            }

            beneficioSA.RegisterClientBenefice(beneficio)
            MessageBox.Show("Descuento asignado a cliente!", "Registro con exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Validar", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        With FormCanastaCompras
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog(Me)
        End With
    End Sub

    Public Sub EnviarItem(be As detalleitems) Implements IExistencias.EnviarItem
        TextProductoRef.Tag = be.codigodetalle
        TextProductoRef.Text = be.descripcionItem
    End Sub

    Private Sub CboTipoTabla_Click(sender As Object, e As EventArgs) Handles CboTipoTabla.Click

    End Sub

    Private Sub CboTipoTabla_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboTipoTabla.SelectedValueChanged
        If CboTipoTabla.Text = "DESCUENTO REBAJA" Then
            TextDetalleBeneficio.Clear()
            TextDetalleBeneficio.Enabled = True
            TextCantidadRef.Visible = True
            Label4.Visible = False
            TextProductoRef.ReadOnly = True
            TextProductoRef.Clear()
            GroupBox2.Enabled = True
            GroupBox3.Enabled = True
            'LabelAlmacen.Visible = False
            'CboAlmacen.Visible = False
            CbotipoAfectacion.Text = "IMPORTE"
            CbotipoAfectacion.Enabled = False
        ElseIf CboTipoTabla.Text = "REGALO" Or CboTipoTabla.Text = "BONIFICACION" Then
            TextProductoRef.ReadOnly = False
            TextDetalleBeneficio.Clear()
            TextDetalleBeneficio.Enabled = True
            TextCantidadRef.Visible = True
            Label4.Visible = True
            TextProductoRef.Clear()
            GroupBox2.Enabled = True
            GroupBox3.Enabled = True
            'LabelAlmacen.Visible = True
            'CboAlmacen.Visible = True
            CbotipoAfectacion.Text = "IMPORTE"
            CbotipoAfectacion.Enabled = False
        End If
    End Sub

    Private Sub CboAlmacen_Click(sender As Object, e As EventArgs) Handles CboAlmacen.Click

    End Sub

    Private Sub GetInventarioLista(idalmacen As Integer)
        ListaInventario = TotalesAlmacenSA.GetInventarioGeneral(New totalesAlmacen With
                                                         {
                                                         .idAlmacen = idalmacen,
                                                         .tipoExistencia = TipoExistencia.Mercaderia,
                                                         .InvAcumulado = True
                                                         }).Where(Function(o) o.cantidad > 0) _
                                                         .OrderBy(Function(o) o.descripcion).ToList
    End Sub

    Private Sub CboAlmacen_SelectedValueChanged(sender As Object, e As EventArgs) Handles CboAlmacen.SelectedValueChanged
        Cursor = Cursors.WaitCursor
        ' If TextDetalleBeneficio.Enabled = True Then
        If CboAlmacen.SelectedValue IsNot Nothing Then
            If IsNumeric(CboAlmacen.SelectedValue) Then
                GetInventarioLista(Integer.Parse(CboAlmacen.SelectedValue))
            End If
        End If

        ' End If
        Cursor = Cursors.Default
    End Sub

    Private Sub TextDetalleBeneficio_TextChanged(sender As Object, e As EventArgs) Handles TextDetalleBeneficio.TextChanged
        If TextDetalleBeneficio.Enabled = True Then
            TextDetalleBeneficio.ForeColor = Color.Black
            TextDetalleBeneficio.Tag = Nothing
            If TextDetalleBeneficio.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then

            Else

            End If
        End If

    End Sub

    Private Sub TextDetalleBeneficio_KeyDown(sender As Object, e As KeyEventArgs) Handles TextDetalleBeneficio.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcProductos.Size = New Size(282, 128)
            Me.pcProductos.ParentControl = Me.TextDetalleBeneficio
            Me.pcProductos.ShowPopup(Point.Empty)
            ' Dim consulta As New List(Of entidad)
            ' consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})
            Dim consulta2 = (From n In ListaInventario
                             Where n.descripcion.StartsWith(TextDetalleBeneficio.Text)).ToList

            FillLSVProducts(consulta2)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcProductos.Size = New Size(282, 128)
            Me.pcProductos.ParentControl = Me.TextDetalleBeneficio
            Me.pcProductos.ShowPopup(Point.Empty)
            LstProducts.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcProductos.IsShowing() Then
                Me.pcProductos.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub FillLSVProducts(consulta As List(Of totalesAlmacen))
        ' LstProducts.Items.Clear()

        LstProducts.DataSource = consulta
        LstProducts.DisplayMember = "descripcion"
        LstProducts.ValueMember = "idItem"

    End Sub

    Private Sub FillLSVProductsRefer(consulta As List(Of totalesAlmacen))
        'ListProductsRef.Items.Clear()

        ListProductsRef.DataSource = consulta
        ListProductsRef.DisplayMember = "descripcion"
        ListProductsRef.ValueMember = "idItem"

    End Sub

    Private Sub LstProducts_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LstProducts.MouseDoubleClick
        Me.pcProductos.HidePopup(PopupCloseType.Done)
    End Sub
    Private Sub pcProductos_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcProductos.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If LstProducts.SelectedItems.Count > 0 Then

                TextDetalleBeneficio.Text = LstProducts.Text
                TextDetalleBeneficio.Tag = LstProducts.SelectedValue
                TextDetalleBeneficio.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TextDetalleBeneficio.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

#Region "TextBoxt Producto referencia"

    Private Sub TextProductoRef_TextChanged(sender As Object, e As EventArgs) Handles TextProductoRef.TextChanged
        Try
            If TextProductoRef.Enabled = True Then
                TextProductoRef.ForeColor = Color.Black
                TextProductoRef.Tag = Nothing
                If TextProductoRef.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then

                Else

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub TextProductoRef_KeyDown(sender As Object, e As KeyEventArgs) Handles TextProductoRef.KeyDown
        Try
            If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

            Else
                '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                Me.PcProductsRefer.Size = New Size(282, 128)
                Me.PcProductsRefer.ParentControl = Me.TextProductoRef
                Me.PcProductsRefer.ShowPopup(Point.Empty)
                ' Dim consulta As New List(Of entidad)
                ' consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})
                Dim consulta2 = (From n In ListaInventario
                                 Where n.descripcion.StartsWith(TextProductoRef.Text)).ToList

                FillLSVProductsRefer(consulta2)
                e.Handled = True
            End If

            If e.KeyCode = Keys.Down Then
                '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                Me.PcProductsRefer.Size = New Size(282, 128)
                Me.PcProductsRefer.ParentControl = Me.TextProductoRef
                Me.PcProductsRefer.ShowPopup(Point.Empty)
                ListProductsRef.Focus()
            End If
            '   End If

            ' e.SuppressKeyPress = True
            If e.KeyCode = Keys.Escape Then
                If Me.PcProductsRefer.IsShowing() Then
                    Me.PcProductsRefer.HidePopup(PopupCloseType.Canceled)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LstProducts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstProducts.SelectedIndexChanged

    End Sub

    Private Sub ListProductsRef_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListProductsRef.MouseDoubleClick
        Me.PcProductsRefer.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub PcProductsRefer_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PcProductsRefer.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If ListProductsRef.SelectedItems.Count > 0 Then
                TextProductoRef.Text = ListProductsRef.Text
                TextProductoRef.Tag = ListProductsRef.SelectedValue
                TextProductoRef.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TextProductoRef.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub
#End Region
End Class