Imports Helios.General
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms
Public Class frmCambioProductoDetalleV1

#Region "Attributes"
    Dim categoriaSA As New itemSA
    Dim tablaSA As New tablaDetalleSA
    Dim dtUM As New DataTable
    Dim listaCategoria As New List(Of item)
    Dim listaSubCategoria As New List(Of item)
    Public Property almacenSA As New almacenSA
    Public Property TotalesAlmacenSA As New TotalesAlmacenSA
    Public Property itemSA As New detalleitemsSA
    Public Property articulo As detalleitems

    Dim documento As documento
    Dim documentocompra As documentocompra
    Dim objDocumentoCompraDet As documentocompradetalle
    Dim ListaDetalle As List(Of documentocompradetalle)
    Public Property DocumentoCompraSA As New DocumentoCompraSA
#End Region

#Region "Constructors"
    Public Sub New(be As totalesAlmacen)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CMBClasificacion()
        LoadControles()
        txtGrupo2.Select()
        UbicarProducto(be)
        txtNombre2.Clear()
    End Sub
#End Region

#Region "Methods"

    Public Sub GetCambioSave()
        documento = New documento
        documento.Action = Business.Entity.BaseBE.EntityAction.INSERT
        documento.idEmpresa = Gempresas.IdEmpresaRuc
        documento.idCentroCosto = GEstableciento.IdEstablecimiento
        documento.tipoDoc = "99"
        documento.fechaProceso = txtFechaIngreso.Value
        documento.nroDoc = "-"
        documento.idOrden = Nothing ' Me.IdOrden
        documento.moneda = "1"
        documento.idEntidad = 0
        documento.entidad = "SIN IDENTIDAD"
        documento.tipoEntidad = "OT"
        documento.nrodocEntidad = "-"

        documento.tipoOperacion = "0001"
        documento.usuarioActualizacion = usuario.IDUsuario
        documento.fechaActualizacion = DateTime.Now

        'CABECERA
        documentocompra = New documentocompra
        documentocompra.situacion = "0001"
        documentocompra.codigoLibro = "13"
        documentocompra.tipoDoc = "99"
        documentocompra.idEmpresa = Gempresas.IdEmpresaRuc
        documentocompra.idCentroCosto = GEstableciento.IdEstablecimiento
        documentocompra.fechaLaboral = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        documentocompra.fechaDoc = txtFechaIngreso.Value ' PERIODO
        documentocompra.fechaContable = String.Format("{0:00}", txtFechaIngreso.Value.Month) & "/" & txtFechaIngreso.Value.Year
        documentocompra.serie = "-"
        documentocompra.numeroDoc = "-"
        documentocompra.aprobado = "N"
        documentocompra.idProveedor = 0
        documentocompra.nombreProveedor = "SIN IDENTIDAD"
        documentocompra.monedaDoc = "1"
        documentocompra.tasaIgv = 0 ' IIf(IsNothing(nudIgv.Value) Or String.IsNullOrEmpty(nudIgv.Value) Or String.IsNullOrWhiteSpace(nudIgv.Value), Nothing, Trim(nudIgv.Value))
        documentocompra.tcDolLoc = 0
        documentocompra.tipoRecaudo = Nothing
        documentocompra.regimen = Nothing
        documentocompra.tasaRegimen = 0
        documentocompra.nroRegimen = Nothing
        documentocompra.importeTotal = CDec(txtImporte2.Text)
        documentocompra.importeUS = 0
        documentocompra.destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.SALIDA_EXISTENCIAS
        documentocompra.estadoPago = TIPO_COMPRA.PAGO.PAGADO
        documentocompra.glosa = "Cambio de existencias"
        documentocompra.referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
        documentocompra.tipoCompra = TIPO_VENTA.CambioArticulo
        documentocompra.usuarioActualizacion = usuario.IDUsuario
        documentocompra.fechaActualizacion = DateTime.Now
        documento.documentocompra = documentocompra

        'DETALLE 
        ListaDetalle = New List(Of documentocompradetalle)

        objDocumentoCompraDet = New documentocompradetalle
        objDocumentoCompraDet.FechaLaboral = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        objDocumentoCompraDet.Serie = "-"
        objDocumentoCompraDet.NumDoc = "-"
        objDocumentoCompraDet.TipoDoc = "99"
        objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
        objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
        objDocumentoCompraDet.tipoCompra = TIPO_VENTA.CambioArticulo
        objDocumentoCompraDet.TipoOperacion = "0001"
        objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
        objDocumentoCompraDet.FechaDoc = txtFechaIngreso.Value
        objDocumentoCompraDet.CuentaProvedor = "4212"
        objDocumentoCompraDet.NombreProveedor = "SIN IDENTIDAD"
        Select Case cboGravado2.Text
            Case "1 - GRAVADO"
                objDocumentoCompraDet.destino = OperacionGravada.Grabado
            Case "2 - EXONERADO"
                objDocumentoCompraDet.destino = OperacionGravada.Exonerado
            Case "3 - INAFECTO"
                objDocumentoCompraDet.destino = OperacionGravada.Inafecto
        End Select

        'If rbNuevo.Checked = True Then
        objDocumentoCompraDet.idItem = Val(txtProductoNew.Tag)
        'Else
        '    objDocumentoCompraDet.idItem = Val(txtNombre2.Tag)
        'End If
        objDocumentoCompraDet.tipoExistencia = cboTipoEx2.SelectedValue
        objDocumentoCompraDet.descripcionItem = txtProductoNew.Text
        objDocumentoCompraDet.DescripcionArticulo2 = txtNombre2.Text.Trim
        objDocumentoCompraDet.unidad1 = cboUM2.SelectedValue
        objDocumentoCompraDet.monto1 = CDec(txtCant2.Text)
        objDocumentoCompraDet.unidad2 = cboPresentacion2.SelectedValue
        objDocumentoCompraDet.monto2 = cboPresentacion2.Text
        objDocumentoCompraDet.precioUnitario = 0
        objDocumentoCompraDet.precioUnitarioUS = 0
        objDocumentoCompraDet.importe = CDec(txtImporte2.Text)
        objDocumentoCompraDet.importeUS = 0
        objDocumentoCompraDet.FechaVcto = Nothing
        objDocumentoCompraDet.preEvento = Nothing
        objDocumentoCompraDet.IdEstablecimiento = almacenSA.GetUbicar_almacenPorID(cboAlmacen.SelectedValue).idEstablecimiento
        objDocumentoCompraDet.almacenRef = cboAlmacen.SelectedValue ' almacen de destino
        objDocumentoCompraDet.almacenDestino = txtAlmacen1.Tag ' almacen de origen
        objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
        objDocumentoCompraDet.fechaModificacion = DateTime.Now
        objDocumentoCompraDet.Glosa = "Cambio de existencias"
        ListaDetalle.Add(objDocumentoCompraDet)

        documento.documentocompra.documentocompradetalle = ListaDetalle

        articulo = New detalleitems

        If rbNuevo.Checked = True Then
            articulo.FlagArticuloNuevo = True
        Else
            articulo.FlagArticuloNuevo = False
            articulo.idItem = txtNombre2.Tag
        End If

        articulo.idEmpresa = Gempresas.IdEmpresaRuc
        articulo.idEstablecimiento = GEstableciento.IdEstablecimiento
        articulo.cuenta = "6011"
        articulo.descripcionItem = txtNombre2.Text
        articulo.presentacion = cboPresentacion2.SelectedValue
        articulo.unidad1 = cboUM2.SelectedValue
        articulo.unidad2 = Nothing
        articulo.tipoExistencia = cboTipoEx2.SelectedValue
        Select Case cboGravado2.Text
            Case "1 - GRAVADO"
                articulo.origenProducto = OperacionGravada.Grabado
            Case "2 - EXONERADO"
                articulo.origenProducto = OperacionGravada.Exonerado
            Case "3 - INAFECTO"
                articulo.origenProducto = OperacionGravada.Inafecto
        End Select
        articulo.tipoProducto = "I"
        articulo.codigo = txtCodBarra2.Text
        articulo.estado = "A"
        articulo.usuarioActualizacion = usuario.IDUsuario
        articulo.fechaActualizacion = Date.Now
        articulo.CantidadKardex = CDec(txtCant2.Text)
        articulo.ImporteKardex = CDec(txtImporte2.Text)

        Dim codProd = DocumentoCompraSA.GrabarCambioArticulo(documento, articulo)
        MessageBox.Show("Registro gravado correctamente")

        If rbNuevo.Checked = True Then
            If MessageBox.Show("Desea configurar precios", "Asignar precios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Dim f As New frmNuevoPrecio
                f.txtProducto.Tag = codProd
                f.txtProducto.Text = articulo.descripcionItem
                f.txtGrav.Text = articulo.origenProducto
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
        Close()
    End Sub

    Public Sub UbicarProducto(be As totalesAlmacen)
        With itemSA.InvocarProductoID(be.idItem)
            txtProductoNew.Text = .descripcionItem
            txtNombre2.Text = .descripcionItem
            txtProductoNew.Tag = .codigodetalle
            'txtSubCategoria.Tag = .idFamilia
            txtCodigoBarra.Text = .codigo
            txtCodBarra2.Text = .codigo

            If Not IsNothing(.idItem) Then
                Dim codFamili = .idItem
                Dim codMarca = .marcaRef

                With categoriaSA.UbicarCategoriaPorID(codFamili)
                    txtCategoria.Text = .descripcion
                    txtCategoria.Tag = .idItem
                    txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                    txtGrupo2.Text = .descripcion
                    txtGrupo2.Tag = .idItem
                    txtGrupo2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                End With

                With categoriaSA.UbicarCategoriaPorID(codMarca)
                    txtSubCategoria.Text = .descripcion
                    txtSubCategoria.Tag = .idItem
                    txtSubCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                    txtMarca2.Text = .descripcion
                    txtMarca2.Tag = .idItem
                    txtMarca2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                End With
                GetSubCategorias()
            End If

            cboTipoExistencia.SelectedValue = .tipoExistencia
            cboTipoEx2.SelectedValue = .tipoExistencia
            'txtUm.Text = .unidad1
            cboUnidades.SelectedValue = .unidad1
            cboUM2.SelectedValue = .unidad1
            'txtCodPresentacion.Text = .presentacion
            cboPresentacion.SelectedValue = .presentacion
            cboPresentacion2.SelectedValue = .presentacion

            Select Case .origenProducto
                Case OperacionGravada.Grabado
                    cboIgv.Text = "1 - GRAVADO"
                    cboGravado2.Text = "1 - GRAVADO"
                Case OperacionGravada.Exonerado
                    cboIgv.Text = "2 - EXONERADO"
                    cboGravado2.Text = "2 - EXONERADO"
                Case OperacionGravada.Inafecto
                    cboIgv.Text = "3 - INAFECTO"
                    cboGravado2.Text = "3 - INAFECTO"
            End Select

        End With

        Dim codT = TotalesAlmacenSA.GetUbicar_totalesAlmacenPorID(be.idMovimiento)
        If Not IsNothing(codT) Then
            Dim codAlmacen = codT.idAlmacen
            txtAlmacen1.Tag = codT.idAlmacen

            cboAlmacen.SelectedValue = codAlmacen
            txtAlmacen1.Text = cboAlmacen.Text
            txtCant2.Text = CDec(codT.cantidad).ToString("N2")
            txtImporte2.Text = CDec(codT.importeSoles).ToString("N2")
        End If
        txtNombre2.Select()
        txtNombre2.Focus()
    End Sub

    Public Sub UbicarProductoEX(be As totalesAlmacen)
        With itemSA.InvocarProductoID(be.idItem)

            txtNombre2.Text = .descripcionItem
            txtNombre2.Tag = .codigodetalle
            txtCodBarra2.Text = .codigo

            If Not IsNothing(.idItem) Then
                Dim codFamili = .idItem
                Dim codMarca = .marcaRef

                With categoriaSA.UbicarCategoriaPorID(codFamili)
                    txtGrupo2.Text = .descripcion
                    txtGrupo2.Tag = .idItem
                    txtGrupo2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                End With

                With categoriaSA.UbicarCategoriaPorID(codMarca)
                    txtMarca2.Text = .descripcion
                    txtMarca2.Tag = .idItem
                    txtMarca2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                End With
                GetSubCategorias()

            End If
            cboTipoEx2.SelectedValue = .tipoExistencia
            cboUM2.SelectedValue = .unidad1
            cboPresentacion2.SelectedValue = .presentacion

            Select Case .origenProducto
                Case OperacionGravada.Grabado
                    cboGravado2.Text = "1 - GRAVADO"
                Case OperacionGravada.Exonerado
                    cboGravado2.Text = "2 - EXONERADO"
                Case OperacionGravada.Inafecto
                    cboGravado2.Text = "3 - INAFECTO"
            End Select
        End With
    End Sub

    Sub GetSubCategorias()
        Dim categoriaSA As New itemSA
        listaSubCategoria = categoriaSA.GetListaMarcaPadre(Val(txtGrupo2.Tag))
        'Label43.Text = listaSubCategoria.Count & " items"
    End Sub

    Private Sub CMBClasificacion()
        Dim categoriaSA As New itemSA

        listaCategoria = New List(Of item)

        listaCategoria = categoriaSA.GetListaPadre()

    End Sub

    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _Utilidad As Decimal
        Private _UtilidadMayor As Decimal
        Private _UtilidadGranMayor As Decimal
        Public Sub New(ByVal name As String, ByVal id As Integer)
            _name = name
            _id = id
            _Utilidad = Utilidad
            '_UtilidadMayor = utiMayor
            '_UtilidadGranMayor = utiGranMayor
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

        Public Property Utilidad() As Decimal
            Get
                Return _Utilidad
            End Get
            Set(ByVal value As Decimal)
                _Utilidad = value
            End Set
        End Property

        Public Property UtilidadMayor() As Decimal
            Get
                Return _UtilidadMayor
            End Get
            Set(ByVal value As Decimal)
                _UtilidadMayor = value
            End Set
        End Property

        Public Property UtilidadGranMayor() As Decimal
            Get
                Return _UtilidadGranMayor
            End Get
            Set(ByVal value As Decimal)
                _UtilidadGranMayor = value
            End Set
        End Property
    End Class

    Private Sub LoadControles()
        Try

            Dim listaUnidades = tablaSA.GetListaTablaDetalle(6, "1")
            Dim listaTipoexistencia = tablaSA.GetListaTablaDetalle(5, "1")
            Dim listaPresentacion = tablaSA.GetListaTablaDetalle(21, "1")

            cboAlmacen.DisplayMember = "descripcionAlmacen"
            cboAlmacen.ValueMember = "idAlmacen"
            cboAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

            cboUnidades.DataSource = listaUnidades
            cboUnidades.DisplayMember = "descripcion"
            cboUnidades.ValueMember = "codigoDetalle2"

            cboUM2.DataSource = listaUnidades
            cboUM2.DisplayMember = "descripcion"
            cboUM2.ValueMember = "codigoDetalle2"

            cboPresentacion.DataSource = listaPresentacion
            cboPresentacion.DisplayMember = "descripcion"
            cboPresentacion.ValueMember = "codigoDetalle"

            cboPresentacion2.DataSource = listaPresentacion
            cboPresentacion2.DisplayMember = "descripcion"
            cboPresentacion2.ValueMember = "codigoDetalle"

            cboTipoExistencia.DisplayMember = "descripcion"
            cboTipoExistencia.ValueMember = "codigoDetalle"
            cboTipoExistencia.DataSource = listaTipoexistencia

            cboTipoEx2.DisplayMember = "descripcion"
            cboTipoEx2.ValueMember = "codigoDetalle"
            cboTipoEx2.DataSource = listaTipoexistencia


            'Label8.Visible = False
            'txtGrupo2.Visible = False
            'Label3.Visible = False
            'txtMarca2.Visible = False
            'Label1.Visible = True
            'txtProductoNew.Visible = True
            ''Label1.Location = New Point(28, 45)
            ''txtProductoNew.Location = New Point(28, 68)
            ''PictureBox1.Location = New Point(303, 68)
            'Label1.Location = New Point(28, 95)
            'txtProductoNew.Location = New Point(28, 116)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
#End Region

#Region "Events"
    Private Sub rbNuevo_CheckedChanged(sender As Object, e As EventArgs) Handles rbNuevo.CheckedChanged
        If rbNuevo.Checked = True Then
            btExiste.Visible = False
            txtNombre2.ReadOnly = False
            txtNombre2.Clear()
        End If
    End Sub

    Private Sub rbExistente_CheckedChanged(sender As Object, e As EventArgs) Handles rbExistente.CheckedChanged
        If rbExistente.Checked = True Then
            btExiste.Visible = True
            txtNombre2.ReadOnly = True
            btExiste_Click(sender, e)
        End If
    End Sub

    Private Sub pcSubCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcSubCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If txtGrupo2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            If e.PopupCloseType = PopupCloseType.Done Then
                If lsvSubCategoria.SelectedItems.Count > 0 Then
                    txtMarca2.Text = lsvSubCategoria.Text
                    txtMarca2.Tag = lsvSubCategoria.SelectedValue
                    txtMarca2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    'ListaMercaderiasXIdHijo(Val(txtmarca2.Tag), cboTipoExistencia.SelectedValue)
                End If
            End If
        End If


        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtMarca2.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCategoria.SelectedItems.Count > 0 Then
                txtGrupo2.Text = lsvCategoria.Text
                txtGrupo2.Tag = lsvCategoria.SelectedValue
                txtMarca2.Clear()
                txtGrupo2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                ' Label43.Text = "0 items"
                GetSubCategorias()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtGrupo2.Focus()
        End If
    End Sub

    Private Sub txtGrupo2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGrupo2.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtGrupo2
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaCategoria _
                     Where n.descripcion.StartsWith(txtGrupo2.Text)).ToList

            lsvCategoria.DataSource = consulta
            lsvCategoria.DisplayMember = "descripcion"
            lsvCategoria.ValueMember = "idItem"
            'e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtGrupo2
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            lsvCategoria.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtGrupo2_TextChanged(sender As Object, e As EventArgs) Handles txtGrupo2.TextChanged
        txtGrupo2.ForeColor = Color.Black
        txtGrupo2.Tag = Nothing
    End Sub

    Private Sub txtMarca2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMarca2.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcSubCategoria.Font = New Font("Segoe UI", 8)
            Me.pcSubCategoria.Size = New Size(241, 110)
            Me.pcSubCategoria.ParentControl = Me.txtMarca2
            Me.pcSubCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaSubCategoria _
                     Where n.descripcion.StartsWith(txtMarca2.Text)).ToList

            lsvSubCategoria.DataSource = consulta
            lsvSubCategoria.DisplayMember = "descripcion"
            lsvSubCategoria.ValueMember = "idItem"
            e.Handled = True
        End If

        '  If Not Me.pcLikeCategoria.IsShowing() Then

        '   End If

        '    If Not Me.pcLikeCategoria.IsShowing() Then
        If e.KeyCode = Keys.Down Then
            Me.pcSubCategoria.Font = New Font("Segoe UI", 8)
            Me.pcSubCategoria.Size = New Size(241, 110)
            Me.pcSubCategoria.ParentControl = Me.txtMarca2
            Me.pcSubCategoria.ShowPopup(Point.Empty)
            lsvSubCategoria.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcSubCategoria.IsShowing() Then
                Me.pcSubCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub txtMarca2_TextChanged(sender As Object, e As EventArgs) Handles txtMarca2.TextChanged
        txtMarca2.ForeColor = Color.Black
        txtMarca2.Tag = Nothing
    End Sub
    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Cursor = Cursors.WaitCursor
        Try
            If txtNombre2.Text.Trim.Length > 0 Then
                If txtNombre2.Text.Trim = txtProductoNew.Text.Trim Then
                    MessageBox.Show("Debe indicar un nombre válido para el artículo", "Ingresar descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtNombre2.Select()
                    txtNombre2.SelectAll()
                    txtNombre2.Clear()
                    Cursor = Cursors.Default
                    Exit Sub
                End If
                GetCambioSave()
            Else
                MessageBox.Show("Debe indicar un nombre para el artículo", "Ingresar descripción", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtNombre2.Select()
                txtNombre2.SelectAll()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub lsvCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvSubCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvSubCategoria.MouseDoubleClick
        Me.pcSubCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub btExiste_Click(sender As Object, e As EventArgs) Handles btExiste.Click
        Dim f As New frmModalBusquedaArticulosAlmacen
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        If Not IsNothing(f.Tag) Then
            Dim c = CType(f.Tag, totalesAlmacen)
            If txtProductoNew.Tag = c.idItem Then
                MessageBox.Show("Debe seleccionar un artículo diferente al histórico", "Validar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btExiste_Click(sender, e)
            End If
            UbicarProductoEX(New totalesAlmacen With {.idItem = c.idItem})
        End If
    End Sub

    Private Sub frmCambioProductoDetalleV1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFechaIngreso.Value = Date.Now
    End Sub
#End Region

End Class