Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Public Class frmNuevaExistencia
    Inherits frmMaster

    Public Property Precios As Boolean = False
    Public Property IdAlmacenPrecio As Integer
    Public Property EstadoManipulacion() As String
    Public Property Listadetalleitem_equivalencias As List(Of detalleitem_equivalencias)
    Public Property UCEquivalencias As UCProductoEquivalencias
    Public Property UCNuenExistencia As UCNuenExistencia
    Public Property UCItemsAnexos As UCItemsAnexos

    '3 - INAFECTO

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        Listadetalleitem_equivalencias = New List(Of detalleitem_equivalencias)
        UCItemsAnexos = New UCItemsAnexos(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        UCEquivalencias = New UCProductoEquivalencias()
        UCEquivalencias.frmNuevaExistencia = Me
        UCNuenExistencia = New UCNuenExistencia(Me)
        PanelBody.Controls.Add(UCNuenExistencia)
        PanelBody.Controls.Add(UCEquivalencias)
        PanelBody.Controls.Add(UCItemsAnexos)
        'UCNuenExistencia.BringToFront()
        'UCNuenExistencia.Show()

    End Sub

    Public Sub New(CodigoItem As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        'UCItemsAnexos = New UCItemsAnexos(Me) With {.Dock = DockStyle.Fill, .Visible = False}
        BunifuFlatButton2.Visible = False
        UCNuenExistencia = New UCNuenExistencia(CodigoItem, Me)
        PanelBody.Controls.Add(UCNuenExistencia)
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


            If UCEquivalencias.ComboPlantilla.Text = "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)" Then
                objitem.tipoItem = "MULT"
            ElseIf UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL" Then
                objitem.tipoItem = "UNIC"
                'Select Case UCEquivalencias.ToggleTipoItem.ToggleState
                '    Case ToggleButton2.ToggleButtonState.OFF 'NO AFECTA STOCK
                '        objitem.tipoItem = "UNIC"
                '    Case ToggleButton2.ToggleButtonState.ON ' SI AFECTA STOCK
                '        objitem.tipoItem = "DET"
                'End Select
            ElseIf UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL DETALLADO" Then

                objitem.tipoItem = "DET"
            End If

            'Se asigna cada uno de los datos registrados
            'objitem.idItem = CInt(txtCategoria.Tag)  ' Trim(txtCodigoDocumento.Text)

            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue


            objitem.tipoBien = UCNuenExistencia.cboTipoBien.Text
            objitem.idClasificacion = CInt(UCNuenExistencia.txtClasificacion.Tag)
            objitem.idItem = CInt(UCNuenExistencia.txtCategoria.Tag)
            objitem.unidad2 = UCNuenExistencia.txtSubCategoria.Tag
            objitem.marcaRef = UCNuenExistencia.txtMarca.Tag
            objitem.idCaracteristica = CInt(UCNuenExistencia.TextPresentacion.Tag)
            objitem.presentacion = UCNuenExistencia.TextPresentacion.Text.Trim

            objitem.descripcionItem = Trim(UCNuenExistencia.txtProductoNew.Text.Trim)
            objitem.unidad1 = UCNuenExistencia.cboUnidades.SelectedValue
            objitem.cuenta = "601111"
            objitem.composicion = UCNuenExistencia.txtValUnid.DecimalValue

            objitem.cantMax = nudCantMax.Value
            objitem.cantMinima = nudCantMin.Value

            objitem.color = UCNuenExistencia.comboColor.Text
            objitem.talla = UCNuenExistencia.comboTallas.Text
            objitem.electricidad = UCNuenExistencia.comboAdicional1.Text
            objitem.transmision = UCNuenExistencia.comboAdicional2.Text
            objitem.Peso = UCNuenExistencia.TextPeso.Text


            If UCNuenExistencia.chAsigar.Checked = True Then
                objitem.codigo = UCNuenExistencia.txtCodigoBarra.Text
            Else
                objitem.codigo = Nothing
            End If


            If UCNuenExistencia.chInterno.Checked = True Then
                objitem.codigoInterno = UCNuenExistencia.txtCodigoInterno.Text
            Else
                objitem.codigoInterno = Nothing
            End If




            objitem.tipoExistencia = UCNuenExistencia.cboTipoExistencia.SelectedValue
            Select Case UCNuenExistencia.cboIgv.Text
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
            objitem.productoRestringido = UCNuenExistencia.CBProductoRestringido.Checked

            Select Case UCNuenExistencia.ToggleAfectaICBPER.ToggleState
                Case ToggleButton2.ToggleButtonState.OFF 'NO AFECTA STOCK
                    objitem.tipoOtroImpuesto = "-"
                    objitem.otroImpuesto = 0

                Case ToggleButton2.ToggleButtonState.ON ' SI AFECTA STOCK
                    objitem.tipoOtroImpuesto = "ICBPER"
                    objitem.otroImpuesto = UCNuenExistencia.NudIcbper.Value

            End Select
            objitem.igv = UCNuenExistencia.NudIgv.Value

            Select Case UCNuenExistencia.ToggleAfectaStock.ToggleState
                Case ToggleButton2.ToggleButtonState.OFF 'NO AFECTA STOCK
                    objitem.AfectoStock = False
                Case ToggleButton2.ToggleButtonState.ON ' SI AFECTA STOCK
                    objitem.AfectoStock = True
            End Select

            objitem.estado = "A"
            If objitem.tipoExistencia = "09" Then
                objitem.detalleitems_conexo = UCItemsAnexos.ListaItemsConexos.ToList
            End If


            objitem.igv = 18
            objitem.preciocompratipo = "FJ"
            objitem.precioCompra = 0
            objitem.firstpercent = 0
            objitem.beforepercent = 0

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
            If UCEquivalencias IsNot Nothing Then
                If UCEquivalencias.ListaEquivalencia IsNot Nothing Then
                    If UCEquivalencias.ListaEquivalencia.Count > 0 Then
                        objitem.detalleitem_equivalencias = UCEquivalencias.ListaEquivalencia ' Tag

                        'Dim validarEquivalencias = UCEquivalencias.ListaEquivalencia.Where(Function(o) o.contenido = 0).Count
                        'If validarEquivalencias > 0 Then
                        '    MessageBox.Show("Debe ingresar todas las representaciones", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    Cursor = Cursors.Default
                        '    Exit Sub
                        'End If

                        Dim validarContenidoNetos = UCEquivalencias.ListaEquivalencia.Where(Function(o) o.contenido_neto = 0).Count
                        If validarContenidoNetos > 0 Then
                            MessageBox.Show("Debe ingresar todas los contenidos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                        '         objitem.unidad1 = UCEquivalencias.ListaEquivalencia.FirstOrDefault.detalle
                    Else
                        MessageBox.Show("Debe configurar las unidades comerciales", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Debe configurar las unidades comerciales", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            objitem.cantidadMinima = UCNuenExistencia.textCantMinima.Value
            objitem.cantidadMaxima = UCNuenExistencia.textCantMaxima.Value

            Dim codxIdtem As Integer = itemSA.InsertItemDualTabla(objitem)
            objitem.codigodetalle = codxIdtem
            'Me.lblEstado.Text = "Item registrado!"
            'c.Cuenta = "Grabado"
            'c.ID = codxIdtem
            'c.IdEvento = UCNuenExistencia.txtSubCategoria.Tag
            'c.NomEvento = UCNuenExistencia.txtSubCategoria.Text
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


            'If UCEquivalencias.ComboPlantilla.Text = "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)" Then
            '    objitem.tipoItem = "MULT"
            'ElseIf UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL" Then
            '    objitem.tipoItem = "UNIC"
            'ElseIf UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL DETALLADO" Then

            '    objitem.tipoItem = "DET"
            'End If



            objitem.codigodetalle = CInt(UCNuenExistencia.txtProductoNew.Tag)

            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue

            objitem.tipoBien = UCNuenExistencia.cboTipoBien.Text
            objitem.idClasificacion = CInt(UCNuenExistencia.txtClasificacion.Tag)
            objitem.idItem = CInt(UCNuenExistencia.txtCategoria.Tag)
            objitem.unidad2 = UCNuenExistencia.txtSubCategoria.Tag
            objitem.marcaRef = UCNuenExistencia.txtMarca.Tag
            objitem.idCaracteristica = CInt(UCNuenExistencia.TextPresentacion.Tag)
            objitem.presentacion = UCNuenExistencia.TextPresentacion.Text.Trim

            'objitem.cuenta = Nothing

            objitem.descripcionItem = UCNuenExistencia.txtProductoNew.Text.Trim
            'objitem.presentacion = txtPresentacion.ValueMember
            '  objitem.presentacion = cboPresentacion.SelectedValue
            'objitem.unidad1 = txtNomUnidad.ValueMember
            objitem.unidad1 = UCNuenExistencia.cboUnidades.SelectedValue

            objitem.cuenta = "601111"
            objitem.composicion = UCNuenExistencia.txtValUnid.DecimalValue

            objitem.cantMax = nudCantMax.Value
            objitem.cantMinima = nudCantMin.Value

            objitem.color = UCNuenExistencia.comboColor.Text
            objitem.talla = UCNuenExistencia.comboTallas.Text
            objitem.electricidad = UCNuenExistencia.comboAdicional1.Text
            objitem.transmision = UCNuenExistencia.comboAdicional2.Text
            objitem.Peso = UCNuenExistencia.TextPeso.Text

            If UCNuenExistencia.chAsigar.Checked = True Then
                objitem.codigo = UCNuenExistencia.txtCodigoBarra.Text
            Else
                objitem.codigo = Nothing
            End If


            If UCNuenExistencia.chInterno.Checked = True Then
                objitem.codigoInterno = UCNuenExistencia.txtCodigoInterno.Text
            Else
                objitem.codigoInterno = Nothing
            End If


            objitem.tipoExistencia = UCNuenExistencia.cboTipoExistencia.SelectedValue
            Select Case UCNuenExistencia.cboIgv.Text
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
            objitem.productoRestringido = UCNuenExistencia.CBProductoRestringido.Checked

            objitem.usuarioActualizacion = usuario.IDUsuario
            objitem.fechaActualizacion = DateTime.Now

            Select Case UCNuenExistencia.ToggleAfectaICBPER.ToggleState
                Case ToggleButton2.ToggleButtonState.OFF 'NO AFECTA STOCK
                    objitem.tipoOtroImpuesto = "-"
                    objitem.otroImpuesto = 0


                Case ToggleButton2.ToggleButtonState.ON ' SI AFECTA STOCK
                    objitem.tipoOtroImpuesto = "ICBPER"
                    objitem.otroImpuesto = UCNuenExistencia.NudIcbper.Value

            End Select


            objitem.idAlmacen = Nothing
            Select Case UCNuenExistencia.ToggleAfectaStock.ToggleState
                Case ToggleButton2.ToggleButtonState.OFF 'NO AFECTA STOCK
                    objitem.AfectoStock = False
                Case ToggleButton2.ToggleButtonState.ON ' SI AFECTA STOCK
                    objitem.AfectoStock = True
            End Select
            objitem.cantidadMinima = UCNuenExistencia.textCantMinima.Value
            objitem.cantidadMaxima = UCNuenExistencia.textCantMaxima.Value
            itemSA.UpdateProducto(objitem)
            Me.lblEstado.Text = "Item modificado!"
            c.Cuenta = "Grabado"
            c.ID = UCNuenExistencia.txtProductoNew.Tag
            c.IdEvento = UCNuenExistencia.txtMarca.Tag
            c.NomEvento = UCNuenExistencia.txtMarca.Text
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

        If Not UCNuenExistencia.cboTipoUnidadComercial.Text = "VARIOS-UNIDADES COMERCIALES" Then
            Exit Sub
        End If

        Select Case btn.Text
            Case "INFORMACION GENERAL"
                If UCEquivalencias IsNot Nothing Then
                    UCEquivalencias.Visible = False
                End If

                UCItemsAnexos.Visible = False
                If UCNuenExistencia IsNot Nothing Then
                    UCNuenExistencia.Visible = True
                    UCNuenExistencia.BringToFront()
                    UCNuenExistencia.Show()
                    btOperacion.ButtonText = "Grabar"
                End If
            Case "UNIDAD COMERCIAL"
                If UCNuenExistencia.txtProductoNew.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe ingresar un descripción del producto", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    UCNuenExistencia.txtProductoNew.Select()
                    sliderTop.Left = BunifuFlatButton15.Left
                    sliderTop.Width = BunifuFlatButton15.Width
                    Exit Sub
                End If

                If UCNuenExistencia.TextPresentacion.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe indicar la presentación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    UCNuenExistencia.TextPresentacion.Select()
                    sliderTop.Left = BunifuFlatButton15.Left
                    sliderTop.Width = BunifuFlatButton15.Width
                    Exit Sub
                End If

                If UCNuenExistencia.txtValUnid.DecimalValue <= 0 Then
                    MessageBox.Show("Debe indicar el contenido mayor a cero", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    UCNuenExistencia.txtValUnid.Select()
                    sliderTop.Left = BunifuFlatButton15.Left
                    sliderTop.Width = BunifuFlatButton15.Width
                    Exit Sub
                End If

                UCItemsAnexos.Visible = False
                UCNuenExistencia.Visible = False
                If UCEquivalencias IsNot Nothing Then
                    UCEquivalencias.Visible = True
                    UCEquivalencias.txtProveedor.Text = UCNuenExistencia.txtProductoNew.Text.Trim
                    UCEquivalencias.TextPresentacion.Text = UCNuenExistencia.TextPresentacion.Text.Trim
                    UCEquivalencias.TextPresentacion.Tag = CDec(UCNuenExistencia.txtValUnid.DecimalValue)

                    'UCEquivalencias.ListaEquivalencia = New List(Of detalleitem_equivalencias)
                    'UCEquivalencias.CargarEquivalenciasDefault()
                    'UCEquivalencias.BringToFront()
                    UCEquivalencias.Show()
                    btOperacion.ButtonText = "Aceptar"

                End If


            Case "COMPONENTES KIT"

                If UCEquivalencias IsNot Nothing Then
                    UCEquivalencias.Visible = False
                End If

                UCNuenExistencia.Visible = False
                If UCItemsAnexos IsNot Nothing Then
                    UCItemsAnexos.Visible = True
                    UCItemsAnexos.BringToFront()
                    UCItemsAnexos.Show()
                    btOperacion.ButtonText = "Aceptar"
                End If
        End Select


    End Sub

    Private Sub frmNuevaExistencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles btOperacion.Click

        Me.Cursor = Cursors.WaitCursor
        'Dim numero = nudCantMin.Value
        If EstadoManipulacion = ENTITY_ACTIONS.INSERT Then
            If UCNuenExistencia.cboTipoUnidadComercial.Text = "UNIDAD POR DETALLE" Then
                UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL DETALLADO"
            ElseIf UCNuenExistencia.cboTipoUnidadComercial.Text = "VARIOS-UNIDADES COMERCIALES" Then
                UCEquivalencias.ComboPlantilla.Text = "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)"
            ElseIf UCNuenExistencia.cboTipoUnidadComercial.Text = "UNIDAD" Then
                UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL"
            End If
        End If




        If UCNuenExistencia.chAsigar.Checked = True Then
            If Not UCNuenExistencia.txtCodigoBarra.Text.Trim.Length > 0 Then

                MessageBox.Show("Ingrese un Codigo de Existencia", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If
        End If

        'If Not nudCantMin. |Value <= nudCantMax.Value Then
        '    'lblEstado.Text = "La cantidad maxima debe ser mayor o igual"
        '    'txtProductoNew.Select()
        '    MessageBox.Show("La cantidad maxima debe ser mayor o igual", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'End If

        If Not UCNuenExistencia.txtMarca.Text.Trim.Length > 0 Then

            MessageBox.Show("Ingrese una marca ", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UCNuenExistencia.txtMarca.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not UCNuenExistencia.TextPresentacion.Text.Trim.Length > 0 Then

            MessageBox.Show("Ingrese una presentacion ", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UCNuenExistencia.TextPresentacion.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        'If UCNuenExistencia.txtMarca.Text.Trim.Length > 0 Then
        '    If UCNuenExistencia.txtMarca.ForeColor = Color.Black Then
        '        MessageBox.Show("Verificar el ingreso correcto de la marca", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        UCNuenExistencia.txtMarca.Select()
        '        Me.Cursor = Cursors.Arrow
        '        Exit Sub
        '    End If
        'End If

        'f (UCNuenExistencia.chClasificacion.Checked = True) Then

        If Not UCNuenExistencia.txtClasificacion.Text.Trim.Length > 0 Then

            MessageBox.Show("Ingrese una Clasificacion", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UCNuenExistencia.txtClasificacion.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not UCNuenExistencia.txtCategoria.Text.Trim.Length > 0 Then

            MessageBox.Show("Ingrese una Categoria", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UCNuenExistencia.txtCategoria.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not UCNuenExistencia.txtSubCategoria.Text.Trim.Length > 0 Then

            MessageBox.Show("Ingrese una SubCategoria", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UCNuenExistencia.txtSubCategoria.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        'If UCNuenExistencia.txtSubCategoria.Text.Trim.Length > 0 Then
        '    If UCNuenExistencia.txtSubCategoria.ForeColor = Color.Black Then
        '        MessageBox.Show("Verificar el ingreso correcto de la clasificación general", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        UCNuenExistencia.txtSubCategoria.Select()
        '        Me.Cursor = Cursors.Arrow
        '        Exit Sub
        '    End If
        'End If
        'ed If

        '     UCNuenExistencia.txtProductoNew.Text = Trim(UCNuenExistencia.txtProductoNew.Text.Trim)

        UCNuenExistencia.txtProductoNew.Text = LimpiarCadenaNombreFichero(UCNuenExistencia.txtProductoNew.Text, "")

        If Trim(UCNuenExistencia.txtProductoNew.Text.Trim).Length > 200 Then
            MessageBox.Show("El máximo de catecteres permitido es {200}.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UCNuenExistencia.txtProductoNew.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not Trim(UCNuenExistencia.txtProductoNew.Text.Trim).Length > 0 Then
            'lblEstado.Text = "Ingrese el nombre del producto"
            'txtProductoNew.Select()
            MessageBox.Show("Ingrese el nombre del producto", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not UCNuenExistencia.cboUnidades.Text.Trim.Length > 0 Then
            'lblEstado.Text = "Ingrese el nombre del producto"
            'txtProductoNew.Select()
            MessageBox.Show("Ingrese la unidad de medida", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            UCNuenExistencia.cboUnidades.Select()
            UCNuenExistencia.cboUnidades.DroppedDown = True
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        'If MessageBoxAdv.Show("va a guardar con cantidad mínima " + CStr(numero) + "?", "atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
        If EstadoManipulacion = ENTITY_ACTIONS.INSERT Then
            If btOperacion.ButtonText = "Grabar" Then

                UCNuenExistencia.Visible = False
                If UCEquivalencias IsNot Nothing Then
                    'If UCEquivalencias.ComboPlantilla.Text = "MIN. Y MAX. UNIDAD COMERCIAL" Then
                    '    If UCEquivalencias.TextUCMaxima.Text.Trim.Length = 0 Then
                    '        MessageBox.Show("Ingresar la unidad comercial maxima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '        Cursor = Cursors.Default
                    '        Exit Sub
                    '    End If

                    '    If UCEquivalencias.TextUCMinima.Text.Trim.Length = 0 Then
                    '        MessageBox.Show("Ingresar la unidad comercial maxima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '        Cursor = Cursors.Default
                    '        Exit Sub
                    '    End If

                    '    UCEquivalencias.AddEquivalentV2(UCEquivalencias.TextUCMaxima.Text, UCEquivalencias.TextCantMax.DecimalValue, )
                    '    UCEquivalencias.AddEquivalentV2(UCEquivalencias.TextUCMinima.Text, UCEquivalencias.TextCantMinima.DecimalValue)
                    'End If







                    'If UCNuenExistencia.ComboBoxAdv1.Text = "UNIDAD POR DETALLE" Then
                    '    UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL DETALLADO"
                    'ElseIf UCNuenExistencia.ComboBoxAdv1.Text = "VARIOS-UNIDADES COMERCIALES" Then
                    '    UCEquivalencias.ComboPlantilla.Text = "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)"

                    If UCNuenExistencia.cboTipoUnidadComercial.Text = "UNIDAD POR DETALLE" Then
                        UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL DETALLADO"
                    ElseIf UCNuenExistencia.cboTipoUnidadComercial.Text = "VARIOS-UNIDADES COMERCIALES" Then
                        UCEquivalencias.ComboPlantilla.Text = "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)"

                        UCEquivalencias.Show()


                    ElseIf UCNuenExistencia.cboTipoUnidadComercial.Text = "UNIDAD" Then
                        UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL"
                    End If


                    UCEquivalencias.txtProveedor.Text = UCNuenExistencia.txtProductoNew.Text.Trim
                    UCEquivalencias.TextPresentacion.Text = UCNuenExistencia.TextPresentacion.Text.Trim
                    UCEquivalencias.TextPresentacion.Tag = CDec(UCNuenExistencia.txtValUnid.DecimalValue)


                    'ElseIf UCNuenExistencia.ComboBoxAdv1.Text = "UNIDAD" Then
                    '    UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL"
                    'End If




                    Select Case UCNuenExistencia.cboTipoExistencia.Text
                        Case "KIT"
                            If UCItemsAnexos.ListaItemsConexos Is Nothing Then
                                MessageBox.Show("Ingresar al menos un item conexo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Cursor = Cursors.Default
                                Exit Sub
                            End If

                            If UCItemsAnexos.ListaItemsConexos.Count = 0 Then
                                MessageBox.Show("Ingresar al menos un item conexo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Cursor = Cursors.Default
                                Exit Sub
                            End If
                        Case Else

                    End Select



                    'UCEquivalencias.ListaEquivalencia = New List(Of detalleitem_equivalencias)
                    'UCEquivalencias.CargarEquivalenciasDefault()
                    'UCEquivalencias.BringToFront()


                    If UCNuenExistencia.cboTipoUnidadComercial.Text = "UNIDAD POR DETALLE" Then
                        UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL DETALLADO"
                    ElseIf UCNuenExistencia.cboTipoUnidadComercial.Text = "VARIOS-UNIDADES COMERCIALES" Then
                        UCEquivalencias.ComboPlantilla.Text = "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)"

                        UCEquivalencias.Show()


                    ElseIf UCNuenExistencia.cboTipoUnidadComercial.Text = "UNIDAD" Then
                        UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL"
                    End If




                    btOperacion.ButtonText = "Aceptar"

                    sliderTop.Left = BunifuFlatButton1.Left
                    sliderTop.Width = BunifuFlatButton1.Width
                End If

            ElseIf btOperacion.ButtonText = "Aceptar" Then


                If UCEquivalencias.ComboPlantilla.Text = "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)" Then

                    UCEquivalencias.ListaEquivalencia = New List(Of detalleitem_equivalencias)

                    If UCEquivalencias.TextUCMaxima.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingresar la unidad comercial maxima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If UCEquivalencias.TextUCMinima.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingresar la unidad comercial mínima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If UCEquivalencias.TextCantMinima.DecimalValue <= 0 Then
                        MessageBox.Show("Ingresar cantidad mínima mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If UCEquivalencias.TextCantMax.DecimalValue <= 0 Then
                        MessageBox.Show("Ingresar cantidad máxima mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If UCEquivalencias.TextCantMax.DecimalValue < UCEquivalencias.TextCantMinima.DecimalValue Then
                        MessageBox.Show("La cantidad máxima debe ser mayor ala minima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If UCEquivalencias.TextCantMax.DecimalValue = UCEquivalencias.TextCantMinima.DecimalValue Then
                        MessageBox.Show("La cantidad máxima debe ser mayor ala minima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If


                    'UNIDAD MAXIMA
                    UCEquivalencias.AddEquivalentV2(UCEquivalencias.TextUCMaxima.Text, UCEquivalencias.TextCantMax.DecimalValue, "MAX")
                    'UNIDAD MINIMA
                    UCEquivalencias.AddEquivalentV2(UCEquivalencias.TextUCMinima.Text, UCEquivalencias.TextCantMinima.DecimalValue, "MIN")


                ElseIf UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL" Then
                    UCEquivalencias.ListaEquivalencia = New List(Of detalleitem_equivalencias)

                    If UCEquivalencias.TextUCMinima.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingresar la unidad comercial mínima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If UCEquivalencias.TextCantMinima.DecimalValue <= 0 Then
                        MessageBox.Show("Ingresar cantidad mínima mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    'UNIDAD MINIMA
                    UCEquivalencias.AddEquivalentV2(UCEquivalencias.TextUCMinima.Text, UCEquivalencias.TextCantMinima.DecimalValue, "SOLO")

                    If UCEquivalencias.ListaEquivalencia.Count = 0 Then
                        MessageBox.Show("Debe configurar las unidades comerciales", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If



                ElseIf UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL DETALLADO" Then
                    UCEquivalencias.ListaEquivalencia = New List(Of detalleitem_equivalencias)

                    If UCNuenExistencia.txtSubCategoria.Tag Is Nothing Then
                        MessageBox.Show("Debe Ingresar una Sub Clasificacion!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If UCEquivalencias.TextUCMinima.Text.Trim.Length = 0 Then
                        MessageBox.Show("Ingresar la unidad comercial mínima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If UCEquivalencias.TextCantMinima.DecimalValue <= 0 Then
                        MessageBox.Show("Ingresar cantidad mínima mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If

                    'UNIDAD MINIMA
                    UCEquivalencias.AddEquivalentV2(UCEquivalencias.TextUCMinima.Text, UCEquivalencias.TextCantMinima.DecimalValue, "SOLO")

                    If UCEquivalencias.ListaEquivalencia.Count = 0 Then
                        MessageBox.Show("Debe configurar las unidades comerciales", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Cursor = Cursors.Default
                        Exit Sub
                    End If



                End If

                GrabarItemEstablec()
            End If
        Else
            EditarItemEstablec()
        End If

        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    'Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles btOperacion.Click

    '    Me.Cursor = Cursors.WaitCursor
    '    'Dim numero = nudCantMin.Value


    '    If UCNuenExistencia.cboTipoUnidadComercial.Text = "UNIDAD POR DETALLE" Then
    '        UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL DETALLADO"
    '    ElseIf UCNuenExistencia.cboTipoUnidadComercial.Text = "VARIOS-UNIDADES COMERCIALES" Then
    '        UCEquivalencias.ComboPlantilla.Text = "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)"
    '    ElseIf UCNuenExistencia.cboTipoUnidadComercial.Text = "UNIDAD" Then
    '        UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL"
    '    End If

    '    If UCNuenExistencia.chAsigar.Checked = True Then
    '        If Not UCNuenExistencia.txtCodigoBarra.Text.Trim.Length > 0 Then

    '            MessageBox.Show("Ingrese un Codigo de Existencia", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Me.Cursor = Cursors.Arrow
    '            Exit Sub
    '        End If
    '    End If

    '    'If Not nudCantMin. |Value <= nudCantMax.Value Then
    '    '    'lblEstado.Text = "La cantidad maxima debe ser mayor o igual"
    '    '    'txtProductoNew.Select()
    '    '    MessageBox.Show("La cantidad maxima debe ser mayor o igual", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    '    Me.Cursor = Cursors.Arrow
    '    '    Exit Sub
    '    'End If

    '    If Not UCNuenExistencia.txtMarca.Text.Trim.Length > 0 Then

    '        MessageBox.Show("Ingrese una marca valida", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Me.Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    If UCNuenExistencia.txtMarca.Text.Trim.Length > 0 Then
    '        If UCNuenExistencia.txtMarca.ForeColor = Color.Black Then
    '            MessageBox.Show("Verificar el ingreso correcto de la marca", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            UCNuenExistencia.txtMarca.Select()
    '            Me.Cursor = Cursors.Arrow
    '            Exit Sub
    '        End If
    '    End If

    '    If (UCNuenExistencia.chClasificacion.Checked = True) Then
    '        If Not UCNuenExistencia.txtSubClasificacion.Text.Trim.Length > 0 Then

    '            MessageBox.Show("Ingrese la clasificación general", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Me.Cursor = Cursors.Arrow
    '            Exit Sub
    '        End If
    '        If UCNuenExistencia.txtSubClasificacion.Text.Trim.Length > 0 Then
    '            If UCNuenExistencia.txtSubClasificacion.ForeColor = Color.Black Then
    '                MessageBox.Show("Verificar el ingreso correcto de la clasificación general", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                UCNuenExistencia.txtSubClasificacion.Select()
    '                Me.Cursor = Cursors.Arrow
    '                Exit Sub
    '            End If
    '        End If

    '    End If

    '    '     UCNuenExistencia.txtProductoNew.Text = Trim(UCNuenExistencia.txtProductoNew.Text.Trim)

    '    UCNuenExistencia.txtProductoNew.Text = LimpiarCadenaNombreFichero(UCNuenExistencia.txtProductoNew.Text, "")

    '    If Trim(UCNuenExistencia.txtProductoNew.Text.Trim).Length > 200 Then
    '        MessageBox.Show("El máximo de catecteres permitido es {200}.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        UCNuenExistencia.txtProductoNew.Select()
    '        Me.Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    If Not Trim(UCNuenExistencia.txtProductoNew.Text.Trim).Length > 0 Then
    '        'lblEstado.Text = "Ingrese el nombre del producto"
    '        'txtProductoNew.Select()
    '        MessageBox.Show("Ingrese el nombre del producto", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Me.Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    If Not UCNuenExistencia.cboUnidades.Text.Trim.Length > 0 Then
    '        'lblEstado.Text = "Ingrese el nombre del producto"
    '        'txtProductoNew.Select()
    '        MessageBox.Show("Ingrese la unidad de medida", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        UCNuenExistencia.cboUnidades.Select()
    '        UCNuenExistencia.cboUnidades.DroppedDown = True
    '        Me.Cursor = Cursors.Arrow
    '        Exit Sub
    '    End If

    '    'If MessageBoxAdv.Show("va a guardar con cantidad mínima " + CStr(numero) + "?", "atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
    '    If EstadoManipulacion = ENTITY_ACTIONS.INSERT Then
    '        If btOperacion.ButtonText = "Grabar" Then

    '            UCNuenExistencia.Visible = False
    '            If UCEquivalencias IsNot Nothing Then
    '                'If UCEquivalencias.ComboPlantilla.Text = "MIN. Y MAX. UNIDAD COMERCIAL" Then
    '                '    If UCEquivalencias.TextUCMaxima.Text.Trim.Length = 0 Then
    '                '        MessageBox.Show("Ingresar la unidad comercial maxima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                '        Cursor = Cursors.Default
    '                '        Exit Sub
    '                '    End If

    '                '    If UCEquivalencias.TextUCMinima.Text.Trim.Length = 0 Then
    '                '        MessageBox.Show("Ingresar la unidad comercial maxima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                '        Cursor = Cursors.Default
    '                '        Exit Sub
    '                '    End If

    '                '    UCEquivalencias.AddEquivalentV2(UCEquivalencias.TextUCMaxima.Text, UCEquivalencias.TextCantMax.DecimalValue, )
    '                '    UCEquivalencias.AddEquivalentV2(UCEquivalencias.TextUCMinima.Text, UCEquivalencias.TextCantMinima.DecimalValue)
    '                'End If


    '                If UCNuenExistencia.cboTipoUnidadComercial.Text = "UNIDAD POR DETALLE" Then
    '                    UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL DETALLADO"
    '                ElseIf UCNuenExistencia.cboTipoUnidadComercial.Text = "VARIOS-UNIDADES COMERCIALES" Then
    '                    UCEquivalencias.ComboPlantilla.Text = "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)"

    '                    UCEquivalencias.Show()


    '                ElseIf UCNuenExistencia.cboTipoUnidadComercial.Text = "UNIDAD" Then
    '                    UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL"
    '                End If

    '                'UCEquivalencias.Visible = True
    '                UCEquivalencias.txtProveedor.Text = UCNuenExistencia.txtProductoNew.Text.Trim
    '                UCEquivalencias.TextPresentacion.Text = UCNuenExistencia.TextPresentacion.Text.Trim
    '                UCEquivalencias.TextPresentacion.Tag = CDec(UCNuenExistencia.txtValUnid.DecimalValue)

    '                Select Case UCNuenExistencia.cboTipoExistencia.Text
    '                    Case "KIT"
    '                        If UCItemsAnexos.ListaItemsConexos Is Nothing Then
    '                            MessageBox.Show("Ingresar al menos un item conexo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                            Cursor = Cursors.Default
    '                            Exit Sub
    '                        End If

    '                        If UCItemsAnexos.ListaItemsConexos.Count = 0 Then
    '                            MessageBox.Show("Ingresar al menos un item conexo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                            Cursor = Cursors.Default
    '                            Exit Sub
    '                        End If
    '                    Case Else

    '                End Select



    '                'UCEquivalencias.ListaEquivalencia = New List(Of detalleitem_equivalencias)
    '                'UCEquivalencias.CargarEquivalenciasDefault()
    '                'UCEquivalencias.BringToFront()



    '                If UCNuenExistencia.cboTipoUnidadComercial.Text = "UNIDAD POR DETALLE" Then
    '                    UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL DETALLADO"
    '                ElseIf UCNuenExistencia.cboTipoUnidadComercial.Text = "VARIOS-UNIDADES COMERCIALES" Then
    '                    UCEquivalencias.ComboPlantilla.Text = "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)"

    '                    UCEquivalencias.Show()


    '                ElseIf UCNuenExistencia.cboTipoUnidadComercial.Text = "UNIDAD" Then
    '                    UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL"
    '                End If




    '                'UCEquivalencias.Show()
    '                btOperacion.ButtonText = "Aceptar"

    '                sliderTop.Left = BunifuFlatButton1.Left
    '                sliderTop.Width = BunifuFlatButton1.Width
    '            End If

    '        ElseIf btOperacion.ButtonText = "Aceptar" Then


    '            If UCEquivalencias.ComboPlantilla.Text = "VARIAS UNIDADES COMERCIALES(ESTABLECER :MIN. Y MAX.)" Then

    '                UCEquivalencias.ListaEquivalencia = New List(Of detalleitem_equivalencias)

    '                If UCEquivalencias.TextUCMaxima.Text.Trim.Length = 0 Then
    '                    MessageBox.Show("Ingresar la unidad comercial maxima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Cursor = Cursors.Default
    '                    Exit Sub
    '                End If

    '                If UCEquivalencias.TextUCMinima.Text.Trim.Length = 0 Then
    '                    MessageBox.Show("Ingresar la unidad comercial mínima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Cursor = Cursors.Default
    '                    Exit Sub
    '                End If

    '                If UCEquivalencias.TextCantMinima.DecimalValue <= 0 Then
    '                    MessageBox.Show("Ingresar cantidad mínima mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Cursor = Cursors.Default
    '                    Exit Sub
    '                End If

    '                If UCEquivalencias.TextCantMax.DecimalValue <= 0 Then
    '                    MessageBox.Show("Ingresar cantidad máxima mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Cursor = Cursors.Default
    '                    Exit Sub
    '                End If

    '                If UCEquivalencias.TextCantMax.DecimalValue < UCEquivalencias.TextCantMinima.DecimalValue Then
    '                    MessageBox.Show("La cantidad máxima debe ser mayor ala minima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Cursor = Cursors.Default
    '                    Exit Sub
    '                End If

    '                If UCEquivalencias.TextCantMax.DecimalValue = UCEquivalencias.TextCantMinima.DecimalValue Then
    '                    MessageBox.Show("La cantidad máxima debe ser mayor ala minima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Cursor = Cursors.Default
    '                    Exit Sub
    '                End If


    '                'UNIDAD MAXIMA
    '                UCEquivalencias.AddEquivalentV2(UCEquivalencias.TextUCMaxima.Text, UCEquivalencias.TextCantMax.DecimalValue, "MAX")
    '                'UNIDAD MINIMA
    '                UCEquivalencias.AddEquivalentV2(UCEquivalencias.TextUCMinima.Text, UCEquivalencias.TextCantMinima.DecimalValue, "MIN")


    '            ElseIf UCEquivalencias.ComboPlantilla.Text = "SÓLO UNIDAD COMERCIAL" Then
    '                UCEquivalencias.ListaEquivalencia = New List(Of detalleitem_equivalencias)

    '                If UCEquivalencias.TextUCMinima.Text.Trim.Length = 0 Then
    '                    MessageBox.Show("Ingresar la unidad comercial mínima!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Cursor = Cursors.Default
    '                    Exit Sub
    '                End If

    '                If UCEquivalencias.TextCantMinima.DecimalValue <= 0 Then
    '                    MessageBox.Show("Ingresar cantidad mínima mayor a cero!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    Cursor = Cursors.Default
    '                    Exit Sub
    '                End If

    '                'UNIDAD MINIMA
    '                UCEquivalencias.AddEquivalentV2(UCEquivalencias.TextUCMinima.Text, UCEquivalencias.TextCantMinima.DecimalValue, "SOLO")
    '            End If

    '            If UCEquivalencias.ListaEquivalencia.Count = 0 Then
    '                MessageBox.Show("Debe configurar las unidades comerciales", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Cursor = Cursors.Default
    '                Exit Sub
    '            End If

    '            GrabarItemEstablec()
    '        End If
    '    Else
    '        EditarItemEstablec()
    '    End If

    '    'End If
    '    Me.Cursor = Cursors.Arrow
    'End Sub
End Class