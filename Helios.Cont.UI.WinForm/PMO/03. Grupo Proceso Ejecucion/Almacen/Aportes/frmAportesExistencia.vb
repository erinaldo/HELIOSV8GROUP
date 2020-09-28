Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports System.Drawing
Imports System.Drawing.Drawing2D
Public Class frmAportesExistencia
    Inherits frmMaster

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Dim baseResult As Boolean = MyBase.ProcessCmdKey(msg, keyData)

        If keyData = Keys.Tab AndAlso txtProveedor.Focused Then
            '  MessageBox.Show("Tab pressed")
            Return True
        End If

        If keyData = (Keys.Tab Or Keys.Shift) AndAlso txtProveedor.Focused Then
            '  MessageBox.Show("Shift-Tab pressed")
            Return True
        End If

        Return baseResult
    End Function

#Region "Variables DetalleCompra"
    Public Property nudBase4 As Decimal = 0
    Public Property nudBase1 As Decimal = 0
    Public Property nudBase2 As Decimal = 0
    Public Property nudBase3 As Decimal = 0

    Public Property nudMontoIgv1 As Decimal = 0
    Public Property nudMontoIgv2 As Decimal = 0
    Public Property nudMontoIgv3 As Decimal = 0

    Public Property nudBaseus4 As Decimal = 0
    Public Property nudBaseus1 As Decimal = 0
    Public Property nudBaseus2 As Decimal = 0
    Public Property nudBaseus3 As Decimal = 0

    Public Property nudMontoIgvus1 As Decimal = 0
    Public Property nudMontoIgvus2 As Decimal = 0
    Public Property nudMontoIgvus3 As Decimal = 0

    Public Property nudIsc1 As Decimal = 0
    Public Property nudIsc2 As Decimal = 0
    Public Property nudIsc3 As Decimal = 0
    Public Property nudIscus1 As Decimal = 0
    Public Property nudIscus2 As Decimal = 0
    Public Property nudIscus3 As Decimal = 0

    Public Property nudOtrosTributosus1 As Decimal = 0
    Public Property nudOtrosTributosus2 As Decimal = 0
    Public Property nudOtrosTributosus3 As Decimal = 0
    Public Property nudOtrosTributosus4 As Decimal = 0

    Public Property nudOtrosTributos1 As Decimal = 0
    Public Property nudOtrosTributos2 As Decimal = 0
    Public Property nudOtrosTributos3 As Decimal = 0
    Public Property nudOtrosTributos4 As Decimal = 0

    Public Property txtIdComprobanteCaja As Integer
    Public Property txtComprobanteCaja As String
    Public Property txtNumCaja As String
    Public Property txtIdEstablecimientoCaja As Integer
    Public Property txtEstablecimientoCaja As String
    Public Property txtIdCaja As Integer
    Public Property txtCaja As String
    Public Property txtCuentaEF As String

    '   Public Property GlosaCompra As String = Nothing
#End Region

    Public Property Flag() As String
    Dim UserControl1 As New ucConfiguracion
    Dim toolTip As Popup
    Public ManipulacionEstado As String
    Private CheckBoxClicked As Boolean = False
    Public Property ListaAsientonTransito As New List(Of asiento)
    Public fecha As DateTime

    Public Property IdComprobante() As Integer
    Public Property Numero() As String
    Public Property Serie() As String


    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        SelecIDEstable = Nothing
        SelecNombreEstable = Nothing
        SelectIdAlmacen = Nothing
        SelectNombreAlmacen = Nothing
        IdAlmacenBack = Nothing

        GConfiguracion = New GConfiguracionModulo

        configuracionModuloV2(Gempresas.IdEmpresaRuc, "APE", Me.Text, GEstableciento.IdEstablecimiento)
        ObtenerListaControlesLoad()
        QGlobalColorSchemeManager1.Global.CurrentTheme = Qios.DevSuite.Components.QColorScheme.LunaBlueThemeName
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.dockingManager1.DockControl(Me.Panel2, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)
        dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 382)

        dockingClientPanel1.BringToFront()
        dockingManager1.MDIActivatedVisibility = True
        Me.dockingClientPanel1.AutoScroll = True

        Me.dockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D

        dockingManager1.SetDockLabel(Panel2, "Existencias")

        'INICIO PERIODO
        lblPerido.Text = PeriodoGeneral
        '   InitializeRAdial()
        SetRenderer()
        txtFechaComprobante.Select()
        dockingManager1.CloseEnabled = False
    End Sub


#Region "CATEGORIA"
    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Public Sub New(ByVal name As String, ByVal id As Integer)
            _name = name
            _id = id
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
    End Class

    Public Sub GrabarCategoria()
        Dim itemSA As New itemSA
        Dim item As New item
        Try
            With item
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                .descripcion = txtNewClasificacion.Text.Trim
                .fechaIngreso = DateTime.Now
                .usuarioActualizacion = "Jiuni"
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx As Integer = itemSA.SaveCategoria(item)
            lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx))
            Me.txtCategoria.ValueMember = CStr(codx)
            txtCategoria.Text = txtNewClasificacion.Text.Trim
            ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue)
        Catch ex As Exception
            lblEstado.Text = (ex.Message)
        End Try
    End Sub
#End Region

#Region "PRODUCTOS"
    Private Sub SetRenderer()
        Dim styleRenderer1 As New StyledRenderer()
        tbIGV.Renderer = styleRenderer1
        'Dim styleRenderer2 As New StyledRenderer()
        'tbIGV.Renderer = styleRenderer2
        'Dim styleRenderer3 As New StyledRenderer()
        'toggleButton11.Renderer = styleRenderer3
        'Dim styleRenderer4 As New StyledRenderer()
        'toggleButton12.Renderer = styleRenderer4
        ' Panel2.Visible = False
    End Sub

    Public Sub GrabarItemEstablec()
        Dim objitem As New detalleitems
        Dim itemSA As New detalleitemsSA
        Try
            'Se asigna cada uno de los datos registrados
            objitem.idItem = txtCategoria.ValueMember    ' Trim(txtCodigoDocumento.Text)
            objitem.idEmpresa = Gempresas.IdEmpresaRuc
            objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
            objitem.cuenta = txtCuentaCodigo.Text
            objitem.descripcionItem = txtProductoNew.Text.Trim
            objitem.presentacion = txtPresentacion.ValueMember
            objitem.unidad1 = txtNomUnidad.ValueMember
            ' objitem.Unidad2 = IIf(IsNothing(cboUM2.Text) Or String.IsNullOrEmpty(cboUM2.Text) Or String.IsNullOrWhiteSpace(cboUM2.Text), Nothing, Trim(cboUM2.SelectedValue))
            objitem.tipoExistencia = cboTipoExistencia.SelectedValue
            objitem.origenProducto = IIf(tbIGV.ToggleState = Tools.ToggleButtonState.Active, "1", "2")
            objitem.tipoProducto = "I"

            objitem.usuarioActualizacion = "Jiuni"
            objitem.fechaActualizacion = DateTime.Now

            Dim codxIdtem As Integer = itemSA.InsertNuevaItems(objitem)
            Me.lblEstado.Image = My.Resources.ok4
            Me.lblEstado.Text = "Item registrado!"

            If chAddCanasta.Checked = True Then
                Dim objInsumo As New detalleitemsSA
                Dim tablaSA As New tablaDetalleSA

                With objInsumo.InvocarProductoID(codxIdtem)
                    dgvCompra.Rows.Add(0, .origenProducto, .codigodetalle, .descripcionItem,
                                         .presentacion,
                                            tablaSA.GetUbicarTablaID(21, .presentacion).descripcion, .unidad1, 0, 0, 0, 0, 0, 0,
                                          0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                          .tipoExistencia, .cuenta, Nothing)
                    txtProductoNew.Clear()
                    txtProductoNew.Select()
                End With
            Else
                txtProductoNew.Clear()
                txtProductoNew.Select()
            End If
        Catch ex As Exception
            'Manejo de errores
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
    End Sub

    'Public Sub EditarItemEstablec(ByVal mat As ItemDS)
    '    Dim objitem As New detalleitems
    '    Dim itemSA As New detalleitemsSA
    '    Try
    '        'Se asigna cada uno de los datos registrados
    '        objitem.codigodetalle = txtCodigo.Text
    '        objitem.idItem = mat.Clasificacion   ' Trim(txtCodigoDocumento.Text)
    '        objitem.idEmpresa = Gempresas.IdEmpresaRuc
    '        objitem.idEstablecimiento = GEstableciento.IdEstablecimiento   ' frmCanastaExistencias.cboEstablecimiento.SelectedValue
    '        objitem.cuenta = mat.Cuenta
    '        objitem.descripcionItem = mat.DescripcionItem
    '        objitem.presentacion = mat.Presentacion
    '        objitem.unidad1 = mat.UnidadMedida
    '        ' objitem.Unidad2 = IIf(IsNothing(cboUM2.Text) Or String.IsNullOrEmpty(cboUM2.Text) Or String.IsNullOrWhiteSpace(cboUM2.Text), Nothing, Trim(cboUM2.SelectedValue))
    '        objitem.tipoExistencia = mat.TipoEx
    '        objitem.origenProducto = IIf(rbAfecta.Checked = True, "1", "2")
    '        objitem.tipoProducto = "I"

    '        objitem.usuarioActualizacion = "Jiuni"
    '        objitem.fechaActualizacion = DateTime.Now

    '        itemSA.UpdateProducto(objitem)
    '        Me.lblEstado.Image = My.Resources.ok4
    '        Me.lblEstado.Text = "Item actualizado!"
    '    Catch ex As Exception
    '        'Manejo de errores
    '        MsgBox("No se pudo grabar el Producto." & vbCrLf & ex.Message)
    '    End Try
    'End Sub
#End Region


#Region "PROVEEDOR"
    Public Sub InsertProveedor()
        Dim objCliente As New entidad
        Dim entidadSA As New entidadSA
        Try
            'Se asigna cada uno de los datos registrados
            objCliente.idEmpresa = Gempresas.IdEmpresaRuc
            objCliente.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR

            If btnRuc.Checked = True Then
                objCliente.tipoDoc = "6"
            ElseIf btnDni.Checked = True Then
                objCliente.tipoDoc = "1"
            ElseIf btnPassport.Checked = True Then
                objCliente.tipoDoc = "7"
            ElseIf btnCarnetEx.Checked = True Then
                objCliente.tipoDoc = "4"
            End If
            objCliente.nrodoc = txtDocProveedor.Text.Trim

            If rbNatural.Checked = True Then
                objCliente.appat = txtApePat.Text.Trim
                objCliente.nombre1 = txtNomProv.Text.Trim
                objCliente.nombreCompleto = objCliente.appat & ", " & objCliente.nombre1
                objCliente.tipoPersona = "N"
            ElseIf rbJuridico.Checked = True Then
                objCliente.nombre = txtNomProv.Text.Trim
                objCliente.nombreCompleto = txtNomProv.Text.Trim
                objCliente.tipoPersona = "J"
            End If
            objCliente.cuentaAsiento = "4212"
            objCliente.estado = "A"
            objCliente.usuarioModificacion = "NN"
            objCliente.fechaModificacion = DateTime.Now

            Dim codx As Integer = entidadSA.GrabarEntidad(objCliente)
            'lblEstado.Text = "Entidad registrada:" & vbCrLf & "Tipo: " & objCliente.tipoEntidad & vbCrLf & "Nombre: " & objCliente.nombreCompleto
            'lblEstado.Image = My.Resources.ok4

            Dim n As New ListViewItem(codx)
            n.SubItems.Add(objCliente.nombreCompleto)
            n.SubItems.Add(objCliente.cuentaAsiento)
            n.SubItems.Add(objCliente.nrodoc)
            lsvProveedor.Items.Add(n)

            txtProveedor.ValueMember = codx
            txtProveedor.Text = objCliente.nombreCompleto
            txtRuc.Text = objCliente.nrodoc
            txtCuenta.Text = objCliente.cuentaAsiento
        Catch ex As Exception
            'Manejo de errores
            MsgBox("No se pudo grabar el cliente." & vbCrLf & ex.Message)
        End Try
    End Sub
#End Region

#Region "Métodos"
    Enum Sys
        Inicio
        Proceso
    End Enum

    Sub InfoConfiguracion(n As Sys)
        If Not IsNothing(GConfiguracion) Then
            If Not IsNothing(GConfiguracion.NomModulo) Then
                UserControl1.lblCodigo.Text = "APE"
                UserControl1.lblModulo.Text = Me.Text
                UserControl1.lblConfiguracion.Text = IIf(GConfiguracion.TipoConfiguracion = "M", "MANUAL", "PROGRAMADA")
                UserControl1.lblComprobante.Text = GConfiguracion.NombreComprobante
                UserControl1.lblSerie.Text = GConfiguracion.Serie
                UserControl1.lblNumImpresiones.Text = IIf(IsNothing(GConfiguracion.ValorActual), 0, GConfiguracion.ValorActual)
                UserControl1.lblAlmacen.Text = GConfiguracion.NombreAlmacen
                UserControl1.lblCaja.Text = GConfiguracion.NomCaja
                ' position the tooltip with its stem towards the right end of the button
                If n = Sys.Inicio Then

                ElseIf n = Sys.Proceso Then
                    toolTip.Show(btnConfiguracion)
                End If

            End If
        End If
    End Sub
    'Public Sub configuracionModulo(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
    '    Dim moduloConfiguracionSA As New ModuloConfiguracionSA
    '    Dim moduloConfiguracion As New moduloConfiguracion
    '    Dim numeracionSA As New NumeracionBoletaSA
    '    Dim TablaSA As New tablaDetalleSA
    '    Dim almacenSA As New almacenSA
    '    Dim cajaSA As New EstadosFinancierosSA

    '    moduloConfiguracion = moduloConfiguracionSA.UbicarConfiguracionPorEmpresaModulo(strIdModulo, strIDEmpresa, intIdEstablecimiento)
    '    If Not IsNothing(moduloConfiguracion) Then
    '        With moduloConfiguracion
    '            GConfiguracion = New GConfiguracionModulo
    '            GConfiguracion.IdModulo = .idModulo
    '            GConfiguracion.NomModulo = strNomModulo
    '            GConfiguracion.TipoConfiguracion = .tipoConfiguracion
    '            Select Case .tipoConfiguracion
    '                Case "P"
    '                    With numeracionSA.GetUbicar_numeracionBoletasPorID(.configComprobante)
    '                        GConfiguracion.ConfigComprobante = .IdEnumeracion
    '                        GConfiguracion.TipoComprobante = .tipo
    '                        GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, .tipo).descripcion
    '                        GConfiguracion.Serie = .serie
    '                        GConfiguracion.ValorActual = .valorInicial
    '                        txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'txtSerieComp.Visible = True
    '                        'txtSerieComp.Text = .serie
    '                        'txtNumeroComp.Visible = False
    '                        'txtIdComprobante.Text = GConfiguracion.TipoComprobante
    '                        'txtComprobante.Text = GConfiguracion.NombreComprobante
    '                        'LinkTipoDoc.Enabled = False
    '                        'txtSerieComp.Enabled = False
    '                    End With
    '                Case "M"
    '                    'txtSerieComp.Visible = True
    '                    'txtNumeroComp.Visible = True
    '                    'LinkTipoDoc.Enabled = True
    '                    'txtSerieComp.Enabled = True
    '            End Select
    '            If Not IsNothing(.configAlmacen) Then
    '                Dim estableSA As New establecimientoSA
    '                With almacenSA.GetUbicar_almacenPorID(.configAlmacen)
    '                    GConfiguracion.IdAlmacen = .idAlmacen
    '                    GConfiguracion.NombreAlmacen = .descripcionAlmacen

    '                    'txtAlmacen.Text = GConfiguracion.NombreAlmacen
    '                    'txtIdAlmacen.Text = GConfiguracion.IdAlmacen
    '                    With estableSA.UbicaEstablecimientoPorID(.idEstablecimiento)
    '                        'txtIdEstableAlmacen.Text = .idCentroCosto
    '                        'txtEstableAlmacen.Text = .nombre
    '                    End With
    '                End With
    '            End If
    '            If Not IsNothing(.ConfigentidadFinanciera) Then
    '                With cajaSA.GetUbicar_estadosFinancierosPorID(.ConfigentidadFinanciera)
    '                    GConfiguracion.IDCaja = .idestado
    '                    GConfiguracion.NomCaja = .descripcion
    '                End With
    '            End If

    '        End With
    '    Else
    '        lblEstado.Text = "Este módulo no contiene una configuración disponible, intentelo más tarde.!"
    '        'Timer1.Enabled = True
    '        'TabCompra.Enabled = False
    '        'TiempoEjecutar(5)
    '    End If
    'End Sub

    Public Sub configuracionModuloV2(strIDEmpresa As String, strIdModulo As String, strNomModulo As String, intIdEstablecimiento As Integer)
        Try

            Dim moduloConfiguracionSA As New ModuloConfiguracionSA
            Dim moduloConfiguracion As New moduloConfiguracion
            Dim numeracionSA As New NumeracionBoletaSA
            Dim TablaSA As New tablaDetalleSA
            Dim almacenSA As New almacenSA
            Dim cajaSA As New EstadosFinancierosSA

            Dim RecuperacionNumeracion = numeracionSA.GetUbicar_numeracionBoletasXUnidadNegocio(New numeracionBoletas With {.empresa = strIDEmpresa, .establecimiento = intIdEstablecimiento, .codigoNumeracion = strIdModulo, .estado = "A"})

            If (Not IsNothing(RecuperacionNumeracion)) Then
                GConfiguracion = New GConfiguracionModulo
                GConfiguracion.ConfigComprobante = CInt(RecuperacionNumeracion.IdEnumeracion)
                GConfiguracion.TipoComprobante = RecuperacionNumeracion.tipo
                GConfiguracion.NombreComprobante = TablaSA.GetUbicarTablaID(10, RecuperacionNumeracion.tipo).descripcion
                GConfiguracion.Serie = RecuperacionNumeracion.serie
                GConfiguracion.ValorActual = RecuperacionNumeracion.valorInicial
            Else
                Throw New Exception("Verificar configuración")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ListadoProductosPorCategoriaTipoExistencia(strCategoria As Integer, strTipoExistencia As String)
        Dim itemSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        Try
            For Each i In itemSA.GetUbicarDetalleItemTipoExistencia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strCategoria, strTipoExistencia)
                Dim n As New ListViewItem(i.codigodetalle)
                n.SubItems.Add(i.descripcionItem)
                n.SubItems.Add(i.unidad1)
                n.SubItems.Add(i.tipoExistencia)
                n.SubItems.Add(String.Empty)
                n.SubItems.Add(i.cuenta)
                lsvListadoItems.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ObtenerListaControlesLoad()
        Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim categoriaSA As New itemSA
        Dim almacenSA As New almacenSA
        lsvProveedor.Items.Clear()
        For Each i As entidad In entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
            Dim n As New ListViewItem(i.idEntidad)
            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.cuentaAsiento)
            n.SubItems.Add(i.nrodoc)
            lsvProveedor.Items.Add(n)
        Next


        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("name")

        dt.Rows.Add(1, "NACIONAL")
        dt.Rows.Add(2, "EXTRANJERA")

        cboMoneda.ValueMember = "id"
        cboMoneda.DisplayMember = "name"
        cboMoneda.DataSource = dt
        cboMoneda.SelectedIndex = 0


        'TIPO DE EXISTENCIA
        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = tablaSA.GetListaTablaDetalle(5, "1")

        'lstUM.DisplayMember = "descripcion"
        'lstUM.ValueMember = "codigoDetalle"
        'lstUM.DataSource = tablaSA.GetListaTablaDetalle(6, "1")

        Dim dtUM As New DataTable
        dtUM.Columns.Add("ID")
        dtUM.Columns.Add("Name")

        For Each i In tablaSA.GetListaTablaDetalle(6, "1")
            dtUM.Rows.Add(i.codigoDetalle, i.descripcion)
        Next
        Me.AutoComplete1.DataSource = dtUM
        Me.AutoComplete1.SetAutoComplete(Me.txtUm, Syncfusion.Windows.Forms.Tools.AutoCompleteModes.MultiSuggestExtended)

        Dim dtPresentacion As New DataTable
        dtPresentacion.Columns.Add("IDPres")
        dtPresentacion.Columns.Add("NamePres")

        For Each i In tablaSA.GetListaTablaDetalle(21, "1")
            dtPresentacion.Rows.Add(i.codigoDetalle, i.descripcion)
        Next
        Me.AutoComplete2.DataSource = dtPresentacion
        Me.AutoComplete2.SetAutoComplete(Me.txtCodPresentacion, Syncfusion.Windows.Forms.Tools.AutoCompleteModes.MultiSuggestExtended)


        For Each i In categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento, Gempresas.IdEmpresaRuc)
            lstCategoria.Items.Add(New Categoria(i.descripcion, i.idItem))
        Next
        lstCategoria.DisplayMember = "Name"
        lstCategoria.ValueMember = "Id"
        '    lstCategoria.DataSource = categoriaSA.GetListaItemPorEstable(GEstableciento.IdEstablecimiento)

        Select Case cboTipoExistencia.SelectedValue
            Case "01"
                txtCuentaName.Text = "Costo"
                txtCuentaCodigo.Text = "601111"
            Case "03"
                txtCuentaName.Text = "Costo"
                txtCuentaCodigo.Text = "602111"
            Case "04"
                txtCuentaName.Text = "Costo"
                txtCuentaCodigo.Text = "604111"
            Case "05"
                txtCuentaName.Text = "Costo"
                txtCuentaCodigo.Text = "603111"
        End Select

        lstAlmacen.DisplayMember = "descripcionAlmacen"
        lstAlmacen.ValueMember = "idAlmacen"
        lstAlmacen.DataSource = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
    End Sub
#End Region

#Region "Métodos DGV"
    Private Sub Validar_Numeros(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        Dim Celda As DataGridViewCell = Me.dgvCompra.CurrentCell()

        If Celda.ColumnIndex = 7 Or Celda.ColumnIndex = 10 Or Celda.ColumnIndex = 11 Then

            If e.KeyChar = "."c Or e.KeyChar = ","c Then

                If InStr(Celda.EditedFormattedValue.ToString, ".", CompareMethod.Text) > 0 Then

                    e.Handled = True
                Else

                    e.Handled = False
                End If
            Else

                If Len(Trim(Celda.EditedFormattedValue.ToString)) > 0 Then

                    If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                        e.Handled = False
                    Else

                        e.Handled = True
                    End If
                Else

                    If e.KeyChar = "0"c Then

                        e.Handled = True
                    Else

                        If Char.IsNumber(e.KeyChar) Or e.KeyChar = Convert.ToChar(8) Then

                            e.Handled = False
                        Else

                            e.Handled = True
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub TotalesCabeceras()

        Dim cTotalMN As Decimal = 0
        Dim cTotalME As Decimal = 0

        Dim cTotalBI As Decimal = 0
        Dim cTotalBI_ME As Decimal = 0

        Dim cTotalIGV As Decimal = 0
        Dim cTotalIGV_ME As Decimal = 0

        Dim cTotalIsc As Decimal = 0
        Dim cTotalIsc_ME As Decimal = 0

        Dim cTotalOTC As Decimal = 0
        Dim cTotalOTC_ME As Decimal = 0

        For Each i As DataGridViewRow In dgvCompra.Rows
            If i.Cells(20).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                cTotalMN += CDec(i.Cells(10).Value)
                cTotalME += CDec(i.Cells(11).Value)

                cTotalBI += 0
                cTotalBI_ME += 0

                cTotalIGV += 0
                cTotalIGV_ME += 0

                cTotalIsc += 0
                cTotalIsc_ME += 0

                cTotalOTC += 0
                cTotalOTC_ME += 0
            End If
        Next

        lblTotalBase.Text = cTotalBI.ToString("N2")
        lblTotalBaseUS.Text = cTotalBI_ME.ToString("N2")

        lblTotalISc.Text = cTotalIsc.ToString("N2")
        lblTotalIScUS.Text = cTotalIsc_ME.ToString("N2")

        lblTotalMontoIgv.Text = cTotalIGV.ToString("N2")
        lblTotalMontoIgvUS.Text = cTotalIGV_ME.ToString("N2")

        lblOtrostribTotal.Text = cTotalOTC.ToString("N2")
        lblOtrostribTotalUS.Text = cTotalOTC_ME.ToString("N2")

        lblTotalAdquisiones.Text = cTotalMN   'cTotalMN.ToString("N2")
        lblTotalUS.Text = cTotalME   'cTotalME.ToString("N2")

    End Sub

    'Public Sub totales_xx()
    '    '     Dim objService = HeliosSEProxy.CrearProxyHELIOS
    '    ' Dim t As DataTable
    '    Dim i As Integer
    '    'Dim base1, base2 As Decimal
    '    'Dim baseus1, baseus2 As Decimal
    '    'Dim otc1, otc2 As Decimal ', otc3, otc4
    '    'Dim otc1US, otc2US As Decimal ', otc3US, otc4US
    '    Dim total, totalbase2 As Decimal ' igv, IGVUS As Decimal ' totalp As Decimal , totalbase3, totalbase4,
    '    Dim tus1, tus2 As Decimal 'tus3, tus4 
    '    Dim totalIgv1 As Decimal = 0
    '    Dim totalIgv1_ME As Decimal = 0
    '    Dim totalIgv2 As Decimal = 0
    '    Dim totalIgv2_ME As Decimal = 0
    '    Dim totalIgv3 As Decimal = 0
    '    Dim totalIgv3_ME As Decimal = 0
    '    Dim totalIgv4 As Decimal = 0
    '    Dim totalIgv4_ME As Decimal = 0



    '    Dim totalBI3 As Decimal = 0
    '    Dim totalBI3_ME As Decimal = 0
    '    Dim totalBI4 As Decimal = 0
    '    Dim totalBI4_ME As Decimal = 0


    '    Dim NUDVALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
    '    For i = 0 To dgvCompra.Rows.Count - 1
    '        If dgvCompra.Rows(i).Cells(20).Value() <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
    '            'total += carrito.Rows(i)(5)
    '            If Not dgvCompra.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(209, 227, 254) Then
    '                If dgvCompra.Rows(i).Cells(1).Value() = "1" Then

    '                    total += dgvCompra.Rows(i).Cells(12).Value() ' total base 01 soles
    '                    tus1 += dgvCompra.Rows(i).Cells(16).Value() ' total base 01 dolares
    '                    totalIgv1 += dgvCompra.Rows(i).Cells(14).Value()
    '                    totalIgv1_ME += dgvCompra.Rows(i).Cells(18).Value()

    '                ElseIf dgvCompra.Rows(i).Cells(1).Value() = "2" Then

    '                    totalbase2 += dgvCompra.Rows(i).Cells(12).Value()
    '                    tus2 += dgvCompra.Rows(i).Cells(16).Value() ' total base 01
    '                    totalIgv2 += dgvCompra.Rows(i).Cells(14).Value()
    '                    totalIgv2_ME += dgvCompra.Rows(i).Cells(18).Value()

    '                ElseIf dgvCompra.Rows(i).Cells(1).Value() = "3" Then
    '                    totalBI3 += dgvCompra.Rows(i).Cells(12).Value()
    '                    totalBI3_ME += dgvCompra.Rows(i).Cells(16).Value() ' total base 01
    '                    totalIgv3 += dgvCompra.Rows(i).Cells(14).Value()
    '                    totalIgv3_ME += dgvCompra.Rows(i).Cells(18).Value()

    '                ElseIf dgvCompra.Rows(i).Cells(1).Value() = "4" Then
    '                    totalBI4 += dgvCompra.Rows(i).Cells(12).Value()
    '                    totalBI4_ME += dgvCompra.Rows(i).Cells(16).Value() ' total base 01
    '                    totalIgv4 += dgvCompra.Rows(i).Cells(14).Value()
    '                    totalIgv4_ME += dgvCompra.Rows(i).Cells(18).Value()
    '                End If
    '            End If
    '        End If

    '    Next
    '    nudBase1 = total.ToString("N2")
    '    nudBaseus1 = tus1.ToString("N2")
    '    nudBase2 = totalbase2.ToString("N2")
    '    nudBaseus2 = tus2.ToString("N2")

    '    nudBase3 = totalBI3.ToString("N2")
    '    nudBaseus3 = totalBI3_ME.ToString("N2")
    '    nudBase4 = totalBI4.ToString("N2")
    '    nudBaseus4 = totalBI4_ME.ToString("N2")

    '    nudMontoIgv1 = totalIgv1.ToString("N2")
    '    nudMontoIgvus1 = totalIgv1_ME.ToString("N2")
    '    nudMontoIgv2 = totalIgv2.ToString("N2")
    '    nudMontoIgvus2 = totalIgv2_ME.ToString("N2")

    '    nudMontoIgv3 = totalIgv3.ToString("N2")
    '    nudMontoIgvus3 = totalIgv3_ME.ToString("N2")
    '    nudMontoIgv3 = totalIgv3.ToString("N2")
    '    nudMontoIgvus3 = totalIgv3_ME.ToString("N2")

    'End Sub

    Private Sub CellEndEditRefresh()
        '**************************************************************

        If dgvCompra.Rows.Count > 0 Then
            'DECLARANDO VARIABLES

            For Each i As DataGridViewRow In dgvCompra.Rows
                If i.Cells(20).Value <> Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE Then
                    Dim colDestinoGravado As String = 0
                    colDestinoGravado = i.Cells(1).Value

                    Dim colCantidad As Decimal = CDec(i.Cells(7).Value)

                    Dim colMN As Decimal = i.Cells(10).Value
                    Dim colME As Decimal = Math.Round(CDec(i.Cells(10).Value) / CDec(txtTipoCambio.Value), 2)
                    Dim colPrecUnit As Decimal = 0
                    Dim colPrecUnitUSD As Decimal = 0


                    If colMN > 0 Then

                        colPrecUnit = Math.Round(colMN / colCantidad, 2)

                        colPrecUnitUSD = Math.Round(colME / colCantidad, 2)

                    Else
                        colPrecUnit = 0

                        colPrecUnitUSD = 0

                    End If



                    If txtTipoCambio.Value = 0.0 Then
                        MsgBox("Ingrese Tipo de Cambio..!")
                        txtTipoCambio.Focus()
                        txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                        Exit Sub
                    End If

                    Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                    If colCantidad = 0 And colMN = 0 And colME = 0 Then
                        i.Cells(8).Value() = "0.00"
                        i.Cells(9).Value() = "0.00"
                        Exit Sub

                    ElseIf colCantidad = 0 Then

                        If cboMoneda.SelectedValue = 1 Then
                            ' DATOS SOLES
                            Select Case colDestinoGravado
                                Case "4"
                                    i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                    i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                    i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES
                                    i.Cells(10).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

                                Case Else

                                    ''   If dgvDetalleCompra.Item(27, dgvDetalleCompra.CurrentRow.Index).Value() = "S" Then
                                    'dgvDetalleCompra.Item(8, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                    'dgvDetalleCompra.Item(9, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                    'dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    'dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    'dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                    'dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                    'dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                    'dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD
                                    'dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                    'Else
                                    i.Cells(8).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                    i.Cells(9).Value() = "0.00" ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 4)
                                    i.Cells(10).Value() = colMN ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    i.Cells(12).Value() = 0 ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                    i.Cells(14).Value() = 0  ' Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                    i.Cells(16).Value() = 0 ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                    i.Cells(18).Value() = 0 ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                    '      i.Cells(19).Value() = Math.Round(CDec(i.Cells(15).Value() / txtTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
                                    '   End If
                            End Select

                        ElseIf cboMoneda.SelectedValue = 2 Then
                            ' DATOS DOLARES
                            Select Case colDestinoGravado
                                Case "4"
                                    i.Cells(9).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                    i.Cells(8).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                    i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                    i.Cells(11).Value() = colME

                                    ' dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                    ' dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' igv del item

                                    '  dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                    '  dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

                                    '  dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
                                Case Else

                                    'If dgvDetalleCompra.Item(27, dgvDetalleCompra.CurrentRow.Index).Value() = "S" Then
                                    '    dgvDetalleCompra.Item(9, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                    '    dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() = colMN 'Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                    '    dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() = colME

                                    '    dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                    '    dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' igv del item

                                    '    dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                    '    dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV
                                    '    dgvDetalleCompra.Item(8, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), 2)
                                    '    dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                    'Else
                                    i.Cells(8).Value() = "0.00"
                                    i.Cells(9).Value() = "0.00"
                                    i.Cells(10).Value() = colMN
                                    i.Cells(11).Value() = colME

                                    i.Cells(12).Value() = 0 ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                    i.Cells(14).Value() = 0 ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                    i.Cells(16).Value() = 0 ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                    i.Cells(18).Value() = 0 ' Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                    '    i.Cells(15).Value() = Math.Round(CDec(i.Cells(19).Value() * nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                    'End If
                            End Select

                        End If
                    ElseIf colCantidad > 0 Then
                        If cboMoneda.SelectedValue = 1 Then
                            ' DATOS SOLES
                            If colDestinoGravado = "4" Then
                                i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                '  dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                '  dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto igv del item

                                ' dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex USD
                                ' dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV USD


                                'dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS DOLARES
                            Else
                                If i.Cells(27).Value() = "S" Then
                                    i.Cells(7).Value() = colCantidad '  CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                    i.Cells(12).Value() = "0.00" ' monto para el kardex
                                    i.Cells(14).Value() = "0.00" ' monto igv del item

                                    i.Cells(16).Value() = "0.00" ' monto para el kardex USD
                                    i.Cells(18).Value() = "0.00" ' monto para el IGV USD


                                    i.Cells(19).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                Else
                                    i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                    i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    i.Cells(11).Value() = colME ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    i.Cells(10).Value() = colMN ' CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                    i.Cells(12).Value() = 0 ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                    i.Cells(14).Value() = 0 ' Math.Round(CDec(neto - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                    i.Cells(16).Value() = 0 ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                    i.Cells(18).Value() = 0 ' Math.Round(CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                    '        i.Cells(19).Value() = Math.Round(CDec(i.Cells(15).Value() / nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES

                                End If

                            End If

                        ElseIf cboMoneda.SelectedValue = 2 Then

                            Select Case colDestinoGravado
                                Case "4"
                                    ' DATOS DOLARES
                                    i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                    i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                    i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                    '  dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                    '  dgvDetalleCompra.Item(14, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' igv del item

                                    ' dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                    ' dgvDetalleCompra.Item(18, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

                                    ' dgvDetalleCompra.Item(15, dgvDetalleCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvDetalleCompra.Item(19, dgvDetalleCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
                                Case Else
                                    ' DATOS DOLARES
                                    If i.Cells(27).Value() = "S" Then
                                        i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                        i.Cells(12).Value() = "0.00" ' monto para el kardex
                                        i.Cells(14).Value() = "0.00" ' igv del item

                                        i.Cells(16).Value() = "0.00" ' monto para el kardex
                                        i.Cells(18).Value() = "0.00" ' monto para el IGV

                                        i.Cells(15).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                    Else
                                        i.Cells(7).Value() = colCantidad ' CDec(dgvDetalleCompra.Item(7, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                        i.Cells(8).Value() = colPrecUnit ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                        i.Cells(9).Value() = colPrecUnitUSD ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                        i.Cells(10).Value() = colMN ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                        i.Cells(11).Value() = colME ' CDec(dgvDetalleCompra.Item(11, dgvDetalleCompra.CurrentRow.Index).Value()).ToString("N2")
                                        i.Cells(12).Value() = 0 ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        i.Cells(14).Value() = 0 ' Math.Round(CDec(dgvDetalleCompra.Item(10, dgvDetalleCompra.CurrentRow.Index).Value() - CDec(dgvDetalleCompra.Item(12, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                        i.Cells(16).Value() = 0 ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                        i.Cells(18).Value() = 0 ' Math.Round(CDec(netous - CDec(dgvDetalleCompra.Item(16, dgvDetalleCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                        '        i.Cells(15).Value() = Math.Round(CDec(i.Cells(19).Value() * nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                    End If

                            End Select

                        End If
                    End If
                    TotalesCabeceras()
                End If

            Next
        End If

    End Sub

    Private Function GlosaCompra() As String
        If Not String.IsNullOrEmpty(txtProveedor.Text) Then
            Return String.Concat("Por Aportes", Space(1), "según/ ", Space(1), txtComprobante.Text, Space(1), ", de Fecha:", Space(1), txtFechaComprobante.Text)
        Else
            Return False
        End If
    End Function
#End Region

#Region "Manipulacion Data"
    Public ListadoItems As New List(Of item)
    Public Function AsientoContableAporte() As asiento
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim nMovimientoAporte As New movimiento
        Dim ListaAsiento As New List(Of asiento)


        With nAsiento
            .idAsiento = 0
            .idDocumento = 0
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCostos = GEstableciento.IdEstablecimiento
            .idDocumentoRef = Nothing
            .idAlmacen = txtAlmacen.ValueMember
            .nombreAlmacen = txtAlmacen.Text
            .idEntidad = txtProveedor.ValueMember
            .nombreEntidad = txtProveedor.Text
            .tipoEntidad = "PR"
            .fechaProceso = fecha
            .codigoLibro = "5"
            .tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            .tipoAsiento = ASIENTO_CONTABLE.APORTE_EXISTENCIA
            .importeMN = lblTotalAdquisiones.Text
            .importeME = lblTotalUS.Text
            .glosa = "POR APORTE DE EXISTENCIAS"
            .usuarioActualizacion = "JIUNI"
            .fechaActualizacion = DateTime.Now
        End With

        For Each i As DataGridViewRow In dgvCompra.Rows
            If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                nMovimiento = New movimiento
                nMovimiento.idmovimiento = 0
                nMovimiento.idAsiento = 0
                nMovimiento.cuenta = dgvCompra.Rows(i.Index).Cells(22).Value
                nMovimiento.descripcion = dgvCompra.Rows(i.Index).Cells(3).Value
                nMovimiento.tipo = "D"
                nMovimiento.monto = CDec(dgvCompra.Rows(i.Index).Cells(10).Value)
                nMovimiento.montoUSD = CDec(dgvCompra.Rows(i.Index).Cells(11).Value)
                nMovimiento.usuarioActualizacion = "Jiuni"
                nMovimiento.fechaActualizacion = DateTime.Now
                nAsiento.movimiento.Add(nMovimiento)
            End If
        Next

        nMovimientoAporte = New movimiento
        nMovimientoAporte.idmovimiento = 0
        nMovimientoAporte.idAsiento = 0
        nMovimientoAporte.cuenta = "50"
        nMovimientoAporte.descripcion = "APORTE DE EXISTENCIAS"
        nMovimientoAporte.tipo = "H"
        nMovimientoAporte.monto = CDec(lblTotalAdquisiones.Text)
        nMovimientoAporte.montoUSD = CDec(lblTotalUS.Text)
        nMovimientoAporte.usuarioActualizacion = "Jiuni"
        nMovimientoAporte.fechaActualizacion = DateTime.Now
        nAsiento.movimiento.Add(nMovimientoAporte)

        Return nAsiento
    End Function

    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)

        For Each i As DataGridViewRow In dgvCompra.Rows
            objTotalesDet = New totalesAlmacen
            objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            objTotalesDet.SecuenciaDetalle = 0
            objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
            objTotalesDet.Modulo = "N"
            objTotalesDet.idEstablecimiento = GEstableciento.IdEstablecimiento
            objTotalesDet.idAlmacen = txtAlmacen.ValueMember
            objTotalesDet.origenRecaudo = i.Cells(1).Value()
            objTotalesDet.tipoCambio = txtTipoCambio.Value
            objTotalesDet.tipoExistencia = i.Cells(21).Value()
            objTotalesDet.idItem = i.Cells(2).Value()
            objTotalesDet.descripcion = i.Cells(3).Value()
            objTotalesDet.idUnidad = i.Cells(6).Value()
            objTotalesDet.unidadMedida = i.Cells(6).Value()
            objTotalesDet.cantidad = CType(i.Cells(7).Value(), Decimal)
            objTotalesDet.precioUnitarioCompra = CType(i.Cells(8).Value(), Decimal)

            objTotalesDet.importeSoles = CType(i.Cells(10).Value(), Decimal)
            objTotalesDet.importeDolares = CType(i.Cells(11).Value(), Decimal)

            objTotalesDet.montoIsc = 0
            objTotalesDet.montoIscUS = 0
            objTotalesDet.Otros = 0
            objTotalesDet.OtrosUS = 0
            objTotalesDet.porcentajeUtilidad = 0
            objTotalesDet.importePorcentaje = 0
            objTotalesDet.importePorcentajeUS = 0
            objTotalesDet.precioVenta = 0
            objTotalesDet.precioVentaUS = 0
            objTotalesDet.usuarioActualizacion = "NN"
            objTotalesDet.fechaActualizacion = Date.Now
            ListaTotales.Add(objTotalesDet)
        Next

        Return ListaTotales
    End Function

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objTabla As New tablaDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad
        Dim VALUEDES As String = ""
        Dim insumosSA As New detalleitemsSA
        Dim CategoriaSA As New itemSA
        Dim almacenSA As New almacenSA
        'Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        'Dim DocumentoGuia As New documentoguiaDetalle
        Try
            With objDoc.UbicarDocumento(intIdDocumento)
                fecha = .fechaProceso
                txtFechaComprobante.Value = fecha
                txtFechaComprobante.CustomFormat = "dd/MM/yyyy hh:mm:ss tt"
                'COMPROBANTE
                With objTabla.GetUbicarTablaID(10, .tipoDoc)
                    IdComprobante = .codigoDetalle
                    txtComprobante.Text = .descripcion
                End With
            End With

            'DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            'If Not IsNothing(DocumentoGuia) Then
            '    With DocumentoGuia
            '        txtSerieGuia.Text = .Serie
            '        txtNumeroGuia.Text = .Numero
            '    End With
            'End If

            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                lblIdDocumento.Text = .idDocumento
                lblPerido.Text = .fechaContable
                'txtNumDoc.ValueMember = .serie
                'txtNumDoc.Text = .numeroDoc
                If .monedaDoc = "1" Then
                    cboMoneda.Text = "MONEDA NACIONAL"
                ElseIf .monedaDoc = "2" Then
                    cboMoneda.Text = "MONEDA EXTRANJERA"
                End If
                Serie = .serie
                Numero = .numeroDoc
                'txtSerieComp.Text = .serie
                'txtNumeroComp.Text = .numeroDoc
                'PROVEEDOR
                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtCuenta.Text = nEntidad.cuentaAsiento
                txtProveedor.ValueMember = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

                '_::::::::::::::::::        :::::::::::::::::::
                txtTipoCambio.Value = .tcDolLoc
                lblTotalAdquisiones.Text = CDec(.importeTotal).ToString("N2")
                lblTotalUS.Text = CDec(.importeUS).ToString("N2")
            End With


            'DETALLE DE LA COMPRA
            dgvCompra.Rows.Clear()
            Dim strCuenta As String
            Dim IDCat As String
            Dim NomCat As String
            Dim IdUM As String
            Dim NomUM As String
            Dim strAlmacen As Integer
            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)
                If i.destino = "1" Then
                    VALUEDES = "1"
                ElseIf i.destino.Trim = "2" Then
                    VALUEDES = "2"
                ElseIf i.destino.Trim = "3" Then
                    VALUEDES = "3"
                ElseIf i.destino.Trim = "4" Then
                    VALUEDES = "4"
                End If
                With objTabla.GetUbicarTablaID(6, i.unidad1)
                    IdUM = .codigoDetalle
                    NomUM = .descripcion
                End With
                With insumosSA.InvocarProductoID(i.idItem)
                    strCuenta = .cuenta
                    IDCat = .idItem
                    NomCat = CategoriaSA.UbicarCategoriaPorID(IDCat).descripcion
                End With
                dgvCompra.Rows.Add(i.secuencia,
                                    VALUEDES,
                                    i.idItem,
                                    i.descripcionItem,
                                    i.unidad2,
                                    i.monto2,
                                    i.unidad1,
                                    FormatNumber(i.monto1, 2),
                                    FormatNumber(i.precioUnitario, 2),
                                    FormatNumber(i.precioUnitarioUS, 2),
                                    FormatNumber(i.importe, 2),
                                    FormatNumber(i.importeUS, 2),
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    0,
                                    Business.Entity.BaseBE.EntityAction.UPDATE, i.tipoExistencia,
                                    insumosSA.InvocarProductoID(i.idItem).cuenta,
                                    i.preEvento,
                                    Nothing, Nothing, Nothing,
                                    Nothing, Nothing, i.bonificacion, i.almacenRef)
                strAlmacen = i.almacenRef
            Next
            With almacenSA.GetUbicar_almacenPorID(strAlmacen)
                txtAlmacen.ValueMember = .idAlmacen
                txtAlmacen.Text = .descripcionAlmacen
            End With
        Catch ex As Exception
            lblEstado.Text = "No se pudo cargar la información. " & ex.Message
        End Try

    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = lblIdDocumento.Text
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .periodo = lblPerido.Text
            .tipoDoc = "99"
            .serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
            .numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
            .idEntidad = txtProveedor.ValueMember
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIgv.Value
            .tipoCambio = txtTipoCambio.Value
            .importeMN = CDec(lblTotalAdquisiones.Text)
            .importeME = CDec(lblTotalUS.Text)
            .glosa = GlosaCompra()
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each i As DataGridViewRow In dgvCompra.Rows
            If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                documentoguiaDetalle = New documentoguiaDetalle
                documentoguiaDetalle.idDocumento = lblIdDocumento.Text
                documentoguiaDetalle.idItem = i.Cells(2).Value
                documentoguiaDetalle.descripcionItem = i.Cells(3).Value
                documentoguiaDetalle.destino = i.Cells(1).Value
                documentoguiaDetalle.unidadMedida = i.Cells(6).Value
                documentoguiaDetalle.cantidad = CDec(i.Cells(7).Value)
                documentoguiaDetalle.precioUnitario = CDec(i.Cells(8).Value)
                documentoguiaDetalle.precioUnitarioUS = CDec(i.Cells(9).Value)
                documentoguiaDetalle.importeMN = CDec(i.Cells(10).Value)
                documentoguiaDetalle.importeME = CDec(i.Cells(11).Value)
                documentoguiaDetalle.almacenRef = CInt(txtAlmacen.ValueMember)
                documentoguiaDetalle.usuarioModificacion = "Jiuni"
                documentoguiaDetalle.fechaModificacion = DateTime.Now
                ListaGuiaDetalle.Add(documentoguiaDetalle)
            End If
        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Public Sub GrabarAporte()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim ListaTotales As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim numeracionSA As New NumeracionBoletaSA
        '  Dim numeracion As New numeracionBoletas

        '        numeracion = numeracionSA.ObtenerDocumentoPorEstablecimiento(GEstableciento.IdEstablecimiento, "00001", "APORT", "VOU")
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = GConfiguracion.TipoComprobante
            .fechaProceso = fecha
            .nroDoc = GConfiguracion.Serie
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "17"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .TipoConfiguracion = GConfiguracion.TipoConfiguracion
            .IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idPadre = 0 ' lblIdDocumento.Text
            .codigoLibro = "5"
            .tipoDoc = GConfiguracion.TipoComprobante
            .tipoDocEntidad = GConfiguracion.TipoComprobante
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha ' PERIODO
            .fechaContable = lblPerido.Text
            .serie = GConfiguracion.Serie
            .numeroDoc = GConfiguracion.Serie
            .idProveedor = txtProveedor.ValueMember
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = 0
            .tcDolLoc = txtTipoCambio.Value
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            .importeTotal = CDec(lblTotalAdquisiones.Text)
            .importeUS = CDec(lblTotalUS.Text)

            .destino = TIPO_COMPRA.APORTE_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            '.glosa = IIf(IsNothing(txtGlosa.Text) Or String.IsNullOrEmpty(txtGlosa.Text) Or String.IsNullOrWhiteSpace(txtGlosa.Text), Nothing, Trim(txtGlosa.Text.Trim))
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.APORTE_EXISTENCIAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        'ASIENTOS CONTABLES
        For Each i As DataGridViewRow In dgvCompra.Rows
            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = txtFechaComprobante.Value
            objDocumentoCompraDet.CuentaProvedor = txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.TipoDoc = "9901"
            objDocumentoCompraDet.NumDoc = Nothing
            objDocumentoCompraDet.Serie = Nothing
            '   If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then
            If i.Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf i.Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf i.Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf i.Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If

            objDocumentoCompraDet.CuentaItem = i.Cells(22).Value()
            objDocumentoCompraDet.idItem = i.Cells(2).Value()
            objDocumentoCompraDet.descripcionItem = i.Cells(3).Value()
            objDocumentoCompraDet.tipoExistencia = i.Cells(21).Value()
            objDocumentoCompraDet.unidad2 = i.Cells(4).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = i.Cells(5).Value() ' PRESENTACION
            objDocumentoCompraDet.unidad1 = i.Cells(6).Value().ToString.Trim

            If Not IsNumeric(i.Cells(7).Value) Then
                lblEstado.Text = "La cantidad debe ser mayor a '0', verificar celda."
                lblEstado.Image = My.Resources.warning2
                Exit Sub
            End If
            objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value())
            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(9).Value())

            If Not IsNumeric(i.Cells(10).Value) Then
                lblEstado.Text = "Indicar el Importe!!"
                lblEstado.Image = My.Resources.warning2
                Exit Sub
            End If
            objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())
            objDocumentoCompraDet.importeUS = CDec(i.Cells(11).Value())

            objDocumentoCompraDet.montokardex = 0
            objDocumentoCompraDet.montoIsc = 0
            objDocumentoCompraDet.montoIgv = 0
            objDocumentoCompraDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = 0
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = 0
            objDocumentoCompraDet.otrosTributosUS = 0
            objDocumentoCompraDet.preEvento = Nothing 'i.Cells(23).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = "N"
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.almacenRef = txtAlmacen.ValueMember
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = "Por Aporte de existencias"

            ' objDocumentoCompraDet.BonificacionMN =

            ListaDetalle.Add(objDocumentoCompraDet)
            '   End If
        Next
        'REGISTRANDO LA GUIA DE REMISION
        '       GuiaRemision(ndocumento)

        nAsiento = AsientoContableAporte()
        ListaAsientonTransito.Add(nAsiento)
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen()

        Dim xcod As Integer = CompraSA.SaveAporteExistencia(ndocumento, ListaTotales)
        lblEstado.Text = "Aporte registrado!"
        lblEstado.Image = My.Resources.ok4
        Dispose()
    End Sub

    Public Sub UpdateAporte()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento

        Dim objTotalesDet As New totalesAlmacen()
        Dim objActividadDeleteEO As New totalesAlmacen()
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim ListaDeleteEO As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        ' Dim ListaAsiento As New List(Of asiento)
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim numeracionSA As New NumeracionBoletaSA
        Dim numeracion As New numeracionBoletas
        Dim almacenSA As New almacenSA

        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idDocumento = lblIdDocumento.Text
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = IdComprobante
            .fechaProceso = fecha
            .nroDoc = Serie & "-" & Numero
            .idOrden = Nothing ' Me.IdOrden
            .tipoOperacion = "17"
            .usuarioActualizacion = "NN"
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .idDocumento = lblIdDocumento.Text
            .idPadre = 0 ' lblIdDocumento.Text
            .codigoLibro = "5"
            .tipoDoc = IdComprobante
            .tipoDocEntidad = IdComprobante
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = fecha
            .fechaContable = lblPerido.Text
            .serie = Serie
            .numeroDoc = Numero
            .idProveedor = txtProveedor.ValueMember
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = 0
            .tcDolLoc = txtTipoCambio.Value
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing

            .importeTotal = CDec(lblTotalAdquisiones.Text)
            .importeUS = CDec(lblTotalUS.Text)

            .destino = TIPO_COMPRA.APORTE_EXISTENCIAS
            .estadoPago = TIPO_COMPRA.PAGO.PAGADO
            .glosa = "Por Aporte de existencias"
            '.glosa = IIf(IsNothing(txtGlosa.Text) Or String.IsNullOrEmpty(txtGlosa.Text) Or String.IsNullOrWhiteSpace(txtGlosa.Text), Nothing, Trim(txtGlosa.Text.Trim))
            .referenciaDestino = Nothing ' IIf(IsNothing(txtDestinoref.Text) Or String.IsNullOrEmpty(txtDestinoref.Text) Or String.IsNullOrWhiteSpace(txtDestinoref.Text), Nothing, Trim(txtDestinoref.Text.Trim))
            .tipoCompra = TIPO_COMPRA.APORTE_EXISTENCIAS
            ' .DocumentoSustentado = "S"
            .usuarioActualizacion = "Jiuni"
            .fechaActualizacion = DateTime.Now
        End With
        ndocumento.documentocompra = nDocumentoCompra

        'ASIENTOS CONTABLES
        For Each i As DataGridViewRow In dgvCompra.Rows

            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.idDocumento = lblIdDocumento.Text
            objDocumentoCompraDet.secuencia = dgvCompra.Rows(i.Index).Cells(0).Value ' i.Cells(0).Value
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.FechaDoc = fecha
            objDocumentoCompraDet.CuentaProvedor = txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.TipoDoc = "9901"
            objDocumentoCompraDet.NumDoc = Numero
            objDocumentoCompraDet.Serie = Serie
            '   If dgvNuevoDoc.Rows(S).Cells(20).Value() = ENTITY_ACTIONS.INSERT Then

            If i.Cells(1).Value() = "1" Then '   ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES" Then
                objDocumentoCompraDet.destino = "1"
            ElseIf i.Cells(1).Value() = "2" Then '   ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV" Then
                objDocumentoCompraDet.destino = "2"
            ElseIf i.Cells(1).Value() = "3" Then '   ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "3"
            ElseIf i.Cells(1).Value() = "4" Then '   ADQUISICIONES NO GRAVADAS" Then
                objDocumentoCompraDet.destino = "4"
            End If

            objDocumentoCompraDet.CuentaItem = i.Cells(22).Value()
            objDocumentoCompraDet.idItem = i.Cells(2).Value()
            objDocumentoCompraDet.descripcionItem = i.Cells(3).Value()
            objDocumentoCompraDet.tipoExistencia = i.Cells(21).Value()
            objDocumentoCompraDet.unidad2 = i.Cells(4).Value().ToString.Trim 'IDPRESENTACION
            objDocumentoCompraDet.monto2 = i.Cells(5).Value() ' PRESENTACION
            objDocumentoCompraDet.unidad1 = i.Cells(6).Value().ToString.Trim

            If Not IsNumeric(i.Cells(7).Value) Then
                lblEstado.Text = "La cantidad debe ser mayor a '0', verificar celda."
                lblEstado.Image = My.Resources.warning2
                Exit Sub
            End If
            objDocumentoCompraDet.monto1 = CDec(i.Cells(7).Value())
            objDocumentoCompraDet.precioUnitario = CDec(i.Cells(8).Value())
            objDocumentoCompraDet.precioUnitarioUS = CDec(i.Cells(9).Value())

            If Not IsNumeric(i.Cells(10).Value) Then
                lblEstado.Text = "Indicar el Importe!!"
                lblEstado.Image = My.Resources.warning2
                Exit Sub
            End If
            objDocumentoCompraDet.importe = CDec(i.Cells(10).Value())
            objDocumentoCompraDet.importeUS = CDec(i.Cells(11).Value())

            objDocumentoCompraDet.montokardex = 0
            objDocumentoCompraDet.montoIsc = 0
            objDocumentoCompraDet.montoIgv = 0
            objDocumentoCompraDet.otrosTributos = 0
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = 0
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = 0
            objDocumentoCompraDet.otrosTributosUS = 0
            objDocumentoCompraDet.preEvento = Nothing 'i.Cells(23).Value() '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = "N"
            '**********************************************************************************
            objDocumentoCompraDet.usuarioModificacion = "Jiuni"
            objDocumentoCompraDet.almacenRef = txtAlmacen.ValueMember
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvNuevoDoc.Rows(S).Cells(28).Value()), Nothing, CDate(dgvNuevoDoc.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = "Por Aporte de existencias"

            If dgvCompra.Rows(i.Index).Cells(20).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.UPDATE
            ElseIf dgvCompra.Rows(i.Index).Cells(20).Value() = Business.Entity.BaseBE.EntityAction.INSERT Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
            ElseIf dgvCompra.Rows(i.Index).Cells(20).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then
                objDocumentoCompraDet.Action = Business.Entity.BaseBE.EntityAction.DELETE
            End If
            ListaDetalle.Add(objDocumentoCompraDet)

            '-----------------------------------------------------------------------------------------------------------------
            If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
                objTotalesDet = New totalesAlmacen
                objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objTotalesDet.SecuenciaDetalle = dgvCompra.Rows(i.Index).Cells(0).Value()
                objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                objTotalesDet.TipoDoc = dgvCompra.Text
                objTotalesDet.Modulo = "N"
                objTotalesDet.idEstablecimiento = GEstableciento.IdEstablecimiento ' almacensa.GetUbicar_almacenPorID(CInt(i.Cells(30).Value())).idEstablecimiento
                objTotalesDet.idAlmacen = txtAlmacen.ValueMember
                objTotalesDet.origenRecaudo = dgvCompra.Rows(i.Index).Cells(1).Value()
                objTotalesDet.tipoCambio = "2.77"
                objTotalesDet.tipoExistencia = dgvCompra.Rows(i.Index).Cells(21).Value()
                objTotalesDet.idItem = dgvCompra.Rows(i.Index).Cells(2).Value()
                objTotalesDet.descripcion = dgvCompra.Rows(i.Index).Cells(3).Value()
                objTotalesDet.idUnidad = dgvCompra.Rows(i.Index).Cells(6).Value()
                objTotalesDet.unidadMedida = Nothing

                objTotalesDet.cantidad = CType(dgvCompra.Rows(i.Index).Cells(7).Value(), Decimal)
                objTotalesDet.precioUnitarioCompra = CType(dgvCompra.Rows(i.Index).Cells(8).Value(), Decimal)
                objTotalesDet.importeSoles = CType(dgvCompra.Rows(i.Index).Cells(10).Value(), Decimal)
                objTotalesDet.importeDolares = CType(dgvCompra.Rows(i.Index).Cells(11).Value(), Decimal)

                objTotalesDet.montoIsc = 0
                objTotalesDet.montoIscUS = 0
                objTotalesDet.Otros = 0
                objTotalesDet.OtrosUS = 0
                objTotalesDet.porcentajeUtilidad = 0
                objTotalesDet.importePorcentaje = 0
                objTotalesDet.importePorcentajeUS = 0
                objTotalesDet.precioVenta = 0
                objTotalesDet.precioVentaUS = 0
                objTotalesDet.usuarioActualizacion = "NN"
                objTotalesDet.fechaActualizacion = Date.Now
                ListaTotales.Add(objTotalesDet)
            End If


            If dgvCompra.Rows(i.Index).Cells(20).Value() = Business.Entity.BaseBE.EntityAction.UPDATE Or
       dgvCompra.Rows(i.Index).Cells(20).Value() = Business.Entity.BaseBE.EntityAction.DELETE Then

                objActividadDeleteEO = New totalesAlmacen
                objActividadDeleteEO.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objActividadDeleteEO.TipoDoc = IdComprobante
                objActividadDeleteEO.SecuenciaDetalle = dgvCompra.Rows(i.Index).Cells(0).Value()
                objActividadDeleteEO.idEmpresa = Gempresas.IdEmpresaRuc
                objActividadDeleteEO.Modulo = "N"
                objActividadDeleteEO.idEstablecimiento = GEstableciento.IdEstablecimiento
                objActividadDeleteEO.idAlmacen = dgvCompra.Rows(i.Index).Cells(30).Value()
                objActividadDeleteEO.origenRecaudo = dgvCompra.Rows(i.Index).Cells(1).Value()
                objActividadDeleteEO.tipoCambio = txtTipoCambio.Value
                objActividadDeleteEO.tipoExistencia = dgvCompra.Rows(i.Index).Cells(21).Value()
                objActividadDeleteEO.idItem = dgvCompra.Rows(i.Index).Cells(2).Value()
                objActividadDeleteEO.descripcion = dgvCompra.Rows(i.Index).Cells(3).Value()
                ListaDeleteEO.Add(objActividadDeleteEO)
            End If
        Next
        nAsiento = AsientoContableAporte()
        ListaAsientonTransito.Add(nAsiento)
        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle


        CompraSA.UpdateAporteExistencia(ndocumento, ListaTotales, ListaDeleteEO)
        lblEstado.Text = "Aporte modificado!"
        lblEstado.Image = My.Resources.ok4

        Dispose()
    End Sub
#End Region

    Private Sub frmAportesExistencia_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmAportesExistencia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        toolTip = New Popup(UserControl1)
        toolTip.AutoClose = False
        toolTip.FocusOnOpen = False
        toolTip.ShowingAnimation = PopupAnimations.Blend
        InfoConfiguracion(Sys.Inicio)

        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            'Panel8.Visible = False
            'GradientPanel3.Visible = False
            cboMoneda.SelectedValue = 1
            txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        ElseIf IsNothing(ManipulacionEstado) Then
            'Panel8.Visible = False
            'GradientPanel3.Visible = False
            cboMoneda.SelectedValue = 1
            ManipulacionEstado = ENTITY_ACTIONS.INSERT
            txtFechaComprobante.Value = New Date(AnioGeneral, MesGeneral, DateTime.Now.Day)
            txtFechaComprobante.CustomFormat = "dd/MM/yyyy"
        Else
            'If DocumentoCompraSA.TieneItemsEnAV(CInt(lblIdDocumento.Text)) = True Then
            '    Panel8.Visible = False
            '    GradientPanel3.Visible = False
            'Else
            '    Panel8.Visible = True
            '    GradientPanel3.Visible = True
            'End If

        End If
    End Sub

    Private Sub dropDownBtn_Click(sender As System.Object, e As System.EventArgs) Handles dropDownBtn.Click
        popupControlContainer1.Font = New Font("Tahoma", 8)
        Me.popupControlContainer1.ParentControl = Me.txtProveedor
        Me.popupControlContainer1.ShowPopup(Point.Empty)
    End Sub

    Private Sub popupControlContainer1_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles popupControlContainer1.BeforePopup
        Me.popupControlContainer1.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.ValueMember = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub OK_Click(sender As System.Object, e As System.EventArgs) Handles OK.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub cancel_Click(sender As System.Object, e As System.EventArgs) Handles cancel.Click
        Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub PopupControlContainer2_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles PopupControlContainer2.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstCategoria.SelectedItems.Count > 0 Then
                Me.txtCategoria.ValueMember = CStr(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Id)
                txtCategoria.Text = lstCategoria.Text
                ListadoProductosPorCategoriaTipoExistencia(DirectCast(Me.lstCategoria.SelectedItem, Categoria).Id, cboTipoExistencia.SelectedValue)
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub lstCategoria_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstCategoria.MouseDoubleClick
        If lstCategoria.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub lstCategoria_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstCategoria.SelectedIndexChanged

    End Sub

    Private Sub ButtonCategoria_Click(sender As System.Object, e As System.EventArgs) Handles ButtonCategoria.Click
        Me.PopupControlContainer2.Font = New Font("Tahoma", 8)
        Me.PopupControlContainer2.Size = New Size(238, 110)
        Me.PopupControlContainer2.ParentControl = Me.txtCategoria
        Me.PopupControlContainer2.ShowPopup(Point.Empty)
    End Sub

    Private Sub btnGRabarProv_Click(sender As System.Object, e As System.EventArgs) Handles btnGRabarProv.Click
        If Not txtDocProveedor.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nro de documento del proveedor"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(321, 248)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtDocProveedor.Select()
            Exit Sub
        End If

        If Not txtNomProv.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del proveedor"
            pcProveedor.Font = New Font("Tahoma", 8)
            pcProveedor.Size = New Size(321, 248)
            Me.pcProveedor.ParentControl = Me.txtProveedor
            Me.pcProveedor.ShowPopup(Point.Empty)
            txtNomProv.Select()
            Exit Sub
        End If

        If rbNatural.Checked = True Then
            If Not txtApePat.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese los apellidos del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 248)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtApePat.Select()
                Exit Sub
            End If
        End If
        btnGRabarProv.Tag = "G"
        Me.pcProveedor.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub btnCancelarProv_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarProv.Click
        Me.pcProveedor.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub btnRuc_Click(sender As System.Object, e As System.EventArgs) Handles btnRuc.Click
        btnRuc.Checked = True
        If btnRuc.Checked = True Then
            btnDni.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnDni_Click(sender As System.Object, e As System.EventArgs) Handles btnDni.Click
        btnDni.Checked = True
        If btnDni.Checked = True Then
            btnRuc.Checked = False
            btnPassport.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnPassport_Click(sender As System.Object, e As System.EventArgs) Handles btnPassport.Click
        btnPassport.Checked = True
        If btnPassport.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnCarnetEx.Checked = False
        End If
    End Sub

    Private Sub btnCarnetEx_Click(sender As System.Object, e As System.EventArgs) Handles btnCarnetEx.Click
        btnCarnetEx.Checked = True
        If btnCarnetEx.Checked = True Then
            btnRuc.Checked = False
            btnDni.Checked = False
            btnPassport.Checked = False
        End If
    End Sub

    Private Sub rbNatural_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbNatural.CheckChanged
        If rbNatural.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = True
            txtApePat.Clear()
            Label31.Visible = True
            Label30.Text = "Nombres:"
        End If
    End Sub

    Private Sub rbJuridico_CheckChanged(sender As System.Object, e As System.EventArgs) Handles rbJuridico.CheckChanged
        If rbJuridico.Checked = True Then
            txtNomProv.Visible = True
            txtNomProv.Clear()
            txtApePat.Visible = False
            txtApePat.Clear()
            Label31.Visible = False
            Label30.Text = "Nombre o Razón Social:"
        End If
    End Sub

    Private Sub pcProveedor_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcProveedor.BeforePopup
        Me.pcProveedor.BackColor = Color.White
    End Sub

    Private Sub pcProveedor_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcProveedor.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtDocProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nro de documento del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 248)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtDocProveedor.Select()
                Exit Sub
            End If

            If Not txtNomProv.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre del proveedor"
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 248)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
                txtNomProv.Select()
                Exit Sub
            End If

            If rbNatural.Checked = True Then
                If Not txtApePat.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese los apellidos del proveedor"
                    pcProveedor.Font = New Font("Tahoma", 8)
                    pcProveedor.Size = New Size(321, 248)
                    Me.pcProveedor.ParentControl = Me.txtProveedor
                    Me.pcProveedor.ShowPopup(Point.Empty)
                    txtApePat.Select()
                    Exit Sub
                End If
            End If
            If btnGRabarProv.Tag = "G" Then
                InsertProveedor()
                btnGRabarProv.Tag = "N"
            Else
                pcProveedor.Font = New Font("Tahoma", 8)
                pcProveedor.Size = New Size(321, 248)
                Me.pcProveedor.ParentControl = Me.txtProveedor
                Me.pcProveedor.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click
        txtDocProveedor.Clear()
        txtNomProv.Clear()
        txtApePat.Clear()
        pcProveedor.Font = New Font("Tahoma", 8)
        pcProveedor.Size = New Size(321, 248)
        Me.pcProveedor.ParentControl = Me.txtProveedor
        Me.pcProveedor.ShowPopup(Point.Empty)
    End Sub

    Private Sub btmGrabarClasificacion_Click(sender As System.Object, e As System.EventArgs) Handles btmGrabarClasificacion.Click
        If Not txtNewClasificacion.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre de la clasificación"
            pcClasificacion.Font = New Font("Tahoma", 8)
            pcClasificacion.Size = New Size(318, 102)
            Me.pcClasificacion.ParentControl = Me.txtCategoria
            Me.pcClasificacion.ShowPopup(Point.Empty)
            txtNewClasificacion.Select()
            Exit Sub
        End If
        btmGrabarClasificacion.Tag = "G"
        Me.pcClasificacion.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv6_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv6.Click
        Me.pcClasificacion.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcClasificacion_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcClasificacion.BeforePopup
        Me.pcClasificacion.BackColor = Color.White
    End Sub

    Private Sub pcClasificacion_CloseUp(sender As System.Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcClasificacion.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If Not txtNewClasificacion.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese el nombre de la clasificación"
                pcClasificacion.Font = New Font("Tahoma", 8)
                pcClasificacion.Size = New Size(318, 102)
                Me.pcClasificacion.ParentControl = Me.txtCategoria
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
                Me.pcClasificacion.ParentControl = Me.txtCategoria
                Me.pcClasificacion.ShowPopup(Point.Empty)
            End If

        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox2.Click
        Me.Cursor = Cursors.WaitCursor
        pcClasificacion.Font = New Font("Tahoma", 8)
        pcClasificacion.Size = New Size(318, 102)
        Me.pcClasificacion.ParentControl = Me.txtCategoria
        Me.pcClasificacion.ShowPopup(Point.Empty)
        txtNewClasificacion.Clear()
        txtNewClasificacion.Select()
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv4_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv4.Click
        Me.Cursor = Cursors.WaitCursor
        If Not txtProductoNew.Text.Trim.Length > 0 Then
            lblEstado.Text = "Ingrese el nombre del producto"
            Me.Cursor = Cursors.Arrow
            Exit Sub
        End If
        GrabarItemEstablec()
        'dockingManager1.SetDockVisibility(PanelNuevoItem, False)
        'dockingManager1.SetDockVisibility(Panel2, True)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv5_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv5.Click
        Me.Cursor = Cursors.WaitCursor
        dockingManager1.SetDockVisibility(PanelNuevoItem, False)
        dockingManager1.SetDockVisibility(Panel2, True)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PegarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles PegarToolStripButton.Click
        Dispose()
    End Sub

    Private Sub btnNuevoProd_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevoProd.Click
        Me.Cursor = Cursors.WaitCursor
        If txtCategoria.Text.Trim.Length > 0 Then
            dockingManager1.SetDockVisibility(PanelNuevoItem, True)
            Me.dockingManager1.DockControl(Me.PanelNuevoItem, Me, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 335)
            dockingManager1.SetDockLabel(PanelNuevoItem, "Nuevo producto")
            dockingManager1.SetDockVisibility(Panel2, False)
            txtcodCategoria.Text = txtCategoria.Text
            txtcodCategoria.ValueMember = txtCategoria.ValueMember
            txtTipoExistencia.Text = cboTipoExistencia.Text
            txtTipoExistencia.ValueMember = cboTipoExistencia.SelectedValue
            txtProductoNew.Clear()
            txtProductoNew.Select()
            Me.Cursor = Cursors.Arrow
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub btnConfiguracion_Click(sender As System.Object, e As System.EventArgs) Handles btnConfiguracion.Click
        InfoConfiguracion(Sys.Proceso)
    End Sub

    Private Sub btnVer_Click(sender As System.Object, e As System.EventArgs) Handles btnVer.Click
        dockingManager1.SetDockVisibility(Panel2, True)
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        If dgvCompra.Rows.Count > 0 Then

            If Not IsNothing(dgvCompra.CurrentRow) Then

                If dgvCompra.Item(20, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.INSERT Then
                    dgvCompra.Rows.RemoveAt(dgvCompra.CurrentCell.RowIndex)
                ElseIf dgvCompra.Item(20, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.UPDATE Then
                    dgvCompra.Item(20, dgvCompra.CurrentRow.Index).Value = Helios.Cont.Business.Entity.BaseBE.EntityAction.DELETE
                    Dim pos As Integer = Me.dgvCompra.CurrentRow.Index

                    dgvCompra.CurrentCell = Nothing
                    Me.dgvCompra.Rows(pos).Visible = False
                End If
                If dgvCompra.Rows.Count > 0 Then
                    CellEndEditRefresh()
                Else
                    lblTotalAdquisiones.Text = "0.00"
                    lblTotalUS.Text = "0.00"
                End If
            End If
        End If
    End Sub

    Private Sub ButtonAdv8_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv8.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ButtonAdv7_Click(sender As System.Object, e As System.EventArgs) Handles ButtonAdv7.Click
        Me.pcAlmacen.HidePopup(PopupCloseType.Canceled)
    End Sub

    Private Sub pcAlmacen_BeforePopup(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles pcAlmacen.BeforePopup
        Me.pcAlmacen.BackColor = Color.FromArgb(227, 241, 254)
    End Sub

    Private Sub pcAlmacen_CloseUp(sender As Object, e As Syncfusion.Windows.Forms.PopupClosedEventArgs) Handles pcAlmacen.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lstAlmacen.SelectedItems.Count > 0 Then
                Me.txtAlmacen.ValueMember = lstAlmacen.SelectedValue
                txtAlmacen.Text = lstAlmacen.Text
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtAlmacen.Focus()
        End If
    End Sub

    Private Sub tbnAlmacen_Click(sender As System.Object, e As System.EventArgs) Handles tbnAlmacen.Click
        pcAlmacen.Font = New Font("Tahoma", 8)
        pcAlmacen.Size = New Size(260, 110)
        Me.pcAlmacen.ParentControl = Me.txtAlmacen
        Me.pcAlmacen.ShowPopup(Point.Empty)
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSerieGuia.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtNumeroGuia.Select()
        End If
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As System.EventArgs) Handles txtSerieGuia.LostFocus
        If txtSerieGuia.Text.Trim.Length > 0 Then
            txtSerieGuia.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
        End If
    End Sub

    Private Sub txtSerieGuia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSerieGuia.TextChanged

    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumeroGuia.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            txtTipoCambio.Select()
        End If
    End Sub

    Private Sub txtNumeroGuia_LostFocus(sender As Object, e As System.EventArgs) Handles txtNumeroGuia.LostFocus
        If txtNumeroGuia.Text.Trim.Length > 0 Then
            txtNumeroGuia.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
        End If
    End Sub

    Private Sub txtNumeroGuia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNumeroGuia.TextChanged

    End Sub

    Private Sub btnConfiguracion_MouseLeave(sender As Object, e As System.EventArgs) Handles btnConfiguracion.MouseLeave
        toolTip.Close()
    End Sub

    Private Sub txtTipoCambio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtTipoCambio.ValueChanged
        If dgvCompra.Rows.Count > 0 Then
            CellEndEditRefresh()
        End If
    End Sub

    Private Sub dgvCompra_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompra.CellContentClick

    End Sub

    Private Sub dgvCompra_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompra.CellEndEdit
        If dgvCompra.Rows.Count > 0 Then
            'DECLARANDO VARIABLES
            Dim colDestinoGravado As Decimal = 0
            colDestinoGravado = dgvCompra.Item(1, dgvCompra.CurrentRow.Index).Value

            Dim colCantidad As Decimal = 0
            If Not CStr(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value).Trim.Length > 0 Then
                lblEstado.Text = "Ingrese una cantidad válida!"
                lblEstado.Image = My.Resources.warning2
                'Timer1.Enabled = True
                'TiempoEjecutar(5)
                Exit Sub
            Else
                colCantidad = dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value
            End If

            Dim colMN As Decimal = 0

            If Not CStr(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value).Trim.Length > 0 Then
                lblEstado.Text = "Ingrese un importe válido!"
                lblEstado.Image = My.Resources.warning2
                'Timer1.Enabled = True
                'TiempoEjecutar(5)
                Exit Sub
            Else
                colMN = dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value
            End If

            Dim colME As Decimal = Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value) / CDec(txtTipoCambio.Value), 2)
            Dim colPrecUnit As Decimal = 0
            Dim colPrecUnitUSD As Decimal = 0


            If colCantidad > 0 AndAlso colMN > 0 Then

                colPrecUnit = Math.Round(colMN / colCantidad, 2)

                colPrecUnitUSD = Math.Round(colME / colCantidad, 2)


            Else
                colPrecUnit = 0

                colPrecUnitUSD = 0

            End If
            If dgvCompra.Columns(e.ColumnIndex).Name = "ImporteNeto" Or dgvCompra.Columns(e.ColumnIndex).Name = "Can1" Or dgvCompra.Columns(e.ColumnIndex).Name = "ImporteUS" Then 'Or dgvCompra.Columns(e.ColumnIndex).Name = "otrostributos" Or dgvCompra.Columns(e.ColumnIndex).Name = "OTCus" Then
                If txtTipoCambio.Value = 0.0 Then
                    MsgBox("Ingrese Tipo de Cambio..!")
                    txtTipoCambio.Focus()
                    txtTipoCambio.Select(0, txtTipoCambio.Text.Length)
                    Exit Sub
                End If
                ' Dim cantidad As Decimal = Convert.ToDecimal(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value())
                ' Dim neto As Decimal = Convert.ToDecimal(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value())
                ' Dim netous As Decimal = Convert.ToDecimal(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value())
                Dim NUDIGV_VALUE As Decimal = Math.Round((txtIgv.Value / 100) + 1, 2)
                If colCantidad = 0 And colMN = 0 And colME = 0 Then
                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"
                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00"
                    Exit Sub
                    'ElseIf neto > 0 And cantidad = 0 Then
                    '    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"
                    '    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00"
                    '    Exit Sub
                ElseIf colCantidad = 0 Then

                    If cboMoneda.SelectedValue = 1 Then
                        ' DATOS SOLES
                        Select Case colDestinoGravado
                            Case "4"
                                dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)
                                dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES
                                dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos) ' MONTO TOTAL DOLARES

                            Case Else

                                If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                    dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto igv del item
                                    dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                    dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD
                                    dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                                Else
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"  'Math.Round(CDec(neto / cantidad), 4) ' PRECIO UNITARIO SOLES
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), 4)
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                    dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                    dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = 0  ' Math.Round(CDec(neto - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                    dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                    dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                    '        dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES
                                End If
                        End Select

                    ElseIf cboMoneda.SelectedValue = 2 Then
                        ' DATOS DOLARES
                        Select Case colDestinoGravado
                            Case "4"
                                dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), 2)
                                dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")

                                ' dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                ' dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos) ' igv del item

                                '  dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                '  dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

                                '  dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
                            Case Else

                                If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(netous / cantidad), 4) ' PRECIO UNITARIO DOLARES
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") 'Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")

                                    dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                    dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00" ' igv del item

                                    dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                    dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00" 'Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), 2)
                                    dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                Else
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = "0.00"
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2")
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2")

                                    dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                    dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                    dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                    dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(netous - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                    '         dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                End If
                        End Select

                    End If
                ElseIf colCantidad > 0 Then
                    If cboMoneda.SelectedValue = 1 Then
                        ' DATOS SOLES
                        If colDestinoGravado = "4" Then
                            dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                            dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                            dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                            dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                            dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                            '  dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                            '  dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(neto - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos) ' monto igv del item

                            ' dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex USD
                            ' dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV USD


                            'dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS DOLARES
                        Else
                            If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then
                                dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") '  CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto igv del item

                                dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex USD
                                dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV USD


                                dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS DOLARES
                            Else
                                dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(neto / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO SOLES
                                dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' Math.Round(CDec(neto / CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL DOLARES
                                dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(neto / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(neto - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto igv del item

                                dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex USD
                                dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV USD


                                '      dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() / nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS DOLARES

                            End If

                        End If

                    ElseIf cboMoneda.SelectedValue = 2 Then

                        Select Case colDestinoGravado
                            Case "4"
                                ' DATOS DOLARES
                                dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                '  dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                '  dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos) ' igv del item

                                ' dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos) ' monto para el kardex
                                ' dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(netous - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos) ' monto para el IGV

                                ' dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos) ' monto OTROS TRIBUTOS SOLES
                            Case Else
                                ' DATOS DOLARES
                                If dgvCompra.Item(27, dgvCompra.CurrentRow.Index).Value() = "S" Then
                                    dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                    dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                    dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = "0.00" ' igv del item

                                    dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el kardex
                                    dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto para el IGV

                                    dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = "0.00" ' monto OTROS TRIBUTOS SOLES
                                Else
                                    dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value() = colCantidad.ToString("N2") ' CDec(dgvCompra.Item(7, dgvCompra.CurrentRow.Index).Value()).ToString("N2") ' CANTIDAD
                                    dgvCompra.Item(8, dgvCompra.CurrentRow.Index).Value() = colPrecUnit.ToString("N2") ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / cantidad), NumDigitos).ToString("N2")
                                    dgvCompra.Item(9, dgvCompra.CurrentRow.Index).Value() = colPrecUnitUSD.ToString("N2") ' Math.Round(CDec(netous / cantidad), NumDigitos).ToString("N2") ' PRECIO UNITARIO DOLARES
                                    dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() = colMN.ToString("N2") ' Math.Round(CDec(netous * CDec(nudTipoCambio.Value)), NumDigitos).ToString("N2") ' MONTO TOTAL SOLES
                                    dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value() = colME.ToString("N2") ' CDec(dgvCompra.Item(11, dgvCompra.CurrentRow.Index).Value()).ToString("N2")
                                    dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                    dgvCompra.Item(14, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(dgvCompra.Item(10, dgvCompra.CurrentRow.Index).Value() - CDec(dgvCompra.Item(12, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' igv del item

                                    dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(netous / CDec(NUDIGV_VALUE)), NumDigitos).ToString("N2") ' monto para el kardex
                                    dgvCompra.Item(18, dgvCompra.CurrentRow.Index).Value() = 0 ' Math.Round(CDec(netous - CDec(dgvCompra.Item(16, dgvCompra.CurrentRow.Index).Value())), NumDigitos).ToString("N2") ' monto para el IGV

                                    '    dgvCompra.Item(15, dgvCompra.CurrentRow.Index).Value() = Math.Round(CDec(dgvCompra.Item(19, dgvCompra.CurrentRow.Index).Value() * nudTipoCambio.Value), NumDigitos).ToString("N2") ' monto OTROS TRIBUTOS SOLES
                                End If

                        End Select

                    End If
                End If
                TotalesCabeceras()
            End If

        End If
    End Sub

    Private Sub dgvCompra_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvCompra.CellFormatting
        If e.RowIndex > -1 Then
            If e.ColumnIndex = Me.dgvCompra.Columns("Gravado").Index _
AndAlso (e.Value IsNot Nothing) Then

                With Me.dgvCompra.Rows(e.RowIndex).Cells(e.ColumnIndex)

                    If e.Value.Equals("1") Then
                        .ToolTipText = "1: ADQ. GRAVADAS DESTINADAS A OPE.GRAVADAS Y/O EXPORTACIONES"
                    ElseIf e.Value.Equals("2") Then
                        .ToolTipText = "2: ADQ. GRAV DEST CONJUNTAMENTE A OPER GRAV Y NO GRAV"
                    ElseIf e.Value.Equals("3") Then
                        .ToolTipText = "3: ADQ. GRAVADAS DESTINADAS A OPER.NO GRAVADAS"
                    ElseIf e.Value.Equals("4") Then
                        .ToolTipText = "4: ADQUISICIONES NO GRAVADAS"
                    End If

                End With

            End If
        End If
    End Sub

    Private Sub dgvCompra_CurrentCellDirtyStateChanged(sender As Object, e As System.EventArgs) Handles dgvCompra.CurrentCellDirtyStateChanged
        Try
            If dgvCompra.IsCurrentCellDirty Then
                dgvCompra.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If

            If TypeOf dgvCompra.CurrentCell Is DataGridViewCheckBoxCell Then
                dgvCompra.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        Catch
        End Try
    End Sub

    Private Sub dgvCompra_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvCompra.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf Validar_Numeros
    End Sub

    Private Sub dgvCompra_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles dgvCompra.KeyDown
        Dim conteo As Integer = dgvCompra.Rows.Count
        Try
            If e.KeyCode = Keys.Enter Then
                Select Case (dgvCompra.CurrentCell.ColumnIndex)
                    Case 7
                        If cboMoneda.SelectedValue = 1 Then
                            If conteo = 1 Then
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(10, Me.dgvCompra.CurrentCell.RowIndex)
                            Else
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(10, Me.dgvCompra.CurrentCell.RowIndex)
                            End If
                        Else
                            If conteo = 1 Then
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(11, Me.dgvCompra.CurrentCell.RowIndex)
                            Else
                                Me.dgvCompra.CurrentCell = Me.dgvCompra(11, Me.dgvCompra.CurrentCell.RowIndex)
                            End If
                        End If
                    Case 3
                        Me.dgvCompra.CurrentCell = Me.dgvCompra(0, Me.dgvCompra.CurrentCell.RowIndex)
                    Case 10 Or 11
                        Me.dgvCompra.CurrentCell = Me.dgvCompra(23, Me.dgvCompra.CurrentCell.RowIndex)
                End Select
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvCompra_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvCompra.RowPostPaint
        Dim grid As DataGridView = TryCast(sender, DataGridView)

        If Not grid.RowHeadersVisible Then
            Return
        End If

        'this method overrides the DataGridView's RowPostPaint event 
        'in order to automatically draw numbers on the row header cells
        'and to automatically adjust the width of the column containing
        'the row header cells so that it can accommodate the new row
        'numbers,

        'store a string representation of the row number in 'strRowNumber'
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()

        'prepend leading zeros to the string if necessary to improve
        'appearance. For example, if there are ten rows in the grid,
        'row seven will be numbered as "07" instead of "7". Similarly, if 
        'there are 100 rows in the grid, row seven will be numbered as "007".
        While strRowNumber.Length < grid.RowCount.ToString().Length
            strRowNumber = Convert.ToString("0") & strRowNumber
        End While

        'determine the display size of the row number string using
        'the DataGridView's current font.
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, grid.Font)

        'adjust the width of the column that contains the row header cells 
        'if necessary
        If grid.RowHeadersWidth < CInt(size.Width + 20) Then
            grid.RowHeadersWidth = CInt(size.Width + 20)
        End If

        'this brush will be used to draw the row number string on the
        'row header cell using the system's current ControlText color
        Dim b As Brush = SystemBrushes.ControlText

        'draw the row number string on the current row header cell using
        'the brush defined above and the DataGridView's default font
        e.Graphics.DrawString(strRowNumber, grid.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        If lsvListadoItems.SelectedItems.Count > 0 Then
            With objInsumo.InvocarProductoID(CInt(lsvListadoItems.SelectedItems(0).SubItems(0).Text))
                dgvCompra.Rows.Add(0, .origenProducto, .codigodetalle, .descripcionItem,
                                     .presentacion,
                                        tablaSA.GetUbicarTablaID(21, .presentacion).descripcion, .unidad1, 0, 0, 0, 0, 0, 0,
                                      0, 0, 0, 0, 0, 0, 0, Business.Entity.BaseBE.EntityAction.INSERT,
                                      .tipoExistencia, .cuenta, Nothing)
            End With
        End If
    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lsvListadoItems.SelectedIndexChanged

    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
            fecha = New DateTime(txtFechaComprobante.Value.Year, txtFechaComprobante.Value.Month, txtFechaComprobante.Value.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        Else
            fecha = New DateTime(fecha.Year, fecha.Month, txtFechaComprobante.Value.Day, txtFechaComprobante.Value.Hour, txtFechaComprobante.Value.Minute, txtFechaComprobante.Value.Second)
        End If
    End Sub

    Private Sub GuardarToolStripButton_Click(sender As System.Object, e As System.EventArgs) Handles GuardarToolStripButton.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                If Not txtProveedor.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese un accionista válido!"
                    Exit Sub
                End If

                If Not txtAlmacen.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese un almacén válido!"
                    Exit Sub
                End If
                If dgvCompra.Rows.Count > 0 Then
                    GrabarAporte()
                Else
                    lblEstado.Text = "Debe haber al menos una fila en la canasta de aportes"
                End If
            Else
                If Not txtProveedor.Text.Trim.Length > 0 Then
                    lblEstado.Text = "Ingrese un accionista válido!"
                    Exit Sub
                End If

                Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                If Filas > 0 Then
                    UpdateAporte()
                Else
                    Me.lblEstado.Image = My.Resources.warning2 ' Bitmap.FromFile("D:\TFS\HELIOS\iconosvb\warning2.png")
                    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                End If
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            lblEstado.Image = My.Resources.warning2
        End Try
        Me.Cursor = Cursors.Arrow
    End Sub
End Class