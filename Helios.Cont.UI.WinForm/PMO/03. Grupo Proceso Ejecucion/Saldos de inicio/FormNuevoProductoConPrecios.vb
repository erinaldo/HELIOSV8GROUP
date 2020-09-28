Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class FormNuevoProductoConPrecios

    Public Property Precios As Boolean = False
    Public Property IdAlmacenPrecio As Integer
    Public Property EstadoManipulacion() As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadControles()
        ' Add any initialization after the InitializeComponent() call.
        '   CargarAlmacenes()
        cboPresentacion.SelectedValue = "09"


        txtSubCategoria.Text = "SIN DETERMINAR"
        txtSubCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        txtSubCategoria.Tag = 0
    End Sub

    Public Sub New(CodigoItem As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadControles()
        UbicarProducto(CodigoItem)
    End Sub

#Region "Métodos"


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



    Public Sub GrabarMarca()

        Dim itemSA As New itemSA
        Dim item As New item
        Try
            With item
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .idPadre = txtCategoria.Tag
                .descripcion = txtmarca.Text.Trim
                .fechaIngreso = DateTime.Now
                .utilidad = 0
                .utilidadmayor = 0
                .utilidadgranmayor = 0
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx As Integer = itemSA.InsertarMarcaHijo(item)
            'lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx, 0, 0, 0))
            'Me.txtCategoria.Tag = CStr(codx)
            'txtCategoria.Text = txtNewClasificacion.Text.Trim
            '   Productoshijos()
            'ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, 0, 0, 0)
        Catch ex As Exception
            '0    lblEstado.Text = (ex.Message)
        End Try
    End Sub


    Public Sub UbicarProducto(intIdItem As Integer)
        Dim itemSA As New detalleitemsSA
        Dim categoriaSA As New itemSA
        Dim totales As New TotalesAlmacenSA


        Try


            With itemSA.InvocarProductoID(intIdItem)
                txtProductoNew.Text = .descripcionItem
                txtProductoNew.Tag = .codigodetalle
                'txtSubCategoria.Tag = .idFamilia
                txtCodigoBarra.Text = .codigo
                If txtCodigoBarra.Text.Trim.Length > 0 Then
                    chAsigar.Checked = True
                End If

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
                'txtUm.Text = .unidad1
                cboUnidades.SelectedValue = .unidad1
                'txtCodPresentacion.Text = .presentacion
                'cboPresentacion.SelectedValue = .presentacion

                Select Case .origenProducto
                    Case OperacionGravada.Grabado
                        cboIgv.Text = "1 - GRAVADO"
                    Case OperacionGravada.Exonerado
                        cboIgv.Text = "2 - EXONERADO"
                    Case OperacionGravada.Inafecto
                        cboIgv.Text = "3 - INAFECTO"
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

        Catch ex As Exception
            MessageBox.Show("Error ")
        End Try
    End Sub

    Public Sub ListaItemsRecurremtes()
        Dim producto As New detalleitems With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .descripcionItem = txtProductoNew.Text}
        Dim itemSA As New detalleitemsSA

        lstProductos.DisplayMember = "descripcionItem"
        lstProductos.ValueMember = "codigodetalle"
        lstProductos.DataSource = itemSA.ReviewProductos(producto)
    End Sub


    Public Sub GrabarItemEstablec()
        Dim objitem As New detalleitems
        Dim itemSA As New detalleitemsSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim c As New RecuperarCarteras
        Try
            'Se asigna cada uno de los datos registrados
            'objitem.idItem = CInt(txtCategoria.Tag)  ' Trim(txtCodigoDocumento.Text)
            objitem.idItem = txtCategoria.Tag
            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
            objitem.marcaRef = txtSubCategoria.Tag
            'objitem.cuenta = Nothing
            objitem.descripcionItem = txtProductoNew.Text.Trim
            'objitem.presentacion = txtPresentacion.ValueMember
            '  objitem.presentacion = cboPresentacion.SelectedValue
            'objitem.unidad1 = txtNomUnidad.ValueMember
            objitem.unidad1 = cboUnidades.SelectedValue
            objitem.unidad2 = txtSubCategoria.Tag
            objitem.cuenta = "601111"

            objitem.cantMax = nudCantMax.Value
            objitem.cantMinima = nudCantMin.Value

            If chAsigar.Checked = True Then
                objitem.codigo = txtCodigoBarra.Text
            Else
                objitem.codigo = Nothing
            End If

            objitem.tipoExistencia = cboTipoExistencia.SelectedValue
            Select Case cboIgv.Text
                Case "1 - GRAVADO"
                    objitem.origenProducto = OperacionGravada.Grabado
                Case "2 - EXONERADO"
                    objitem.origenProducto = OperacionGravada.Exonerado
                Case "3 - INAFECTO"
                    objitem.origenProducto = OperacionGravada.Inafecto
            End Select
            objitem.tipoProducto = "I"
            'objitem.fechaLote = txtFechalote.Value

            objitem.Percepcion = ChPercepcion.Checked
            objitem.Retencion = ChRetencion.Checked
            objitem.AfectoCompra = ChCompra.Checked
            objitem.AfectoVenta = ChVenta.Checked
            objitem.ValorPercepcion = txtValorPercepcion.DecimalValue
            objitem.ValorRetencion = txtValorRetencion.DecimalValue

            objitem.usuarioActualizacion = usuario.IDUsuario
            objitem.fechaActualizacion = DateTime.Now
            'If Precios = True Then
            objitem.idAlmacen = Nothing
            objitem.estado = "A"

            Dim listaItemsParecidos = itemSA.GetExistenciasByempresaNombre(objitem.descripcionItem, Gempresas.IdEmpresaRuc)
            If listaItemsParecidos.Count > 0 Then
                Dim f As New FormArticulosHomogeneos(listaItemsParecidos)
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog(Me)
                If f.Tag IsNot Nothing Then
                    Select Case f.Tag
                        Case "Cancel"
                            Exit Sub
                    End Select
                End If
            End If

            objitem.CustomPrecios = New List(Of configuracionPrecioProducto)
            objitem.CustomPrecios.Add(New configuracionPrecioProducto With {.fecha = DateTime.Now, .tipo = 1,
                                      .idPrecio = 1, .descripcion = "Precio por Menor", .precioMN = TextMenor.DecimalValue})

            objitem.CustomPrecios.Add(New configuracionPrecioProducto With {.fecha = DateTime.Now, .tipo = 1,
                                      .idPrecio = 2, .descripcion = "Precio por Mayor", .precioMN = TextMayor.DecimalValue})

            objitem.CustomPrecios.Add(New configuracionPrecioProducto With {.fecha = DateTime.Now, .tipo = 1,
                                      .idPrecio = 3, .descripcion = "Precio por Gran Mayor", .precioMN = TextGmayor.DecimalValue})

            Dim codxIdtem As Integer = itemSA.InsertItemDualTabla(objitem)
            '  Me.lblEstado.Text = "Item registrado!"
            c.Cuenta = "Grabado"
            c.ID = codxIdtem
            c.IdEvento = txtSubCategoria.Tag
            c.NomEvento = txtSubCategoria.Text
            datos.Add(c)
            '---------------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------------
            'If (MessageBox.Show("Desea asignar el precio ahora ?", "Precio", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
            '    Dim form As New frmExistenciaPrecios(txtProductoNew.Text.Trim)
            '    form.StartPosition = FormStartPosition.CenterParent
            '    form.ShowDialog(Me)
            'End If
            '---------------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------------
            Dispose()
            'Else
            '    Dim codxIdtem As Integer = itemSA.InsertNuevaItems(objitem)
            '    Me.lblEstado.Image = My.Resources.ok4
            '    Me.lblEstado.Text = "Item registrado!"
            '    c.Cuenta = "Grabado"
            '    c.ID = codxIdtem
            '    c.IdEvento = txtCategoria.Tag
            '    datos.Add(c)
            '    Dispose()
            'End If


        Catch ex As Exception
            'Manejo de errores
            'lblEstado.Text = ex.Message
            MessageBox.Show("La existencia ingresada tiene un codigo que ya esta siendo utilizada cambie el codigo", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Public Sub EditarItemEstablec()
        Dim objitem As New detalleitems
        Dim itemSA As New detalleitemsSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim c As New RecuperarCarteras
        Try
            'Se asigna cada uno de los datos registrados
            objitem.codigodetalle = CInt(txtProductoNew.Tag)
            objitem.idItem = txtCategoria.Tag    ' Trim(txtCodigoDocumento.Text)
            objitem.NomClasificacion = txtCategoria.Text
            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
            objitem.cuenta = Nothing
            objitem.marcaRef = txtSubCategoria.Tag
            objitem.NomMarca = txtSubCategoria.Text
            objitem.descripcionItem = txtProductoNew.Text.Trim
            'objitem.presentacion = txtPresentacion.ValueMember
            '  objitem.presentacion = cboPresentacion.SelectedValue
            objitem.cantMax = nudCantMax.Value
            objitem.cantMinima = nudCantMin.Value
            ' objitem.unidad1 = txtNomUnidad.ValueMember
            objitem.unidad1 = cboUnidades.SelectedValue
            objitem.codigo = txtCodigoBarra.Text
            objitem.unidad2 = txtSubCategoria.Tag
            ' objitem.Unidad2 = IIf(IsNothing(cboUM2.Text) Or String.IsNullOrEmpty(cboUM2.Text) Or String.IsNullOrWhiteSpace(cboUM2.Text), Nothing, Trim(cboUM2.SelectedValue))
            objitem.tipoExistencia = cboTipoExistencia.SelectedValue
            Select Case cboIgv.Text
                Case "1 - GRAVADO"
                    objitem.origenProducto = OperacionGravada.Grabado
                Case "2 - EXONERADO"
                    objitem.origenProducto = OperacionGravada.Exonerado
                Case "3 - INAFECTO"
                    objitem.origenProducto = OperacionGravada.Inafecto
            End Select
            objitem.tipoProducto = "I"
            'objitem.fechaLote = txtFechalote.Value
            objitem.usuarioActualizacion = usuario.IDUsuario
            objitem.fechaActualizacion = DateTime.Now

            objitem.idAlmacen = Nothing
            itemSA.UpdateProducto(objitem)
            '     Me.lblEstado.Text = "Item registrado!"
            c.Cuenta = "Grabado"
            c.ID = txtProductoNew.Tag
            c.IdEvento = txtSubCategoria.Tag
            c.NomEvento = txtSubCategoria.Text
            datos.Add(c)
            Tag = objitem
            Close()

        Catch ex As Exception
            'Manejo de errores
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '     lblEstado.Text = ex.Message
        End Try
    End Sub

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

    Public Sub GrabarCategoria()
        Dim itemSA As New itemSA
        Dim item As New item
        Try
            With item
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                '  .descripcion = txtNewClasificacion.Text.Trim
                .fechaIngreso = DateTime.Now
                .utilidad = 0
                .utilidadmayor = 0
                .utilidadgranmayor = 0
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx As Integer = itemSA.SaveCategoria(item)
            'lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx, 0, 0, 0))
            'Me.txtCategoria.Tag = CStr(codx)
            'txtCategoria.Text = txtNewClasificacion.Text.Trim

            'Productoshijos()
            CMBClasificacion()
            'ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, 0, 0, 0)
        Catch ex As Exception
            '       lblEstado.Text = (ex.Message)
        End Try
    End Sub
#End Region

    Private Sub carcagarpadre()
        Dim categoriaSA As New itemSA
        'CboClasificacion.DisplayMember = "descripcion"
        'CboClasificacion.ValueMember = "idItem"
        'CboClasificacion.DataSource = categoriaSA.GetListaPadre()
    End Sub


    Private Sub LoadControles()
        Dim categoriaSA As New itemSA
        Dim tablaSA As New tablaDetalleSA
        Dim dtUM As New DataTable

        Try


            'Dim tablaSA As New tablaDetalleSA
            Me.cboUnidades.DataSource = tablaSA.GetListaTablaDetalle(6, "1")
            Me.cboUnidades.DisplayMember = "descripcion"
            Me.cboUnidades.ValueMember = "codigoDetalle2"
            'Me.cboEntidadFinanciera.DataSource = estadoSA.ObtenerEstadosFinancierosPorTipo(GEstableciento.IdEstablecimiento, tiping, strBusqueda)
            'Me.cboEntidadFinanciera.DisplayMember = "descripcion"
            'Me.cboEntidadFinanciera.ValueMember = "idestado"
            Me.cboPresentacion.DataSource = tablaSA.GetListaTablaDetalle(21, "1")
            Me.cboPresentacion.DisplayMember = "descripcion"
            Me.cboPresentacion.ValueMember = "codigoDetalle"






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
            cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")


            Label8.Visible = False
            txtCategoria.Visible = False
            PictureBox2.Visible = False
            Label3.Visible = False
            txtSubCategoria.Visible = False
            PictureBox6.Visible = False
            Label1.Visible = True
            txtProductoNew.Visible = True
            PictureBox1.Visible = True

            'Label1.Location = New Point(28, 45)
            'txtProductoNew.Location = New Point(28, 68)
            'PictureBox1.Location = New Point(303, 68)
            Label1.Location = New Point(28, 95)
            txtProductoNew.Location = New Point(28, 116)
            PictureBox1.Location = New Point(308, 116)

        Catch ex As Exception
            '       lblEstado.Text = ex.Message
        End Try

    End Sub

    'Sub calsificacion()
    '    Dim categoriaSA As New itemSA


    '    CboClasificacion.DisplayMember = "descripcion"
    '    CboClasificacion.ValueMember = "idItem"
    '    CboClasificacion.DataSource = categoriaSA.GetListaPadre()
    'End Sub


#End Region

#Region "Events"
    Private Sub frmNuevaExistencia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNuevaExistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCategoria.Select()
        CMBClasificacion()
        Productoshijos()
        Label1.Location = New Point(28, 203)
        txtProductoNew.Location = New Point(28, 226)
        PictureBox1.Location = New Point(303, 226)
        Label3.Visible = True
        txtSubCategoria.Visible = True
        PictureBox6.Visible = True
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
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

    Private Sub lstCategoria_MouseCaptureChanged(sender As Object, e As EventArgs) Handles lstCategoria.MouseCaptureChanged

    End Sub

    Private Sub lstCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstCategoria.MouseDoubleClick
        If lstCategoria.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lstCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCategoria.SelectedIndexChanged

    End Sub

    Private Sub txtProductoNew_KeyDown(sender As Object, e As KeyEventArgs)
        'Me.Cursor = Cursors.WaitCursor
        'If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
        '    e.SuppressKeyPress = True
        '    txtCategoria.Select()
        '    txtCategoria.Focus()
        'End If
        '' Using this unconventional if statement syntax to avoid "and" symbol (documentation restriction, please ignore).

        '' If user pressed key down, then show the popup.
        ''    If e.Alt Then
        'If e.KeyCode = Keys.Down Then
        '    If Not Me.pcMercaderia.IsShowing() Then
        '        ' Let the popup align around the source textBox.
        '        ListaItemsRecurremtes()
        '        Me.pcMercaderia.Font = New Font("Segoe UI", 8)
        '        Me.pcMercaderia.Size = New Size(294, 110)
        '        Me.pcMercaderia.ParentControl = Me.txtProductoNew
        '        Me.pcMercaderia.ShowPopup(Point.Empty)

        '        e.Handled = True
        '    End If
        'End If
        ''   End If
        '' Escape should close the popup.
        'If e.KeyCode = Keys.Escape Then
        '    If Me.pcMercaderia.IsShowing() Then
        '        Me.pcMercaderia.HidePopup(PopupCloseType.Canceled)
        '    End If
        'End If
        'Me.Cursor = Cursors.Arrow
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

    Private Sub pcMercaderia_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcMercaderia.BeforePopup
        Me.pcMercaderia.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcMercaderia_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcMercaderia.CloseUp
        'If e.PopupCloseType = PopupCloseType.Done Then

        'End If
        '' Set focus back to textbox.
        'If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        '    Me.cboProductos.Focus()
        'End If

    End Sub

    Private Sub pcMercaderia_Popup(sender As Object, e As EventArgs) Handles pcMercaderia.Popup
        Me.lstProductos.Focus()
        '   Me.popupTextBox.SelectionStart = 0
        ' Me.popupTextBox.SelectionLength = 0
    End Sub

    'Private Sub txtCategoria_KeyDown(sender As Object, e As KeyEventArgs)
    '    Dim categoriaSA As New itemSA
    '    If e.KeyCode = Keys.Down Then
    '        If Not Me.PopupControlContainer2.IsShowing() Then
    '            ' Let the popup align around the source textBox.
    '            Me.PopupControlContainer2.Font = New Font("Segoe UI", 8)
    '            Me.PopupControlContainer2.Size = New Size(238, 110)
    '            Me.PopupControlContainer2.ParentControl = Me.cboProductos
    '            Me.PopupControlContainer2.ShowPopup(Point.Empty)

    '            e.Handled = True
    '        End If
    '    End If
    '    '  End If
    '    ' Escape should close the popup.
    '    If e.KeyCode = Keys.Escape Then
    '        If Me.PopupControlContainer2.IsShowing() Then
    '            Me.PopupControlContainer2.HidePopup(PopupCloseType.Canceled)
    '        End If
    '    End If
    '    If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True
    '        If cboProductos.Text.Trim.Length > 0 Then
    '            lstCategoria.Items.Clear()
    '            For Each i In categoriaSA.GetListaItemPorEstableLike(GEstableciento.IdEstablecimiento, txtCategoria.Text.Trim)
    '                lstCategoria.Items.Add(New Categoria(i.descripcion, i.idItem))
    '            Next
    '            lstCategoria.DisplayMember = "Name"
    '            lstCategoria.ValueMember = "Id"
    '            Me.PopupControlContainer2.Font = New Font("Segoe UI", 8)
    '            Me.PopupControlContainer2.Size = New Size(238, 110)
    '            Me.PopupControlContainer2.ParentControl = Me.cboProductos
    '            Me.PopupControlContainer2.ShowPopup(Point.Empty)
    '        End If
    '    End If
    'End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        With frmNuevaMarca
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
    End Sub

    Dim listaSubCategoria As New List(Of item)
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



    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        'If txtCategoria.Text.Trim.Length > 0 Then

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
        'Else
        '    MessageBox.Show("seleccione una clasificacion")
        'End If

    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        'If Not txtmarca.Text.Trim.Length > 0 Then
        '    lblEstado.Text = "Ingrese el nombre de la clasificación"
        '    PopupControlContainer4.Font = New Font("Tahoma", 8)
        '    PopupControlContainer4.Size = New Size(337, 150)
        '    Me.PopupControlContainer4.ParentControl = Me.cboProductos
        '    Me.PopupControlContainer4.ShowPopup(Point.Empty)
        '    txtmarca.Select()
        '    Exit Sub
        'End If

        'btmGrabarClasificacion.Tag = "G"
        'Me.PopupControlContainer4.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer4.CloseUp
        'If e.PopupCloseType = PopupCloseType.Done Then
        '    If Not txtmarca.Text.Trim.Length > 0 Then
        '        lblEstado.Text = "Ingrese el nombre de la clasificación"
        '        PopupControlContainer4.Font = New Font("Tahoma", 8)
        '        PopupControlContainer4.Size = New Size(337, 150)
        '        Me.PopupControlContainer4.ParentControl = Me.cboProductos
        '        Me.PopupControlContainer4.ShowPopup(Point.Empty)
        '        txtNewClasificacion.Select()
        '        Exit Sub
        '    End If

        '    If btmGrabarClasificacion.Tag = "G" Then
        '        GrabarMarca()
        '        btmGrabarClasificacion.Tag = "N"
        '    Else
        '        pcClasificacion.Font = New Font("Tahoma", 8)
        '        pcClasificacion.Size = New Size(337, 150)
        '        Me.pcClasificacion.ParentControl = Me.cboProductos
        '        Me.pcClasificacion.ShowPopup(Point.Empty)
        '    End If

        'End If
        '' Set focus back to textbox.
        'If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
        '    Me.cboProductos.Focus()
        'End If
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor
        'Dim numero = nudCantMin.Value
        If chAsigar.Checked = True Then
            If Not txtCodigoBarra.Text.Trim.Length > 0 Then

                MessageBox.Show("Ingrese un Codigo de Existencia", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
        End If

        'If Not nudCantMin.Value <= nudCantMax.Value Then
        '    'lblEstado.Text = "La cantidad maxima debe ser mayor o igual"
        '    'txtProductoNew.Select()
        '    MessageBox.Show("La cantidad maxima debe ser mayor o igual", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'End If

        If Not txtSubCategoria.Text.Trim.Length > 0 Then

            MessageBox.Show("Ingrese una marca valida", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If txtSubCategoria.Text.Trim.Length > 0 Then
            If txtSubCategoria.ForeColor = Color.Black Then
                MessageBox.Show("Verificar el ingreso correcto de la marca", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSubCategoria.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
        End If

        If (chClasificacion.Checked = True) Then
            If Not txtCategoria.Text.Trim.Length > 0 Then

                MessageBox.Show("Ingrese la clasificación general", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
            If txtCategoria.Text.Trim.Length > 0 Then
                If txtCategoria.ForeColor = Color.Black Then
                    MessageBox.Show("Verificar el ingreso correcto de la clasificación general", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCategoria.Select()
                    Me.Cursor = Cursors.Arrow
                    Exit Sub
                End If
            End If

        End If

        If Not txtProductoNew.Text.Trim.Length > 0 Then
            'lblEstado.Text = "Ingrese el nombre del producto"
            'txtProductoNew.Select()
            MessageBox.Show("Ingrese el nombre del producto", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not cboUnidades.Text.Trim.Length > 0 Then
            'lblEstado.Text = "Ingrese el nombre del producto"
            'txtProductoNew.Select()
            MessageBox.Show("Ingrese la unidad de medida", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboUnidades.Select()
            cboUnidades.DroppedDown = True
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        'If MessageBoxAdv.Show("va a guardar con cantidad mínima " + CStr(numero) + "?", "atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        If EstadoManipulacion = ENTITY_ACTIONS.INSERT Then
            GrabarItemEstablec()
        Else
            EditarItemEstablec()
        End If
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub nudCantMax_ValueChanged(sender As Object, e As EventArgs) Handles nudCantMax.ValueChanged

    End Sub

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
        txtCategoria.ForeColor = Color.Black
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
        txtSubCategoria.ForeColor = Color.Black
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


    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp

    End Sub

    Private Sub GradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles GradientPanel2.Paint

    End Sub

    Private Sub chClasificacion_CheckedChanged(sender As Object, e As EventArgs) Handles chClasificacion.CheckedChanged
        If (chClasificacion.Checked = False) Then
            Label8.Visible = False
            txtCategoria.Visible = False
            PictureBox2.Visible = False
            'Label3.Visible = False
            'txtSubCategoria.Visible = False
            'PictureBox6.Visible = False
            Label1.Visible = True
            txtProductoNew.Visible = True
            PictureBox1.Visible = True

            txtCategoria.Tag = Nothing
            txtCategoria.Clear()
            txtSubCategoria.Tag = Nothing
            txtSubCategoria.Clear()
            txtProductoNew.Clear()

            'Label1.Location = New Point(28, 95)
            'txtProductoNew.Location = New Point(28, 116)
            'PictureBox1.Location = New Point(308, 116)
        Else
            Label8.Visible = True
            txtCategoria.Visible = True
            PictureBox2.Visible = True
            'Label3.Visible = True
            'txtSubCategoria.Visible = True
            'PictureBox6.Visible = True
            Label1.Visible = True
            txtProductoNew.Visible = True
            PictureBox1.Visible = True

            txtCategoria.Tag = Nothing
            txtCategoria.Clear()
            txtSubCategoria.Tag = Nothing
            txtSubCategoria.Clear()
            txtProductoNew.Clear()

            'Label1.Location = New Point(28, 203)
            'txtProductoNew.Location = New Point(28, 226)
            'PictureBox1.Location = New Point(303, 226)

        End If
    End Sub

    Private Sub chAsigar_CheckStateChanged(sender As Object, e As EventArgs) Handles chAsigar.CheckStateChanged
        If chAsigar.Checked = True Then
            txtCodigoBarra.Enabled = True
            txtCodigoBarra.Select()
        Else
            txtCodigoBarra.Clear()
            txtCodigoBarra.Enabled = False
        End If
    End Sub

    Private Sub txtCodigoBarra_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoBarra.TextChanged

    End Sub

    Private Sub ChRetencion_OnChange(sender As Object, e As EventArgs) Handles ChRetencion.OnChange
        If ChRetencion.Checked Then
            ChPercepcion.Checked = False
            txtValorRetencion.DecimalValue = 0
            txtValorRetencion.Enabled = True
            txtValorPercepcion.Enabled = False
            txtValorRetencion.SelectAll()
        Else
            txtValorRetencion.DecimalValue = 0
            txtValorPercepcion.DecimalValue = 0
            ChCompra.Checked = False
            ChVenta.Checked = False
        End If

        If ChRetencion.Checked Or ChPercepcion.Checked Then
            ChCompra.Enabled = True
            ChVenta.Enabled = True
        Else
            ChCompra.Enabled = False
            ChVenta.Enabled = False
            txtValorRetencion.DecimalValue = 0
            txtValorPercepcion.DecimalValue = 0
        End If
    End Sub

    Private Sub ChPercepcion_OnChange(sender As Object, e As EventArgs) Handles ChPercepcion.OnChange
        If ChPercepcion.Checked Then
            ChRetencion.Checked = False
            txtValorPercepcion.DecimalValue = 0
            txtValorPercepcion.Enabled = True
            txtValorRetencion.Enabled = False
            txtValorPercepcion.SelectAll()
        Else
            txtValorRetencion.DecimalValue = 0
            txtValorPercepcion.DecimalValue = 0
            ChCompra.Checked = False
            ChVenta.Checked = False
        End If

        If ChRetencion.Checked Or ChPercepcion.Checked Then
            ChCompra.Enabled = True
            ChVenta.Enabled = True
        Else
            ChCompra.Enabled = False
            ChVenta.Enabled = False
            txtValorRetencion.DecimalValue = 0
            txtValorPercepcion.DecimalValue = 0
        End If
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub
#End Region

End Class