Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class FrmNuevoActivoInmovilizado

    Inherits frmMaster


    Public Property Precios As Boolean = False
    Public Property IdAlmacenPrecio As Integer
    Public Property EstadoManipulacion() As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        LoadControles()
        ' Add any initialization after the InitializeComponent() call.

    End Sub




#Region "categoria"
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

#Region "metodos"


    Sub Productoshijos()
        Dim categoriaSA As New itemSA

        cboProductos.DisplayMember = "descripcion"
        cboProductos.ValueMember = "idItem"
        cboProductos.DataSource = categoriaSA.GetListaMarcaPadre(CboClasificacion.SelectedValue)
    End Sub

    Public Sub GrabarMarca()

        Dim itemSA As New itemSA
        Dim item As New item
        Try
            With item
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .idPadre = CboClasificacion.SelectedValue
                .descripcion = txtmarca.Text.Trim
                .fechaIngreso = DateTime.Now
                .utilidad = 0
                .utilidadmayor = 0
                .utilidadgranmayor = 0
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx As Integer = itemSA.InsertarMarcaHijo(item)
            'lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx, 0, 0, 0))
            'Me.txtCategoria.Tag = CStr(codx)
            'txtCategoria.Text = txtNewClasificacion.Text.Trim
            Productoshijos()
            'ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, 0, 0, 0)
        Catch ex As Exception
            lblEstado.Text = (ex.Message)
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
            objitem.idItem = cboProductos.SelectedValue   ' Trim(txtCodigoDocumento.Text)
            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
            objitem.cuenta = Nothing
            objitem.descripcionItem = txtProductoNew.Text.Trim
            'objitem.presentacion = txtPresentacion.ValueMember
            objitem.presentacion = cboPresentacion.SelectedValue

            ' objitem.unidad1 = txtNomUnidad.ValueMember
            objitem.unidad1 = cboUnidades.SelectedValue
            ' objitem.Unidad2 = IIf(IsNothing(cboUM2.Text) Or String.IsNullOrEmpty(cboUM2.Text) Or String.IsNullOrWhiteSpace(cboUM2.Text), Nothing, Trim(cboUM2.SelectedValue))
            objitem.tipoExistencia = "08"
            Select Case cboIgv.Text
                Case "1 - GRAVADO"
                    objitem.origenProducto = OperacionGravada.Grabado
                Case "2 - EXONERADO"
                    objitem.origenProducto = OperacionGravada.Exonerado
                Case "3 - INAFECTO"
                    objitem.origenProducto = OperacionGravada.Inafecto
            End Select
            objitem.tipoProducto = "I"

            objitem.usuarioActualizacion = "Jiuni"
            objitem.fechaActualizacion = DateTime.Now


            objitem.modelo = txtModelo.Text
            objitem.transmision = txtdescrip.Text

            objitem.idAlmacen = IdAlmacenPrecio
            itemSA.UpdateProducto(objitem)
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Item registrado!"
            c.Cuenta = "Grabado"
            c.ID = txtProductoNew.Tag
            c.IdEvento = cboProductos.SelectedValue
            datos.Add(c)
            Dispose()

        Catch ex As Exception
            'Manejo de errores
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
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
            objitem.idItem = cboProductos.SelectedValue
            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
            objitem.cuenta = CStr(cboCuenta.SelectedValue)
            objitem.descripcionItem = txtProductoNew.Text.Trim
            'objitem.presentacion = txtPresentacion.ValueMember
            objitem.presentacion = cboPresentacion.SelectedValue
            'objitem.unidad1 = txtNomUnidad.ValueMember
            objitem.unidad1 = cboUnidades.SelectedValue
            'objitem.marcaRef = cboMarca.SelectedValue
            ' objitem.Unidad2 = IIf(IsNothing(cboUM2.Text) Or String.IsNullOrEmpty(cboUM2.Text) Or String.IsNullOrWhiteSpace(cboUM2.Text), Nothing, Trim(cboUM2.SelectedValue))
            objitem.tipoExistencia = "08"
            Select Case cboIgv.Text
                Case "1 - GRAVADO"
                    objitem.origenProducto = OperacionGravada.Grabado
                Case "2 - EXONERADO"
                    objitem.origenProducto = OperacionGravada.Exonerado
                Case "3 - INAFECTO"
                    objitem.origenProducto = OperacionGravada.Inafecto
            End Select
            objitem.tipoProducto = "I"

            objitem.usuarioActualizacion = usuario.IDUsuario
            objitem.fechaActualizacion = DateTime.Now


            objitem.modelo = txtModelo.Text
            objitem.transmision = txtdescrip.Text
            objitem.marcaRef = cboProductos.Text

        


            'If Precios = True Then
            objitem.idAlmacen = IdAlmacenPrecio
            Dim codxIdtem As Integer = itemSA.InsertItemDualTabla(objitem)
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Item registrado!"
            c.Cuenta = "Grabado"
            c.ID = codxIdtem
            c.IdEvento = cboProductos.SelectedValue
            datos.Add(c)
            Dispose()



        Catch ex As Exception
            'Manejo de errores
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub



    Private Sub carcagarpadre()
        Dim categoriaSA As New itemSA
        CboClasificacion.DisplayMember = "descripcion"
        CboClasificacion.ValueMember = "idItem"
        CboClasificacion.DataSource = categoriaSA.GetListaPadre()
    End Sub

    Private Sub LoadControles()
        Dim categoriaSA As New itemSA
        Dim tablaSA As New tablaDetalleSA
        Dim dtUM As New DataTable
        Dim cuentaSA As New cuentaplanContableEmpresaSA
        Try


            'Dim tablaSA As New tablaDetalleSA
            Me.cboUnidades.DataSource = tablaSA.GetListaTablaDetalle(6, "1")
            Me.cboUnidades.DisplayMember = "descripcion"
            Me.cboUnidades.ValueMember = "codigoDetalle"

            Me.cboPresentacion.DataSource = tablaSA.GetListaTablaDetalle(21, "1")
            Me.cboPresentacion.DisplayMember = "descripcion"
            Me.cboPresentacion.ValueMember = "codigoDetalle"

            For Each i In categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
                lstCategoria.Items.Add(New Categoria(i.descripcion, i.idItem))
            Next
            lstCategoria.DisplayMember = "Name"
            lstCategoria.ValueMember = "Id"

            cboCuenta.DisplayMember = "descripcion"
            cboCuenta.ValueMember = "cuenta"
            cboCuenta.DataSource = cuentaSA.LoadCuentasActInmov(Gempresas.IdEmpresaRuc)


            CboClasificacion.DisplayMember = "descripcion"
            CboClasificacion.ValueMember = "idItem"
            CboClasificacion.DataSource = categoriaSA.GetListaPadre()

            'cboMarca.DisplayMember = "descripcion"
            'cboMarca.ValueMember = "codigoDetalle"
            'cboMarca.DataSource = tablaSA.GetListaTablaDetalle(503, "1")

        Catch ex As Exception
            lblEstado.Text = ex.Message
        End Try

    End Sub

    Sub calsificacion()
        Dim categoriaSA As New itemSA


        CboClasificacion.DisplayMember = "descripcion"
        CboClasificacion.ValueMember = "idItem"
        CboClasificacion.DataSource = categoriaSA.GetListaPadre()
    End Sub



    Public Sub GrabarCategoria()
        Dim itemSA As New itemSA
        Dim item As New item
        Try
            With item
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .descripcion = txtNewClasificacion.Text.Trim
                .fechaIngreso = DateTime.Now
                .utilidad = 0
                .utilidadmayor = 0
                .utilidadgranmayor = 0
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx As Integer = itemSA.SaveCategoria(item)
            calsificacion()

            'lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx))
            'Me.txtCategoria.Tag = CStr(codx)
            'txtCategoria.Text = txtNewClasificacion.Text.Trim
            'txtCategoria.Tag = nupUtilidad.Value
        Catch ex As Exception
            lblEstado.Text = (ex.Message)
        End Try
    End Sub
#End Region
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Dim f As New frmNuevaClasificacion
        f.StartPosition = FormStartPosition.CenterParent
        'f.txtCodigo.Tag = CboClasificacion.SelectedValue
        'f.txtCodigo.Text = CboClasificacion.Text
        f.ShowDialog()
        carcagarpadre()

        'Me.Cursor = Cursors.WaitCursor
        'pcClasificacion.Font = New Font("Tahoma", 8)
        'pcClasificacion.Size = New Size(337, 150)
        'Me.pcClasificacion.ParentControl = Me.CboClasificacion
        'Me.pcClasificacion.ShowPopup(Point.Empty)
        'txtNewClasificacion.Clear()
        'txtNewClasificacion.Select()
        'Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub pcClasificacion_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcClasificacion.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtNewClasificacion.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre de la clasificación"
                pcClasificacion.Font = New Font("Tahoma", 8)
                pcClasificacion.Size = New Size(337, 150)
                Me.pcClasificacion.ParentControl = Me.cboProductos
                Me.pcClasificacion.ShowPopup(Point.Empty)
                txtNewClasificacion.Select()
                Exit Sub
            End If

            If btmGrabarClasificacion.Tag = "G" Then
                GrabarCategoria()


                btmGrabarClasificacion.Tag = "N"
            Else
                pcClasificacion.Font = New Font("Tahoma", 8)
                pcClasificacion.Size = New Size(318, 102)
                Me.pcClasificacion.ParentControl = Me.cboProductos
                Me.pcClasificacion.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.CboClasificacion.Focus()
        End If
    End Sub

    Private Sub pcClasificacion_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcClasificacion.BeforePopup
        Me.pcClasificacion.BackColor = Color.White
    End Sub

    Private Sub lstCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCategoria.SelectedIndexChanged

    End Sub

    Private Sub btmGrabarClasificacion_Click(sender As Object, e As EventArgs) Handles btmGrabarClasificacion.Click
        If Not txtNewClasificacion.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre de la clasificación"
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(337, 150)
            Me.pcClasificacion.ParentControl = Me.cboProductos
            Me.pcClasificacion.ShowPopup(Point.Empty)
            txtNewClasificacion.Select()
            Exit Sub
        End If

        btmGrabarClasificacion.Tag = "G"
        Me.pcClasificacion.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.pcClasificacion.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub FrmNuevoActivoInmovilizado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click


        If Not CboClasificacion.Text.Trim.Length > 0 Then
            MessageBox.Show("seleccione una clasificacion")
        End If

        Dim datos As List(Of item) = item.Instance()
        datos.Clear()


        Dim f As New frmNuevaMarca
        f.StartPosition = FormStartPosition.CenterParent
        f.txtCodigo.Tag = CboClasificacion.SelectedValue
        f.txtCodigo.Text = CboClasificacion.Text
        f.ShowDialog()
        Productoshijos()


        If datos.Count > 0 Then
            cboProductos.SelectedValue = CInt(datos(0).idItem)
        End If
        'Me.Cursor = Cursors.WaitCursor
        'PopupControlContainer4.Font = New Font("Tahoma", 8)
        'PopupControlContainer4.Size = New Size(337, 150)
        'Me.PopupControlContainer4.ParentControl = cboProductos
        'Me.PopupControlContainer4.ShowPopup(Point.Empty)
        'txtmarca.Clear()
        'txtmarca.Select()
        'Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ButtonAdv9_Click(sender As Object, e As EventArgs) Handles ButtonAdv9.Click
        If Not txtmarca.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre de la clasificación"
            PopupControlContainer4.Font = New Font("Tahoma", 8)
            PopupControlContainer4.Size = New Size(337, 150)
            Me.PopupControlContainer4.ParentControl = Me.cboProductos
            Me.PopupControlContainer4.ShowPopup(Point.Empty)
            txtmarca.Select()
            Exit Sub
        End If

        btmGrabarClasificacion.Tag = "G"
        Me.PopupControlContainer4.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Dispose()
    End Sub

    Private Sub PopupControlContainer4_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer4.BeforePopup
        Me.pcClasificacion.BackColor = Color.White
    End Sub

    Private Sub PopupControlContainer4_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PopupControlContainer4.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtmarca.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre de la clasificación"
                PopupControlContainer4.Font = New Font("Tahoma", 8)
                PopupControlContainer4.Size = New Size(337, 150)
                Me.PopupControlContainer4.ParentControl = Me.cboProductos
                Me.PopupControlContainer4.ShowPopup(Point.Empty)
                txtNewClasificacion.Select()
                Exit Sub
            End If

            If btmGrabarClasificacion.Tag = "G" Then
                GrabarMarca()
                btmGrabarClasificacion.Tag = "N"
            Else
                pcClasificacion.Font = New Font("Tahoma", 8)
                pcClasificacion.Size = New Size(337, 150)
                Me.pcClasificacion.ParentControl = Me.cboProductos
                Me.pcClasificacion.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.cboProductos.Focus()
        End If
    End Sub

    Private Sub CboClasificacion_Click(sender As Object, e As EventArgs) Handles CboClasificacion.Click

    End Sub

    Private Sub CboClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboClasificacion.SelectedIndexChanged

        Productoshijos()

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dispose()
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click
        Me.Cursor = Cursors.WaitCursor

        If Not cboProductos.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese Una Marca"
            txtProductoNew.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not txtModelo.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el modelo del producto"
            txtProductoNew.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        If Not txtdescrip.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el una serie , placa o ubicacion"
            txtProductoNew.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If

        If Not txtProductoNew.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del producto"
            txtProductoNew.Select()
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        'If Not txtCategoria.Text.Trim.Length > 0 Then
        '    lblEstado.Text = "Ingrese la clasificación del producto"
        '    txtCategoria.Select()
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'End If

        'If Not txtCategoria.Tag > 0 Then
        '    lblEstado.Text = "Ingrese la clasificación del producto"
        '    txtCategoria.Select()
        '    Me.Cursor = Cursors.Arrow
        '    Exit Sub
        'End If
        If EstadoManipulacion = ENTITY_ACTIONS.INSERT Then
            GrabarItemEstablec()
        Else
            EditarItemEstablec()
        End If
        'dockingManager1.SetDockVisibility(PanelNuevoItem, False)
        'dockingManager1.SetDockVisibility(Panel2, True)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub FrmNuevoActivoInmovilizado_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class