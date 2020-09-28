Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class FormCrearExistenciaNueva
    Public Property Precios As Boolean = False
    Public Property IdAlmacenPrecio As Integer
    Public Property EstadoManipulacion() As String
    Public Property Listadetalleitem_equivalencias As List(Of detalleitem_equivalencias)
    Public Property ucNuevoCalzado As ucFormCrearExistenciaNueva
    Public Property ListaEquivalencia As List(Of detalleitem_equivalencias)

    '3 - INAFECTO

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Listadetalleitem_equivalencias = New List(Of detalleitem_equivalencias)

        ucNuevoCalzado = New ucFormCrearExistenciaNueva(Me)
        PanelBody.Controls.Add(ucNuevoCalzado)

    End Sub

    Public Sub New(CodigoItem As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        'UCItemsAnexos = New UCItemsAnexos(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        BunifuFlatButton2.Visible = False
        ucNuevoCalzado = New ucFormCrearExistenciaNueva(CodigoItem, Me)
        PanelBody.Controls.Add(ucNuevoCalzado)
        '  PanelBody.Controls.Add(UCItemsAnexos)
        BunifuFlatButton1.Visible = False

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ' UbicarProducto(CodigoItem)
    End Sub


#Region "Métodos"


    'Public Sub UbicarProducto(intIdItem As Integer)
    '    Dim itemSA As New detalleitemsSA
    '    Dim categoriaSA As New itemSA
    '    Dim totales As New TotalesAlmacenSA


    '    Try


    '        With itemSA.InvocarProductoID(intIdItem)
    '            txtProductoNew.Text = .descripcionItem
    '            txtProductoNew.Tag = .codigodetalle
    '            'txtSubCategoria.Tag = .idFamilia
    '            txtCodigoBarra.Text = .codigo
    '            If txtCodigoBarra.Text.Trim.Length > 0 Then
    '                chAsigar.Checked = True
    '            End If

    '            Dim codMarca = .unidad2
    '            If Not IsNothing(.idItem) Then
    '                Dim codFamili = .idItem


    '                With categoriaSA.UbicarCategoriaPorID(codFamili)
    '                    txtCategoria.Text = .descripcion
    '                    txtCategoria.Tag = .idItem
    '                    txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

    '                    ''txtCategoria.Tag = .idPadre
    '                    'CMBClasificacion()
    '                    'Dim consulta = (From n In listaCategoria _
    '                    '     Where n.idFamilia = .idPadre).First
    '                    'With consulta
    '                    '    txtCategoria.Tag = consulta.idFamilia
    '                    '    txtCategoria.Text = consulta.nombre
    '                    '    txtCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                    'End With
    '                End With
    '            End If

    '            'Productoshijos()
    '            With categoriaSA.UbicarCategoriaPorID(codMarca)
    '                txtSubCategoria.Text = .descripcion
    '                txtSubCategoria.Tag = .idItem
    '                txtSubCategoria.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '            End With



    '            cboTipoExistencia.SelectedValue = .tipoExistencia
    '            'txtUm.Text = .unidad1
    '            cboUnidades.SelectedValue = .unidad1
    '            'txtCodPresentacion.Text = .presentacion
    '            'cboPresentacion.SelectedValue = .presentacion

    '            Select Case .origenProducto
    '                Case OperacionGravada.Grabado
    '                    cboIgv.Text = "1 - GRAVADO"
    '                Case OperacionGravada.Exonerado
    '                    cboIgv.Text = "2 - EXONERADO"
    '                Case OperacionGravada.Inafecto
    '                    cboIgv.Text = "3 - INAFECTO"
    '            End Select

    '        End With


    '        'If txtCategoria.Text.Trim.Length > 0 Then

    '        '    chClasificacion.Enabled = False
    '        '    Label8.Visible = True
    '        '    txtCategoria.Visible = True
    '        '    PictureBox2.Visible = True
    '        '    'Label3.Visible = True
    '        '    'txtSubCategoria.Visible = True
    '        '    'PictureBox6.Visible = True
    '        '    Label1.Visible = True
    '        '    txtProductoNew.Visible = True
    '        '    PictureBox1.Visible = True


    '        '    Label1.Location = New Point(28, 203)
    '        '    txtProductoNew.Location = New Point(28, 226)
    '        '    PictureBox1.Location = New Point(303, 226)
    '        'Else


    '        '    chClasificacion.Enabled = False
    '        '    Label8.Visible = False
    '        '    txtCategoria.Visible = False
    '        '    PictureBox2.Visible = False
    '        '    'Label3.Visible = False
    '        '    'txtSubCategoria.Visible = False
    '        '    'PictureBox6.Visible = False
    '        '    Label1.Visible = True
    '        '    txtProductoNew.Visible = True
    '        '    PictureBox1.Visible = True

    '        '    txtCategoria.Tag = Nothing
    '        '    txtCategoria.Clear()
    '        '    txtSubCategoria.Tag = Nothing
    '        '    txtSubCategoria.Clear()
    '        '    'txtProductoNew.Clear()

    '        '    Label1.Location = New Point(28, 95)
    '        '    txtProductoNew.Location = New Point(28, 116)
    '        '    PictureBox1.Location = New Point(308, 116)
    '        'End If

    '    Catch ex As Exception
    '        MessageBox.Show("Error ")
    '    End Try
    'End Sub


    Public Sub GrabarItemEstablec()
        Dim objitem As New detalleitems
        Dim itemSA As New detalleitemsSA
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        Dim c As New RecuperarCarteras
        Try
            'Se asigna cada uno de los datos registrados
            'objitem.idItem = CInt(txtCategoria.Tag)  ' Trim(txtCodigoDocumento.Text)
            '    objitem.fotoUrl = ucNuevoCalzado.PictureBox2.Image.Tag
            objitem.idItem = ucNuevoCalzado.ComboCategoria.SelectedValue
            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
            objitem.marcaRef = ucNuevoCalzado.txtMarca.Tag
            'objitem.cuenta = Nothing
            objitem.descripcionItem = Trim(ucNuevoCalzado.txtProductoNew.Text.Trim)
            'objitem.presentacion = txtPresentacion.ValueMember
            '  objitem.presentacion = cboPresentacion.SelectedValue
            'objitem.unidad1 = txtNomUnidad.ValueMember
            objitem.unidad1 = ucNuevoCalzado.cboUnidades.SelectedValue
            objitem.unidad2 = ucNuevoCalzado.ComboSubCategoria.SelectedValue
            objitem.cuenta = "601111"
            objitem.composicion = ucNuevoCalzado.txtValUnid.DecimalValue
            objitem.presentacion = ucNuevoCalzado.TextPresentacion.Text.Trim
            objitem.cantMax = nudCantMax.Value
            objitem.cantMinima = nudCantMin.Value
            objitem.codigo = ucNuevoCalzado.txtCodigoBarra.Text

            objitem.tipoExistencia = ucNuevoCalzado.cboTipoExistencia.SelectedValue
            Select Case ucNuevoCalzado.cboIgv.Text
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
            objitem.productoRestringido = False ' ucNuevoCalzado.CBProductoRestringido.Checked

            Select Case ucNuevoCalzado.ToggleAfectaICBPER.ToggleState
                Case ToggleButton2.ToggleButtonState.OFF 'NO AFECTA STOCK
                    objitem.tipoOtroImpuesto = "-"
                    objitem.otroImpuesto = 0


                Case ToggleButton2.ToggleButtonState.ON ' SI AFECTA STOCK
                    objitem.tipoOtroImpuesto = "ICBPER"
                    objitem.otroImpuesto = ucNuevoCalzado.NudIcbper.Value

            End Select
            objitem.igv = ucNuevoCalzado.NudIgv.Value

            Select Case ucNuevoCalzado.ToggleAfectaStock.ToggleState
                Case ToggleButton2.ToggleButtonState.OFF 'NO AFECTA STOCK
                    objitem.AfectoStock = False
                Case ToggleButton2.ToggleButtonState.ON ' SI AFECTA STOCK
                    objitem.AfectoStock = True
            End Select

            objitem.estado = "A"
            If objitem.tipoExistencia = "09" Then
                '    objitem.detalleitems_conexo = UCItemsAnexos.ListaItemsConexos.ToList
            End If


            objitem.igv = 18
            '   objitem.preciocompratipo = "FJ"
            objitem.precioCompra = 0

            objitem.talla = ucNuevoCalzado.comboTallas.Text
            objitem.color = ucNuevoCalzado.comboColor.Text
            objitem.Peso = ucNuevoCalzado.TextPeso.Text
            '  objitem.firstpercent = 0
            '  objitem.beforepercent = 0
            objitem.detalleitem_equivalencias = ListaEquivalencia
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

            objitem.cantidadMinima = ucNuevoCalzado.textCantMinima.Value
            objitem.cantidadMaxima = ucNuevoCalzado.textCantMaxima.Value

            Dim codxIdtem As Integer = itemSA.InsertItemDualTabla(objitem)
            objitem.codigodetalle = codxIdtem
            'Me.lblEstado.Text = "Item registrado!"
            'c.Cuenta = "Grabado"
            'c.ID = codxIdtem
            'c.IdEvento = ucNuevoCalzado.txtSubCategoria.Tag
            'c.NomEvento = ucNuevoCalzado.txtSubCategoria.Text
            'datos.Add(c)
            Tag = objitem
            '---------------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------------
            'If (MessageBox.Show("Desea asignar el precio ahora ?", "Precio", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = DialogResult.Yes Then
            '    Dim form As New frmExistenciaPrecios(txtProductoNew.Text.Trim)
            '    form.StartPosition = FormStartPosition.CenterParent
            '    form.ShowDialog(Me)
            'End If
            '---------------------------------------------------------------------------------------
            '---------------------------------------------------------------------------------------
            Close()
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
            '    objitem.fotoUrl = ucNuevoCalzado.PictureBox2.Image.Tag
            objitem.codigodetalle = CInt(ucNuevoCalzado.txtProductoNew.Tag)
            objitem.idItem = ucNuevoCalzado.ComboCategoria.SelectedValue
            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
            objitem.marcaRef = ucNuevoCalzado.txtMarca.Tag
            'objitem.cuenta = Nothing
            objitem.presentacion = ucNuevoCalzado.TextPresentacion.Text.Trim
            objitem.descripcionItem = ucNuevoCalzado.txtProductoNew.Text.Trim
            'objitem.presentacion = txtPresentacion.ValueMember
            '  objitem.presentacion = cboPresentacion.SelectedValue
            'objitem.unidad1 = txtNomUnidad.ValueMember
            objitem.unidad1 = ucNuevoCalzado.cboUnidades.SelectedValue
            objitem.unidad2 = ucNuevoCalzado.ComboSubCategoria.SelectedValue
            objitem.cuenta = "601111"
            objitem.composicion = ucNuevoCalzado.txtValUnid.DecimalValue

            objitem.cantMax = nudCantMax.Value
            objitem.cantMinima = nudCantMin.Value

            '  If ucNuevoCalzado.chAsigar.Checked = True Then
            objitem.codigo = ucNuevoCalzado.txtCodigoBarra.Text
            ' Else
            ' objitem.codigo = Nothing
            ' End If

            objitem.tipoExistencia = ucNuevoCalzado.cboTipoExistencia.SelectedValue
            Select Case ucNuevoCalzado.cboIgv.Text
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
            objitem.productoRestringido = False ' ucNuevoCalzado.CBProductoRestringido.Checked

            objitem.usuarioActualizacion = usuario.IDUsuario
            objitem.fechaActualizacion = DateTime.Now

            Select Case ucNuevoCalzado.ToggleAfectaICBPER.ToggleState
                Case ToggleButton2.ToggleButtonState.OFF 'NO AFECTA STOCK
                    objitem.tipoOtroImpuesto = "-"
                    objitem.otroImpuesto = 0


                Case ToggleButton2.ToggleButtonState.ON ' SI AFECTA STOCK
                    objitem.tipoOtroImpuesto = "ICBPER"
                    objitem.otroImpuesto = ucNuevoCalzado.NudIcbper.Value

            End Select


            objitem.idAlmacen = Nothing
            Select Case ucNuevoCalzado.ToggleAfectaStock.ToggleState
                Case ToggleButton2.ToggleButtonState.OFF 'NO AFECTA STOCK
                    objitem.AfectoStock = False
                Case ToggleButton2.ToggleButtonState.ON ' SI AFECTA STOCK
                    objitem.AfectoStock = True
            End Select
            objitem.cantidadMinima = ucNuevoCalzado.textCantMinima.Value
            objitem.cantidadMaxima = ucNuevoCalzado.textCantMaxima.Value

            objitem.talla = ucNuevoCalzado.comboTallas.Text
            objitem.color = ucNuevoCalzado.comboColor.Text
            objitem.Peso = ucNuevoCalzado.TextPeso.Text

            itemSA.UpdateProducto(objitem)
            Me.lblEstado.Text = "Item modificado!"
            c.Cuenta = "Grabado"
            c.ID = ucNuevoCalzado.txtProductoNew.Tag
            c.IdEvento = ucNuevoCalzado.txtMarca.Tag
            c.NomEvento = ucNuevoCalzado.txtMarca.Text
            datos.Add(c)
            Tag = objitem
            Close()

        Catch ex As Exception
            'Manejo de errores
            MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblEstado.Text = ex.Message
        End Try
    End Sub


#End Region


    Private Sub btOperacion_Click(sender As Object, e As EventArgs)

    End Sub

    'Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
    '    Close() 'Dispose()
    'End Sub

    Private Sub nudCantMax_ValueChanged(sender As Object, e As EventArgs) Handles nudCantMax.ValueChanged

    End Sub



    Private Sub txtCodigoBarra_TextChanged(sender As Object, e As EventArgs)

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

    'Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs)
    '    If txtProductoNew.Text.Trim.Length > 0 Then
    '        Dim f As New FormCrearEquivalenciasArticulo(New detalleitems With
    '                                                {
    '                                                .descripcionItem = txtProductoNew.Text.Trim,
    '                                                .unidad1 = cboUnidades.SelectedValue
    '                                                })
    '        f.textValUnidades.DecimalValue = txtValUnid.DecimalValue
    '        f.StartPosition = FormStartPosition.CenterParent
    '        f.ShowDialog(Me)
    '        If f.Tag IsNot Nothing Then
    '            Dim ListaEquivalencias = CType(f.Tag, List(Of detalleitem_equivalencias))
    '            Tag = ListaEquivalencias
    '        End If
    '    Else
    '        MessageBox.Show("Debe indicar la descripción del producto y la unidad de medida!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        txtProductoNew.Select()
    '    End If
    'End Sub

    Private Sub BunifuFlatButton15_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton15.Click, BunifuFlatButton1.Click, BunifuFlatButton2.Click
        sliderTop.Left = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Left
        sliderTop.Width = (CType(sender, Bunifu.Framework.UI.BunifuFlatButton)).Width

        Dim btn As Bunifu.Framework.UI.BunifuFlatButton = CType(sender, Bunifu.Framework.UI.BunifuFlatButton)
        'PanelBody.Controls.Clear()
        Select Case btn.Text
            Case "INFORMACION GENERAL"
                'If UCEquivalencias IsNot Nothing Then
                '    UCEquivalencias.Visible = False
                'End If

                '  UCItemsAnexos.Visible = False
                If ucNuevoCalzado IsNot Nothing Then
                    ucNuevoCalzado.Visible = True
                    ucNuevoCalzado.BringToFront()
                    ucNuevoCalzado.Show()
                    btOperacion.ButtonText = "Grabar"
                End If
                'Case "UNIDAD COMERCIAL"
                '    If ucNuevoCalzado.txtProductoNew.Text.Trim.Length = 0 Then
                '        MessageBox.Show("Debe ingresar un descripción del producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '        ucNuevoCalzado.txtProductoNew.Select()
                '        sliderTop.Left = BunifuFlatButton15.Left
                '        sliderTop.Width = BunifuFlatButton15.Width
                '        Exit Sub
                '    End If

                '    If ucNuevoCalzado.TextPresentacion.Text.Trim.Length = 0 Then
                '        MessageBox.Show("Debe indicar la presentación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '        ucNuevoCalzado.TextPresentacion.Select()
                '        sliderTop.Left = BunifuFlatButton15.Left
                '        sliderTop.Width = BunifuFlatButton15.Width
                '        Exit Sub
                '    End If

                '    If ucNuevoCalzado.txtValUnid.DecimalValue <= 0 Then
                '        MessageBox.Show("Debe indicar el contenido mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '        ucNuevoCalzado.txtValUnid.Select()
                '        sliderTop.Left = BunifuFlatButton15.Left
                '        sliderTop.Width = BunifuFlatButton15.Width
                '        Exit Sub
                '    End If

                '    UCItemsAnexos.Visible = False
                '    ucNuevoCalzado.Visible = False
                '    If UCEquivalencias IsNot Nothing Then
                '        UCEquivalencias.Visible = True
                '        UCEquivalencias.txtProveedor.Text = ucNuevoCalzado.txtProductoNew.Text.Trim
                '        UCEquivalencias.TextPresentacion.Text = ucNuevoCalzado.TextPresentacion.Text.Trim
                '        UCEquivalencias.TextPresentacion.Tag = CDec(ucNuevoCalzado.txtValUnid.DecimalValue)

                '        'UCEquivalencias.ListaEquivalencia = New List(Of detalleitem_equivalencias)
                '        'UCEquivalencias.CargarEquivalenciasDefault()
                '        'UCEquivalencias.BringToFront()
                '        UCEquivalencias.Show()
                '        btOperacion.ButtonText = "Aceptar"

                '    End If


                'Case "COMPONENTES KIT"

                '    If UCEquivalencias IsNot Nothing Then
                '        UCEquivalencias.Visible = False
                '    End If

                '    ucNuevoCalzado.Visible = False
                '    If UCItemsAnexos IsNot Nothing Then
                '        UCItemsAnexos.Visible = True
                '        UCItemsAnexos.BringToFront()
                '        UCItemsAnexos.Show()
                '        btOperacion.ButtonText = "Aceptar"
                '    End If
        End Select


    End Sub

    Private Sub frmNuevaExistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles btOperacion.Click

        Me.Cursor = Cursors.WaitCursor
        'Dim numero = nudCantMin.Value


        If Not ucNuevoCalzado.txtCodigoBarra.Text.Trim.Length > 0 Then

            MessageBox.Show("Ingrese un código para el producto", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If


        'If Not nudCantMin. |Value <= nudCantMax.Value Then
        '    'lblEstado.Text = "La cantidad maxima debe ser mayor o igual"
        '    'txtProductoNew.Select()
        '    MessageBox.Show("La cantidad maxima debe ser mayor o igual", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'End If

        If Not ucNuevoCalzado.txtMarca.Text.Trim.Length > 0 Then

            MessageBox.Show("Ingrese una marca valida", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If ucNuevoCalzado.txtMarca.Text.Trim.Length > 0 Then
            If ucNuevoCalzado.txtMarca.ForeColor = Color.Black Then
                MessageBox.Show("Verificar el ingreso correcto de la marca", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ucNuevoCalzado.txtMarca.Select()
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
        End If


        'If Not ucNuevoCalzado.txtCategoria.Text.Trim.Length > 0 Then

        '    MessageBox.Show("Ingrese la clasificación general", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'End If
        'If ucNuevoCalzado.txtCategoria.Text.Trim.Length > 0 Then
        '    If ucNuevoCalzado.txtCategoria.ForeColor = Color.Black Then
        '        MessageBox.Show("Verificar el ingreso correcto de la clasificación general", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        ucNuevoCalzado.txtCategoria.Select()
        '        Me.Cursor = Cursors.Arrow
        '        Exit Sub
        '    End If
        'End If



        '     ucNuevoCalzado.txtProductoNew.Text = Trim(ucNuevoCalzado.txtProductoNew.Text.Trim)

        ucNuevoCalzado.txtProductoNew.Text = LimpiarCadenaNombreFichero(ucNuevoCalzado.txtProductoNew.Text, "")

        If Trim(ucNuevoCalzado.txtProductoNew.Text.Trim).Length > 200 Then
            MessageBox.Show("El máximo de catecteres permitido es {200}.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ucNuevoCalzado.txtProductoNew.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not Trim(ucNuevoCalzado.txtProductoNew.Text.Trim).Length > 0 Then
            'lblEstado.Text = "Ingrese el nombre del producto"
            'txtProductoNew.Select()
            MessageBox.Show("Ingrese el nombre del producto", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not ucNuevoCalzado.cboUnidades.Text.Trim.Length > 0 Then
            'lblEstado.Text = "Ingrese el nombre del producto"
            'txtProductoNew.Select()
            MessageBox.Show("Ingrese la unidad de medida", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ucNuevoCalzado.cboUnidades.Select()
            ucNuevoCalzado.cboUnidades.DroppedDown = True
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        'If MessageBoxAdv.Show("va a guardar con cantidad mínima " + CStr(numero) + "?", "atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        If EstadoManipulacion = ENTITY_ACTIONS.INSERT Then
            '    If btOperacion.ButtonText = "Grabar" Then

            ucNuevoCalzado.Visible = False


            '    ElseIf btOperacion.ButtonText = "Aceptar" Then

            ListaEquivalencia = New List(Of detalleitem_equivalencias)

            If ucNuevoCalzado.TextUCMinima.Text.Trim.Length = 0 Then
                MessageBox.Show("Ingresar la unidad comercial mínima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
                Exit Sub
            End If

            If ucNuevoCalzado.CurrencyTextBox1.DecimalValue <= 0 Then
                MessageBox.Show("Ingresar cantidad mínima mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
                Exit Sub
            End If

            'UNIDAD MINIMA
            AddEquivalentV2(ucNuevoCalzado.TextUCMinima.Text, ucNuevoCalzado.CurrencyTextBox1.DecimalValue, "SOLO")


            If ListaEquivalencia.Count = 0 Then
                MessageBox.Show("Debe configurar las unidades comerciales", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Cursor = Cursors.Default
                Exit Sub
            End If

            GrabarItemEstablec()
            '    End If
        Else
            EditarItemEstablec()
        End If

        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub AddEquivalentV2(Text As String, contenido As String)
        Try
            Dim obj As New detalleitem_equivalencias
            Dim id = System.Guid.NewGuid()
            obj.IDGUI = id.ToString()
            obj.estado = "A"
            obj.detalle = Text
            obj.contenido = Decimal.Parse(contenido)
            obj.fraccionUnidad = 0
            obj.detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos)
            ListaEquivalencia.Add(obj)
            '   LoadGridEquivalenciasV2()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub AddEquivalentV2(UnidadComercial As String, contenido As Decimal?, Flag As String)
        Dim representacion As Integer = 0
        Dim valor As Decimal = 0
        Dim cont As String = Nothing
        Try

            'If GridEquivalencia.Table.Records.Count = 0 Then
            cont = UnidadComercial ' frmNuevaExistencia.UCNuenExistencia.cboUnidades.Text
            valor = 1
            representacion = 1
            'Else

            '    cont = UnidadComercial

            '    Dim primeraFila As Decimal = Decimal.Parse(GridEquivalencia.Table.Records(0).GetValue("contenido_neto"))
            '    Dim content As Decimal = primeraFila / contenido
            '    representacion = content

            '    valor = 0

            '    valor = 1 / content
            'End If


            Dim obj As New detalleitem_equivalencias
            Dim id = System.Guid.NewGuid()
            obj.IDGUI = id.ToString()
            obj.estado = "A"
            obj.detalle = ucNuevoCalzado.cboUnidades.SelectedValue
            obj.unidadComercial = UnidadComercial
            obj.contenido = representacion
            obj.fraccionUnidad = valor
            obj.contenido_neto = contenido
            obj.flag = Flag
            obj.detalleitemequivalencia_catalogos = New List(Of detalleitemequivalencia_catalogos) From
                {
                New detalleitemequivalencia_catalogos With
                    {
                    .nombre_corto = "CATALOGO GENERAL",
                    .nombre_largo = "CATALOGO GENERAL",
                    .predeterminado = True,
                    .estado = 1
                    }
                }
            ListaEquivalencia.Add(obj)
            ' LoadGridEquivalenciasV2()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class