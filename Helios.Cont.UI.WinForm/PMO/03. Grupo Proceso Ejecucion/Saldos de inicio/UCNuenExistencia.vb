Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Syncfusion.Windows.Forms
Imports System.Text.RegularExpressions
Imports Helios.Cont.Presentation.WinForm
Imports PopupControl

Public Class UCNuenExistencia

#Region "Attributes"

    Public frmNuevaExistencias As frmNuevaExistencia
    Dim listaSubCategoria As New List(Of item)

    Dim listaClasificacion As New List(Of item)

    Dim listaCategoriasItem As New List(Of item)

    Dim ListaTablaDetalle As New List(Of tabladetalle)

    Public Property EstadoManipulacion() As String

    Dim popup As Popup

    Public consultaItems As List(Of item)

    Public ControlCategorias As ucBuscarCategorias

#End Region

#Region "Constructors"
    Public Sub New(form As frmNuevaExistencia)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadControles()
        ListaCateriasItem()
        CargaSinDeterminar()

        'txtMarca.Text = "SIN DETERMINAR"
        'txtMarca.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        'txtMarca.Tag = 0
        frmNuevaExistencias = form

        ControlCategorias = New ucBuscarCategorias(Me)
        '   UserControl = New ucBuscarEntidades(Me)
        popup = New Popup(ControlCategorias)
        popup.Resizable = True

        EstadoManipulacion = ENTITY_ACTIONS.INSERT

    End Sub

    Public Sub New(CodigoItem As Integer, form As frmNuevaExistencia)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadControles()
        ListaCateriasItem()
        CargaSinDeterminar()
        frmNuevaExistencias = form

        'txtMarca.Text = "SIN DETERMINAR"
        'txtMarca.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        'txtMarca.Tag = 0

        UbicarProducto(CodigoItem)
        Label9.Visible = True
        cboUnidades.Visible = True
        txtProductoNew.ReadOnly = True
        cboUnidades.Enabled = False
        cboIgv.Enabled = False

        ControlCategorias = New ucBuscarCategorias(Me)
        '   UserControl = New ucBuscarEntidades(Me)
        popup = New Popup(ControlCategorias)
        popup.Resizable = True

        EstadoManipulacion = ENTITY_ACTIONS.UPDATE

    End Sub
#End Region

#Region "Methods"


    Public Sub CargaSinDeterminar()
        Try

            Dim CLASIFICACION = (From I In listaCategoriasItem Where I.descripcion = "SIN CLASIFICACION").FirstOrDefault

            If CLASIFICACION IsNot Nothing Then

                txtClasificacion.Text = CLASIFICACION.descripcion
                txtClasificacion.Tag = CLASIFICACION.idItem
            End If


            Dim CATEGORIA = (From I In listaCategoriasItem Where I.descripcion = "SIN CATEGORIA").FirstOrDefault

            If CATEGORIA IsNot Nothing Then

                txtCategoria.Text = CATEGORIA.descripcion
                txtCategoria.Tag = CATEGORIA.idItem
            End If

            Dim SUBCATEGORIA = (From I In listaCategoriasItem Where I.descripcion = "SIN SUBCATEGORIA").FirstOrDefault

            If SUBCATEGORIA IsNot Nothing Then

                txtSubCategoria.Text = SUBCATEGORIA.descripcion
                txtSubCategoria.Tag = SUBCATEGORIA.idItem
            End If


            Dim MARCA = (From I In listaCategoriasItem Where I.descripcion = "SIN MARCA").FirstOrDefault

            If MARCA IsNot Nothing Then

                txtMarca.Text = MARCA.descripcion
                txtMarca.Tag = MARCA.idItem
            End If


            Dim PRESENTACION = (From I In listaCategoriasItem Where I.descripcion = "SIN PRESENTACION").FirstOrDefault

            If PRESENTACION IsNot Nothing Then

                TextPresentacion.Text = PRESENTACION.descripcion
                TextPresentacion.Tag = PRESENTACION.idItem
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub AgregarTabla(IDTabla As String)
        Dim tablaSA As New tablaDetalleSA

        Dim obj As New tabladetalle
        obj.idtabla = IDTabla
        Select Case IDTabla
            Case "19" 'color

                Dim ListaColores = (From i In ListaTablaDetalle Where i.idtabla = 19).ToList

                obj.codigoDetalle = ListaColores.Count() + 1
            Case "18" 'talla
                Dim ListaTallas = (From i In ListaTablaDetalle Where i.idtabla = 18).ToList
                obj.codigoDetalle = ListaTallas.Count() + 1

            Case "25" 'talla
                Dim ListaAdicional1 = (From i In ListaTablaDetalle Where i.idtabla = 25).ToList
                obj.codigoDetalle = ListaAdicional1.Count() + 1

            Case "26" 'talla
                Dim ListaAdicional2 = (From i In ListaTablaDetalle Where i.idtabla = 26).ToList
                obj.codigoDetalle = ListaAdicional2.Count() + 1


        End Select
        obj.codigoDetalle2 = "N"
        obj.descripcion = textTabla.Text.Trim
        obj.estadodetalle = "1"
        obj.usuarioModificacion = usuario.IDUsuario
        obj.fechaModificacion = DateTime.Now

        Dim tabla = tablaSA.InsertarTablaDetalle(obj)
        Select Case IDTabla
            Case "19" 'color
                ' ListaColores.Add(obj)

                ListaTablaDetalle.Add(obj)
                Dim ListaColores = (From i In ListaTablaDetalle Where i.idtabla = 19).ToList

                comboColor.DataSource = New List(Of tabla)
                Me.comboColor.DataSource = ListaColores 'tablaSA.GetListaTablaDetalle(19, "1")
                Me.comboColor.DisplayMember = "descripcion"
                Me.comboColor.ValueMember = "codigoDetalle"



                'comboColor.Refresh()
                comboColor.Text = obj.descripcion
            Case "18" 'talla
                'ListaTallas.Add(obj)


                ListaTablaDetalle.Add(obj)
                Dim ListaTallas = (From i In ListaTablaDetalle Where i.idtabla = 18).ToList

                comboTallas.DataSource = New List(Of tabla)
                Me.comboTallas.DataSource = ListaTallas 'tablaSA.GetListaTablaDetalle(18, "1")
                Me.comboTallas.DisplayMember = "descripcion"
                Me.comboTallas.ValueMember = "codigoDetalle"
                'comboTallas.Refresh()
                comboTallas.Text = obj.descripcion


            Case "25" 'talla
                'ListaTallas.Add(obj)


                ListaTablaDetalle.Add(obj)
                Dim ListaAdicional1 = (From i In ListaTablaDetalle Where i.idtabla = 25).ToList

                comboAdicional1.DataSource = New List(Of tabla)
                Me.comboAdicional1.DataSource = ListaAdicional1 'tablaSA.GetListaTablaDetalle(18, "1")
                Me.comboAdicional1.DisplayMember = "descripcion"
                Me.comboAdicional1.ValueMember = "codigoDetalle"
                'comboTallas.Refresh()
                comboAdicional1.Text = obj.descripcion




            Case "26" 'talla
                'ListaTallas.Add(obj)


                ListaTablaDetalle.Add(obj)
                Dim ListaAdicional2 = (From i In ListaTablaDetalle Where i.idtabla = 26).ToList

                comboAdicional2.DataSource = New List(Of tabla)
                Me.comboAdicional2.DataSource = ListaAdicional2 'tablaSA.GetListaTablaDetalle(18, "1")
                Me.comboAdicional2.DisplayMember = "descripcion"
                Me.comboAdicional2.ValueMember = "codigoDetalle"
                'comboTallas.Refresh()
                comboAdicional2.Text = obj.descripcion
        End Select
        textTabla.Clear()
        popupNewTabla.HidePopup()
    End Sub


    Public Sub ListaCateriasItem()
        Try


            Dim categoriaSA As New itemSA
            ' categoriaSA.GetListaPadre()
            listaCategoriasItem = New List(Of item)
            listaCategoriasItem = categoriaSA.GetListaCategoriasItem(New item With
                                                              {
                                                              .idEmpresa = Gempresas.IdEmpresaRuc,
                                                              .idEstablecimiento = GEstableciento.IdEstablecimiento
                                                              })





        Catch ex As Exception

        End Try
    End Sub

    Private Sub CMBgrupoClasificacion()
        Dim categoriaSA As New itemSA
        ' categoriaSA.GetListaPadre()
        listaClasificacion = New List(Of item)
        listaClasificacion = categoriaSA.GetListaItemsPorTipo(New item With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .tipo = TipoGrupoArticulo.CategoriaGeneral
                                                          })

    End Sub
    Private Sub LoadControles()
        Dim categoriaSA As New itemSA
        Dim tablaSA As New tablaDetalleSA
        Dim dtUM As New DataTable

        Try

            ListaTablaDetalle = tablaSA.GetListaTablaDetalleTipos("1")

            Me.cboUnidades.DataSource = tablaSA.GetListaTablaDetalle(6, "1")
            Me.cboUnidades.DisplayMember = "descripcion"
            Me.cboUnidades.ValueMember = "codigoDetalle"

            Dim ListaColores = (From i In ListaTablaDetalle Where i.idtabla = 19).ToList

            Me.comboColor.DataSource = ListaColores 'tablaSA.GetListaTablaDetalle(19, "1")
            Me.comboColor.DisplayMember = "descripcion"
            Me.comboColor.ValueMember = "codigoDetalle"

            Dim ColorSinDet = (From i In ListaColores Where i.descripcion = "SIN DETERMINAR").FirstOrDefault
            If ColorSinDet IsNot Nothing Then
                Me.comboColor.Text = ColorSinDet.descripcion
            End If

            Dim ListaTallas = (From i In ListaTablaDetalle Where i.idtabla = 18).ToList

            Me.comboTallas.DataSource = ListaTallas 'tablaSA.GetListaTablaDetalle(18, "1")
            Me.comboTallas.DisplayMember = "descripcion"
            Me.comboTallas.ValueMember = "codigoDetalle"

            Dim TallaSinDet = (From i In ListaTallas Where i.descripcion = "SIN DETERMINAR").FirstOrDefault
            If TallaSinDet IsNot Nothing Then
                Me.comboTallas.Text = TallaSinDet.descripcion
            End If

            Dim ListaAdicional1 = (From i In ListaTablaDetalle Where i.idtabla = 25).ToList

            Me.comboAdicional1.DataSource = ListaAdicional1 'tablaSA.GetListaTablaDetalle(18, "1")
            Me.comboAdicional1.DisplayMember = "descripcion"
            Me.comboAdicional1.ValueMember = "codigoDetalle"

            Dim Adicional1SinDet = (From i In ListaAdicional1 Where i.descripcion = "SIN DETERMINAR").FirstOrDefault
            If Adicional1SinDet IsNot Nothing Then
                Me.comboAdicional1.Text = Adicional1SinDet.descripcion
            End If

            Dim ListaAdicional2 = (From i In ListaTablaDetalle Where i.idtabla = 26).ToList

            Me.comboAdicional2.DataSource = ListaAdicional2 'tablaSA.GetListaTablaDetalle(18, "1")
            Me.comboAdicional2.DisplayMember = "descripcion"
            Me.comboAdicional2.ValueMember = "codigoDetalle"

            Dim Adicional2SinDet = (From i In ListaAdicional2 Where i.descripcion = "SIN DETERMINAR").FirstOrDefault
            If Adicional2SinDet IsNot Nothing Then
                Me.comboAdicional2.Text = Adicional2SinDet.descripcion
            End If

            cboTipoExistencia.DisplayMember = "descripcion"
            cboTipoExistencia.ValueMember = "codigoDetalle"
            cboTipoExistencia.DataSource = General.TablasGenerales.GetExistencias ' tablaSA.GetListaTablaDetalle(5, "1")

        Catch ex As Exception
            ' lblEstado.Text = ex.Message
        End Try

    End Sub

    'Dim listaCategoria As New List(Of item)
    'Private Sub CMBClasificacion()
    '    Dim categoriaSA As New itemSA
    '    ' categoriaSA.GetListaPadre()
    '    listaCategoria = New List(Of item)
    '    listaCategoria = categoriaSA.GetListaItemsPorTipo(New item With
    '                                                      {
    '                                                      .idEmpresa = Gempresas.IdEmpresaRuc,
    '                                                      .tipo = TipoGrupoArticulo.CategoriaGeneral
    '                                                      })

    'End Sub

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
                If txtCodigoBarra.Text.Trim.Length > 0 Then
                    chAsigar.Checked = True
                End If


                txtCodigoInterno.Text = .codigoInterno
                If txtCodigoInterno.Text.Trim.Length > 0 Then
                    chInterno.Checked = True
                End If


                cboTipoBien.Text = .tipoBien


                If Not IsNothing(.idClasificacion) Then

                    Dim consulta = (From i In listaCategoriasItem
                                    Where i.idItem = .idClasificacion).SingleOrDefault

                    If consulta IsNot Nothing Then
                        txtClasificacion.Text = consulta.descripcion
                        txtClasificacion.Tag = consulta.idItem
                        txtClasificacion.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End If

                End If

                If Not IsNothing(.idItem) Then


                    Dim consulta = (From i In listaCategoriasItem
                                    Where i.idItem = .idItem).SingleOrDefault

                    If consulta IsNot Nothing Then
                        txtCategoria.Text = consulta.descripcion
                        txtCategoria.Tag = consulta.idItem
                        txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End If
                    'Dim codFamili = .idItem
                    'With categoriaSA.UbicarCategoriaPorID(codFamili)
                    '    txtSubClasificacion.Text = .descripcion
                    '    txtSubClasificacion.Tag = .idItem
                    '    txtSubClasificacion.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    'End With
                End If


                If Not IsNothing(.unidad2) Then


                    Dim consulta = (From i In listaCategoriasItem
                                    Where i.idItem = .unidad2).SingleOrDefault

                    If consulta IsNot Nothing Then
                        txtSubCategoria.Text = consulta.descripcion
                        txtSubCategoria.Tag = consulta.idItem
                        txtSubCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End If
                    'Dim codFamili = .idItem
                    'With categoriaSA.UbicarCategoriaPorID(codFamili)
                    '    txtSubClasificacion.Text = .descripcion
                    '    txtSubClasificacion.Tag = .idItem
                    '    txtSubClasificacion.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    'End With
                End If



                If Not IsNothing(.marcaRef) Then


                    Dim consulta = (From i In listaCategoriasItem
                                    Where i.idItem = .marcaRef).SingleOrDefault

                    If consulta IsNot Nothing Then


                        txtMarca.Text = consulta.descripcion
                        txtMarca.Tag = consulta.idItem
                        txtMarca.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                    End If


                    'Dim codMarca = .marcaRef
                    ''Productoshijos()
                    'With categoriaSA.UbicarCategoriaPorID(codMarca)
                    '    txtMarca.Text = .descripcion
                    '    txtMarca.Tag = .idItem
                    '    txtMarca.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    'End With

                End If



                If Not IsNothing(.idCaracteristica) Then


                    Dim consulta = (From i In listaCategoriasItem
                                    Where i.idItem = .idCaracteristica).SingleOrDefault

                    If consulta IsNot Nothing Then

                        TextPresentacion.Text = consulta.descripcion
                        TextPresentacion.Tag = consulta.idItem
                        TextPresentacion.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

                    End If

                End If


                Dim COLOR2 = .color
                comboColor.Text = .color
                comboTallas.Text = .talla




                comboAdicional1.Text = .electricidad
                comboAdicional2.Text = .transmision
                TextPeso.Text = .Peso




                cboTipoExistencia.SelectedValue = .tipoExistencia
                cboTipoExistencia.Enabled = False
                'txtUm.Text = .unidad1
                Dim um = .unidad1
                cboUnidades.SelectedValue = .unidad1
                'TextPresentacion.Text = .presentacion
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
                If .cantidadMinima IsNot Nothing Then
                    textCantMinima.Value = .cantidadMinima
                    textCantMaxima.Value = .cantidadMaxima
                Else
                    textCantMinima.Value = 10
                    textCantMaxima.Value = 100
                End If




                Select Case .tipoItem
                    Case "MULT"
                        cboTipoUnidadComercial.Text = "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)"
                    Case "UNIC"
                        cboTipoUnidadComercial.Text = "SÓLO UNIDAD COMERCIAL"
                    Case "DET"
                        cboTipoUnidadComercial.Text = "SÓLO UNIDAD COMERCIAL DETALLADO"
                End Select
                cboTipoUnidadComercial.Enabled = False


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

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub MappingItemsConexos(Conexos As List(Of detalleitems_conexo))
        frmNuevaExistencias.UCItemsAnexos.LoadProductosConexos(Conexos)
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
    Private Sub txtCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSubCategoria.KeyDown

        'If txtCategoria.Tag Is Nothing Then

        '    MessageBox.Show("Seleccione una SubClasificacion")
        '    Exit Sub
        'End If


        'If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        'Else
        '    Me.pcSubClasificacion.Font = New Font("Segoe UI", 8)
        '    Me.pcSubClasificacion.Size = New Size(241, 110)
        '    Me.pcSubClasificacion.ParentControl = Me.txtSubCategoria
        '    Me.pcSubClasificacion.ShowPopup(Point.Empty)


        '    Dim consulta = (From n In listaCategoriasItem
        '                    Where n.descripcion.StartsWith(txtSubCategoria.Text) And n.idPadre = txtCategoria.Tag And n.tipo = TipoGrupoArticulo.SubCategoriaGeneral).ToList

        '    lsvSubClasificacion.DataSource = consulta
        '    lsvSubClasificacion.DisplayMember = "descripcion"
        '    lsvSubClasificacion.ValueMember = "idItem"
        '    e.Handled = True



        '    txtMarca.Clear()
        '    TextPresentacion.Clear()
        'End If

        'If e.KeyCode = Keys.Down Then
        '    Me.pcSubClasificacion.Font = New Font("Segoe UI", 8)
        '    Me.pcSubClasificacion.Size = New Size(241, 110)
        '    Me.pcSubClasificacion.ParentControl = Me.txtSubCategoria
        '    Me.pcSubClasificacion.ShowPopup(Point.Empty)
        '    lsvSubClasificacion.Focus()
        'End If

        'If e.KeyCode = Keys.Escape Then
        '    If Me.pcSubClasificacion.IsShowing() Then
        '        Me.pcSubClasificacion.HidePopup(PopupCloseType.Canceled)
        '    End If
        'End If


    End Sub

    Private Sub txtCategoria_TextChanged_1(sender As Object, e As EventArgs) Handles txtSubCategoria.TextChanged
        txtSubCategoria.ForeColor = Color.White
        txtSubCategoria.Tag = Nothing
    End Sub

    Private Sub txtSubCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMarca.KeyDown




        'If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        'Else
        '    Me.pcLikeMarca.Font = New Font("Segoe UI", 8)
        '    Me.pcLikeMarca.Size = New Size(241, 110)
        '    Me.pcLikeMarca.ParentControl = Me.txtMarca
        '    Me.pcLikeMarca.ShowPopup(Point.Empty)



        '    Dim consulta = (From n In listaCategoriasItem
        '                    Where n.descripcion.StartsWith(txtMarca.Text) And n.tipo = TipoGrupoArticulo.Marca).ToList

        '    lsvMarca.DataSource = consulta
        '    lsvMarca.DisplayMember = "descripcion"
        '    lsvMarca.ValueMember = "idItem"



        '    TextPresentacion.Clear()
        'End If


        'If e.KeyCode = Keys.Down Then
        '    Me.pcLikeMarca.Font = New Font("Segoe UI", 8)
        '    Me.pcLikeMarca.Size = New Size(241, 110)
        '    Me.pcLikeMarca.ParentControl = Me.txtMarca
        '    Me.pcLikeMarca.ShowPopup(Point.Empty)
        '    lsvMarca.Focus()
        'End If

        'If e.KeyCode = Keys.Escape Then
        '    If Me.pcLikeMarca.IsShowing() Then
        '        Me.pcLikeMarca.HidePopup(PopupCloseType.Canceled)
        '    End If
        'End If



    End Sub

    Private Sub txtSubCategoria_TextChanged(sender As Object, e As EventArgs) Handles txtMarca.TextChanged
        txtMarca.ForeColor = Color.White
        txtMarca.Tag = Nothing
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



    Private Sub chAsigar_CheckStateChanged(sender As Object, e As EventArgs) Handles chAsigar.CheckStateChanged
        If chAsigar.Checked = True Then
            txtCodigoBarra.Enabled = True
            txtCodigoBarra.Select()
        Else
            txtCodigoBarra.Clear()
            txtCodigoBarra.Enabled = False
        End If
    End Sub



    Private Sub UCNuenExistencia_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtSubCategoria.Select()
        'CMBClasificacion()
        'Productoshijos()
        'Label1.Location = New Point(28, 203)
        'txtProductoNew.Location = New Point(28, 226)
        'PictureBox1.Location = New Point(303, 226)
        Label3.Visible = True
        txtMarca.Visible = True
        'PictureBox6.Visible = True
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
        TextPresentacion.ForeColor = Color.White
        TextPresentacion.Tag = Nothing
    End Sub

    Private Sub txtProductoNew_TextChanged(sender As Object, e As EventArgs) Handles txtProductoNew.TextChanged
        'TextPresentacion.Text = txtProductoNew.Text
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

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click

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







    Private Sub txtPrincipal_TextChanged(sender As Object, e As EventArgs) Handles txtClasificacion.TextChanged
        txtClasificacion.ForeColor = Color.White
        txtClasificacion.Tag = Nothing
    End Sub

    Private Sub txtPrincipal_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClasificacion.KeyDown
        'If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then



        'Else
        '    Me.pcGrupo.Font = New Font("Segoe UI", 8)
        '    Me.pcGrupo.Size = New Size(241, 110)
        '    Me.pcGrupo.ParentControl = Me.txtClasificacion
        '    Me.pcGrupo.ShowPopup(Point.Empty)
        '    Dim consulta = (From n In listaCategoriasItem
        '                    Where n.descripcion.StartsWith(txtClasificacion.Text) And n.tipo = TipoGrupoArticulo.Principal).ToList

        '    LsvGrupo.DataSource = consulta
        '    LsvGrupo.DisplayMember = "descripcion"
        '    LsvGrupo.ValueMember = "idItem"
        '    e.Handled = True


        '    txtCategoria.Clear()
        '    txtSubCategoria.Clear()
        '    txtMarca.Clear()
        '    TextPresentacion.Clear()
        'End If


        'If e.KeyCode = Keys.Down Then
        '    Me.pcGrupo.Font = New Font("Segoe UI", 8)
        '    Me.pcGrupo.Size = New Size(241, 110)
        '    Me.pcGrupo.ParentControl = Me.txtClasificacion
        '    Me.pcGrupo.ShowPopup(Point.Empty)
        '    LsvGrupo.Focus()
        'End If

        'If e.KeyCode = Keys.Escape Then
        '    If Me.pcGrupo.IsShowing() Then
        '        Me.pcGrupo.HidePopup(PopupCloseType.Canceled)
        '    End If
        'End If
    End Sub

    Private Sub txtClasificacion_TextChanged(sender As Object, e As EventArgs) Handles txtCategoria.TextChanged
        txtCategoria.ForeColor = Color.White
        txtCategoria.Tag = Nothing
    End Sub

    Private Sub txtClasificacion_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria.KeyDown
        'Try


        '    If txtClasificacion.Tag Is Nothing Then

        '        MessageBox.Show("Seleccione un Grupo Principal")
        '        Exit Sub
        '    End If


        '    If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        '    Else
        '        Me.pcClasificacion.Font = New Font("Segoe UI", 8)
        '        Me.pcClasificacion.Size = New Size(241, 110)
        '        Me.pcClasificacion.ParentControl = Me.txtCategoria
        '        Me.pcClasificacion.ShowPopup(Point.Empty)



        '        Dim consulta = (From n In listaCategoriasItem
        '                        Where n.descripcion.StartsWith(txtCategoria.Text) And n.idPadre = txtClasificacion.Tag And n.tipo = TipoGrupoArticulo.CategoriaGeneral).ToList




        '        lsvClasificacion.DataSource = consulta
        '        lsvClasificacion.DisplayMember = "descripcion"
        '        lsvClasificacion.ValueMember = "idItem"
        '        e.Handled = True



        '        txtSubCategoria.Clear()
        '        txtMarca.Clear()
        '        TextPresentacion.Clear()
        '    End If


        '    If e.KeyCode = Keys.Down Then
        '        Me.pcClasificacion.Font = New Font("Segoe UI", 8)
        '        Me.pcClasificacion.Size = New Size(241, 110)
        '        Me.pcClasificacion.ParentControl = Me.txtCategoria
        '        Me.pcClasificacion.ShowPopup(Point.Empty)
        '        lsvClasificacion.Focus()
        '    End If

        '    If e.KeyCode = Keys.Escape Then
        '        If Me.pcClasificacion.IsShowing() Then
        '            Me.pcClasificacion.HidePopup(PopupCloseType.Canceled)
        '        End If
        '    End If

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub TextPresentacion_KeyDown(sender As Object, e As KeyEventArgs) Handles TextPresentacion.KeyDown


        'If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        'Else
        '    Me.pcLikePresentacion.Font = New Font("Segoe UI", 8)
        '    Me.pcLikePresentacion.Size = New Size(241, 110)
        '    Me.pcLikePresentacion.ParentControl = Me.TextPresentacion
        '    Me.pcLikePresentacion.ShowPopup(Point.Empty)


        '    Dim consulta = (From n In listaCategoriasItem
        '                    Where n.descripcion.StartsWith(TextPresentacion.Text) And n.idPadre = txtMarca.Tag And n.tipo = TipoGrupoArticulo.Presentacion).ToList


        '    lsvPresentacion.DataSource = consulta
        '    lsvPresentacion.DisplayMember = "descripcion"
        '    lsvPresentacion.ValueMember = "idItem"
        '    e.Handled = True
        'End If


        'If e.KeyCode = Keys.Down Then
        '    Me.pcLikePresentacion.Font = New Font("Segoe UI", 8)
        '    Me.pcLikePresentacion.Size = New Size(241, 110)
        '    Me.pcLikePresentacion.ParentControl = Me.txtMarca
        '    Me.pcLikePresentacion.ShowPopup(Point.Empty)
        '    lsvPresentacion.Focus()
        'End If

        'If e.KeyCode = Keys.Escape Then
        '    If Me.pcLikePresentacion.IsShowing() Then
        '        Me.pcLikePresentacion.HidePopup(PopupCloseType.Canceled)
        '    End If
        'End If
    End Sub



    Private Sub cboTipoUnidadComercial_Click(sender As Object, e As EventArgs) Handles cboTipoUnidadComercial.Click

    End Sub

    Private Sub cboTipoUnidadComercial_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTipoUnidadComercial.SelectedValueChanged
        Try

            If cboTipoUnidadComercial.Text = "VARIOS-UNIDADES COMERCIALES" Then
                frmNuevaExistencias.btOperacion.ButtonText = "Grabar"

            Else
                If frmNuevaExistencias IsNot Nothing Then
                    frmNuevaExistencias.btOperacion.ButtonText = "Aceptar"
                End If
            End If





        Catch ex As Exception

        End Try
    End Sub

    Private Sub chInterno_CheckStateChanged(sender As Object, e As EventArgs) Handles chInterno.CheckStateChanged
        If chInterno.Checked = True Then
            txtCodigoInterno.Enabled = True
            txtCodigoInterno.Select()
        Else
            txtCodigoInterno.Clear()
            txtCodigoInterno.Enabled = False
        End If
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        If textTabla.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingreser una descripción", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If (gradientPanel4.Tag = "COLOR") Then
            AgregarTabla("19")
        ElseIf (gradientPanel4.Tag = "TALLA") Then
            AgregarTabla("18")
        ElseIf (gradientPanel4.Tag = "ADICIONAL1") Then
            AgregarTabla("25")
        ElseIf (gradientPanel4.Tag = "ADICIONAL2") Then
            AgregarTabla("26")
        End If
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        gradientPanel4.BackColor = Color.FromArgb(36, 41, 46)
        gradientPanel4.Tag = "COLOR"
        popupNewTabla.ParentControl = comboColor
        popupNewTabla.ShowPopup(Point.Empty)
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        gradientPanel4.BackColor = Color.FromArgb(36, 41, 46)
        gradientPanel4.Tag = "TALLA"
        popupNewTabla.ParentControl = comboTallas
        popupNewTabla.ShowPopup(Point.Empty)
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        gradientPanel4.BackColor = Color.FromArgb(36, 41, 46)
        gradientPanel4.Tag = "ADICIONAL1"
        popupNewTabla.ParentControl = comboAdicional1
        popupNewTabla.ShowPopup(Point.Empty)
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        gradientPanel4.BackColor = Color.FromArgb(36, 41, 46)
        gradientPanel4.Tag = "ADICIONAL2"
        popupNewTabla.ParentControl = comboAdicional2
        popupNewTabla.ShowPopup(Point.Empty)
    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        If listaCategoriasItem IsNot Nothing Then


            Dim consulta = (From n In listaCategoriasItem
                            Where n.tipo = TipoGrupoArticulo.Principal).ToList



            consultaItems = consulta 'entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, "CL", TextLikeCliente.Text.Trim)
            ControlCategorias.FillLSVItems(consultaItems, TipoGrupoArticulo.Principal)
            'popup.Show(TryCast(sender, ButtonAdv))
            popup.Show(txtClasificacion)
        End If
    End Sub

    Private Sub ButtonAdv17_Click(sender As Object, e As EventArgs) Handles ButtonAdv17.Click
        Dim datos As List(Of item) = item.Instance()
        datos.Clear()

        Dim f As New frmNuevoGrupoPrin
        f.txtDescripcion.Text = txtClasificacion.Text
        txtClasificacion.Clear()
        f.StartPosition = FormStartPosition.CenterParent
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.ShowDialog()

        CMBgrupoClasificacion()
        If datos.Count > 0 Then
            txtClasificacion.Text = datos(0).descripcion
            txtClasificacion.ForeColor = Color.White  'Color.FromKnownColor(KnownColor.HotTrack)
            txtClasificacion.Tag = CInt(datos(0).idItem)

            ListaCateriasItem()


            txtCategoria.Text = ""
            txtCategoria.Tag = Nothing

            txtSubCategoria.Text = ""
            txtSubCategoria.Tag = Nothing




        End If
    End Sub

    Private Sub ButtonAdv13_Click(sender As Object, e As EventArgs) Handles ButtonAdv13.Click


        If listaCategoriasItem IsNot Nothing Then



            Dim consulta = (From n In listaCategoriasItem
                            Where n.idPadre = txtClasificacion.Tag And n.tipo = TipoGrupoArticulo.CategoriaGeneral).ToList



            consultaItems = consulta 'entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, "CL", TextLikeCliente.Text.Trim)
            ControlCategorias.FillLSVItems(consultaItems, TipoGrupoArticulo.CategoriaGeneral)
            'popup.Show(TryCast(sender, ButtonAdv))
            popup.Show(txtCategoria)
        End If

    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        If listaCategoriasItem IsNot Nothing Then



            Dim consulta = (From n In listaCategoriasItem
                            Where n.idPadre = txtCategoria.Tag And n.tipo = TipoGrupoArticulo.SubCategoriaGeneral).ToList



            consultaItems = consulta 'entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, "CL", TextLikeCliente.Text.Trim)
            ControlCategorias.FillLSVItems(consultaItems, TipoGrupoArticulo.SubCategoriaGeneral)
            'popup.Show(TryCast(sender, ButtonAdv))
            popup.Show(txtSubCategoria)
        End If
    End Sub

    Private Sub ButtonAdv14_Click(sender As Object, e As EventArgs) Handles ButtonAdv14.Click
        If listaCategoriasItem IsNot Nothing Then



            Dim consulta = (From n In listaCategoriasItem
                            Where n.tipo = TipoGrupoArticulo.Marca).ToList



            consultaItems = consulta 'entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, "CL", TextLikeCliente.Text.Trim)
            ControlCategorias.FillLSVItems(consultaItems, TipoGrupoArticulo.Marca)
            'popup.Show(TryCast(sender, ButtonAdv))
            popup.Show(txtMarca)
        End If
    End Sub

    Private Sub ButtonAdv16_Click(sender As Object, e As EventArgs) Handles ButtonAdv16.Click
        If listaCategoriasItem IsNot Nothing Then


            Dim consulta = (From n In listaCategoriasItem
                            Where n.idPadre = txtMarca.Tag And n.tipo = TipoGrupoArticulo.Presentacion).ToList



            consultaItems = consulta 'entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, "CL", TextLikeCliente.Text.Trim)
            ControlCategorias.FillLSVItems(consultaItems, TipoGrupoArticulo.Presentacion)
            'popup.Show(TryCast(sender, ButtonAdv))
            popup.Show(TextPresentacion)
        End If
    End Sub

    Private Sub ButtonAdv18_Click(sender As Object, e As EventArgs) Handles ButtonAdv18.Click
        If txtCategoria.Tag Is Nothing Then

            MessageBox.Show("Seleccione una Clasificacion")
        Else

            Dim datos As List(Of item) = item.Instance()
            datos.Clear()

            Dim f As New frmNuevaClasificacion
            f.txtClasificacion.Text = txtCategoria.Text
            f.lblidClasificacion.Text = txtCategoria.Tag
            f.txtDescripcion.Text = txtSubCategoria.Text
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            txtSubCategoria.Clear()
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            'CMBClasificacion()
            If datos.Count > 0 Then
                txtSubCategoria.Text = datos(0).descripcion
                txtSubCategoria.ForeColor = Color.White 'Color.FromKnownColor(KnownColor.HotTrack)
                txtSubCategoria.Tag = CInt(datos(0).idItem)
                ListaCateriasItem()
            End If

        End If
    End Sub

    Private Sub ButtonAdv19_Click(sender As Object, e As EventArgs) Handles ButtonAdv19.Click
        If txtMarca.Tag Is Nothing Then

            MessageBox.Show("Seleccione una Marca")
        Else

            Dim datos As List(Of item) = item.Instance()
            datos.Clear()


            Dim f As New frmNuevoPresentacion
            f.StartPosition = FormStartPosition.CenterParent
            f.lblidmarca.Text = txtMarca.Tag
            f.txtMarca.Text = txtMarca.Text
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            TextPresentacion.Clear()

            f.ShowDialog()
            Productoshijos()

            If datos.Count > 0 Then
                TextPresentacion.Text = datos(0).descripcion
                TextPresentacion.ForeColor = Color.White 'Color.FromKnownColor(KnownColor.HotTrack)
                TextPresentacion.Tag = CInt(datos(0).idItem)
                ListaCateriasItem()


                If EstadoManipulacion = ENTITY_ACTIONS.INSERT Then

                    txtProductoNew.Text = txtClasificacion.Text + "-" +
                                                        txtCategoria.Text + "-" +
                                                        txtSubCategoria.Text + "-" +
                                                        txtMarca.Text + "-" +
                                                        TextPresentacion.Text
                End If


            End If
        End If
    End Sub

    Private Sub ButtonAdv20_Click(sender As Object, e As EventArgs) Handles ButtonAdv20.Click
        If txtClasificacion.Tag Is Nothing Then

            MessageBox.Show("Seleccione un Grupo Principal")
        Else



            Dim datos As List(Of item) = item.Instance()
            datos.Clear()

            Dim f As New frmNuevoGrupoClas
            f.lblidgrupo.Text = txtClasificacion.Tag
            f.txtGrupo.Text = txtClasificacion.Text
            f.txtDescripcion.Text = txtCategoria.Text
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            txtCategoria.Clear()
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()

            CMBgrupoClasificacion()
            If datos.Count > 0 Then
                txtCategoria.Text = datos(0).descripcion
                txtCategoria.ForeColor = Color.White 'Color.FromKnownColor(KnownColor.HotTrack)
                txtCategoria.Tag = CInt(datos(0).idItem)
                ListaCateriasItem()

                txtSubCategoria.Text = ""
                txtSubCategoria.Tag = Nothing
            End If

        End If
    End Sub

    Private Sub ButtonAdv21_Click(sender As Object, e As EventArgs) Handles ButtonAdv21.Click
        If txtSubCategoria.Tag Is Nothing Then

            MessageBox.Show("Seleccione una SubClasificacion")
        Else

            Dim datos As List(Of item) = item.Instance()
            datos.Clear()


            Dim f As New frmNuevaMarca
            f.StartPosition = FormStartPosition.CenterParent
            'f.lblidSubClasificacion.Text = txtSubClasificacion.Tag
            'f.txtSubClasificacion.Text = txtSubClasificacion.Text
            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
            'f.txtDescripcion.Text = txtMarca.Text
            txtMarca.Clear()

            f.ShowDialog()
            Productoshijos()

            If datos.Count > 0 Then
                txtMarca.Text = datos(0).descripcion
                txtMarca.ForeColor = Color.White 'Color.FromKnownColor(KnownColor.HotTrack)
                txtMarca.Tag = CInt(datos(0).idItem)
                ListaCateriasItem()

                TextPresentacion.Text = ""
                TextPresentacion.Tag = Nothing
            End If
        End If
    End Sub




#End Region

End Class
