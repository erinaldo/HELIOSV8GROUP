Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms
Imports System.Text.RegularExpressions
Imports Helios.Cont.Presentation.WinForm
Public Class ucNuevoCalzado
#Region "Attributes"

    Public frmNuevaExistencias As FormNuevoCalzado
    Dim listaSubCategoria As New List(Of item)
#End Region

#Region "Constructors"
    Public Sub New(form As FormNuevoCalzado)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadControles()
        'cboPresentacion.SelectedValue = "09"

        txtSubCategoria.Text = "SIN DETERMINAR"
        txtSubCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        txtSubCategoria.Tag = 0
        frmNuevaExistencias = form
    End Sub

    Public Sub New(CodigoItem As Integer, form As FormNuevoCalzado)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadControles()
        '   cboPresentacion.SelectedValue = "09"
        frmNuevaExistencias = form

        txtSubCategoria.Text = "SIN DETERMINAR"
        txtSubCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        txtSubCategoria.Tag = 0

        UbicarProducto(CodigoItem)
        Label9.Visible = True
        cboUnidades.Visible = True
        txtProductoNew.ReadOnly = True
        cboUnidades.Enabled = False
        cboIgv.Enabled = False
    End Sub
#End Region

#Region "Methods"
    Private Sub LoadControles()
        Dim categoriaSA As New itemSA
        Dim tablaSA As New tablaDetalleSA
        Dim dtUM As New DataTable

        Try


            'Dim tablaSA As New tablaDetalleSA
            Me.cboUnidades.DataSource = tablaSA.GetListaTablaDetalle(6, "1")
            Me.cboUnidades.DisplayMember = "descripcion"
            Me.cboUnidades.ValueMember = "codigoDetalle"
            'Me.cboEntidadFinanciera.DataSource = estadoSA.ObtenerEstadosFinancierosPorTipo(GEstableciento.IdEstablecimiento, tiping, strBusqueda)
            'Me.cboEntidadFinanciera.DisplayMember = "descripcion"
            'Me.cboEntidadFinanciera.ValueMember = "idestado"
            'Me.cboPresentacion.DataSource = tablaSA.GetListaTablaDetalle(21, "1")
            'Me.cboPresentacion.DisplayMember = "descripcion"
            'Me.cboPresentacion.ValueMember = "codigoDetalle"






            'CboClasificacion.DisplayMember = "descripcion"
            'CboClasificacion.ValueMember = "idItem"
            'CboClasificacion.DataSource = categoriaSA.GetListaPadre()


            'dtUM.Columns.Add("ID")
            'dtUM.Columns.Add("Name")
            'For Each i In tablaSA.GetListaTablaDetalle(6, "1")
            '    dtUM.Rows.Add(i.codigoDetalle, i.descripcion)
            'Next
            'Me.AutoComplete1.DataSource = dtUM
            'Me.AutoComplete1.SetAutoComplete(Me.txtUm, Syncfusion.Windows.Forms.Tools.AutoCompleteModes.MultiSuggestExtended)

            'Dim dtPresentacion As New DataTable
            'dtPresentacion.Columns.Add("IDPres")
            'dtPresentacion.Columns.Add("NamePres")

            'For Each i In tablaSA.GetListaTablaDetalle(21, "1")
            '    dtPresentacion.Rows.Add(i.codigoDetalle, i.descripcion)
            'Next
            'Me.AutoComplete2.DataSource = dtPresentacion
            'Me.AutoComplete2.SetAutoComplete(Me.txtCodPresentacion, Syncfusion.Windows.Forms.Tools.AutoCompleteModes.MultiSuggestExtended)


            'cboUnidades.DisplayMember = "descripcion"
            'cboUnidades.ValueMember = "codigoDetalle"
            'cboUnidades.DataSource = tablaSA.GetListaTablaDetalle(6, "1")


            'cboPresentacion.DisplayMember = "descripcion"
            'cboPresentacion.ValueMember = "codigoDetalle"
            'cboPresentacion.DataSource = tablaSA.GetListaTablaDetalle(21, "1")

            'For Each i In categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento)
            '    lstCategoria.Items.Add(New Categoria(i.descripcion, i.idItem))
            'Next
            'lstCategoria.DisplayMember = "Name"
            'lstCategoria.ValueMember = "Id"

            cboTipoExistencia.DisplayMember = "descripcion"
            cboTipoExistencia.ValueMember = "codigoDetalle"
            cboTipoExistencia.DataSource = General.TablasGenerales.GetExistencias ' tablaSA.GetListaTablaDetalle(5, "1")


            'Label8.Visible = False
            'txtCategoria.Visible = False
            ''     PictureBox2.Visible = False
            'Label3.Visible = False
            'txtSubCategoria.Visible = False
            'PictureBox6.Visible = False
            'Label1.Visible = True
            'txtProductoNew.Visible = True
            'PictureBox1.Visible = True

            'Label1.Location = New Point(28, 45)
            'txtProductoNew.Location = New Point(28, 68)
            'PictureBox1.Location = New Point(303, 68)
            'Label1.Location = New Point(28, 95)
            'txtProductoNew.Location = New Point(28, 116)
            'PictureBox1.Location = New Point(308, 116)

        Catch ex As Exception
            ' lblEstado.Text = ex.Message
        End Try

    End Sub

    Dim listaCategoria As New List(Of item)
    Private Sub CMBClasificacion()
        Dim categoriaSA As New itemSA
        ' categoriaSA.GetListaPadre()
        listaCategoria = New List(Of item)
        listaCategoria = categoriaSA.GetListaItemsPorTipo(New item With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .tipo = TipoGrupoArticulo.CategoriaGeneral
                                                          })

    End Sub

    Sub Productoshijos()
        Dim categoriaSA As New itemSA

        Dim lista = categoriaSA.GetListaItemsPorTipo(New item With
                                                             {
                                                             .idEmpresa = Gempresas.IdEmpresaRuc,
                                                             .tipo = "M"
                                                             })

        listaSubCategoria = New List(Of item)
        listaSubCategoria.Add(New item With {
                              .idItem = 0, .descripcion = "SIN DETERMINAR"})
        listaSubCategoria.AddRange(lista)

        'Label43.Text = listaSubCategoria.Count & " items"
        'categoriaSA.GetListaMarcaPadre(Val(txtCategoria.Tag))
    End Sub

    'Public Sub GrabarMarca()

    '    Dim itemSA As New itemSA
    '    Dim item As New item
    '    Try
    '        With item
    '            .idEmpresa = Gempresas.IdEmpresaRuc
    '            .idEstablecimiento = GEstableciento.IdEstablecimiento
    '            .idPadre = txtCategoria.Tag
    '            .descripcion = txtmarca.Text.Trim
    '            .fechaIngreso = DateTime.Now
    '            .utilidad = 0
    '            .utilidadmayor = 0
    '            .utilidadgranmayor = 0
    '            .usuarioActualizacion = usuario.IDUsuario
    '            .fechaActualizacion = DateTime.Now
    '        End With

    '        Dim codx As Integer = itemSA.InsertarMarcaHijo(item)
    '        'lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx, 0, 0, 0))
    '        'Me.txtCategoria.Tag = CStr(codx)
    '        'txtCategoria.Text = txtNewClasificacion.Text.Trim
    '        Productoshijos()
    '        'ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, 0, 0, 0)
    '    Catch ex As Exception
    '        '   lblEstado.Text = (ex.Message)
    '    End Try
    'End Sub


    Public Sub UbicarProducto(intIdItem As Integer)
        Dim itemSA As New detalleitemsSA
        Dim categoriaSA As New itemSA
        Dim totales As New TotalesAlmacenSA
        Dim prod As detalleitems
        Try
            prod = itemSA.InvocarProductoID(intIdItem)

            With prod

                'If prod.detalleitems_conexo Is Nothing Then
                '    frmNuevaExistencias.BunifuFlatButton2.Visible = False
                'Else
                '    If prod.detalleitems_conexo.Count > 0 Then
                '        frmNuevaExistencias.BunifuFlatButton2.Visible = True
                '        MappingItemsConexos(prod.detalleitems_conexo.ToList)
                '    Else
                '        frmNuevaExistencias.BunifuFlatButton2.Visible = False
                '    End If
                'End If

                txtProductoNew.Text = .descripcionItem
                txtProductoNew.Tag = .codigodetalle
                'txtSubCategoria.Tag = .idFamilia
                txtCodigoBarra.Text = .codigo
                'If txtCodigoBarra.Text.Trim.Length > 0 Then
                '    chAsigar.Checked = True
                'End If

                Dim codMarca = .unidad2
                If Not IsNothing(.idItem) Then
                    Dim codFamili = .idItem


                    With categoriaSA.UbicarCategoriaPorID(codFamili)
                        txtCategoria.Text = .descripcion
                        txtCategoria.Tag = .idItem
                        txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                        ''txtCategoria.Tag = .idPadre
                        'CMBClasificacion()
                        'Dim consulta = (From n In listaCategoria _
                        '     Where n.idFamilia = .idPadre).First
                        'With consulta
                        '    txtCategoria.Tag = consulta.idFamilia
                        '    txtCategoria.Text = consulta.nombre
                        '    txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        'End With
                    End With
                End If

                'Productoshijos()
                With categoriaSA.UbicarCategoriaPorID(codMarca)
                    txtSubCategoria.Text = .descripcion
                    txtSubCategoria.Tag = .idItem
                    txtSubCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                End With



                cboTipoExistencia.SelectedValue = .tipoExistencia
                cboTipoExistencia.Enabled = False
                'txtUm.Text = .unidad1
                Dim um = .unidad1
                cboUnidades.SelectedValue = .unidad1
                TextPresentacion.Text = .presentacion
                'cboPresentacion.SelectedValue = .presentacion
                txtValUnid.DecimalValue = 0 ' Decimal.Parse(.composicion)
                Select Case .origenProducto
                    Case OperacionGravada.Grabado
                        cboIgv.Text = "1 - GRAVADO"
                    Case OperacionGravada.Exonerado
                        cboIgv.Text = "2 - EXONERADO"
                    Case OperacionGravada.Inafecto
                        cboIgv.Text = "3 - INAFECTO"
                End Select

                If .tipoOtroImpuesto = "ICBPER" Then
                    ToggleAfectaICBPER.ToggleState = ToggleButton2.ToggleButtonState.ON
                    Label12.Visible = True
                    NudIcbper.Visible = True


                End If


                CBProductoRestringido.Checked = .productoRestringido
                textCantMinima.Value = .cantidadMinima
                textCantMaxima.Value = .cantidadMaxima

                Select Case .AfectoStock
                    Case False ' ToggleButton2.ToggleButtonState.OFF 'NO AFECTA STOCK
                        ToggleAfectaStock.ToggleState = ToggleButton2.ToggleButtonState.OFF
                    Case True ' ToggleButton2.ToggleButtonState.ON ' SI AFECTA STOCK
                        'objitem.AfectoStock = True
                        ToggleAfectaStock.ToggleState = ToggleButton2.ToggleButtonState.ON
                    Case Else
                        ToggleAfectaStock.ToggleState = ToggleButton2.ToggleButtonState.OFF
                End Select

            End With


            'If txtCategoria.Text.Trim.Length > 0 Then

            '    chClasificacion.Enabled = False
            '    Label8.Visible = True
            '    txtCategoria.Visible = True
            '    PictureBox2.Visible = True
            '    'Label3.Visible = True
            '    'txtSubCategoria.Visible = True
            '    'PictureBox6.Visible = True
            '    Label1.Visible = True
            '    txtProductoNew.Visible = True
            '    PictureBox1.Visible = True


            '    Label1.Location = New Point(28, 203)
            '    txtProductoNew.Location = New Point(28, 226)
            '    PictureBox1.Location = New Point(303, 226)
            'Else


            '    chClasificacion.Enabled = False
            '    Label8.Visible = False
            '    txtCategoria.Visible = False
            '    PictureBox2.Visible = False
            '    'Label3.Visible = False
            '    'txtSubCategoria.Visible = False
            '    'PictureBox6.Visible = False
            '    Label1.Visible = True
            '    txtProductoNew.Visible = True
            '    PictureBox1.Visible = True

            '    txtCategoria.Tag = Nothing
            '    txtCategoria.Clear()
            '    txtSubCategoria.Tag = Nothing
            '    txtSubCategoria.Clear()
            '    'txtProductoNew.Clear()

            '    Label1.Location = New Point(28, 95)
            '    txtProductoNew.Location = New Point(28, 116)
            '    PictureBox1.Location = New Point(308, 116)
            'End If

            Dim foto = prod.fotoUrl
            If foto IsNot Nothing Then

                If foto.ToString.Trim.Length > 0 Then
                    PictureBox2.Image = Image.FromFile(prod.fotoUrl)
                Else
                    PictureBox2.Image = ImageListAdv1.Images(0)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MappingItemsConexos(Conexos As List(Of detalleitems_conexo))
        '   frmNuevaExistencias.UCItemsAnexos.LoadProductosConexos(Conexos)
    End Sub

    Public Sub ListaItemsRecurremtes()
        Dim producto As New detalleitems With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .descripcionItem = txtProductoNew.Text}
        Dim itemSA As New detalleitemsSA

        lstProductos.DisplayMember = "descripcionItem"
        lstProductos.ValueMember = "codigodetalle"
        lstProductos.DataSource = itemSA.ReviewProductos(producto)
    End Sub


    'Public Sub GrabarItemEstablec()
    '    Dim objitem As New detalleitems
    '    Dim itemSA As New detalleitemsSA
    '    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
    '    datos.Clear()
    '    Dim c As New RecuperarCarteras
    '    Try
    '        'Se asigna cada uno de los datos registrados
    '        'objitem.idItem = CInt(txtCategoria.Tag)  ' Trim(txtCodigoDocumento.Text)
    '        objitem.idItem = txtCategoria.Tag
    '        objitem.idEmpresa = Gempresas.IdEmpresaRuc
    '        objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
    '        objitem.marcaRef = txtSubCategoria.Tag
    '        'objitem.cuenta = Nothing
    '        objitem.descripcionItem = txtProductoNew.Text.Trim
    '        'objitem.presentacion = txtPresentacion.ValueMember
    '        '  objitem.presentacion = cboPresentacion.SelectedValue
    '        'objitem.unidad1 = txtNomUnidad.ValueMember
    '        objitem.unidad1 = cboUnidades.SelectedValue
    '        objitem.unidad2 = txtSubCategoria.Tag
    '        objitem.cuenta = "601111"
    '        objitem.composicion = txtValUnid.DecimalValue

    '        objitem.cantMax = nudCantMax.Value
    '        objitem.cantMinima = nudCantMin.Value

    '        If chAsigar.Checked = True Then
    '            objitem.codigo = txtCodigoBarra.Text
    '        Else
    '            objitem.codigo = Nothing
    '        End If

    '        objitem.tipoExistencia = cboTipoExistencia.SelectedValue
    '        Select Case cboIgv.Text
    '            Case "1 - GRAVADO"
    '                objitem.origenProducto = OperacionGravada.Grabado
    '            Case "2 - EXONERADO"
    '                objitem.origenProducto = OperacionGravada.Exonerado
    '            Case "3 - INAFECTO"
    '                objitem.origenProducto = OperacionGravada.Inafecto
    '        End Select
    '        objitem.tipoProducto = "I"
    '        'objitem.fechaLote = txtFechalote.Value

    '        objitem.Percepcion = ChPercepcion.Checked
    '        objitem.Retencion = ChRetencion.Checked
    '        objitem.AfectoCompra = ChCompra.Checked
    '        objitem.AfectoVenta = ChVenta.Checked
    '        objitem.ValorPercepcion = txtValorPercepcion.DecimalValue
    '        objitem.ValorRetencion = txtValorRetencion.DecimalValue

    '        objitem.usuarioActualizacion = usuario.IDUsuario
    '        objitem.fechaActualizacion = DateTime.Now
    '        'If Precios = True Then
    '        objitem.idAlmacen = Nothing
    '        objitem.estado = "A"

    '        Dim listaItemsParecidos = itemSA.GetExistenciasByempresaNombre(objitem.descripcionItem, Gempresas.IdEmpresaRuc)
    '        If listaItemsParecidos.Count > 0 Then
    '            Dim f As New FormArticulosHomogeneos(listaItemsParecidos)
    '            f.StartPosition = FormStartPosition.CenterParent
    '            f.ShowDialog(Me)
    '            If f.Tag IsNot Nothing Then
    '                Select Case f.Tag
    '                    Case "Cancel"
    '                        Exit Sub
    '                End Select
    '            End If
    '        End If
    '        If UCEquivalencias IsNot Nothing Then
    '            If UCEquivalencias.ListaEquivalencia IsNot Nothing Then
    '                objitem.detalleitem_equivalencias = UCEquivalencias.ListaEquivalencia ' Tag
    '            End If
    '        End If

    '        Dim codxIdtem As Integer = itemSA.InsertItemDualTabla(objitem)
    '        Me.lblEstado.Text = "Item registrado!"
    '        c.Cuenta = "Grabado"
    '        c.ID = codxIdtem
    '        c.IdEvento = txtSubCategoria.Tag
    '        c.NomEvento = txtSubCategoria.Text
    '        datos.Add(c)
    '        '---------------------------------------------------------------------------------------
    '        '---------------------------------------------------------------------------------------
    '        'If (MessageBox.Show("Desea asignar el precio ahora ?", "Precio", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
    '        '    Dim form As New frmExistenciaPrecios(txtProductoNew.Text.Trim)
    '        '    form.StartPosition = FormStartPosition.CenterParent
    '        '    form.ShowDialog(Me)
    '        'End If
    '        '---------------------------------------------------------------------------------------
    '        '---------------------------------------------------------------------------------------
    '        Dispose()
    '        'Else
    '        '    Dim codxIdtem As Integer = itemSA.InsertNuevaItems(objitem)
    '        '    Me.lblEstado.Image = My.Resources.ok4
    '        '    Me.lblEstado.Text = "Item registrado!"
    '        '    c.Cuenta = "Grabado"
    '        '    c.ID = codxIdtem
    '        '    c.IdEvento = txtCategoria.Tag
    '        '    datos.Add(c)
    '        '    Dispose()
    '        'End If


    '    Catch ex As Exception
    '        'Manejo de errores
    '        'lblEstado.Text = ex.Message
    '        MessageBox.Show("La existencia ingresada tiene un codigo que ya esta siendo utilizada cambie el codigo", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    End Try
    'End Sub

    'Public Sub EditarItemEstablec()
    '    Dim objitem As New detalleitems
    '    Dim itemSA As New detalleitemsSA
    '    Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
    '    datos.Clear()
    '    Dim c As New RecuperarCarteras
    '    Try
    '        'Se asigna cada uno de los datos registrados
    '        objitem.codigodetalle = CInt(txtProductoNew.Tag)
    '        objitem.idItem = txtCategoria.Tag    ' Trim(txtCodigoDocumento.Text)
    '        objitem.NomClasificacion = txtCategoria.Text
    '        objitem.idEmpresa = Gempresas.IdEmpresaRuc
    '        objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
    '        objitem.cuenta = Nothing
    '        objitem.marcaRef = txtSubCategoria.Tag
    '        objitem.NomMarca = txtSubCategoria.Text
    '        objitem.descripcionItem = txtProductoNew.Text.Trim
    '        'objitem.presentacion = txtPresentacion.ValueMember
    '        '  objitem.presentacion = cboPresentacion.SelectedValue
    '        objitem.cantMax = 0 'nudCantMax.Value
    '        objitem.cantMinima = 0 ' nudCantMin.Value
    '        ' objitem.unidad1 = txtNomUnidad.ValueMember
    '        objitem.unidad1 = cboUnidades.SelectedValue
    '        objitem.codigo = txtCodigoBarra.Text
    '        objitem.unidad2 = txtSubCategoria.Tag
    '        ' objitem.Unidad2 = IIf(IsNothing(cboUM2.Text) Or String.IsNullOrEmpty(cboUM2.Text) Or String.IsNullOrWhiteSpace(cboUM2.Text), Nothing, Trim(cboUM2.SelectedValue))
    '        objitem.tipoExistencia = cboTipoExistencia.SelectedValue
    '        Select Case cboIgv.Text
    '            Case "1 - GRAVADO"
    '                objitem.origenProducto = OperacionGravada.Grabado
    '            Case "2 - EXONERADO"
    '                objitem.origenProducto = OperacionGravada.Exonerado
    '            Case "3 - INAFECTO"
    '                objitem.origenProducto = OperacionGravada.Inafecto
    '        End Select
    '        objitem.tipoProducto = "I"
    '        'objitem.fechaLote = txtFechalote.Value
    '        objitem.usuarioActualizacion = usuario.IDUsuario
    '        objitem.fechaActualizacion = DateTime.Now

    '        objitem.idAlmacen = Nothing
    '        itemSA.UpdateProducto(objitem)
    '        ' Me.lblEstado.Text = "Item registrado!"
    '        c.Cuenta = "Grabado"
    '        c.ID = txtProductoNew.Tag
    '        c.IdEvento = txtSubCategoria.Tag
    '        c.NomEvento = txtSubCategoria.Text
    '        datos.Add(c)
    '        Tag = objitem
    '        'Close()

    '    Catch ex As Exception
    '        'Manejo de errores
    '        MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        '    lblEstado.Text = ex.Message
    '    End Try
    'End Sub

#Region "CATEGORIA"
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

#End Region
#End Region

#Region "Events"
    Private Sub txtCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaCategoria
                            Where n.descripcion.StartsWith(txtCategoria.Text)).ToList

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
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
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

    Private Sub txtCategoria_TextChanged_1(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged
        txtCategoria.ForeColor = Color.White
        txtCategoria.Tag = Nothing
    End Sub

    Private Sub txtSubCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSubCategoria.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcSubCategoria.Font = New Font("Segoe UI", 8)
            Me.pcSubCategoria.Size = New Size(241, 110)
            Me.pcSubCategoria.ParentControl = Me.txtSubCategoria
            Me.pcSubCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaSubCategoria
                            Where n.descripcion.StartsWith(txtSubCategoria.Text)).ToList

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
            Me.pcSubCategoria.ParentControl = Me.txtSubCategoria
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

    Private Sub txtSubCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtSubCategoria.TextChanged
        txtSubCategoria.ForeColor = Color.White
        txtSubCategoria.Tag = Nothing
    End Sub

    Private Sub lsvCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvCategoria.SelectedIndexChanged

    End Sub

    Private Sub lsvSubCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvSubCategoria.MouseDoubleClick
        Me.pcSubCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub lsvSubCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvSubCategoria.SelectedIndexChanged

    End Sub

    Private Sub pcSubCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcSubCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor
        'If txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvSubCategoria.SelectedItems.Count > 0 Then
                txtSubCategoria.Text = lsvSubCategoria.Text
                txtSubCategoria.Tag = lsvSubCategoria.SelectedValue
                txtSubCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If
        'End If


        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtSubCategoria.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCategoria.SelectedItems.Count > 0 Then
                txtCategoria.Text = lsvCategoria.Text
                txtCategoria.Tag = lsvCategoria.SelectedValue
                txtSubCategoria.Clear()
                txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                ' Label43.Text = "0 items"
                '  Productoshijos()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Cursor = Cursors.WaitCursor
        ListaItemsRecurremtes()
        Me.pcMercaderia.Font = New Font("Segoe UI", 8)
        Me.pcMercaderia.Size = New Size(294, 110)
        Me.pcMercaderia.ParentControl = Me.txtProductoNew
        Me.pcMercaderia.ShowPopup(Point.Empty)
        Me.Cursor = Cursors.Arrow
    End Sub


    'Private Sub chAsigar_CheckStateChanged(sender As Object, e As EventArgs) Handles chAsigar.CheckStateChanged
    '    '   If chAsigar.Checked = True Then
    '    txtCodigoBarra.Enabled = True
    '        txtCodigoBarra.Select()
    '    'Else
    '    '    txtCodigoBarra.Clear()
    '    '    txtCodigoBarra.Enabled = False
    '    'End If
    'End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim datos As List(Of item) = item.Instance()
        datos.Clear()


        Dim f As New frmNuevaMarca
        f.StartPosition = FormStartPosition.CenterParent
        f.txtCodigo.Tag = txtCategoria.Tag
        f.txtCodigo.Text = txtCategoria.Tag

        f.txtDescripcion.Text = txtSubCategoria.Text
        txtSubCategoria.Clear()

        f.ShowDialog()
        Productoshijos()

        If datos.Count > 0 Then
            txtSubCategoria.Text = datos(0).descripcion
            txtSubCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtSubCategoria.Tag = CInt(datos(0).idItem)
        End If
    End Sub

    Private Sub UCNuenExistencia_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtCategoria.Select()
        CMBClasificacion()
        Productoshijos()
        'Label1.Location = New Point(28, 203)
        'txtProductoNew.Location = New Point(28, 226)
        'PictureBox1.Location = New Point(303, 226)
        Label3.Visible = True
        txtSubCategoria.Visible = True
        PictureBox6.Visible = True
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Dim datos As List(Of item) = item.Instance()
        datos.Clear()

        Dim f As New frmNuevaClasificacion
        f.txtDescripcion.Text = txtCategoria.Text
        txtCategoria.Clear()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()

        CMBClasificacion()
        If datos.Count > 0 Then
            txtCategoria.Text = datos(0).descripcion
            txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            txtCategoria.Tag = CInt(datos(0).idItem)
        End If
    End Sub

    Private Sub cboUnidades_Click(sender As Object, e As EventArgs) Handles cboUnidades.Click

    End Sub

    Private Sub cboUnidades_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboUnidades.SelectedValueChanged
        'If frmNuevaExistencias.UCEquivalencias IsNot Nothing Then
        '    frmNuevaExistencias.UCEquivalencias.Visible = True
        '    frmNuevaExistencias.UCEquivalencias.txtProveedor.Text = frmNuevaExistencias.UCNuenExistencia.txtProductoNew.Text.Trim
        '    frmNuevaExistencias.UCEquivalencias.TextPresentacion.Text = frmNuevaExistencias.UCNuenExistencia.TextPresentacion.Text.Trim
        '    frmNuevaExistencias.UCEquivalencias.TextPresentacion.Tag = CDec(frmNuevaExistencias.UCNuenExistencia.txtValUnid.DecimalValue)

        '    UCEquivalencias.ListaEquivalencia = New List(Of detalleitem_equivalencias)
        '    UCEquivalencias.CargarEquivalenciasDefault()
        '    'UCEquivalencias.BringToFront()
        '    UCEquivalencias.Show()
        '    btOperacion.Text = "Aceptar"
        'End If
    End Sub

    Private Sub TextPresentacion_TextChanged(sender As Object, e As EventArgs) Handles TextPresentacion.TextChanged

    End Sub

    Private Sub txtProductoNew_TextChanged(sender As Object, e As EventArgs) Handles txtProductoNew.TextChanged
        TextPresentacion.Text = txtProductoNew.Text
    End Sub

    Private Sub txtProductoNew_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtProductoNew.KeyPress
        Dim re As New Regex("^[|_''!°@#[]$%&/()=?¿.¡}´]*$", RegexOptions.IgnoreCase)
        e.Handled = re.IsMatch(e.KeyChar)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CBProductoRestringido.CheckedChanged

    End Sub



    Private Sub ToggleAfectaICBPER_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleAfectaICBPER.ButtonStateChanged
        If ToggleAfectaICBPER.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            Label12.Visible = True
            NudIcbper.Visible = True
        Else
            Label12.Visible = False
            NudIcbper.Visible = False
        End If

    End Sub

    Private Sub ToggleAfectaICBPER_Click(sender As Object, e As EventArgs) Handles ToggleAfectaICBPER.Click

    End Sub

    Private Sub CboTipoExistencia_Click(sender As Object, e As EventArgs) Handles cboTipoExistencia.Click

    End Sub

    Private Sub cboTipoExistencia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedValueChanged
        If frmNuevaExistencias Is Nothing Then Exit Sub
        Select Case cboTipoExistencia.Text
            Case "KIT"
                If frmNuevaExistencias.EstadoManipulacion = ENTITY_ACTIONS.INSERT Then
                    frmNuevaExistencias.BunifuFlatButton2.Visible = True
                Else
                    frmNuevaExistencias.BunifuFlatButton2.Visible = False
                End If

            Case Else
                frmNuevaExistencias.BunifuFlatButton2.Visible = False
        End Select
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Dim strFileName As String = ""
        OpenFileDialog1.InitialDirectory = "C:\"
        OpenFileDialog1.Title = "Open an Image"
        OpenFileDialog1.Filter = "jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp"
        Dim DidWork As Integer = OpenFileDialog1.ShowDialog()

        PictureBox2.Image.Tag = Nothing

        If DidWork <> DialogResult.Cancel Then
            strFileName = OpenFileDialog1.FileName
            PictureBox2.Image = Image.FromFile(strFileName)
            PictureBox2.Image.Tag = strFileName
            OpenFileDialog1.Reset()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

    End Sub




#End Region
End Class
