Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Grouping

Public Class frmNotaCreditoBonificaciones
    Inherits frmMaster

    Dim ListaAsientonTransito As New List(Of asiento)
    Public Property TotalesXcanbeceras As TotalesXcanbecera
    Public Property idAlmacenVirtual() As Integer
    Public Property ManipulacionEstado() As String

    Public Class TotalesXcanbecera
        '   Private base_mn, base_me, igv_mn, igv_me, total_mn, total_me As Decimal?

        Public Property BaseMN() As Decimal
        Public Property BaseME() As Decimal
        Public Property IgvMN() As Decimal
        Public Property IgvME() As Decimal
        Public Property TotalMN() As Decimal
        Public Property TotalME() As Decimal

        Public Property base1() As Decimal
        Public Property base1me() As Decimal
        Public Property base2() As Decimal
        Public Property base2me() As Decimal
        Public Property MontoIgv1() As Decimal
        Public Property MontoIgv1me() As Decimal
        Public Property MontoIgv2() As Decimal
        Public Property MontoIgv2me() As Decimal

        Public Property PercepcionMN() As Decimal
        Public Property PercepcionME() As Decimal

        Public Sub New()
            BaseMN = 0
            BaseME = 0
            IgvMN = 0
            IgvME = 0
            TotalMN = 0
            TotalME = 0
            base1 = 0
            base1me = 0
            base2 = 0
            base2me = 0
            MontoIgv1 = 0
            MontoIgv1me = 0
            MontoIgv2 = 0
            MontoIgv2me = 0
            PercepcionMN = 0
            PercepcionME = 0
        End Sub


    End Class

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Loadcontroles()
        GetTableGrid()
        configuracionInicio()
    End Sub

    Public Sub New(intIdDocumento As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Loadcontroles()
        GetTableGrid()
        UbicarDocumento(intIdDocumento)
    End Sub

    Sub ConfiguracionInicio()
        TotalesXcanbeceras = New TotalesXcanbecera()
        Dim almacenSA As New almacenSA
        idAlmacenVirtual = almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen
        'configurando docking manager
        dockingManager1.DockControlInAutoHideMode(Panel2, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 413)
        dockingManager1.DockControlInAutoHideMode(Panel5, Syncfusion.Windows.Forms.Tools.DockingStyle.Left, 413)
        Me.DockingClientPanel1.AutoScroll = True
        Me.DockingClientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        dockingManager1.SetDockLabel(Panel2, "Existencias")
        dockingManager1.SetDockLabel(Panel5, "Servicios y Otros")
        dockingManager1.CloseEnabled = False

        dockingManager1.DockControlInAutoHideMode(Panel8, Syncfusion.Windows.Forms.Tools.DockingStyle.Right, 565)
        dockingManager1.SetDockLabel(Panel8, "Compras del proveedor")

        dockingManager1.SetDockVisibility(Panel5, False)

        '    ToolStripButton1.Image = ImageListAdv1.Images(1)

        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

        dgvCompra.TableDescriptor.Columns("pume").Width = 0
        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
        cboMoneda.SelectedValue = 1

        'confgiurando variables generales
        txtGlosa.Text = "Por la compra según " & "Nota de Crédito"
        txtIva.DoubleValue = TmpIGV / 100
        'lblPerido.Text = lblPerido.Text 
        txtTipoCambio.DecimalValue = TmpTipoCambio
        txtFecha.Value = New Date(CInt(AnioGeneral), CInt(MesGeneral), DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
        txtFecha.Select()
        txtPeriodoCompras.Value = New DateTime(AnioGeneral, MesGeneral, DateTime.Now.Day)
    End Sub


    Public Sub HIJOS(idservicio As Integer)
        Dim servicioSA As New servicioSA
        cboServicio.DisplayMember = "descripcion"
        cboServicio.ValueMember = "idServicio"
        cboServicio.DataSource = servicioSA.ListadoServiciosHijosXIdTipo(New servicio With {.codigo = "CM", .idPadre = idservicio})
    End Sub


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

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean



        parpadear = Not parpadear
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If TiempoRestante > 0 Then
            parpadeo()

            'lblAgregar.Visible = True
            'lblMensaje.Visible = True
            'tsSave.Enabled = False
            'lblMensaje.Text = "Agregar otro en: " & TiempoRestante
            TiempoRestante = TiempoRestante - 1
        ElseIf TiempoRestante = 0 Then
            Timer1.Enabled = False
            'lblEstado.ForeColor = Color.Navy
            'lblEstado.BackColor = Color.Transparent
            PanelError.Visible = False
            '      Dispose()
        Else
            Timer1.Enabled = False
            'Ejecuta tu función cuando termina el tiempo
            TiempoEjecutar(10)

        End If
    End Sub
    Private TiempoRestante As Integer
    Public Sub TimerOn(ByRef Interval As Short)
        If Interval > 0 Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If

    End Sub
    Public Function TiempoEjecutar(ByVal Tiempo As Integer)
        TiempoEjecutar = ""
        TiempoRestante = Tiempo  ' 1 minutos=60 segundos 
        Timer1.Interval = 400

        Call TimerOn(1000) ' Hechanos a andar el timer
    End Function
#End Region

#Region "CATEGORIA"
    Public Class Categoria

        Private _name As String
        Private _id As Integer
        Private _Utilidad As Decimal
        Private _UtilidadMayor As Decimal
        Private _UtilidadGranMayor As Decimal
        Public Sub New(ByVal name As String, ByVal id As Integer, ByVal utilidad As Decimal, utiMayor As Decimal, utiGranMayor As Decimal)
            _name = name
            _id = id
            _Utilidad = utilidad
            _UtilidadMayor = utiMayor
            _UtilidadGranMayor = utiGranMayor
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
                .descripcion = txtNewClasificacion.Text.Trim
                .fechaIngreso = DateTime.Now
                .utilidad = 0
                .utilidadmayor = 0
                .utilidadgranmayor = 0
                .usuarioActualizacion = usuario.IDUsuario
                .fechaActualizacion = DateTime.Now
            End With

            Dim codx As Integer = itemSA.SaveCategoria(item)
            'lstCategoria.Items.Add(New Categoria(txtNewClasificacion.Text.Trim, codx, 0, 0, 0))
            'Me.txtCategoria.Tag = CStr(codx)
            'txtCategoria.Text = txtNewClasificacion.Text.Trim
            'ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, 0, 0, 0)
            clasificacion()
        Catch ex As Exception
            lblEstado.Text = (ex.Message)
        End Try
    End Sub
#End Region

#Region "CESTO SERVICIOS"



#End Region

#Region "Métodos"
    Dim listaCategoria As New List(Of item)
    Private Sub CMBClasificacion()
        Dim categoriaSA As New itemSA
        'Dim objItem As New item With {.idItem = 0, .descripcion = "Seleccione un Item"}
        listaCategoria = New List(Of item)

        listaCategoria = categoriaSA.GetListaPadre()
        Label47.Text = listaCategoria.Count & " items"
    End Sub

    Sub clasificacion()
        Dim categoriaSA As New itemSA
        listaCategoria = New List(Of item)
        listaCategoria = categoriaSA.GetListaPadre()
        Label42.Text = listaCategoria.Count & " items"

    End Sub

    Private Sub ListaMercaderiasXIdHijo(iditem As Integer, tipo As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXIdHijo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, iditem, tipo)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(0)
            n.SubItems.Add(0)
            n.SubItems.Add(0)
            n.SubItems.Add(i.cuenta)
            n.SubItems.Add(i.presentacion)
            lsvListadoItems.Items.Add(n)
        Next

    End Sub

    Dim listaSubCategoria As New List(Of item)

    Sub Productoshijos()
        Dim categoriaSA As New itemSA
        listaSubCategoria = categoriaSA.GetListaMarcaPadre(Val(txtCategoria.Tag))
        Label28.Text = listaSubCategoria.Count & " items"
    End Sub

    Private Sub UbicarCompraXProveedorNroSerie(RucProveedor As String, strPeriodo As String)
        Dim documentoCompraSA As New DocumentoCompraSA
        Dim documentoCompra As New List(Of documentocompra)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable

        dt.Columns.Add("idDocumento", GetType(Integer))
        dt.Columns.Add("tipoCompra", GetType(String))
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("periodo", GetType(String))

        dt.Columns.Add("TipoDoc", GetType(String))
        dt.Columns.Add("Serie", GetType(String))
        dt.Columns.Add("Numero", GetType(String))
        dt.Columns.Add("moneda", GetType(String))
        dt.Columns.Add("montoMN", GetType(Decimal))
        dt.Columns.Add("montoME", GetType(Decimal))

        documentoCompra = documentoCompraSA.UbicarCompraPorProveedorXperiodo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, RucProveedor, strPeriodo)
        Dim str As String
        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
                Dim dr As DataRow = dt.NewRow()
                str = Nothing
                str = CDate(i.fechaDoc).ToString("dd-MMM hh:mm tt ")
                dr(0) = i.idDocumento
                dr(1) = i.tipoCompra
                dr(2) = str
                dr(3) = i.fechaContable
                dr(4) = tablaSA.GetUbicarTablaID(10, i.tipoDoc).descripcion.Substring(0, 3)
                dr(5) = i.serie
                dr(6) = i.numeroDoc
                Select Case i.monedaDoc
                    Case 1
                        dr(7) = "NAC"
                    Case Else
                        dr(7) = "EXT"
                End Select
                dr(8) = i.importeTotal
                dr(9) = i.importeUS
                dt.Rows.Add(dr)
            Next
            GridGroupingControl1.DataSource = dt

        Else

        End If
    End Sub

    Public Sub UbicarEntidadPorRuc(strNro As String)
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        entidad = entidadSA.UbicarEntidadPorRucNro(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strNro)
        If Not IsNothing(entidad) Then
            With entidad
                txtProveedor.Text = .nombreCompleto
                txtProveedor.Tag = .idEntidad
                '   txtCuenta.Text = .cuentaAsiento
                txtRuc.Text = .nrodoc
            End With
        Else
            txtProveedor.Clear()
            '  txtCuenta.Clear()
            txtRuc.Clear()
            If MessageBoxAdv.Show("Desea crear un nuevo proveedor?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                Dim f As New frmCrearENtidades
                f.CaptionLabels(0).Text = "Nuevo proveedor"
                f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                f.StartPosition = FormStartPosition.CenterParent
                f.ShowDialog()
            End If
        End If
    End Sub

    Public Sub UbicarDocumento(ByVal intIdDocumento As Integer)
        Dim objDoc As New DocumentoSA
        Dim objDocCompra As New DocumentoCompraSA
        Dim objDocCompraDet As New DocumentoCompraDetalleSA
        Dim objEntidad As New entidadSA
        Dim nEntidad As New entidad

        Dim documentoCajaDetalleSA As New DocumentoCajaDetalleSA
        Dim documentoCajaSA As New DocumentoCajaSA
        Dim objDocCaja As New DocumentoSA
        Dim establecSA As New establecimientoSA
        Dim inventarioBL As New inventarioMovimientoSA
        Dim DocumentoGuiaSA As New DocumentoGuiaDetalleSA
        Dim DocumentoGuia As New documentoguiaDetalle

        Try
            DocumentoGuia = DocumentoGuiaSA.UbicarGuiaDetallePorIdDocumentoPadreCAC(intIdDocumento)
            If Not IsNothing(DocumentoGuia) Then
                With DocumentoGuia
                    txtSerieGuia.Text = .Serie
                    txtNumeroGuia.Text = .Numero
                End With
            End If

            'CABECERA COMPROBANTE
            With objDocCompra.UbicarDocumentoCompra(intIdDocumento)
                If Not IsNothing(.fechaConstancia) Then
                    txtFecDetraccion.Value = .fechaConstancia
                End If
                txtNroConstancia.Text = .nroConstancia
                txtFecha.Value = .fechaDoc
                'lblIdDocumento.Text = .idDocumento
                lblPerido.Text = .fechaContable
                txtSerie.Text = .serie
                txtNumero.Text = .numeroDoc
                cboMoneda.SelectedValue = .monedaDoc

                Select Case cboMoneda.SelectedValue
                    Case 1

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

                        dgvCompra.TableDescriptor.Columns("pume").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0

                        cboMoneda.SelectedValue = 1
                        tb19.ToggleState = ToggleButton2.ToggleButtonState.ON
                    Case 2

                        dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                        dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
                        dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

                        dgvCompra.TableDescriptor.Columns("pume").Width = 60
                        dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                        dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                        dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                        dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                        cboMoneda.SelectedValue = 2
                        tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF
                End Select

                nEntidad = objEntidad.UbicarEntidadPorID(.idProveedor).First()
                txtRuc.Text = nEntidad.nrodoc
                txtProveedor.Tag = nEntidad.idEntidad
                txtProveedor.Text = nEntidad.nombreCompleto

                txtTipoCambio.DecimalValue = .tcDolLoc
                txtIva.DoubleValue = .tasaIgv
                txtGlosa.Text = .glosa
            End With

            'DETALLE DE LA COMPRA
            dgvCompra.Table.Records.DeleteAll()
            Panel2.Visible = False
            Panel5.Visible = False
            Panel8.Visible = False
            For Each i In objDocCompraDet.UbicarDocumentoCompraDetalle(intIdDocumento)

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", i.destino)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", i.idItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", i.descripcionItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("um", i.unidad1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", i.monto1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", i.montokardex)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", i.importe)

                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", i.montokardexUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", i.importeUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", i.montoIgv)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", i.montoIgvUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", i.tipoExistencia)
                Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", i.precioUnitario)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", i.precioUnitarioUS)
                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", i.unidad2)
                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", i.almacenRef)
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            Next
            ToolStripButton2.Enabled = False
            TotalTalesXcolumna()
        Catch ex As Exception
            MsgBox("No se pudo cargar la información." & vbCrLf & ex.Message)
        End Try

    End Sub

    Sub GuiaRemision(objDocumentoCompra As documento)
        Dim guiaRemisionBE As New documentoGuia
        Dim documentoguiaDetalle As New documentoguiaDetalle
        Dim ListaGuiaDetalle As New List(Of documentoguiaDetalle)
        'REGISTRANDO LA GUIA DE REMISION
        With guiaRemisionBE
            .idDocumento = 0
            .codigoLibro = "8"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .periodo = lblPerido.Text
            .tipoDoc = "99"
            .idEntidad = CInt(txtProveedor.Tag)
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIva.DoubleValue
            .tipoCambio = txtTipoCambio.DecimalValue
            .importeMN = TotalesXcanbeceras.TotalMN
            .importeME = TotalesXcanbeceras.TotalMN
            .glosa = txtGlosa.Text.Trim
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With
        objDocumentoCompra.documentoGuia = guiaRemisionBE

        For Each r As Record In dgvCompra.Table.Records

            If r.GetValue("tipoExistencia") <> "GS" Then
                If r.GetValue("almacen") <> idAlmacenVirtual Then
                    documentoguiaDetalle = New documentoguiaDetalle
                    If txtSerieGuia.Text.Trim.Length > 0 Then
                        'objDocumentoCompra.documentoGuia.serie = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                        objDocumentoCompra.documentoGuia.serie = txtSerieGuia.Text
                    Else
                        '   MessageBoxAdv.Show("Ingrese número de serie de la guía!")
                        Throw New Exception("Ingrese número de serie de la guía!")
                        '   Exit Sub
                    End If
                    If txtNumeroGuia.Text.Trim.Length > 0 Then
                        objDocumentoCompra.documentoGuia.numeroDoc = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))
                    Else
                        ' MessageBoxAdv.Show("Ingrese número de la guía!")
                        Throw New Exception("Ingrese el nùmero de la guía!")
                        '  Exit Sub
                    End If
                    documentoguiaDetalle.idDocumento = 0
                    documentoguiaDetalle.idItem = r.GetValue("idProducto")
                    documentoguiaDetalle.descripcionItem = r.GetValue("item")
                    documentoguiaDetalle.destino = r.GetValue("gravado")
                    documentoguiaDetalle.unidadMedida = r.GetValue("um")
                    documentoguiaDetalle.cantidad = CDec(r.GetValue("cantidad"))
                    documentoguiaDetalle.precioUnitario = CDec(r.GetValue("pumn"))
                    documentoguiaDetalle.precioUnitarioUS = CDec(r.GetValue("pume"))
                    documentoguiaDetalle.importeMN = CDec(r.GetValue("totalmn"))
                    documentoguiaDetalle.importeME = CDec(r.GetValue("totalme"))
                    documentoguiaDetalle.almacenRef = CInt(r.GetValue("almacen"))
                    documentoguiaDetalle.usuarioModificacion = "Jiuni"
                    documentoguiaDetalle.fechaModificacion = DateTime.Now
                    ListaGuiaDetalle.Add(documentoguiaDetalle)
                End If
            End If

        Next
        objDocumentoCompra.documentoGuia.documentoguiaDetalle = ListaGuiaDetalle
    End Sub

    Public Function AsientoCabeceraCompra(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        'ASIENTO POR LA COMPRA
        nAsiento = New asiento
        nAsiento.periodo = lblPerido.Text
        nAsiento.idDocumento = 0
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_Existencia
        nAsiento.importeMN = TotalesXcanbeceras.TotalMN
        nAsiento.importeME = TotalesXcanbeceras.TotalME
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function
    Dim cuentaMascaraSA As New cuentaMascaraSA
    Dim cuentaMascara As New cuentaMascara
    Public Sub AsientoCompra()
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoCabeceraCompra(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME) ' CABECERA ASIENTO

        '---------------------------------------------------------------------------------------------
        'DETALLE DEL ASIENTO DE COMPRA
        'MOVIMIENTOS
        For Each r As Record In dgvCompra.Table.Records

            '   If dgvCompra.Rows(i.Index).Cells(20).Value() <> Business.Entity.BaseBE.EntityAction.DELETE Then
            If r.GetValue("valBonif") <> "S" Then

                nMovimiento = New movimiento
                If Not r.GetValue("tipoExistencia") = "GS" Then
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, r.GetValue("tipoExistencia"), "ITEM", "COMPRA")
                    Select Case r.GetValue("tipoExistencia")
                        Case "08"
                            nMovimiento.cuenta = "33"
                        Case Else
                            Select Case cuentaMascara.parametro
                                Case "01"
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "03"
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "04"
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                                Case "05"
                                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                            End Select
                            '    nMovimiento.cuenta = dgvCompra.Rows(i.Index).Cells(22).Value()
                    End Select
                Else
                    nMovimiento.cuenta = r.GetValue("idProducto")
                End If

                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                Select Case TextBoxExt1.Tag
                    Case "03", "02"
                        nMovimiento.monto = CDec(r.GetValue("totalmn"))
                        nMovimiento.montoUSD = CDec(r.GetValue("totalme"))
                    Case Else
                        Select Case r.GetValue("gravado")
                            Case "1"
                                nMovimiento.monto = CDec(r.GetValue("vcmn"))
                                nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
                            Case Else
                                nMovimiento.monto = CDec(r.GetValue("totalmn"))
                                nMovimiento.montoUSD = CDec(r.GetValue("totalme"))
                        End Select

                End Select

                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                asientoTransitod.movimiento.Add(nMovimiento)


                If CDec(r.GetValue("percepcionMN")) > 0 Then
                    nMovimiento = New movimiento
                    nMovimiento.cuenta = "40113"
                    nMovimiento.descripcion = r.GetValue("item")
                    nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                    nMovimiento.monto = CDec(r.GetValue("percepcionMN"))
                    nMovimiento.montoUSD = CDec(r.GetValue("percepcionME"))
                    nMovimiento.fechaActualizacion = DateTime.Now
                    nMovimiento.usuarioActualizacion = usuario.IDUsuario
                    asientoTransitod.movimiento.Add(nMovimiento)
                End If

            End If
            '     End If
        Next

        asientoTransitod.movimiento.Add(AS_IGV(txtTotalIva.DecimalValue, Math.Round(txtTotalIva.DecimalValue / txtTipoCambio.DecimalValue, 2)))
        asientoTransitod.movimiento.Add(AS_Proveedor(TotalesXcanbeceras.TotalMN, TotalesXcanbeceras.TotalME))

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Public Function AS_Proveedor(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "PROV", "COMPRA")

        nMovimiento = New movimiento With {
              .cuenta = cuentaMascara.cuentaEspecifica,
              .descripcion = txtProveedor.Text,
              .tipo = ASIENTO_CONTABLE.UBICACION.HABER,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function AS_IGV(cMonto As Decimal, cMontoUS As Decimal) As movimiento
        Dim nMovimiento As New movimiento
        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "IGV", "COMPRA")
        nMovimiento = New movimiento With {
              .cuenta = cuentaMascara.cuentaEspecifica,
              .descripcion = "I.G.V.",
              .tipo = ASIENTO_CONTABLE.UBICACION.DEBE,
              .monto = cMonto,
              .montoUSD = cMontoUS,
              .fechaActualizacion = DateTime.Now,
              .usuarioActualizacion = usuario.IDUsuario}

        Return nMovimiento
    End Function

    Public Function ASBOF(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = txtProveedor.Tag
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.BONIFICACION
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Public Sub AsientoBONIF(r As Record)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = ASBOF(CDec(r.GetValue("vcmn")), CDec(r.GetValue("vcme"))) ' CABECERA ASIENTO
        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        If r.GetValue("almacen") = idAlmacenVirtual Then
            Select Case r.GetValue("tipoExistencia")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "CDS", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        Else
            Select Case r.GetValue("tipoExistencia")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ALM", "BONIF01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ALM", "BONIF03.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ALM", "BONIF04.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ALM", "BONIF05.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        End If

        nMovimiento.descripcion = r.GetValue("item")
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = CDec(r.GetValue("vcmn"))
        nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento

        'Select Case r.GetValue("tipoExistencia")
        '    Case "01"
        '        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ALM", "BONIF01.2")
        '        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '    Case "03"
        '        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ALM", "BONIF03.2")
        '        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '    Case "04"
        '        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ALM", "BONIF04.2")
        '        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        '    Case "05"
        '        cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ALM", "BONIF05.2")
        '        nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
        'End Select
        'End If

        nMovimiento.cuenta = "7311"
        nMovimiento.descripcion = "Bonif. obtenidas, descuentos rebajas-terceros"
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = CDec(r.GetValue("vcmn"))
        nMovimiento.montoUSD = CDec(r.GetValue("vcme"))
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub


    Public Sub GrabarMarca(iditem As Integer)

        Dim itemSA As New itemSA
        Dim item As New item
        Try
            With item
                .idEmpresa = Gempresas.IdEmpresaRuc
                .idEstablecimiento = GEstableciento.IdEstablecimiento
                '.idPadre = CboClasificacion.SelectedValue
                .idPadre = iditem
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
            Productoshijos()
            'Productoshijos2()
            'ListadoProductosPorCategoriaTipoExistencia(codx, cboTipoExistencia.SelectedValue, 0, 0, 0)
        Catch ex As Exception
            lblEstado.Text = (ex.Message)
        End Try
    End Sub

    Sub Grabar()
        Dim CompraSA As New DocumentoCompraSA
        Dim ndocumento As New documento()
        Dim DocCaja As New documento
        Dim almacenSA As New almacenSA

        Dim ListaTotales As New List(Of totalesAlmacen)

        Dim nDocumentoCompra As New documentocompra()
        Dim objDocumentoCompraDet As New documentocompradetalle
        Dim entidadSA As New entidadSA
        Dim entidad As New entidad

        Dim asientoSA As New AsientoSA
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento

        Dim ListaDetalle As New List(Of documentocompradetalle)

        Dim guiaRemisionBE As New documentoGuia
        Dim guiaREmisionDetaellBE As New documentoguiaDetalle

        Dim documentoTributo As New documento
        Dim listadoDePrecios As New List(Of listadoPrecios)

        '------------------------------------------ lista de Precio ------------------------------------
        Dim PreciosConIVABE As New listadoPrecios
        Dim PreciosSINIVABE As New listadoPrecios
        Dim listaPrecioSA As New ListadoPrecioSA

        Dim PrecioUnitarioMN As Decimal = 0.0

        ListaAsientonTransito = New List(Of asiento)
        With ndocumento
            .Action = Business.Entity.BaseBE.EntityAction.INSERT
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            If IsNothing(GProyectos) Then
            Else
                .idProyecto = GProyectos.IdProyectoActividad
            End If
            .tipoDoc = "07"
            .fechaProceso = txtFecha.Value
            .nroDoc = txtSerie.Text.Trim & "-" & txtNumero.Text.Trim
            .idOrden = Nothing ' Me.IdOrden
            .moneda = IIf(txtMon.Text = 1, "1", "2")
            .idEntidad = Val(txtProveedor.Tag)
            .entidad = txtProveedor.Text
            .tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            .nrodocEntidad = txtRuc.Text
            .tipoOperacion = "02"
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
        End With

        With nDocumentoCompra
            .tieneDetraccion = "N"
            '.TipoConfiguracion = GConfiguracion.TipoConfiguracion
            '.IdNumeracion = IIf(IsNothing(GConfiguracion.ConfigComprobante), 0, GConfiguracion.ConfigComprobante)
            .idPadre = IdCompraOrigen
            .codigoLibro = "8"
            .tipoDoc = "07"
            .idEmpresa = Gempresas.IdEmpresaRuc
            .idCentroCosto = GEstableciento.IdEstablecimiento
            .fechaDoc = txtFecha.Value
            .fechaContable = lblPerido.Text
            .fechaConstancia = txtFecDetraccion.Value
            .nroConstancia = txtNroConstancia.Text
            .serie = txtSerie.Text.Trim
            .numeroDoc = txtNumero.Text
            .idProveedor = CInt(txtProveedor.Tag)
            .nombreProveedor = txtProveedor.Text
            .monedaDoc = IIf(cboMoneda.SelectedValue = 1, "1", "2")
            .tasaIgv = txtIva.DoubleValue
            .tcDolLoc = txtTipoCambio.DecimalValue
            .tipoRecaudo = Nothing
            .regimen = Nothing
            .tasaRegimen = 0
            .nroRegimen = Nothing
            '****************** DESTINO EN SOLES ************************************************************************
            .bi01 = TotalesXcanbeceras.base1
            .bi02 = TotalesXcanbeceras.base2

            .igv01 = TotalesXcanbeceras.MontoIgv1
            .igv02 = TotalesXcanbeceras.MontoIgv2


            '****************** DESTINO EN DOLARES ************************************************************************
            .bi01us = TotalesXcanbeceras.base1me
            .bi02us = TotalesXcanbeceras.base2me

            .igv01us = TotalesXcanbeceras.MontoIgv1me
            .igv02us = TotalesXcanbeceras.MontoIgv2me

            '****************************************************************************************************************
            .importeTotal = TotalesXcanbeceras.TotalMN
            .importeUS = TotalesXcanbeceras.TotalME
            .destino = TIPO_COMPRA.BONIFICACIONES_RECIBIDAS
            .estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO
            .glosa = txtGlosa.Text.Trim
            .referenciaDestino = Nothing
            .tipoCompra = TIPO_COMPRA.BONIFICACIONES_RECIBIDAS
            .situacion = TIPO_SITUACION.ALMACEN_FISICO
            .usuarioActualizacion = usuario.IDUsuario
            .fechaActualizacion = DateTime.Now
            .aprobado = "N"
        End With
        ndocumento.documentocompra = nDocumentoCompra

        'REGISTRANDO LA GUIA DE REMISION
        GuiaRemision(ndocumento)

        'If CDec(txtTotalPagar.DecimalValue) > 0 Then
        '    AsientoCompra()
        'End If
        'ASIENTOS CONTABLES
        For Each r As Record In dgvCompra.Table.Records

            Select Case r.GetValue("tipoExistencia")

                Case "GS"

                Case Else
                    MV_Item_Transito(r)
            End Select

            objDocumentoCompraDet = New documentocompradetalle
            objDocumentoCompraDet.estadoPago = r.GetValue("valPago")
            objDocumentoCompraDet.TipoOperacion = "9917"
            objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
            objDocumentoCompraDet.IdEstablecimiento = GEstableciento.IdEstablecimiento
            objDocumentoCompraDet.tipoCompra = TIPO_COMPRA.BONIFICACIONES_RECIBIDAS
            objDocumentoCompraDet.FechaDoc = txtFecha.Value
            objDocumentoCompraDet.FechaLaboral = DiaLaboral
            objDocumentoCompraDet.CuentaProvedor = "4212" ' txtCuenta.Text.Trim
            objDocumentoCompraDet.NombreProveedor = txtProveedor.Text.Trim
            objDocumentoCompraDet.Serie = txtSerie.Text.Trim
            objDocumentoCompraDet.NumDoc = txtNumero.Text.Trim
            objDocumentoCompraDet.TipoDoc = "07"
            objDocumentoCompraDet.destino = r.GetValue("gravado")
            objDocumentoCompraDet.CuentaItem = Nothing
            objDocumentoCompraDet.idItem = r.GetValue("idProducto")
            objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoExistencia")
            objDocumentoCompraDet.descripcionItem = r.GetValue("item")

            If IsNumeric(r.GetValue("cantidad")) Then
                If CDec(r.GetValue("cantidad")) > 0 Then
                    objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad")) ' cantidad
                Else
                    If MessageBoxAdv.Show("Desea ingresar el item con cantidad cero?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        objDocumentoCompraDet.monto1 = 0
                    Else
                        lblEstado.Text = "Ingrese una cantidad mayor a cero del item, " & r.GetValue("item")
                        Timer1.Enabled = True
                        PanelError.Visible = True
                        TiempoEjecutar(10)
                        Exit Sub
                    End If
                End If
            Else
                lblEstado.Text = "Ingrese una cantidad válida del item, " & r.GetValue("item")
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If
            Select Case r.GetValue("tipoExistencia")
                Case "GS"
                    objDocumentoCompraDet.unidad1 = Nothing
                    objDocumentoCompraDet.unidad2 = Nothing
                    objDocumentoCompraDet.monto2 = Nothing
                    objDocumentoCompraDet.almacenRef = Nothing
                Case Else
                    objDocumentoCompraDet.unidad1 = r.GetValue("um")
                    objDocumentoCompraDet.unidad2 = r.GetValue("presentacion")  'IDPRESENTACION
                    objDocumentoCompraDet.monto2 = Nothing  ' PRESENTACION
                    objDocumentoCompraDet.almacenRef = CInt(r.GetValue("almacen"))
            End Select
            objDocumentoCompraDet.precioUnitario = CDec(r.GetValue("pumn"))
            objDocumentoCompraDet.precioUnitarioUS = CDec(r.GetValue("pume"))
            If IsNumeric(r.GetValue("totalmn")) Then
                If CDec(r.GetValue("totalmn")) > 0 Then
                    objDocumentoCompraDet.importe = CDec(r.GetValue("totalmn"))
                Else
                    lblEstado.Text = "Ingrese un importe mayor a cero del item, " & r.GetValue("item")
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)
                    Exit Sub
                End If
            Else
                lblEstado.Text = "Ingrese un importe válido del item, " & r.GetValue("item")
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
                Exit Sub
            End If


            objDocumentoCompraDet.importeUS = CDec(r.GetValue("totalme"))

            objDocumentoCompraDet.montokardex = CDec(r.GetValue("vcmn"))
            objDocumentoCompraDet.montoIsc = 0 ' CDec(i.Cells(13).Value())
            objDocumentoCompraDet.montoIgv = 0 ' CDec(r.GetValue("igvmn"))
            objDocumentoCompraDet.otrosTributos = 0 ' CDec(i.Cells(15).Value())
            '**********************************************************************************
            objDocumentoCompraDet.montokardexUS = CDec(r.GetValue("vcme"))
            objDocumentoCompraDet.montoIscUS = 0
            objDocumentoCompraDet.montoIgvUS = 0 'CDec(r.GetValue("igvme"))
            objDocumentoCompraDet.otrosTributosUS = 0
            objDocumentoCompraDet.preEvento = Nothing  '= "00", Nothing, dgvCompra.Rows(S).Cells(23).Value())
            objDocumentoCompraDet.bonificacion = r.GetValue("valBonif")

            objDocumentoCompraDet.percepcionMN = CDec(r.GetValue("percepcionMN"))
            objDocumentoCompraDet.percepcionME = CDec(r.GetValue("percepcionME"))
            '**********************************************************************************
            objDocumentoCompraDet.fechaModificacion = DateTime.Now
            objDocumentoCompraDet.FechaVcto = Nothing ' IIf(IsNothing(dgvCompra.Rows(S).Cells(28).Value()), Nothing, CDate(dgvCompra.Rows(S).Cells(28).Value()))
            objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
            Dim s = r.GetValue("almacen")
            If s.ToString.Trim.Length > 0 Then
                If r.GetValue("almacen") = idAlmacenVirtual Then
                    objDocumentoCompraDet.situacion = TIPO_SITUACION.ALMACEN_TRANSITO
                    objDocumentoCompraDet.entregable = "NO"
                Else
                    objDocumentoCompraDet.situacion = TIPO_SITUACION.ALMACEN_FISICO
                    objDocumentoCompraDet.entregable = "SI"
                End If
            End If
            objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario

            Dim marcaVal = IIf(IsDBNull(r.GetValue("marca")), Nothing, r.GetValue("marca"))
            objDocumentoCompraDet.marcaRef = marcaVal

            objDocumentoCompraDet.categoria = (r.GetValue("cat"))

            ListaDetalle.Add(objDocumentoCompraDet)

        Next
        ndocumento.documentocompra.estadoPago = TIPO_COMPRA.PAGO.PENDIENTE_PAGO

        ndocumento.asiento = ListaAsientonTransito
        ndocumento.documentocompra.documentocompradetalle = ListaDetalle
        'TOTALES ALMACEN
        ListaTotales = ListaTotalesAlmacen()
        Dim xcod As Integer = CompraSA.GrabarBonificaciones(ndocumento, ListaTotales)
        lblEstado.Text = "compra registrada!"
        Dispose()
    End Sub

    Private Function ListaTotalesAlmacen() As List(Of totalesAlmacen)
        Dim objTotalesDet As New totalesAlmacen
        Dim ListaTotales As New List(Of totalesAlmacen)
        Dim almacenSA As New almacenSA

        For Each r As Record In dgvCompra.Table.Records
            If Not r.GetValue("tipoExistencia") = "GS" Then
                'If r.GetValue("almacen") <> idAlmacenVirtual Then
                objTotalesDet = New totalesAlmacen
                objTotalesDet.Action = Business.Entity.BaseBE.EntityAction.INSERT
                objTotalesDet.SecuenciaDetalle = 0
                objTotalesDet.idEmpresa = Gempresas.IdEmpresaRuc
                objTotalesDet.Modulo = "N"
                'With almacenSA.GetUbicar_almacenPorID(CInt(r.GetValue("almacen")))
                objTotalesDet.idEstablecimiento = GEstableciento.IdEstablecimiento
                objTotalesDet.idAlmacen = CInt(r.GetValue("almacen"))
                'End With
                objTotalesDet.origenRecaudo = r.GetValue("gravado")
                objTotalesDet.tipoCambio = txtTipoCambio.DecimalValue
                objTotalesDet.tipoExistencia = r.GetValue("tipoExistencia")
                objTotalesDet.idItem = r.GetValue("idProducto")
                objTotalesDet.descripcion = r.GetValue("item")
                objTotalesDet.idUnidad = r.GetValue("um")
                objTotalesDet.unidadMedida = Nothing
                objTotalesDet.cantidad = CType(r.GetValue("cantidad"), Decimal)
                objTotalesDet.precioUnitarioCompra = CType(r.GetValue("pumn"), Decimal)

                objTotalesDet.importeSoles = CType(r.GetValue("vcmn"), Decimal)
                objTotalesDet.importeDolares = CType(r.GetValue("vcme"), Decimal)


                objTotalesDet.montoIsc = 0
                objTotalesDet.montoIscUS = 0
                objTotalesDet.Otros = 0
                objTotalesDet.OtrosUS = 0
                objTotalesDet.porcentajeUtilidad = 0
                objTotalesDet.importePorcentaje = 0
                objTotalesDet.importePorcentajeUS = 0
                objTotalesDet.precioVenta = 0
                objTotalesDet.precioVentaUS = 0
                objTotalesDet.usuarioActualizacion = usuario.IDUsuario
                objTotalesDet.fechaActualizacion = Date.Now
                ListaTotales.Add(objTotalesDet)
                'End If
            End If
        Next

        Return ListaTotales
    End Function

    Public Function AsientoTransito(cMonto As Decimal, cMontoUS As Decimal) As asiento
        Dim nAsiento As New asiento
        nAsiento = New asiento
        nAsiento.idDocumento = 0
        nAsiento.periodo = lblPerido.Text
        nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
        nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
        nAsiento.idEntidad = CInt(txtProveedor.Tag)
        nAsiento.nombreEntidad = txtProveedor.Text
        nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
        nAsiento.fechaProceso = txtFecha.Value
        nAsiento.codigoLibro = "8"
        nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
        nAsiento.tipoAsiento = ASIENTO_CONTABLE.PRODUCTOS_EN_TRANSITO
        nAsiento.importeMN = cMonto
        nAsiento.importeME = cMontoUS
        nAsiento.glosa = txtGlosa.Text.Trim
        nAsiento.usuarioActualizacion = usuario.IDUsuario
        nAsiento.fechaActualizacion = DateTime.Now
        Return nAsiento
    End Function

    Private Sub AsientoItemPagado()
        Dim nAsiento As New asiento
        Dim nMovimiento As New movimiento
        Dim cajaSa As New EstadosFinancierosSA
        Try
            nAsiento = New asiento
            nAsiento.periodo = lblPerido.Text
            nAsiento.idDocumento = 0
            nAsiento.idEmpresa = Gempresas.IdEmpresaRuc
            nAsiento.idCentroCostos = GEstableciento.IdEstablecimiento
            nAsiento.idEntidad = CInt(txtProveedor.Tag)
            nAsiento.nombreEntidad = txtProveedor.Text
            nAsiento.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR
            nAsiento.fechaProceso = txtFecha.Value
            nAsiento.codigoLibro = "8"
            nAsiento.tipo = ASIENTO_CONTABLE.HABILITADO.DISABLED
            nAsiento.tipoAsiento = ASIENTO_CONTABLE.Compra_Existencia
            nAsiento.importeMN = TotalesXcanbeceras.TotalMN
            nAsiento.importeME = TotalesXcanbeceras.TotalME
            nAsiento.glosa = txtGlosa.Text.Trim
            nAsiento.usuarioActualizacion = usuario.IDUsuario
            nAsiento.fechaActualizacion = DateTime.Now

            For Each r As Record In dgvCompra.Table.Records
                nMovimiento = New movimiento
                nMovimiento.cuenta = "4212"
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.movimiento.Add(nMovimiento)

                nMovimiento = New movimiento
                nMovimiento.cuenta = cajaSa.GetUbicar_estadosFinancierosPorID(GFichaUsuarios.IdCajaDestino).cuenta
                nMovimiento.descripcion = r.GetValue("item")
                nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
                nMovimiento.monto = r.GetValue("totalmn")
                nMovimiento.montoUSD = r.GetValue("totalme")
                nMovimiento.fechaActualizacion = DateTime.Now
                nMovimiento.usuarioActualizacion = usuario.IDUsuario
                nAsiento.movimiento.Add(nMovimiento)

            Next
            ListaAsientonTransito.Add(nAsiento)
        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try

    End Sub

    Public Sub MV_Item_Transito(i As Record)
        Dim asientoTransitod As New asiento
        Dim mascaraSA As New mascaraContable2SA
        Dim mascaraExistenciasSA As New mascaraContableExistenciaSA
        Dim nMovimiento As New movimiento

        asientoTransitod = AsientoTransito(CDec(i.GetValue("vcmn")), CDec(i.GetValue("vcme"))) ' CABECERA ASIENTO

        'MOVIMIENTOS -1 cuenta 20
        nMovimiento = New movimiento
        If i.GetValue("almacen") = idAlmacenVirtual Then
            Select Case i.GetValue("tipoExistencia")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "EXT01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "EXT03.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "EXT04.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "EXT05.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select
        Else
            Select Case i.GetValue("tipoExistencia")
                Case "01"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "01", "ITEM", "ALM01.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "03"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "03", "ITEM", "ALM03.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "04"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "04", "ITEM", "ALM04.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
                Case "05"
                    cuentaMascara = cuentaMascaraSA.UbicarCuentaXmoduloXitem(Gempresas.IdEmpresaRuc, "05", "ITEM", "ALM05.1")
                    nMovimiento.cuenta = cuentaMascara.cuentaEspecifica
            End Select

        End If

        nMovimiento.descripcion = i.GetValue("item")
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.DEBE
        nMovimiento.monto = i.GetValue("vcmn")
        nMovimiento.montoUSD = i.GetValue("vcme")
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        'MOVIMIENTOS - 2 cuenta 28
        nMovimiento = New movimiento
        nMovimiento.cuenta = "7311"
        nMovimiento.descripcion = i.GetValue("item")
        nMovimiento.tipo = ASIENTO_CONTABLE.UBICACION.HABER
        nMovimiento.monto = i.GetValue("vcmn")
        nMovimiento.montoUSD = i.GetValue("vcme")
        nMovimiento.fechaActualizacion = DateTime.Now
        nMovimiento.usuarioActualizacion = usuario.IDUsuario
        asientoTransitod.movimiento.Add(nMovimiento)

        ListaAsientonTransito.Add(asientoTransitod)
    End Sub

    Sub TotalTalesXcolumna()
        Dim totalVC As Decimal = 0
        Dim totalVCme As Decimal = 0

        Dim totalIVA As Decimal = 0
        Dim totalIVAme As Decimal = 0

        Dim totalDesc As Decimal = 0
        Dim totalDescme As Decimal = 0

        Dim total As Decimal = 0
        Dim totalme As Decimal = 0

        Dim bs1 As Decimal = 0
        Dim bs1me As Decimal = 0
        Dim bs2 As Decimal = 0
        Dim bs2me As Decimal = 0
        Dim igv1 As Decimal = 0
        Dim igv1me As Decimal = 0
        Dim igv2 As Decimal = 0
        Dim igv2me As Decimal = 0

        For Each r As Record In dgvCompra.Table.Records


            totalVC += CDec(r.GetValue("vcmn"))
            totalVCme += CDec(r.GetValue("vcme"))

            totalIVA += CDec(r.GetValue("igvmn"))
            totalIVAme += CDec(r.GetValue("igvme"))

            total += CDec(r.GetValue("totalmn"))
            totalme += CDec(r.GetValue("totalme"))

            Select Case r.GetValue("gravado")
                Case "1"
                    bs1 += CDec(r.GetValue("vcmn"))
                    bs1me += CDec(r.GetValue("vcme"))

                    igv1 += CDec(r.GetValue("igvmn"))
                    igv1me += CDec(r.GetValue("igvme"))
                Case "2"
                    bs2 += CDec(r.GetValue("vcmn"))
                    bs2me += CDec(r.GetValue("vcme"))

                    igv2 += CDec(r.GetValue("igvmn"))
                    igv2me += CDec(r.GetValue("igvme"))
            End Select




        Next

        TotalesXcanbeceras = New TotalesXcanbecera()

        TotalesXcanbeceras.BaseMN = totalVC
        TotalesXcanbeceras.BaseME = totalVCme

        TotalesXcanbeceras.IgvMN = totalIVA
        TotalesXcanbeceras.IgvME = totalIVAme

        TotalesXcanbeceras.TotalMN = total
        TotalesXcanbeceras.TotalME = totalme

        TotalesXcanbeceras.base1 = bs1
        TotalesXcanbeceras.base1me = bs1me
        TotalesXcanbeceras.base2 = bs2
        TotalesXcanbeceras.base2me = bs2me

        TotalesXcanbeceras.MontoIgv1 = igv1
        TotalesXcanbeceras.MontoIgv1me = igv1me
        TotalesXcanbeceras.MontoIgv2 = igv2
        TotalesXcanbeceras.MontoIgv2me = igv2me

        '****************************************************
        If cboMoneda.SelectedValue = 1 Then
            txtBonifica.DecimalValue = totalDesc
            txtTotalBase.DecimalValue = totalVC
            txtTotalIva.DecimalValue = totalIVA
            txtTotalPagar.DecimalValue = total
        Else

            txtBonifica.DecimalValue = totalDescme
            txtTotalBase.DecimalValue = totalVCme
            txtTotalIva.DecimalValue = totalIVAme
            txtTotalPagar.DecimalValue = totalme

        End If

    End Sub

    Private Sub ListaMercaderias(strTipoEx As String, strBusqueda As String)
        Dim existenciaSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        For Each i In existenciaSA.GetUbicarProductoXdescripcion2(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, Nothing, strTipoEx, strBusqueda)
            Dim n As New ListViewItem(i.codigodetalle)
            n.SubItems.Add(i.descripcionItem)
            n.SubItems.Add(i.unidad1)
            n.SubItems.Add(i.tipoExistencia)
            n.SubItems.Add(0)
            n.SubItems.Add(0)
            n.SubItems.Add(0)
            n.SubItems.Add(i.cuenta)
            n.SubItems.Add(i.presentacion)
            lsvListadoItems.Items.Add(n)
        Next

    End Sub

    Private Sub ListadoProductosPorCategoriaTipoExistencia(strCategoria As Integer, strTipoExistencia As String, intUtilidad As Decimal, utiMayor As Decimal, utiGranMayor As Decimal)
        Dim itemSA As New detalleitemsSA
        lsvListadoItems.Items.Clear()
        Try
            For Each i In itemSA.GetUbicarDetalleItemTipoExistencia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, strCategoria, strTipoExistencia)
                Dim n As New ListViewItem(i.codigodetalle)
                n.SubItems.Add(i.descripcionItem)
                n.SubItems.Add(i.unidad1)
                n.SubItems.Add(i.tipoExistencia)
                n.SubItems.Add(intUtilidad)
                n.SubItems.Add(utiMayor)
                n.SubItems.Add(utiGranMayor)
                n.SubItems.Add(i.cuenta)
                lsvListadoItems.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Loadcontroles()
        '  Dim entidadSA As New entidadSA
        Dim tablaSA As New tablaDetalleSA
        Dim listatabla As New List(Of tabladetalle)
        Dim categoriaSA As New itemSA
        Dim servicioSA As New servicioSA
        Dim efSA As New EstadosFinancierosSA

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
        listatabla = New List(Of tabladetalle)
        listatabla = tablaSA.GetListaTablaDetalle(5, "1")
        Dim listaNoExistencias As New List(Of String)
        listaNoExistencias.Add("06")
        listaNoExistencias.Add("07")
        listaNoExistencias.Add("08")
        listaNoExistencias.Add("02")

        Dim consultaExistencia = (From n In listatabla _
                                 Where Not listaNoExistencias.Contains(n.codigoDetalle)).ToList

        cboTipoExistencia.DisplayMember = "descripcion"
        cboTipoExistencia.ValueMember = "codigoDetalle"
        cboTipoExistencia.DataSource = consultaExistencia

        'cboServicioPadre.DisplayMember = "descripcion"
        'cboServicioPadre.ValueMember = "idServicio"
        'cboServicioPadre.DataSource = servicioSA.ListadoServiciosPadre

        txtBuscarProducto.Visible = True
        btnNuevoProd.Visible = True

        Label16.Text = "Buscar item"
        txtCategoria.Visible = False
        PictureBox2.Visible = False
        Label47.Visible = False
        Label28.Visible = False

        Label35.Visible = False
        txtSubCategoria.Visible = False
        PictureBox6.Visible = False

        TextBoxExt3.Visible = True

    End Sub

    Public Sub CargarEntidadesXtipo(strTipo As String, strBusqueda As String)
        Dim entidadSA As New entidadSA
        Try

            'Me.lstEntidades.DataSource = entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, strTipo, strBusqueda)
            'Me.lstEntidades.DisplayMember = "nombreCompleto"
            'Me.lstEntidades.ValueMember = "idEntidad"
            lsvProveedor.Items.Clear()
            For Each i As entidad In entidadSA.BuscarEntidadXdescripcion(Gempresas.IdEmpresaRuc, TIPO_ENTIDAD.PROVEEDOR, strBusqueda)
                Dim n As New ListViewItem(i.idEntidad)
                n.SubItems.Add(i.nombreCompleto)
                n.SubItems.Add(i.cuentaAsiento)
                n.SubItems.Add(i.nrodoc)
                lsvProveedor.Items.Add(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetTableAlmacen() As DataTable
        Dim almacenSA As New almacenSA
        Dim dt As New DataTable()
        dt.Columns.Add("idAlmacen", GetType(Integer))
        dt.Columns.Add("descripcionAlmacen", GetType(String))

        If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then

            For Each i In almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idAlmacen
                dr(1) = i.descripcionAlmacen
                dt.Rows.Add(dr)
            Next

        Else
            For Each i In almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})

                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idAlmacen
                dr(1) = i.descripcionAlmacen
                dt.Rows.Add(dr)
            Next
        End If
        Return dt
    End Function

    Public Function GetTableCombos() As DataTable
        Dim almacenSA As New almacenSA
        Dim dt As New DataTable()
        dt.Columns.Add("id", GetType(String))
        dt.Columns.Add("name", GetType(String))
        Dim dr As DataRow = dt.NewRow()
        dr(0) = "1"
        dr(1) = "SI"
        dt.Rows.Add(dr)

        Dim dr2 As DataRow = dt.NewRow()
        dr2(0) = "2"
        dr2(1) = "NO"
        dt.Rows.Add(dr2)

        Return dt
    End Function

#End Region
    Dim comboTable As New DataTable

    Private Sub frmNotaCreditoBonificaciones_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub frmNotaCreditoBonificaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboTable = Me.GetTableAlmacen
        Dim ggcStyle As GridTableCellStyleInfo = dgvCompra.TableDescriptor.Columns(14).Appearance.AnyRecordFieldCell
        ggcStyle.CellType = "ComboBox"
        ggcStyle.DataSource = Me.comboTable
        ggcStyle.ValueMember = "idAlmacen"
        ggcStyle.DisplayMember = "descripcionAlmacen"
        ggcStyle.DropDownStyle = GridDropDownStyle.Exclusive
        dgvCompra.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell
        dgvCompra.ShowRowHeaders = False
    End Sub

    Private Sub TextBoxExt2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.Alt Then
            If e.KeyCode = Keys.Down Then
                If Not Me.popupControlContainer1.IsShowing() Then
                    ' Let the popup align around the source textBox.
                    Me.popupControlContainer1.ParentControl = Me.txtProveedor
                    ' Passing Point.Empty will align it automatically around the above ParentControl.
                    Me.popupControlContainer1.ShowPopup(Point.Empty)

                    e.Handled = True
                End If
            End If
        End If
        '' Escape should close the popup.
        If e.KeyCode = Keys.Escape Then
            If Me.popupControlContainer1.IsShowing() Then
                Me.popupControlContainer1.HidePopup(PopupCloseType.Canceled)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtProveedor.Text.Trim.Length > 0 Then
                Me.popupControlContainer1.ParentControl = Me.txtProveedor
                Me.popupControlContainer1.ShowPopup(Point.Empty)
                CargarEntidadesXtipo(TIPO_ENTIDAD.PROVEEDOR, txtProveedor.Text.Trim)
            End If
        End If
    End Sub

    Private Sub TextBoxExt2_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

    Private Sub popupControlContainer1_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles popupControlContainer1.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvProveedor.SelectedItems.Count > 0 Then
                Me.txtProveedor.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                txtProveedor.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                txtRuc.Text = lsvProveedor.SelectedItems(0).SubItems(3).Text
                ' txtCuenta.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text

                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por bonificaciones según " & "Nota de Crédito" & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                End If

                'Dim strPeriodo As String = String.Format("{0:00}", CInt(txtPeriodoCompras.Value.Month))
                'strPeriodo = String.Concat(strPeriodo, "/", txtPeriodoCompras.Value.Year)


                'UbicarCompraXProveedorNroSerie(txtRuc.Text, strPeriodo)

                txtSerieGuia.Select()
                txtSerieGuia.SelectAll()
            End If
        End If
        ' Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtProveedor.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub


    Private Sub UbicarCompraDetalle(idDocumento As Integer)
        Dim documentoCompraSA As New DocumentoCompraDetalleSA
        Dim documentoCompra As New List(Of documentocompradetalle)
        Dim tablaSA As New tablaDetalleSA
        Dim dt As New DataTable
        dt.Columns.Add("idItem", GetType(String))
        dt.Columns.Add("descripcion", GetType(String))
        dt.Columns.Add("tipoexistencia", GetType(String))
        dt.Columns.Add("unidad", GetType(String))

        dt.Columns.Add("monto", GetType(Decimal))
        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("importemn", GetType(Decimal))
        dt.Columns.Add("importeme", GetType(Decimal))

        documentoCompra = documentoCompraSA.UbicarDocumentoCompraDetalle(idDocumento)

        If Not IsNothing(documentoCompra) Then
            For Each i In documentoCompra
                Dim dr As DataRow = dt.NewRow()
                dr(0) = i.idItem
                dr(1) = i.descripcionItem
                'dr(2) = i.tipoExistencia
                dr(2) = tablaSA.GetUbicarTablaID(5, i.tipoExistencia).descripcion
                'dr(3) = i.unidad1
                dr(3) = tablaSA.GetUbicarTablaID(6, i.unidad1).descripcion.Substring(0, 3)
                'dr(4) = tablaSA.GetUbicarTablaID(10, i.TipoDoc).descripcion.Substring(0, 3)
                dr(4) = i.monto1
                dr(5) = i.precioUnitario
                dr(6) = i.precioUnitarioUS
                dr(7) = i.importe
                dr(8) = i.importeUS
                '
                dt.Rows.Add(dr)
            Next
            dgvCompraDetalle.DataSource = dt

        Else

        End If
    End Sub


    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            Me.popupControlContainer1.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        PanelError.Visible = False
        Timer1.Enabled = False
    End Sub

    Private Sub txtSerie_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerie.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por bonificaciones según " & "Nota de Crédito" & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                End If
                txtNumero.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerie.Clear()
        End Try
    End Sub

    Private Sub txtSerie_LostFocus(sender As Object, e As EventArgs) Handles txtSerie.LostFocus
        Try
            If txtSerie.Text.Trim.Length > 0 Then
                '  If chFormato.Checked = True Then
                txtSerie.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerie.Text))
                'End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerie.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1)) = True Then

                        If Len(txtSerie.Text) <= 2 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 1))

                        ElseIf Len(txtSerie.Text) <= 3 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 2))

                        ElseIf Len(txtSerie.Text) <= 4 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 3))

                        ElseIf Len(txtSerie.Text) <= 5 Then

                            txtSerie.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerie.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerie.Text), 4))

                        End If
                    End If
                Else

                    txtSerie.Select()
                    txtSerie.Focus()
                    txtSerie.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

            Else

                txtSerie.Select()
                txtSerie.Focus()
                txtSerie.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        End Try

        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
            txtGlosa.Text = "Por bonificaciones según " & "Nota de Crédito" & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
        End If

    End Sub

    Private Sub txtNumero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumero.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
                    txtGlosa.Text = "Por bonificaciones según " & "Nota de Crédito" & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
                End If
                'cboMoneda.Select()
                txtProveedor.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumero.Clear()
        End Try

    End Sub

    Private Sub txtNumero_LostFocus(sender As Object, e As EventArgs) Handles txtNumero.LostFocus
        Try
            If txtNumero.Text.Trim.Length > 0 Then
                '    If chFormato.Checked = True Then
                txtNumero.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumero.Text))

                'End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumero.Select()
            txtNumero.Focus()
            txtNumero.Clear()
            lblEstado.Text = "Error de formato verifiuqe el ingreso!"
        End Try

        If txtSerie.Text.Trim.Length > 0 AndAlso txtNumero.Text.Trim.Length > 0 AndAlso txtProveedor.Text.Trim.Length > 0 Then
            txtGlosa.Text = "Por bonificaciones según " & "Nota de Crédito" & Space(1) & "Nro. " & txtSerie.Text.Trim & "-" & txtNumero.Text.Trim & Space(1) & "del proveedor " & txtProveedor.Text.Trim
        End If
    End Sub

    Private Sub PopupControlContainer2_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles PopupControlContainer2.BeforePopup
        Me.PopupControlContainer2.BackColor = Color.White
    End Sub

    Private Sub lstCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lstCategoria.MouseDoubleClick
        If lstCategoria.SelectedItems.Count > 0 Then
            Me.PopupControlContainer2.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        'If txtCategoria.Text.Trim.Length > 0 Then
        '    ListadoProductosPorCategoriaTipoExistencia(txtCategoria.Tag, cboTipoExistencia.SelectedValue, txtCategoria.Tag, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
        'End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboTipoExistencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTipoExistencia.SelectedIndexChanged
        'If cboTipoExistencia.SelectedIndex > -1 Then
        '    If txtCategoria.Text.Trim.Length > 0 Then
        '        ListadoProductosPorCategoriaTipoExistencia(txtCategoria.Tag, cboTipoExistencia.SelectedValue, txtCategoria.Tag, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadMayor, DirectCast(Me.lstCategoria.SelectedItem, Categoria).UtilidadGranMayor)
        '    End If
        'End If
    End Sub

    Private Sub pcClasificacion_BeforePopup(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles pcClasificacion.BeforePopup
        Me.pcClasificacion.BackColor = Color.White
    End Sub

    Private Sub txtBuscarProducto_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBuscarProducto.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            ListaMercaderias(cboTipoExistencia.SelectedValue, txtBuscarProducto.Text.Trim)
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        Dim entidadSA As New entidadSA
        Dim cajaSA As New EstadosFinancierosSA
        Dim almacenSA As New almacenSA
        Dim itemSA As New itemSA
        If lsvListadoItems.SelectedItems.Count > 0 Then
            Dim selFila As ListViewItem = lsvListadoItems.SelectedItems(0)

            With objInsumo.InvocarProductoID(CInt(selFila.SubItems(0).Text))

                Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
                Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", .codigodetalle)
                Me.dgvCompra.Table.CurrentRecord.SetValue("item", .descripcionItem)
                Me.dgvCompra.Table.CurrentRecord.SetValue("um", .unidad1)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

                Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
                ' Me.dgvCompra.Table.CurrentRecord.SetValue("marca", .marcaRef)
                'Dim imItem = .idItem
                'dgdfg()
                Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

                Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
                Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                If .tipoExistencia <> "GS" Then
                    Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen)
                    'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
                End If
                Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", .presentacion)

                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

                'Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)
                ' Me.dgvCompra.Table.CurrentRecord.SetValue("cat", itemSA.UbicarCategoriaPorID(.idItem).idPadre)
                Me.dgvCompra.Table.CurrentRecord.SetValue("cat", 0)
                Me.dgvCompra.Table.AddNewRecord.EndEdit()
            End With
        End If
    End Sub
    Sub GetTableGrid()
        Dim dt As New DataTable()

        dt.Columns.Add("codigo", GetType(String))
        dt.Columns.Add("gravado", GetType(String))
        dt.Columns.Add("idProducto", GetType(Integer))
        dt.Columns.Add("item", GetType(String))
        dt.Columns.Add("um", GetType(String))
        dt.Columns.Add("cantidad", GetType(Decimal))
        dt.Columns.Add("vcmn", GetType(Decimal))
        dt.Columns.Add("pcmn", GetType(Decimal))
        dt.Columns.Add("totalmn", GetType(Decimal))
        dt.Columns.Add("vcme", GetType(Decimal))
        dt.Columns.Add("pcme", GetType(Decimal))
        dt.Columns.Add("totalme", GetType(Decimal))
        dt.Columns.Add("igvmn", GetType(Decimal))
        dt.Columns.Add("igvme", GetType(Decimal))

        dt.Columns.Add("tipoExistencia", GetType(String))
        dt.Columns.Add("marca", GetType(String))
        dt.Columns.Add("almacen", GetType(String))
        dt.Columns.Add("caja", GetType(String))

        dt.Columns.Add("pumn", GetType(Decimal))
        dt.Columns.Add("pume", GetType(Decimal))
        dt.Columns.Add("chPago", GetType(Boolean))
        dt.Columns.Add("valPago", GetType(String))

        dt.Columns.Add("chBonif", GetType(Boolean))
        dt.Columns.Add("valBonif", GetType(String))
        dt.Columns.Add("presentacion", GetType(String))

        dt.Columns.Add("percepcionMN", GetType(Decimal))
        dt.Columns.Add("percepcionME", GetType(Decimal))
        dt.Columns.Add("cat", GetType(Integer))
        dgvCompra.DataSource = dt
    End Sub

    Private Sub btnNuevoProd_Click(sender As Object, e As EventArgs) Handles btnNuevoProd.Click

        'If cboProductos.Text.Trim.Length > 0 Then

        Dim almacenSA As New almacenSA
        Dim objInsumo As New detalleitemsSA
        Dim tablaSA As New tablaDetalleSA
        Dim catSA As New itemSA
        Dim cat As New item
        Dim ITEMSA As New itemSA
        Me.Cursor = Cursors.WaitCursor
        Dim datos As List(Of RecuperarCarteras) = RecuperarCarteras.Instance()
        datos.Clear()
        'If txtCategoria.Text.Trim.Length > 0 Then
        'If Not IsNothing(txtCategoria.Tag) Then
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                ' .cboIgv.Enabled = False
                ' .cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboTipoExistencia.Enabled = False
                .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                .UCNuenExistencia.cboUnidades.Enabled = True
            Else

            End If

            .UCNuenExistencia.cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue
            '.txtCategoria.Tag = txtCategoria.Tag
            '.txtCategoria.Text = txtCategoria.Text
            ' .CboClasificacion.SelectedValue = CboClasificacion.SelectedValue
            '.cboProductos.SelectedValue = cboProductos.SelectedValue
            '  .cboTipoExistencia.SelectedValue = cboTipoExistencia.SelectedValue

            ' .cboTipoExistencia.Text = cboTipoExistencia.Text
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            If datos.Count > 0 Then
                If MessageBoxAdv.Show("Desea agregar el producto a la canasta de compras?", "tención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    If datos(0).Cuenta = "Grabado" Then
                        '  If lsvListadoItems.SelectedItems.Count > 0 Then

                        With objInsumo.InvocarProductoID(CInt(datos(0).ID))
                            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
                            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
                            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", .origenProducto)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", .codigodetalle)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("item", .descripcionItem)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("um", .unidad1)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

                            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", .tipoExistencia)
                            'Me.dgvCompra.Table.CurrentRecord.SetValue("marca", .marcaRef)
                            Dim imItem = .idItem
                            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", CStr(imItem))

                            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

                            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
                            If .tipoExistencia <> "GS" Then
                                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", almacenSA.GetUbicar_almacenVirtual(GEstableciento.IdEstablecimiento).idAlmacen)
                                'Me.dgvCompra.Table.CurrentRecord.SetValue("caja", 0)
                            End If
                            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", .presentacion)

                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
                            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

                            'Me.dgvCompra.Table.CurrentRecord.SetValue("cat", .idItem)
                            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", ITEMSA.UbicarCategoriaPorID(.idItem).idPadre)
                            Me.dgvCompra.Table.AddNewRecord.EndEdit()
                        End With
                        ' End If


                    End If
                End If
            End If
        End With
        'Else

        '    lblEstado.Text = "Debe elegir una clasificacion"
        '    Timer1.Enabled = True
        '    PanelError.Visible = True
        '    TiempoEjecutar(10)
        'End If
        'Else
        '    lblEstado.Text = "Debe elegir una clasificacion"
        '    Timer1.Enabled = True
        '    PanelError.Visible = True
        '    TiempoEjecutar(10)
        'End If

        Me.Cursor = Cursors.Arrow


        'Else

        '    lblEstado.Text = "Seleccione una Marca"
        '    Timer1.Enabled = True
        '    PanelError.Visible = True
        '    TiempoEjecutar(10)
        'End If
    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvListadoItems.SelectedIndexChanged

    End Sub

    Private Sub dgvCompra_QueryCellStyleInfo(sender As Object, e As GridTableCellStyleInfoEventArgs) Handles dgvCompra.QueryCellStyleInfo
        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chPago" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        If e.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso e.TableCellIdentity.Column.Name = "chBonif" Then
            e.Style.CellType = "CheckBox"
            e.Style.CellValueType = GetType(Boolean)
            '   e.Style.CellValue = CheckBoxValue
            e.Style.[ReadOnly] = False
            e.Style.CellAppearance = GridCellAppearance.Raised
            e.Style.Enabled = True
            e.Style.Description = e.Style.CellValue.ToString()
        End If

        e.Handled = True

        If Not IsNothing(e.TableCellIdentity.Column) Then
            Dim el As Syncfusion.Grouping.Element = e.TableCellIdentity.DisplayElement

            If (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "gravado")) Then

                Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case str
                    Case "GS"
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.AliceBlue
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing

                        If e.TableCellIdentity.Column.MappingName = "gravado" AndAlso CInt(Fix(e.Style.CellValue)) >= 3 Then
                            e.Style.CellValue = 1
                        End If

                    Case Else
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.AliceBlue
                End Select

            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "cantidad")) Then
                Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case str
                    Case "GS"
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.AliceBlue
                        e.Style.CellValue = 1
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                    Case Else
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.AliceBlue
                End Select
            ElseIf (el.Kind = Syncfusion.Grouping.DisplayElementKind.Record AndAlso e.TableCellIdentity.Column IsNot Nothing AndAlso (e.TableCellIdentity.Column.Name = "almacen")) Then
                Dim str = Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue
                Select Case str
                    Case "GS"
                        e.Style.[ReadOnly] = True
                        e.Style.BackColor = Color.AliceBlue
                        e.Style.CellValue = 1
                        '        Me.dgvCompra.TableModel(e.TableCellIdentity.RowIndex, 15).CellValue = Nothing
                    Case Else
                        e.Style.[ReadOnly] = False
                        e.Style.BackColor = Color.AliceBlue
                End Select
            Else
                'e.Style.[ReadOnly] = False
            End If

            'If e.TableCellIdentity.Column.Name = "gravado" Then
            '    If e.Style.CellValue.Equals("1") Then



            '        e.Style.BackColor = Color.LightYellow
            '    End If
            'End If

            If (e.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse e.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) Then
                'Checks for the column name when the cellvalue is greater than 5.
                'If IsNumeric(e.Style.CellValue) Then
                '    If e.TableCellIdentity.Column.MappingName = "cantidad" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                '        ' e.Style.BackColor = Color.LightYellow
                '        e.Style.BackColor = Color.Yellow
                '        '     e.Style.Format = "##.00"
                '    End If
                'End If
                'If e.TableCellIdentity.Column.MappingName = "vcmn" AndAlso CInt(Fix(e.Style.CellValue)) > 0 Then
                '    e.Style.BackColor = Color.LightYellow
                '    'e.Style.Format = "S/.##.00"
                'End If
                'If e.TableCellIdentity.Column.MappingName = "almacen" Then
                '    e.Style.BackColor = Color.LightYellow
                'End If
                '    End If
                '    'If e.TableCellIdentity.Column.Name = "importeMN" Then
                '    '    If IsNumeric(e.Style.CellValue) Then
                '    '        '        If Fix(e.Style.CellValue) > 0 Then
                '    '        '    e.Style.ReadOnly = True
                '    '        e.TableCellIdentity.Table.CurrentRecord.SetValue("HaberMN", 0)
                '    '        'End If
                '    '    End If

            End If
        End If
    End Sub

    Private Sub dgvCompra_SaveCellText(sender As Object, e As GridCellTextEventArgs) Handles dgvCompra.SaveCellText
        Dim style As GridTableCellStyleInfo = DirectCast(e.Style, GridTableCellStyleInfo)
        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
            '  Me.CheckBoxValue = Boolean.Parse(e.Text)
            e.Handled = True
        End If
    End Sub

    Private Sub dgvCompra_SelectedRecordsChanged(sender As Object, e As SelectedRecordsChangedEventArgs) Handles dgvCompra.SelectedRecordsChanged

    End Sub

    Private Sub dgvCompra_TableControlCellClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCellClick
        Dim style As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style.Enabled Then
            If style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If

        Dim style2 As GridTableCellStyleInfo = e.TableControl.Model(e.Inner.RowIndex, e.Inner.ColIndex)
        If style2.Enabled Then
            If style2.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell AndAlso style2.TableCellIdentity.Column.Name = "chBonif" Then
                e.Inner.Cancel = True
            End If
            Console.WriteLine(e.Inner.RowIndex.ToString() & "TableControlCellClick")
        End If
    End Sub
    Sub Calculosxxx()

        TotalTalesXcolumna()
    End Sub


    Sub Calculos()
        Dim cantidad As Decimal = 0
        Dim VC As Decimal = 0
        Dim VCme As Decimal = 0
        Dim Igv As Decimal = 0
        Dim IgvME As Decimal = 0
        Dim totalMN As Decimal = 0
        Dim colBI As Decimal = 0
        Dim colBIme As Decimal = 0
        Dim colPrecUnit As Decimal = 0
        Dim colPrecUnitme As Decimal = 0
        Dim colDestinoGravado As Integer
        Dim colBonifica As String = Nothing


        colDestinoGravado = Me.dgvCompra.Table.CurrentRecord.GetValue("gravado")
        '****************************************************************
        colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")

        cantidad = Me.dgvCompra.Table.CurrentRecord.GetValue("cantidad")

        Select Case cboMoneda.SelectedValue
            Case 1 'MONEDA NACIONAL
                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                VC = Me.dgvCompra.Table.CurrentRecord.GetValue("vcmn")
                VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)

            Case 2 'MONEDA EXTRANJERA

                Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
                VCme = Me.dgvCompra.Table.CurrentRecord.GetValue("vcme") ' 
                VC = Math.Round(VCme * CDec(txtTipoCambio.DecimalValue), 2)

        End Select

        Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
        If cantidad > 0 AndAlso VC > 0 Then
            Igv = 0 ' Math.Round(VC * (TmpIGV / 100), 2)
            IgvME = 0 ' Math.Round(VCme * (TmpIGV / 100), 2)

            colBI = VC + Igv
            colBIme = VCme + IgvME

            colPrecUnit = Math.Round(VC / cantidad, 2)
            colPrecUnitme = Math.Round(VCme / cantidad, 2)
        ElseIf cantidad = 0 Then
            Igv = 0 ' Math.Round(VC * (TmpIGV / 100), 2)
            IgvME = 0 ' Math.Round(VCme * (TmpIGV / 100), 2)
            colBI = VC + Igv
            colBIme = VCme + IgvME
            colPrecUnit = 0
            colPrecUnitme = 0
        Else
            colPrecUnit = 0
            colPrecUnitme = 0

            colBI = 0
            colBIme = 0
            Igv = 0
            IgvME = 0
        End If
        Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", VC.ToString("N2"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", VCme.ToString("N2"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", colPrecUnit.ToString("N2"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("pume", colPrecUnitme.ToString("N2"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", VC.ToString("N2"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", VCme.ToString("N2"))
        Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", 0)
        Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", 0)

        TotalTalesXcolumna()
    End Sub

    'Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCheckBoxClick

    'End Sub

    Private chk As Boolean, check As Boolean = False
    Private ht As New ArrayList()

    Private Sub dgvCompra_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellChanged
        'Dim cc As GridCurrentCell = Me.dgvCompra.TableControl.CurrentCell
        'cc.ConfirmChanges()

        'If Not IsNothing(cc) Then
        '    Select Case cc.ColIndex
        '        Case 4 ' cantidad
        '            Calculos()
        '        Case 5 'Valor de compra
        '            Calculos()
        '        Case 6
        '            Calculos()
        '        Case 8
        '            Dim colPercepcionME As Decimal = 0
        '            colPercepcionME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")) / TmpTipoCambio, 2)
        '            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", colPercepcionME)
        '            Calculos()
        '        Case 14
        '            If Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia") = "GS" Then
        '                Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", String.Empty)
        '            End If

        '        Case 1
        '            Calculos()
        '    End Select
        'End If
    End Sub

    Private Sub dgvCompra_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvCompra.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub
    'Private Sub dgvCompra_TableControlCheckBoxClick(sender As Object, e As GridTableControlCellClickEventArgs) Handles dgvCompra.TableControlCheckBoxClick
    '    Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
    '    Dim el As Element = Me.dgvCompra.Table.GetInnerMostCurrentElement()

    '    Dim colindexVal As Integer = style.CellIdentity.ColIndex

    '    Dim RowIndex2 As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.RowIndex
    '    If RowIndex2 > -1 Then
    '        Select Case colindexVal
    '            Case 18

    '                If IsNothing(GFichaUsuarios) Then
    '                    lblEstado.Text = "Debe iniciar una caja, antes de realizar esta operación.!"
    '                    PanelError.Visible = True
    '                    Timer1.Enabled = True
    '                    TiempoEjecutar(10)
    '                    'Me.dgvCompra.TableModel(e.Inner.RowIndex, 16).CellValue = False
    '                    Exit Sub
    '                Else
    '                    If style.Enabled Then
    '                        Dim column As Integer = Me.dgvCompra.TableModel.NameToColIndex("chPago")
    '                        ' Console.WriteLine("CheckBoxClicked")
    '                        '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
    '                        If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
    '                            chk = CBool(Me.dgvCompra.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

    '                            e.TableControl.BeginUpdate()

    '                            e.TableControl.EndUpdate(True)
    '                        End If
    '                        If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chPago" Then
    '                            Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
    '                            Dim curStatus As Boolean = Boolean.Parse(style.Text)
    '                            e.TableControl.BeginUpdate()

    '                            If curStatus Then
    '                                '   CheckBoxValue = False
    '                            End If
    '                            If curStatus = True Then
    '                                Dim RowIndex As Integer = e.Inner.RowIndex
    '                                Dim ColIndex As Integer = e.Inner.ColIndex

    '                                Me.dgvCompra.TableModel(RowIndex, 19).CellValue = "No Pagado"

    '                            Else
    '                                Dim RowIndex As Integer = e.Inner.RowIndex
    '                                Dim ColIndex As Integer = e.Inner.ColIndex

    '                                Me.dgvCompra.TableModel(RowIndex, 19).CellValue = "Pagado"



    '                            End If
    '                            e.TableControl.EndUpdate()
    '                            If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
    '                            ElseIf Not ht.Contains(curStatus) Then
    '                            End If
    '                            ht.Clear()
    '                        End If
    '                    End If
    '                End If




    '            Case 20

    '                '      Dim style As GridTableCellStyleInfo = CType(e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex), GridTableCellStyleInfo)
    '                If style.Enabled Then
    '                    Dim column As Integer = Me.dgvCompra.TableModel.NameToColIndex("chBonif")
    '                    ' Console.WriteLine("CheckBoxClicked")
    '                    '   Dim s = e.TableControl.Table.CurrentRecord.GetValue("colModVenta")
    '                    If style.Enabled AndAlso style.TableCellIdentity.TableCellType = GridTableCellType.ColumnHeaderCell Then
    '                        chk = CBool(Me.dgvCompra.TableModel(style.TableCellIdentity.RowIndex, column).CellValue)

    '                        e.TableControl.BeginUpdate()

    '                        e.TableControl.EndUpdate(True)
    '                    End If
    '                    If style.Enabled AndAlso (style.TableCellIdentity.TableCellType = GridTableCellType.RecordFieldCell OrElse style.TableCellIdentity.TableCellType = GridTableCellType.AlternateRecordFieldCell) AndAlso style.TableCellIdentity.Column.Name = "chBonif" Then
    '                        Dim currentRecord As Record = style.TableCellIdentity.DisplayElement.GetRecord()
    '                        Dim curStatus As Boolean = Boolean.Parse(style.Text)
    '                        e.TableControl.BeginUpdate()

    '                        If curStatus Then
    '                            '   CheckBoxValue = False
    '                        End If
    '                        If curStatus = True Then
    '                            Dim RowIndex As Integer = e.Inner.RowIndex
    '                            Dim ColIndex As Integer = e.Inner.ColIndex
    '                            '      MsgBox(False)
    '                            Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "N" ' curStatus

    '                            '******************************************************************

    '                            Dim cantidad As Decimal = 0
    '                            Dim VC As Decimal = 0
    '                            Dim VCme As Decimal = 0
    '                            Dim Igv As Decimal = 0
    '                            Dim IgvME As Decimal = 0
    '                            Dim totalMN As Decimal = 0
    '                            Dim colBI As Decimal = 0
    '                            Dim colBIme As Decimal = 0
    '                            Dim colPrecUnit As Decimal = 0
    '                            Dim colPrecUnitme As Decimal = 0
    '                            Dim colDestinoGravado As Integer
    '                            Dim colBonifica As String = Nothing

    '                            Dim valPercepMN As Decimal = 0
    '                            Dim valPercepME As Decimal = 0


    '                            colDestinoGravado = Me.dgvCompra.TableModel(RowIndex, 1).CellValue

    '                            If colDestinoGravado = 1 Then
    '                                valPercepMN = Me.dgvCompra.TableModel(RowIndex, 8).CellValue
    '                                valPercepME = Me.dgvCompra.TableModel(RowIndex, 13).CellValue
    '                            Else
    '                                valPercepMN = 0
    '                                valPercepME = 0
    '                            End If

    '                            '****************************************************************
    '                            '      colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")

    '                            cantidad = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
    '                            Me.dgvCompra.TableModel(RowIndex, 4).CellValue = cantidad.ToString("N2") '  Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
    '                            VC = Me.dgvCompra.TableModel(RowIndex, 5).CellValue
    '                            VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
    '                            If cantidad > 0 AndAlso VC > 0 Then
    '                                Igv = Math.Round(VC * (TmpIGV / 100), 2)
    '                                IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

    '                                colBI = VC + Igv + valPercepMN
    '                                colBIme = VCme + IgvME + valPercepME

    '                                colPrecUnit = Math.Round(VC / cantidad, 2)
    '                                colPrecUnitme = Math.Round(VCme / cantidad, 2)
    '                            ElseIf cantidad = 0 Then
    '                                Igv = Math.Round(VC * (TmpIGV / 100), 2)
    '                                IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
    '                                colBI = VC + Igv + valPercepMN
    '                                colBIme = VCme + IgvME + valPercepME
    '                                colPrecUnit = 0
    '                                colPrecUnitme = 0
    '                            Else
    '                                colPrecUnit = 0
    '                                colPrecUnitme = 0

    '                                colBI = 0
    '                                colBIme = 0
    '                                Igv = 0
    '                                IgvME = 0
    '                            End If


    '                            Select Case TextBoxExt1.Tag
    '                                Case "08"

    '                                Case "03", "02"

    '                                    Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
    '                                    Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
    '                                    Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
    '                                    Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

    '                                    Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2") 'importe total
    '                                    Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2") 'importe total me

    '                                    Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0 'igvmn
    '                                    Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0 'igvme

    '                                    Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0 'percepcion
    '                                    Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0 'percepcion me


    '                                Case Else
    '                                    If cboMoneda.SelectedValue = 1 Then
    '                                        ' DATOS SOLES

    '                                        Select Case colDestinoGravado
    '                                            Case "2", "3", "4"

    '                                                Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
    '                                                Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
    '                                                Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
    '                                                Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

    '                                                Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
    '                                                Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

    '                                                Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
    '                                                Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0

    '                                                Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
    '                                                Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0


    '                                            Case Else
    '                                                If Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "S" Then ' BOnIFICACIOn

    '                                                    Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
    '                                                    Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
    '                                                    Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
    '                                                    Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")
    '                                                    Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
    '                                                    Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

    '                                                    Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
    '                                                    Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0

    '                                                    Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
    '                                                    Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0

    '                                                Else
    '                                                    If cantidad > 0 Then


    '                                                        Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

    '                                                        Me.dgvCompra.TableModel(RowIndex, 9).CellValue = colBI.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 14).CellValue = colBIme.ToString("N2")

    '                                                        Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


    '                                                    Else

    '                                                        Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

    '                                                        Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

    '                                                        Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


    '                                                    End If

    '                                                End If
    '                                        End Select

    '                                    ElseIf cboMoneda.SelectedValue = 2 Then

    '                                        Select Case colDestinoGravado
    '                                            Case "4"

    '                                            Case Else


    '                                        End Select

    '                                    End If
    '                            End Select

    '                        Else
    '                            Dim RowIndex As Integer = e.Inner.RowIndex
    '                            Dim ColIndex As Integer = e.Inner.ColIndex
    '                            '     MsgBox(True)
    '                            Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "S"

    '                            '******************************************************************

    '                            Dim cantidad As Decimal = 0
    '                            Dim VC As Decimal = 0
    '                            Dim VCme As Decimal = 0
    '                            Dim Igv As Decimal = 0
    '                            Dim IgvME As Decimal = 0
    '                            Dim totalMN As Decimal = 0
    '                            Dim colBI As Decimal = 0
    '                            Dim colBIme As Decimal = 0
    '                            Dim colPrecUnit As Decimal = 0
    '                            Dim colPrecUnitme As Decimal = 0
    '                            Dim colDestinoGravado As Integer
    '                            Dim colBonifica As String = Nothing
    '                            '****************************************************************


    '                            Dim valPercepMN As Decimal = 0
    '                            Dim valPercepME As Decimal = 0


    '                            colDestinoGravado = Me.dgvCompra.TableModel(RowIndex, 1).CellValue

    '                            If colDestinoGravado = 1 Then
    '                                valPercepMN = Me.dgvCompra.TableModel(RowIndex, 8).CellValue
    '                                valPercepME = Me.dgvCompra.TableModel(RowIndex, 13).CellValue
    '                            Else
    '                                valPercepMN = 0
    '                                valPercepME = 0
    '                            End If

    '                            '      colBonifica = Me.dgvCompra.Table.CurrentRecord.GetValue("chBonif")
    '                            cantidad = Me.dgvCompra.TableModel(RowIndex, 4).CellValue
    '                            Me.dgvCompra.TableModel(RowIndex, 4).CellValue = cantidad.ToString("N2") '  Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", cantidad.ToString("N2"))
    '                            VC = Me.dgvCompra.TableModel(RowIndex, 5).CellValue
    '                            VCme = Math.Round(VC / CDec(txtTipoCambio.DecimalValue), 2)
    '                            If cantidad > 0 AndAlso VC > 0 Then
    '                                Igv = Math.Round(VC * (TmpIGV / 100), 2)
    '                                IgvME = Math.Round(VCme * (TmpIGV / 100), 2)

    '                                colBI = VC + Igv
    '                                colBIme = VCme + IgvME

    '                                colPrecUnit = Math.Round(VC / cantidad, 2)
    '                                colPrecUnitme = Math.Round(VCme / cantidad, 2)
    '                            ElseIf cantidad = 0 Then
    '                                Igv = Math.Round(VC * (TmpIGV / 100), 2)
    '                                IgvME = Math.Round(VCme * (TmpIGV / 100), 2)
    '                                colBI = VC + Igv
    '                                colBIme = VCme + IgvME
    '                                colPrecUnit = 0
    '                                colPrecUnitme = 0
    '                            Else
    '                                colPrecUnit = 0
    '                                colPrecUnitme = 0

    '                                colBI = 0
    '                                colBIme = 0
    '                                Igv = 0
    '                                IgvME = 0
    '                            End If


    '                            Select Case cboTipoDoc.SelectedValue
    '                                Case "08"

    '                                Case "03", "02"

    '                                    Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
    '                                    Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
    '                                    Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
    '                                    Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

    '                                    Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
    '                                    Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

    '                                    Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
    '                                    Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0

    '                                    Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
    '                                    Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0


    '                                Case Else
    '                                    If cboMoneda.SelectedValue = 1 Then
    '                                        ' DATOS SOLES

    '                                        Select Case colDestinoGravado
    '                                            Case "2", "3", "4"

    '                                                Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
    '                                                Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
    '                                                Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
    '                                                Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

    '                                                Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
    '                                                Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

    '                                                Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
    '                                                Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0
    '                                                Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
    '                                                Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0

    '                                            Case Else
    '                                                If Me.dgvCompra.TableModel(RowIndex, 21).CellValue = "S" Then ' BOnIFICACIOn

    '                                                    Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
    '                                                    Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
    '                                                    Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
    '                                                    Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

    '                                                    Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
    '                                                    Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

    '                                                    Me.dgvCompra.TableModel(RowIndex, 7).CellValue = 0
    '                                                    Me.dgvCompra.TableModel(RowIndex, 12).CellValue = 0

    '                                                    Me.dgvCompra.TableModel(RowIndex, 8).CellValue = 0
    '                                                    Me.dgvCompra.TableModel(RowIndex, 13).CellValue = 0
    '                                                Else
    '                                                    If cantidad > 0 Then


    '                                                        Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

    '                                                        Me.dgvCompra.TableModel(RowIndex, 9).CellValue = colBI.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 14).CellValue = colBIme.ToString("N2")

    '                                                        Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


    '                                                    Else

    '                                                        Me.dgvCompra.TableModel(RowIndex, 5).CellValue = VC.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 10).CellValue = VCme.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 6).CellValue = colPrecUnit.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 11).CellValue = colPrecUnitme.ToString("N2")

    '                                                        Me.dgvCompra.TableModel(RowIndex, 9).CellValue = VC.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 14).CellValue = VCme.ToString("N2")

    '                                                        Me.dgvCompra.TableModel(RowIndex, 7).CellValue = Igv.ToString("N2")
    '                                                        Me.dgvCompra.TableModel(RowIndex, 12).CellValue = IgvME.ToString("N2")


    '                                                    End If

    '                                                End If
    '                                        End Select

    '                                    ElseIf cboMoneda.SelectedValue = 2 Then

    '                                        Select Case colDestinoGravado
    '                                            Case "4"

    '                                            Case Else


    '                                        End Select

    '                                    End If
    '                            End Select


    '                        End If
    '                        e.TableControl.EndUpdate()
    '                        If ht.Contains(curStatus) AndAlso (Not ht.Contains((Not curStatus))) Then
    '                        ElseIf Not ht.Contains(curStatus) Then
    '                        End If
    '                        ht.Clear()
    '                    End If
    '                End If
    '        End Select

    '        Me.dgvCompra.TableControl.Refresh()
    '        TotalTalesXcolumna()
    '    End If
    'End Sub

    Private Sub dgvCompra_TableControlCurrentCellEditingComplete(sender As Object, e As GridTableControlEventArgs) Handles dgvCompra.TableControlCurrentCellEditingComplete
        Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Select Case ColIndex
                Case 4 ' cantidad
                    Calculos()
                Case 5 'Valor de compra
                    Calculos()
                Case 6
                    Calculos()
                Case 8
                    Dim colPercepcionME As Decimal = 0
                    colPercepcionME = Math.Round(CDec(Me.dgvCompra.Table.CurrentRecord.GetValue("percepcionMN")) / TmpTipoCambio, 2)
                    Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", colPercepcionME)
                    Calculos()
                Case 14
                    If Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia") = "GS" Then
                        Me.dgvCompra.Table.CurrentRecord.SetValue("almacen", String.Empty)
                    End If

                Case 1
                    Calculos()
            End Select
        End If

    End Sub

    Public Function TieneCuentaFinanciera() As Boolean
        Dim efSA As New EstadosFinancierosSA
        Dim ef As New estadosFinancieros
        Dim estableSA As New establecimientoSA
        Dim valBool As Boolean = False

        GFichaUsuarios = New GFichaUsuario

        If IsNothing(GFichaUsuarios.NombrePersona) Then
            With frmFichaUsuarioCaja
                ModuloAppx = ModuloSistema.CAJA
                .lblNivel.Text = "Caja"
                .lblEstadoCaja.Visible = True
                '.GroupBox1.Visible = True
                '.GroupBox2.Visible = True
                '.GroupBox4.Visible = True
                '.cboMoneda.Visible = True
                .Timer1.Enabled = True
                .ManipulacionEstado = ENTITY_ACTIONS.INSERT
                .StartPosition = FormStartPosition.CenterParent
                .ShowDialog()
                If IsNothing(GFichaUsuarios.NombrePersona) Then
                    valBool = False
                    '   Return False
                Else
                    valBool = True
                    '   Return True
                End If
            End With
        End If
        Return valBool
    End Function
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        'If IsNothing(GFichaUsuarios) Then
        '    If TieneCuentaFinanciera() = True Then
        '        ToolStripButton1.Image = ImageListAdv1.Images(1)
        '        dgvCompra.TableDescriptor.Columns("chPago").Width = 50
        '        MessageBoxAdv.Show("Usuario iniciado!")
        '    Else

        '    End If
        'Else

        'End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub txtSerieGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSerieGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                txtNumeroGuia.Select()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtSerieGuia.Clear()
        End Try
    End Sub

    Private Sub txtSerieGuia_LostFocus(sender As Object, e As EventArgs) Handles txtSerieGuia.LostFocus
        Try
            If txtSerieGuia.Text.Trim.Length > 0 Then
                '  If chFormato.Checked = True Then
                txtSerieGuia.Text = String.Format("{0:00000}", Convert.ToInt32(txtSerieGuia.Text))
                'End If
            End If

        Catch ex As Exception

            If IsNumeric(Microsoft.VisualBasic.Mid(Trim(txtSerieGuia.Text), 2, 1)) = True Then

                If IsNumeric(Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1)) = True Then

                    If Not IsNumeric(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1)) = True Then

                        If Len(txtSerieGuia.Text) <= 2 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "000" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 1))

                        ElseIf Len(txtSerieGuia.Text) <= 3 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "00" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 2))

                        ElseIf Len(txtSerieGuia.Text) <= 4 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + "0" + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 3))

                        ElseIf Len(txtSerieGuia.Text) <= 5 Then

                            txtSerieGuia.Text = String.Format(Microsoft.VisualBasic.Left(Trim(txtSerieGuia.Text), 1) + Microsoft.VisualBasic.Right(Trim(txtSerieGuia.Text), 4))

                        End If
                    End If
                Else

                    txtSerieGuia.Select()
                    txtSerieGuia.Focus()
                    txtSerieGuia.Clear()
                    lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                    Timer1.Enabled = True
                    PanelError.Visible = True
                    TiempoEjecutar(10)

                End If

            Else

                txtSerieGuia.Select()
                txtSerieGuia.Focus()
                txtSerieGuia.Clear()
                lblEstado.Text = "INGRESE PRIMERO SOLO UNA LETRA SEGUIDO DE UN NUMERO"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)
            End If

        End Try
    End Sub

    Private Sub txtNumeroGuia_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroGuia.KeyDown
        Try
            If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
                e.SuppressKeyPress = True
                'cboMoneda.Select()
                txtSerieGuia.Select()
                'txtProveedor.Focus()
            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            txtNumeroGuia.Clear()
        End Try
    End Sub

    Private Sub txtNumeroGuia_LostFocus(sender As Object, e As EventArgs) Handles txtNumeroGuia.LostFocus
        Try
            If txtNumeroGuia.Text.Trim.Length > 0 Then
                '    If chFormato.Checked = True Then
                txtNumeroGuia.Text = String.Format("{0:00000000000000000000}", Convert.ToInt32(txtNumeroGuia.Text))

                'End If
            End If
        Catch ex As Exception
            'MessageBoxAdv.Show("Error de formato!", "Atención", Nothing, MessageBoxIcon.Error)
            txtNumeroGuia.Select()
            txtNumeroGuia.Focus()
            txtNumeroGuia.Clear()
            lblEstado.Text = "Error de formato verifique el ingreso!"
        End Try
    End Sub

    Private Sub tb19_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles tb19.ButtonStateChanged
        If Not IsNothing(TotalesXcanbeceras) Then
            If tb19.ToggleState = ToggleButton2.ToggleButtonState.ON Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseME
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvME
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalME
                dgvCompra.TableDescriptor.Columns("pumn").Width = 0
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 0
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 0
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 0
                dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

                dgvCompra.TableDescriptor.Columns("pume").Width = 60
                dgvCompra.TableDescriptor.Columns("vcme").Width = 65
                dgvCompra.TableDescriptor.Columns("igvme").Width = 65
                dgvCompra.TableDescriptor.Columns("totalme").Width = 70
                dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                cboMoneda.SelectedValue = 2

            ElseIf tb19.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
                txtTotalBase.DecimalValue = TotalesXcanbeceras.BaseMN
                txtTotalIva.DecimalValue = TotalesXcanbeceras.IgvMN
                txtTotalPagar.DecimalValue = TotalesXcanbeceras.TotalMN

                dgvCompra.TableDescriptor.Columns("pumn").Width = 60
                dgvCompra.TableDescriptor.Columns("vcmn").Width = 65
                dgvCompra.TableDescriptor.Columns("igvmn").Width = 65
                dgvCompra.TableDescriptor.Columns("totalmn").Width = 70
                dgvCompra.TableDescriptor.Columns("percepcionMN").Width = 0

                dgvCompra.TableDescriptor.Columns("pume").Width = 0
                dgvCompra.TableDescriptor.Columns("vcme").Width = 0
                dgvCompra.TableDescriptor.Columns("igvme").Width = 0
                dgvCompra.TableDescriptor.Columns("totalme").Width = 0
                dgvCompra.TableDescriptor.Columns("percepcionME").Width = 0
                cboMoneda.SelectedValue = 1
            End If
        End If
    End Sub


    Private Sub lsvServicios_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellKeyPress(sender As Object, e As GridTableControlKeyPressEventArgs) Handles dgvCompra.TableControlCurrentCellKeyPress

    End Sub

    Private Sub dgvCompra_TableControlCurrentCellStartEditing(sender As Object, e As GridTableControlCancelEventArgs) Handles dgvCompra.TableControlCurrentCellStartEditing
        'Dim cc As GridCurrentCell = e.TableControl.CurrentCell
        'Dim style As GridTableCellStyleInfo = DirectCast(e.TableControl.GetTableViewStyleInfo(cc.RowIndex, cc.ColIndex), GridTableCellStyleInfo)
        'If style.TableCellIdentity.DisplayElement.Kind = DisplayElementKind.Record AndAlso style.TableCellIdentity.Column.Name = "gravado" Then
        '    Dim str = Me.dgvCompra.Table.CurrentRecord.GetValue("tipoExistencia")
        '    Select Case str
        '        Case "GS"
        '            Me.dgvCompra.TableModel(cc.RowIndex, 1).ReadOnly = True
        '            e.Inner.Cancel = True
        '        Case Else
        '            Me.dgvCompra.TableModel(cc.RowIndex, 1).ReadOnly = True
        '    End Select


        'End If
    End Sub

    Private Sub txtRuc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRuc.KeyDown
        Me.Cursor = Cursors.WaitCursor
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If txtRuc.Text.Trim.Length > 0 Then
                'If VAL_RUC(txtRuc.Text) = False Then
                '    MessageBoxAdv.Show("RUC NO VALIDO", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBoxAdv.Show("OK", "SIGEA", MessageBoxButtons.OK, MessageBoxIcon.Information)
                UbicarEntidadPorRuc(txtRuc.Text.Trim)
                'End If

            End If
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Dim f As New frmCrearENtidades
        f.CaptionLabels(0).Text = "Nuevo proveedor"
        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
    End Sub

    Private Sub txtSerie_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSerie.KeyPress

    End Sub

    Private Sub txtSerie_TextChanged(sender As Object, e As EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub cboServicio_Click(sender As Object, e As EventArgs) Handles cboServicio.Click

    End Sub

    Private Sub cboServicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboServicio.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        Dim servicioSA As New servicioSA
        Dim servicio As New servicio
        If cboServicio.SelectedIndex > -1 Then
            servicio = servicioSA.UbicarServicioPorId(New servicio With {.idServicio = cboServicio.SelectedValue})
            txtCuenta.Text = servicio.cuenta
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv15_Click(sender As Object, e As EventArgs) Handles ButtonAdv15.Click
        If cboServicio.Text.Trim.Length > 0 Then
            Me.dgvCompra.Table.AddNewRecord.SetCurrent()
            Me.dgvCompra.Table.AddNewRecord.BeginEdit()
            Me.dgvCompra.Table.CurrentRecord.SetValue("codigo", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("gravado", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("idProducto", txtCuenta.Text.Trim)
            Me.dgvCompra.Table.CurrentRecord.SetValue("item", txtServicio.Text.Trim)
            Me.dgvCompra.Table.CurrentRecord.SetValue("um", Nothing)
            Me.dgvCompra.Table.CurrentRecord.SetValue("cantidad", 1)
            Me.dgvCompra.Table.CurrentRecord.SetValue("vcmn", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalmn", 0)

            Me.dgvCompra.Table.CurrentRecord.SetValue("vcme", 0.0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("totalme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvmn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("igvme", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("tipoExistencia", TipoRecurso.SERVICIO)
            Me.dgvCompra.Table.CurrentRecord.SetValue("marca", Nothing)

            Me.dgvCompra.Table.CurrentRecord.SetValue("pumn", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("pume", 0)
            Me.dgvCompra.Table.CurrentRecord.SetValue("chPago", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valPago", "No Pagado")

            Me.dgvCompra.Table.CurrentRecord.SetValue("chBonif", False)
            Me.dgvCompra.Table.CurrentRecord.SetValue("valBonif", "N")
            Me.dgvCompra.Table.CurrentRecord.SetValue("presentacion", Nothing)
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionMN", FormatNumber(0, 2))
            Me.dgvCompra.Table.CurrentRecord.SetValue("percepcionME", FormatNumber(0, 2))

            Me.dgvCompra.Table.CurrentRecord.SetValue("cat", cboServicio.SelectedValue)
            Me.dgvCompra.Table.AddNewRecord.EndEdit()
        Else
            lblEstado.Text = "Seleccione un Servicio hijo"
            PanelError.Visible = True
            TiempoEjecutar(10)
        End If
    End Sub

    Private Sub GridGroupingControl1_TableControlCurrentCellControlDoubleClick(sender As Object, e As GridTableControlControlEventArgs) Handles GridGroupingControl1.TableControlCurrentCellControlDoubleClick
        Dim DocumentoCompraSA As New DocumentoCompraDetalleSA
        Me.Cursor = Cursors.WaitCursor
        If DocumentoCompraSA.TieneItemsEnAV(Me.GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento")) = True Then
            PanelError.Visible = True
            lblEstado.Text = "El comprobante posee items en el almacen en transito, " & "necesita realizar la distribución, para seguir el proceso!"
            Timer1.Enabled = True
            TiempoEjecutar(10)
            Me.Cursor = Cursors.Arrow
        Else
            UbicarDetalle(GridGroupingControl1.Table.CurrentRecord.GetValue("idDocumento"))
        End If

        Me.Cursor = Cursors.Arrow
    End Sub
    Public Property IdCompraOrigen() As Integer
    Public Sub UbicarDetalle(intIddocumento As Integer)
        Dim detalleSA As New DocumentoCompraDetalleSA
        Dim objLista As New DocumentoCajaDetalleSA
        Dim detalle As New documentocompradetalle
        Dim compraSA As New DocumentoCompraSA
        Dim entidadSA As New entidadSA
        Dim dt As New DataTable

        Dim cTotalmn As Decimal = 0
        Dim cTotalme As Decimal = 0
        Dim cCreditomn As Decimal = 0
        Dim cCreditome As Decimal = 0
        Dim cDebitomn As Decimal = 0
        Dim cDebitome As Decimal = 0

        Dim cCantidadNC As Decimal = 0
        Dim cCantidadDB As Decimal = 0
        Dim cTotalCantidad As Decimal = 0
        Dim saldoCantidad As Decimal = 0
        Try
            With compraSA.UbicarDocumentoCompra(intIddocumento)
                IdCompraOrigen = .idDocumento


                If .monedaDoc = "1" Then
                    txtMon.Text = "1"
                ElseIf .monedaDoc = "2" Then
                    txtMon.Text = "2"
                End If

                txtTipoCambio.Text = .tcDolLoc
                txtTipoCambio.ReadOnly = True
                txtIva.Text = .tasaIgv
                txtImpFacmn.DecimalValue = .importeTotal
                txtImpFacme.DecimalValue = .importeUS

                Dim tablaSA As New tablaDetalleSA

                txtTipoDoc.Text = tablaSA.GetUbicarTablaID(CInt(10), .tipoDoc).descripcion

                TextBoxExt4.Text = .serie
                TextBoxExt3.Text = .numeroDoc
            End With

            'Dim saldomn As Decimal = 0
            'Dim saldome As Decimal = 0

            'dt.Columns.Add("sec", GetType(Integer))
            'dt.Columns.Add("grav", GetType(String))
            'dt.Columns.Add("idItem", GetType(Integer))
            'dt.Columns.Add("item", GetType(String))
            'dt.Columns.Add("cantidad", GetType(Decimal))
            'dt.Columns.Add("precMN", GetType(Decimal))
            'dt.Columns.Add("importeMN", GetType(Decimal))
            'dt.Columns.Add("precME", GetType(Decimal))
            'dt.Columns.Add("importeME", GetType(Decimal))
            'dt.Columns.Add("tipoEx", GetType(String))
            'dt.Columns.Add("almacenRef", GetType(Integer))

            'dt.Columns.Add("cantCompra", GetType(Decimal))
            'dt.Columns.Add("compraMN", GetType(Decimal))
            'dt.Columns.Add("compraME", GetType(Decimal))
            'dt.Columns.Add("montokardex", GetType(Decimal))
            'dt.Columns.Add("montokardexus", GetType(Decimal))
            'dt.Columns.Add("montoIgv", GetType(Decimal))
            'dt.Columns.Add("montoIgvUS", GetType(Decimal))
            'dt.Columns.Add("cboMov", GetType(String))
            'dt.Columns.Add("canDev", GetType(Decimal))
            'dt.Columns.Add("canSaldo", GetType(Decimal))

            'dt.Columns.Add("vcmn", GetType(Decimal))
            'dt.Columns.Add("vcme", GetType(Decimal))
            'dt.Columns.Add("ivamn", GetType(Decimal))
            'dt.Columns.Add("ivame", GetType(Decimal))
            'dt.Columns.Add("totalmn", GetType(Decimal))
            'dt.Columns.Add("totalme", GetType(Decimal))

            'dt.Columns.Add("pumn", GetType(Decimal))
            'dt.Columns.Add("pume", GetType(Decimal))
            'dt.Columns.Add("estadoPago", GetType(String))

            'dt.Columns.Add("ValDevmn", GetType(Decimal))
            'dt.Columns.Add("ValDevme", GetType(Decimal))
            'dt.Columns.Add("action", GetType(String))

            'For Each i As documentoCajaDetalle In objLista.ObtenerCuentasPorPagarPorDetails(intIddocumento)
            '    detalle = detalleSA.SumaNotasXidPadreItem(i.secuencia)

            '    saldoCantidad = i.CantidadCompra - detalle.monto1
            '    cTotalmn = CDec(i.MontoDeudaSoles) - detalle.importe - CDec(i.MontoPagadoSoles) + detalle.ImporteDBMN
            '    cTotalme = CDec(i.MontoDeudaUSD) - detalle.importeUS - CDec(i.MontoPagadoUSD) + detalle.ImporteDBME

            '    saldomn += cTotalmn
            '    saldome += cTotalme

            '    saldomn += cTotalmn
            '    saldome += cTotalme

            '    Dim dr As DataRow = dt.NewRow()
            '    dr(0) = i.secuencia
            '    dr(1) = i.destino
            '    dr(2) = i.idItem
            '    dr(3) = i.DetalleItem
            '    Select Case i.TipoExistencia
            '        Case "GS"
            '            dr(4) = 0
            '        Case Else
            '            If IsNothing(detalle) Then
            '                dr(4) = 0
            '            Else
            '                dr(4) = i.CantidadCompra - detalle.monto1  ' detalle.monto1
            '            End If
            '    End Select
            '    dr(5) = 0
            '    If cTotalmn < 0 Then
            '        cTotalmn = 0
            '    End If
            '    dr(6) = cTotalmn
            '    dr(7) = 0
            '    If cTotalme < 0 Then
            '        cTotalme = 0
            '    End If
            '    dr(8) = cTotalme
            '    dr(9) = i.TipoExistencia
            '    dr(10) = i.almacenRef

            '    dr(11) = i.CantidadCompra
            '    dr(12) = i.MontoDeudaSoles
            '    dr(13) = i.MontoDeudaUSD
            '    dr(14) = i.montokardex
            '    dr(15) = i.montokardexus
            '    dr(16) = i.montoIgv
            '    dr(17) = i.montoIgvUS
            '    dr(18) = "3"
            '    dr(19) = 0
            '    dr(20) = 0
            '    dr(21) = 0
            '    dr(22) = 0
            '    dr(23) = 0
            '    dr(24) = 0
            '    dr(25) = 0
            '    dr(26) = 0
            '    dr(27) = 0
            '    dr(28) = 0
            '    Select Case i.EstadoCobro
            '        Case TIPO_COMPRA.PAGO.PAGADO

            '            dr(29) = "Pagado"
            '        Case Else
            '            dr(29) = "Pendiente"

            '    End Select
            '    dr(30) = 0
            '    dr(31) = 0
            '    dr(32) = "activo"
            '    dt.Rows.Add(dr)
            'Next
            'dgvMov.DataSource = dt
            'dgvMov.TableModel.RowHeights.ResizeToFit(GridRangeInfo.Table(), GridResizeToFitOptions.ResizeCoveredCells)
            ''    Me.dgvMov.TableOptions.ListBoxSelectionMode = SelectionMode.One

        Catch ex As Exception
            lblEstado.Text = ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub tb19_Click(sender As Object, e As EventArgs) Handles tb19.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If GridGroupingControl1.Table.Records.Count > 0 Then

            Dim el As Element = Me.GridGroupingControl1.Table.GetInnerMostCurrentElement()
            If el IsNot Nothing Then
                Dim table As GridTable = TryCast(el.ParentTable, GridTable)
                Dim tableControl As GridTableControl = Me.GridGroupingControl1.GetTableControl(table.TableDescriptor.Name)
                Dim cc As GridCurrentCell = tableControl.CurrentCell
                Dim style As GridTableCellStyleInfo = table.GetTableCellStyle(cc.RowIndex, cc.ColIndex)
                Dim rec As GridRecord = TryCast(el, GridRecord)
                If rec Is Nothing AndAlso TypeOf el Is GridRecordRow Then
                    rec = TryCast(el.ParentRecord, GridRecord)
                End If
                If rec IsNot Nothing Then



                    If IsNothing(Me.GridGroupingControl1.Table.CurrentRecord) Then

                    Else
                        UbicarCompraDetalle(CInt(rec.GetValue("idDocumento")))
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtPeriodoCompras_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPeriodoCompras.KeyPress

    End Sub

    Private Sub txtPeriodoCompras_ValueChanged(sender As Object, e As EventArgs) Handles txtPeriodoCompras.ValueChanged

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim strPeriodo As String = String.Format("{0:00}", CInt(txtPeriodoCompras.Value.Month))
        strPeriodo = String.Concat(strPeriodo, "/", txtPeriodoCompras.Value.Year)
        UbicarCompraXProveedorNroSerie(txtRuc.Text, strPeriodo)
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboServicioPadre_Click(sender As Object, e As EventArgs) Handles cboServicioPadre.Click

    End Sub

    Private Sub cboServicioPadre_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboServicioPadre.SelectedValueChanged
        If cboServicioPadre.Text.Trim.Length > 0 Then
            HIJOS(cboServicioPadre.SelectedValue)
        Else
            lblEstado.Text = "Seleccione un Servicio Padre"
        End If
    End Sub

    Private Sub CboClasificacion_SelectedIndexChanged(sender As Object, e As EventArgs)
        Productoshijos()
    End Sub

    Private Sub ButtonAdv8_Click(sender As Object, e As EventArgs) Handles ButtonAdv8.Click
        Dispose()
    End Sub

    Private Sub ToggleButton21_ButtonStateChanged(sender As Object, e As ToggleButton2.ToggleButtonStateEventArgs) Handles ToggleButton21.ButtonStateChanged
        Me.Cursor = Cursors.WaitCursor
        If ToggleButton21.ToggleState = ToggleButton2.ToggleButtonState.OFF Then
            txtBuscarProducto.Visible = False
            btnNuevoProd.Visible = False

            Label16.Text = "Clasificación"
            txtCategoria.Visible = True
            PictureBox2.Visible = True
            Label47.Visible = True
            Label28.Visible = True

            Label35.Visible = True
            txtSubCategoria.Visible = True
            PictureBox6.Visible = True

            CMBClasificacion()

        Else
            txtBuscarProducto.Visible = True
            btnNuevoProd.Visible = True

            Label16.Text = "Buscar item"
            txtCategoria.Visible = False
            PictureBox2.Visible = False
            Label47.Visible = False
            Label28.Visible = False

            Label35.Visible = False
            txtSubCategoria.Visible = False
            PictureBox6.Visible = False

        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        If Not IsNothing(Me.dgvCompra.Table.CurrentRecord) Then
            Me.dgvCompra.Table.CurrentRecord.Delete()
            TotalTalesXcolumna()
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            If Not txtSerie.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de serie válido"
                PanelError.Visible = True
                TiempoEjecutar(10)
                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done serie"
            End If

            If Not txtProveedor.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un proveedor válido"

                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done proveedor"

            End If

            If Not txtNumero.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingresar un número de comprobante válido"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            Else
                lblEstado.Text = "Done número comprobante"

            End If

            If Not txtTipoDoc.Text.Trim.Length > 0 Then
                lblEstado.Text = "Ingrese comprobante de referencia!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

                Me.Cursor = Cursors.Arrow
                Exit Sub
            End If


            '***********************************************************************
            If dgvCompra.Table.Records.Count > 0 Then
                Me.lblEstado.Text = "Done!"
                '    If ManipulacionEstado = ENTITY_ACTIONS.INSERT Then
                Grabar()
                'Else
                'Dim Filas As Integer = dgvCompra.DisplayedRowCount(True)
                'If Filas > 0 Then
                '    UpdateCompra()
                'Else

                '    Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                '    Timer1.Enabled = True
                '    PanelError.Visible = True
                '    TiempoEjecutar(10)

                'End If


                '    End If
            Else

                Me.lblEstado.Text = "Ingrese items a la canasta de compra!"
                Timer1.Enabled = True
                PanelError.Visible = True
                TiempoEjecutar(10)

            End If
        Catch ex As Exception
            lblEstado.Text = ex.Message
            Timer1.Enabled = True
            PanelError.Visible = True
            TiempoEjecutar(10)

            ListaAsientonTransito = New List(Of asiento)

        End Try
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub pcSubCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcSubCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvSubCategoria.SelectedItems.Count > 0 Then
                txtSubCategoria.Text = lsvSubCategoria.Text
                txtSubCategoria.Tag = lsvSubCategoria.SelectedValue

                ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtSubCategoria.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub txtSubCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSubCategoria.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcSubCategoria.Font = New Font("Segoe UI", 8)
            Me.pcSubCategoria.Size = New Size(241, 110)
            Me.pcSubCategoria.ParentControl = Me.txtSubCategoria
            Me.pcSubCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaSubCategoria _
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

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        If e.PopupCloseType = PopupCloseType.Done Then
            If lsvCategoria.SelectedItems.Count > 0 Then
                txtCategoria.Text = lsvCategoria.Text
                txtCategoria.Tag = lsvCategoria.SelectedValue
                txtSubCategoria.Clear()
                Label28.Text = "0 items"
                Productoshijos()
            End If
        End If
        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.txtCategoria.Focus()
        End If
    End Sub

    Private Sub lsvCategoria_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCategoria.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub txtCategoria_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCategoria.KeyDown

        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(241, 110)
            Me.pcLikeCategoria.ParentControl = Me.txtCategoria
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta = (From n In listaCategoria _
                     Where n.descripcion.StartsWith(txtCategoria.Text)).ToList

            lsvCategoria.DataSource = consulta
            lsvCategoria.DisplayMember = "descripcion"
            lsvCategoria.ValueMember = "idItem"
            e.Handled = True
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

    Private Sub ToggleButton21_Click(sender As Object, e As EventArgs) Handles ToggleButton21.Click

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        'Dim f As New frmNuevaMarca
        'f.StartPosition = FormStartPosition.CenterParent
        'f.ShowDialog()
        Dim f As New frmNuevaMarca
        f.StartPosition = FormStartPosition.CenterParent
        f.txtCodigo.Tag = txtCategoria.Tag
        f.txtCodigo.Text = txtCategoria.Tag
        f.ShowDialog()
        Productoshijos()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim f As New frmNuevaClasificacion
        f.StartPosition = FormStartPosition.CenterParent
        'f.txtCodigo.Tag = CboClasificacion.SelectedValue
        'f.txtCodigo.Text = CboClasificacion.Text
        f.ShowDialog()
        CMBClasificacion()
    End Sub

    Private Sub txtFecha_ValueChanged(sender As Object, e As EventArgs) Handles txtFecha.ValueChanged
        If IsDate(txtFecha.Value) Then
            If txtFecha.Value.Date > DiaLaboral.Date Then
                txtFecha.Value = DiaLaboral
                MessageBox.Show("Debe respetar la fecha laboral o fechas inferiores a esta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
End Class