Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Public Class FormConfirmarNotaCompra
#Region "Variables"
    Public Property prod As detalleitems
    Public Property listaProveedores As List(Of entidad)
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))
    Public Property IdNotaGlobal As Integer
#End Region

#Region "Constructors"
    Public Sub New(grid As GridGroupingControl)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCompra, False, False, 11.0F)
        threadProveedores()
        FillDGV(grid)
    End Sub

    Public Sub New(idNota As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        FormatoGridAvanzado(dgvCompra, False, False, 11.0F)
        threadProveedores()
        FillDGV(idNota)
        IdNotaGlobal = idNota
    End Sub
#End Region

#Region "Proveedores"
    Private Sub FillLSVProveedores(consulta As List(Of entidad))
        lsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            lsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub threadProveedores()
        Dim tipo = TIPO_ENTIDAD.PROVEEDOR
        Dim empresa = Gempresas.IdEmpresaRuc
        Dim thread As System.Threading.Thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim entidadSA As New entidadSA
        Dim lista = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipo, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaProveedores = New List(Of entidad)
            listaProveedores = lista
        End If
    End Sub
#End Region

#Region "Methods"
    Private Sub FillDGV(grid As GridGroupingControl)
        Dim articuloSA As New detalleitemsSA
        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("gravado")
        dt.Columns.Add("idProducto")
        dt.Columns.Add("item")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("pumn")
        dt.Columns.Add("totalmn")
        dt.Columns.Add("idddoc")
        dt.Columns.Add("fecha")

        For Each i In grid.Table.SelectedRecords
            prod = articuloSA.InvocarProductoID(Integer.Parse(i.Record.GetValue("iditem")))
            Dim iddoc = i.Record.GetValue("idDocumento")
            dt.Rows.Add(i.Record.GetValue("secuencia"),
                        prod.origenProducto,
                        prod.codigodetalle,
                        prod.descripcionItem,
                        prod.unidad1,
                        Decimal.Parse(i.Record.GetValue("cantidad")),
                        0,
                        0,
                        iddoc, i.Record.GetValue("fechaDoc"))
        Next
        dgvCompra.DataSource = dt
    End Sub

    Private Sub FillDGV(idDocumentoNota As Integer)
        Dim articuloSA As New detalleitemsSA
        Dim compraSA As New DocumentoCompraDetalleSA
        Dim compraCabSA As New DocumentoCompraSA
        Dim dt As New DataTable
        dt.Columns.Add("codigo")
        dt.Columns.Add("gravado")
        dt.Columns.Add("idProducto")
        dt.Columns.Add("item")
        dt.Columns.Add("um")
        dt.Columns.Add("cantidad")
        dt.Columns.Add("pumn")
        dt.Columns.Add("totalmn")
        dt.Columns.Add("idddoc")
        dt.Columns.Add("fecha")

        For Each i In compraSA.UbicarDocumentoCompraDetalle(idDocumentoNota)
            'prod = articuloSA.InvocarProductoID(Integer.Parse(i.Record.GetValue("iditem")))
            'Dim iddoc = i.Record.GetValue("idDocumento")
            dt.Rows.Add(i.secuencia,
                        i.descripcionItem,
                        i.idItem,
                        i.descripcionItem,
                        i.unidad1,
                        i.monto1,
                        i.precioUnitario,
                        i.importe,
                        i.idDocumento, Nothing)
        Next
        dgvCompra.DataSource = dt

        Dim ent = compraCabSA.GetUbicarCompraPorID(idDocumentoNota)
        txtProveedor.Text = ent.entidad.nombreCompleto
        txtProveedor.Tag = ent.entidad.idEntidad
        txtruc.Text = ent.entidad.nrodoc

        txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Try
            If Not txtProveedor.Text.Trim.Length > 0 Then

                MessageBox.Show("Ingrese el proveedor de la compra", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProveedor.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            If txtProveedor.Text.Trim.Length > 0 Then
                If txtProveedor.ForeColor = Color.Black Then
                    MessageBox.Show("Verificar el ingreso correcto del proveedor", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtProveedor.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            End If
            Select Case cboTipoDoc.Text
                Case "NOTA"

                Case Else
                    If txtSerie.Text.Trim.Length = 0 Then
                        MessageBox.Show("Debe ingresar la serie", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtSerie.Select()
                        Exit Sub
                    End If

                    If txtNumero.Text.Trim.Length = 0 Then
                        MessageBox.Show("Debe ingresar el número", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtNumero.Select()
                        Exit Sub
                    End If
            End Select

            CommitOperation()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Validar")
        End Try
    End Sub

    Private Function EstructuraDocumentoCompra(be As documento) As documento
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim compraSA As New DocumentoCompraSA

        Dim compraSel = compraSA.UbicarDocumentoCompra(IdNotaGlobal)

        Dim lista As New List(Of documentocompradetalle)

        Dim documento As New documento With
        {
        .Action = BaseBE.EntityAction.INSERT,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .tipoDoc = If(cboTipoDoc.Text = "FACTURA", "01", "03"),
        .fechaProceso = be.fechaProceso,
        .moneda = "1",
        .idEntidad = be.idEntidad,
        .entidad = be.entidad,
        .tipoEntidad = "PR",
        .nrodocEntidad = be.nrodocEntidad,
        .nroDoc = String.Format("{0}-{1}", txtSerie.Text.Trim, txtNumero.Text.Trim),
        .tipoOperacion = StatusTipoOperacion.COMPRA,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }

        Dim compra As New documentocompra With
        {
        .codigoLibro = StatusCodigoLibroContable.REGISTRO_DE_COMPRAS,
        .idEmpresa = compraSel.idEmpresa,
        .idCentroCosto = compraSel.idCentroCosto,
        .fechaLaboral = compraSel.fechaLaboral,
        .fechaDoc = compraSel.fechaDoc,
        .fechaContable = GetPeriodo(compraSel.fechaDoc, True),
        .tipoDoc = If(cboTipoDoc.Text = "FACTURA", "01", "03"),
        .serie = txtSerie.Text.Trim,
        .numeroDoc = txtNumero.Text.Trim,
        .idProveedor = compraSel.idProveedor,
        .monedaDoc = "1",
        .tasaIgv = 18.0,
        .tcDolLoc = 3,
        .tipocambio = 3,
        .bi01 = compraSel.bi01,
        .bi02 = 0,
        .bi03 = 0,
        .bi04 = 0,
        .isc01 = 0,
        .isc02 = 0,
        .isc03 = 0,
        .igv01 = compraSel.importeTotal - compraSel.bi01,
        .igv02 = 0,
        .igv03 = 0,
        .otc01 = 0,
        .otc02 = 0,
        .otc03 = 0,
        .otc04 = 0,
        .bi01us = 0,
        .bi02us = 0,
        .bi03us = 0,
        .bi04us = 0,
        .isc01us = 0,
        .isc02us = 0,
        .isc03us = 0,
        .igv01us = 0,
        .igv02us = 0,
        .igv03us = 0,
        .otc01us = 0,
        .otc02us = 0,
        .otc03us = 0,
        .otc04us = 0,
        .importeTotal = compraSel.importeTotal,
        .importeUS = 0,
        .destino = TIPO_COMPRA.COMPRA,
        .estadoPago = "PN",
        .glosa = "Conversion de nota a una compra sustenatada con documento tributario",
        .tipoCompra = TIPO_COMPRA.COMPRA,
        .sustentado = "S",
        .idPadre = compraSel.idDocumento,
        .situacion = "1",
        .aprobado = "N",
        .apruebaPago = "N",
        .tieneDetraccion = "N",
        .estadoEntrega = "E",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        documento.documentocompra = compra
        documento.fechaProceso = compraSel.fechaDoc

        Dim det = detalleSA.UbicarDocumentoCompraDetalle(IdNotaGlobal)

        For Each i In det
            Dim compraDetalle As New documentocompradetalle With
                {
                .secuencia = i.secuencia,
                .idItem = i.idItem,
                .descripcionItem = i.descripcionItem,
                .tipoExistencia = i.tipoExistencia,
                .destino = i.destino,
                .unidad1 = i.unidad1,
                .monto1 = i.monto1,
                .monto2 = 0,
                .precioUnitario = i.precioUnitario,
                .precioUnitarioUS = i.precioUnitarioUS,
                .importe = i.importe,
                .importeUS = i.importeUS,
                .montokardex = i.montokardex,
                .montoIsc = i.montoIsc,
                .montoIgv = i.importe - i.montokardex,
                .montokardexUS = i.montokardexUS,
                .montoIgvUS = i.montoIgvUS,
                .bonificacion = "N",
                .nrolote = i.nrolote,
                .almacenRef = i.almacenRef,
                .estadoPago = i.estadoPago,
                .ItemEntregadototal = "S",
                .codigoLote = i.codigoLote,
                .usuarioModificacion = i.usuarioModificacion,
                .fechaModificacion = i.fechaModificacion
            }
            lista.Add(compraDetalle)
        Next
        documento.documentocompra.documentocompradetalle = lista
        Return documento
    End Function

    Private Sub CommitOperation()
        Dim docompra As New documento
        Dim compraSA As New DocumentoCompraSA
        Dim lista As New List(Of documento)
        Dim listadetalle As New List(Of documentocompradetalle)
        Dim obj As documento = Nothing

        obj = New documento
        obj.idEmpresa = Gempresas.IdEmpresaRuc
        obj.idDocumento = IdNotaGlobal
        obj.idEntidad = txtProveedor.Tag
        obj.entidad = txtProveedor.Text
        obj.nrodocEntidad = txtruc.Text
        obj.documentocompra = New documentocompra With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idDocumento = IdNotaGlobal,
            .aprobado = "S",
            .idProveedor = Integer.Parse(txtProveedor.Tag)
            }

        Select Case cboTipoDoc.Text
            Case "NOTA"

            Case Else
                docompra = EstructuraDocumentoCompra(obj)
        End Select

        Select Case cboTipoDoc.Text
            Case "NOTA"
                compraSA.ConfirmarNotaDeCompra(obj, Nothing)
            Case Else
                compraSA.ConfirmarNotaDeCompra(obj, docompra)
        End Select
        MessageBox.Show("Operación completada!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dim miInterfaz As ICommitOperacion = TryCast(Me.Owner, ICommitOperacion)
        If miInterfaz IsNot Nothing Then miInterfaz.Commit(True)
        Close()
    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
        Dim cc As GridCurrentCell = dgvCompra.TableControl.CurrentCell
        cc.ConfirmChanges()
        If cc.ColIndex > -1 Then
            Dim style As GridTableCellStyleInfo = e.TableControl.Table.TableModel(cc.RowIndex, cc.ColIndex)

            If style.TableCellIdentity.Column.Name = "cantidad" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    Dim value As Decimal = Convert.ToDecimal(text)
                    cc.Renderer.ControlValue = value


                End If
            ElseIf style.TableCellIdentity.Column.Name = "totalmn" Then
                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    Dim r As Record = dgvCompra.Table.CurrentRecord
                    Dim value As Decimal = Convert.ToDecimal(text)
                    cc.Renderer.ControlValue = value

                    Dim cant As Decimal = CDec(r.GetValue("cantidad"))
                    Dim precioUnitario As Decimal = Math.Round(value / cant, 2)

                    r.SetValue("pumn", precioUnitario)
                End If

            ElseIf style.TableCellIdentity.Column.Name = "pumn" Then

                Dim text As String = cc.Renderer.ControlText

                If text.Trim.Length > 0 Then
                    Dim valuePrecUnit As Decimal = Convert.ToDecimal(text)
                    cc.Renderer.ControlValue = valuePrecUnit
                    Dim r As Record = dgvCompra.Table.CurrentRecord

                    Dim cant As Decimal = CDec(r.GetValue("cantidad"))
                    Dim Total As Decimal = Math.Round(cant * valuePrecUnit, 2)

                    r.SetValue("totalmn", Total)

                End If
            End If
        End If
    End Sub

    Private Sub txtProveedor_TextChanged_1(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged
        txtProveedor.ForeColor = Color.Black
        txtProveedor.Tag = Nothing
        If txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer4.Size = New Size(319, 128)
            Me.PopupControlContainer4.ParentControl = Me.txtProveedor
            Me.PopupControlContainer4.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})
            Dim consulta2 = (From n In listaProveedores
                             Where n.nombreCompleto.StartsWith(txtProveedor.Text) Or n.nrodoc.StartsWith(txtProveedor.Text)).ToList

            consulta.AddRange(consulta2)
            FillLSVProveedores(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer4.Size = New Size(319, 128)
            Me.PopupControlContainer4.ParentControl = Me.txtProveedor
            Me.PopupControlContainer4.ShowPopup(Point.Empty)
            lsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.PopupControlContainer4.IsShowing() Then
                Me.PopupControlContainer4.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer4.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                If lsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                    Dim f As New frmCrearENtidades
                    f.CaptionLabels(0).Text = "Nuevo proveedor"
                    f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, entidad)
                        txtProveedor.Text = c.nombreCompleto
                        txtProveedor.Tag = c.idEntidad
                        txtruc.Visible = True
                        txtruc.Text = c.nrodoc
                        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        listaProveedores.Add(c)
                    End If
                Else
                    txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                    txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                    txtProveedor.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
                    txtruc.Visible = True
                End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            txtProveedor.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub cboTipoDoc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoDoc.SelectedValueChanged
        If cboTipoDoc.Text = "NOTA" Then
            txtSerie.Clear()
            txtNumero.Clear()
            txtSerie.Visible = False
            txtNumero.Visible = False
        Else
            txtSerie.Visible = True
            txtNumero.Visible = True
            txtSerie.Select()
        End If
    End Sub

    Private Sub FormConfirmarNotaCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
#End Region

#Region "Events"
    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        PopupControlContainer4.HidePopup(PopupCloseType.Done)
    End Sub
#End Region

End Class