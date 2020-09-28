Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class FormPedidoTransferenciaDeInventario

#Region "Variables"
    Public Property Alert As Alert
    Public Property almacenListado As List(Of almacen)
    Private threadEntidades As Thread
    Public Property ListaEntidad As List(Of entidad)
    Public Property ListaTrabajadores As List(Of Persona)
    Dim entidadSA As New entidadSA
    Dim personaSA As New PersonaSA
    Friend Delegate Sub SetDelegateEntidad(ByVal lista As List(Of entidad), tipo As String)
    Friend Delegate Sub SetDelegatePersona(ByVal Persons As List(Of Persona))
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.KeyPreview = True
        CargarListas()
        GetCMBMeses()
        FormatoGridAvanzado(dgvMov, False, False, 11.0F)
    End Sub
#End Region

#Region "Personal"

    Sub HabilitarControles(tipoEntidad As String, estado As Boolean)
        Select Case tipoEntidad
            Case TIPO_ENTIDAD.CLIENTE
                RBProveedor.Enabled = estado
                '    RBCPlanilla.Enabled = estado
                RBOtros.Enabled = estado
            Case TIPO_ENTIDAD.PROVEEDOR
                RBCliente.Enabled = estado
                '   RBCPlanilla.Enabled = estado
                RBOtros.Enabled = estado
            Case TIPO_ENTIDAD.PERSONA_GENERAL
                RBCliente.Enabled = estado
                RBProveedor.Enabled = estado
             '   RBCPlanilla.Enabled = estado
            Case TIPO_ENTIDAD.PERSONAL_PLANILLA
                RBCliente.Enabled = estado
                RBProveedor.Enabled = estado
                RBOtros.Enabled = estado
        End Select

    End Sub

    Private Sub GetThreadEntidades(strTipo As String)
        'ProgressBar1.Visible = True
        'ProgressBar1.Style = ProgressBarStyle.Marquee
        TextPersona.Clear()
        TextDNI.Clear()
        HabilitarControles(strTipo, False)
        threadEntidades = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetEntidades(strTipo)))
        threadEntidades.Start()
    End Sub

    Private Sub GetEntidades(tipoPerson As String)

        Select Case tipoPerson
            Case TIPO_ENTIDAD.PROVEEDOR, TIPO_ENTIDAD.CLIENTE
                Dim ListaEntidades As New List(Of entidad)
                ListaEntidades = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipoPerson, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
                setDataSourceEntidad(ListaEntidades, tipoPerson)
            Case TIPO_ENTIDAD.PERSONA_GENERAL
                Dim listaPersonas As New PersonaSA
                Dim ListaPersons As New List(Of Persona)
                ListaPersons = personaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                 .tipoPersona = "T"}).ToList
                setDataSourcePersona(ListaPersons)
        End Select


    End Sub

    Private Sub setDataSourceEntidad(GetEntidades As List(Of entidad), tipo As String)
        If Me.InvokeRequired Then
            Dim deleg As New SetDelegateEntidad(AddressOf setDataSourceEntidad)
            Invoke(deleg, New Object() {GetEntidades, tipo})
        Else
            ListaEntidad = New List(Of entidad)
            ListaEntidad = GetEntidades
            '         ProgressBar1.Visible = False
            HabilitarControles(tipo, True)
        End If
    End Sub

    Private Sub setDataSourcePersona(GetPersonas As List(Of Persona))
        If Me.InvokeRequired Then
            Dim deleg As New SetDelegatePersona(AddressOf setDataSourcePersona)
            Invoke(deleg, New Object() {GetPersonas})
        Else
            ListaTrabajadores = New List(Of Persona)
            ListaTrabajadores = GetPersonas
            'ProgressBar1.Visible = False
            HabilitarControles(TIPO_ENTIDAD.PERSONA_GENERAL, True)
        End If
    End Sub

    Private Sub FillLSVPersonas(consulta As List(Of Persona))
        lsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idPersona)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.idPersona)
            lsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub FillLSVEntidades(consulta As List(Of entidad))
        lsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            lsvProveedor.Items.Add(n)
        Next
    End Sub
#End Region

#Region "TIMER"
    Sub parpadeo()
        Static parpadear As Boolean

        'If Not parpadear Then
        '    lblEstado.ForeColor = lblEstado.BackColor
        '    lblEstado.BackColor = Color.Yellow
        'Else
        '    lblEstado.ForeColor = SystemColors.WindowText
        'End If

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

#Region "Methods"

    Sub GetDiasMes(mes As Integer, anio As Integer)
        Dim days As Integer = System.DateTime.DaysInMonth(anio, mes)
        TxtDia.MaxValue = days
        TxtDia.MinValue = 1

    End Sub


    Public Sub CargarListas()
        Dim tablaSA As New Helios.Cont.WCFService.ServiceAccess.tablaDetalleSA
        Dim almacenSA As New almacenSA
        '   Dim entidadSA As New entidadSA
        ' Dim almacen As New List(Of almacen)
        Dim categoriaSA As New itemSA

        almacenListado = New List(Of almacen)

        almacenListado = almacenSA.GetListar_almacenExceptAV(New almacen With {.idEmpresa = Gempresas.IdEmpresaRuc, .idEstablecimiento = GEstableciento.IdEstablecimiento, .TipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        cboAlmacen.ValueMember = "idAlmacen"
        cboAlmacen.DisplayMember = "descripcionAlmacen"
        cboAlmacen.DataSource = almacenListado


        Dim almacenDestino = almacenListado.Where(Function(o) o.idAlmacen <> cboAlmacen.SelectedValue).ToList

        ComboAlmacenDestino.ValueMember = "idAlmacen"
        ComboAlmacenDestino.DisplayMember = "descripcionAlmacen"
        ComboAlmacenDestino.DataSource = almacenDestino

        Dim tabla As New List(Of tabladetalle)
        Dim lista As New List(Of String)

        lista.Add("04.01")
        lista.Add("04.02")
        lista.Add("06")
        lista.Add("07.02")
        lista.Add("08.02")
        lista.Add("09.02")
        lista.Add("10.01")
        lista.Add("10.05")
        lista.Add("11")
        lista.Add("12")
        lista.Add("13")
        lista.Add("14")
        lista.Add("15")
        lista.Add("99.02")
        lista.Add("99.09")


        'lista.Add("0001")
        'lista.Add("01")
        'lista.Add("02")
        'lista.Add("04.01")
        'lista.Add("04.02")
        'lista.Add("06")
        'lista.Add("07.02")
        'lista.Add("08.02")
        'lista.Add("09.02")
        'lista.Add("10.01")
        'lista.Add("10.05")
        'lista.Add("11")
        'lista.Add("12")
        'lista.Add("13")
        'lista.Add("14")
        'lista.Add("15")
        'lista.Add("99.02")
        'lista.Add("99.09")

        tabla = tablaSA.GetListaTablaDetalle(12, "1")

        Dim dtUM As New DataTable
        dtUM.Columns.Add("ID")
        dtUM.Columns.Add("Name")

        'For Each i In tablaSA.GetListaTablaDetalle(6, "1")
        '    dtUM.Rows.Add(i.codigoDetalle, i.descripcion)
        'Next
        'Me.AutoComplete1.DataSource = dtUM
        'Me.AutoComplete1.SetAutoComplete(Me.txtUm, Syncfusion.Windows.Forms.Tools.AutoCompleteModes.MultiSuggestExtended)

        Dim dtPresentacion As New DataTable
        dtPresentacion.Columns.Add("IDPres")
        dtPresentacion.Columns.Add("NamePres")


    End Sub

    Private Sub GetCMBMeses()
        Dim listaAnios As New empresaPeriodoSA
        cboAnio.DisplayMember = "periodo"
        cboAnio.ValueMember = "periodo"
        cboAnio.DataSource = listaAnios.GetListar_empresaPeriodo(New empresaPeriodo With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento})
        cboAnio.Text = DateTime.Now.Year

        cboMesCompra.DisplayMember = "Mes"
        cboMesCompra.ValueMember = "Codigo"
        cboMesCompra.DataSource = ListaDeMeses()
        cboMesCompra.SelectedValue = String.Format("{0:00}", DateTime.Now.Month)
    End Sub

    Private Sub GrabarPedidoTrasnferencia()
        Dim compraSA As New DocumentoCompraSA
        Dim objDocumentoCompraDet As documentocompradetalle
        Dim ListaDetalle As New List(Of documentocompradetalle)
        Dim sumaMN As Decimal = 0
        Dim sumaME As Decimal = 0
        Dim tipoentidad As String = String.Empty
        If RBProveedor.Checked = True Then
            tipoentidad = TIPO_ENTIDAD.PROVEEDOR
        ElseIf RBCliente.Checked = True Then
            tipoentidad = TIPO_ENTIDAD.CLIENTE
        ElseIf RBOtros.Checked = True Then
            tipoentidad = TIPO_ENTIDAD.PERSONA_GENERAL
        End If

        dgvMov.TableControl.CurrentCell.EndEdit()
        dgvMov.TableControl.Table.TableDirty = True
        dgvMov.TableControl.Table.EndEdit()

        Dim documento As New documento With
        {
        .Action = Business.Entity.BaseBE.EntityAction.INSERT,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .tipoDoc = "99",
        .fechaProceso = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), 'txtFechaComprobante.Value
        .nroDoc = "PT01",
        .moneda = "1",
        .idEntidad = Val(TextPersona.Tag),
        .entidad = TextPersona.Text,
        .nrodocEntidad = TextDNI.Text,
        .tipoEntidad = tipoentidad,
        .idOrden = Nothing, ' Me.IdOrden
        .tipoOperacion = "11",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
        }

        Dim idEntidad As Integer?
        Dim idPersona As Integer?
        Select Case tipoentidad
            Case TIPO_ENTIDAD.PROVEEDOR, TIPO_ENTIDAD.CLIENTE
                idEntidad = TextPersona.Tag
            Case Else
                idPersona = TextPersona.Tag
        End Select

        Dim documentocompra As New documentocompra With
        {
        .idPadre = 0,'lblIdDocumento.Text
        .situacion = "11",
        .codigoLibro = "13",
        .tipoDoc = "99",
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idCentroCosto = GEstableciento.IdEstablecimiento,
        .fechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
        .fechaDoc = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second), 'txtFechaComprobante.Value ' PERIODO
        .fechaContable = lblPerido.Text,
        .serie = String.Empty,
        .numeroDoc = String.Empty,
        .idProveedor = If(idEntidad.HasValue, idEntidad, Nothing),
        .idPersona = If(idPersona.HasValue, idPersona, Nothing),
        .nombreProveedor = TextPersona.Text,
        .monedaDoc = "1",
        .tasaIgv = 0,
        .tcDolLoc = 0,'txtTipoCambio.DecimalValue}
        .importeTotal = 0,
        .importeUS = 0,
        .destino = TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES,
        .estadoPago = TIPO_COMPRA.PAGO.PAGADO,
        .glosa = txtGlosa.Text,
        .referenciaDestino = Nothing,
        .tipoCompra = TIPO_COMPRA.MOVIMIENTO_ALMACEN.TRANSFERENCIA_ALMACENES,
        .aprobado = "N",
        .estadoEntrega = EstadoTransferenciaAlmacen.Pedido,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
        }
        documento.documentocompra = documentocompra

        If dgvMov.Table.Records IsNot Nothing AndAlso dgvMov.Table.Records.Count > 0 Then
            For Each r As Record In dgvMov.Table.Records

                objDocumentoCompraDet = New documentocompradetalle
                objDocumentoCompraDet.CustomRecursoCostoLote = New recursoCostoLote
                objDocumentoCompraDet.CustomRecursoCostoLote.codigoLote = CInt(r.GetValue("codigoLote"))
                objDocumentoCompraDet.tipoCosto = Nothing
                objDocumentoCompraDet.TipoOperacion = StatusTipoOperacion.TRANSFERENCIA_ENTRE_ALMACENES
                objDocumentoCompraDet.IdEmpresa = Gempresas.IdEmpresaRuc
                objDocumentoCompraDet.FechaLaboral = New DateTime(DiaLaboral.Year, DiaLaboral.Month, DiaLaboral.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)
                objDocumentoCompraDet.FechaDoc = New DateTime(cboAnio.Text, CInt(cboMesCompra.SelectedValue), TxtDia.Text, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) 'txtFechaComprobante.Value
                objDocumentoCompraDet.CuentaProvedor = "4212"
                objDocumentoCompraDet.NombreProveedor = TextPersona.Text.Trim
                objDocumentoCompraDet.TipoDoc = "99"
                objDocumentoCompraDet.NumDoc = String.Empty
                objDocumentoCompraDet.Serie = String.Empty
                objDocumentoCompraDet.destino = r.GetValue("grav")
                objDocumentoCompraDet.CuentaItem = String.Empty ' r.GetValue("cuenta")
                objDocumentoCompraDet.idItem = Val(r.GetValue("idItem"))
                objDocumentoCompraDet.tipoExistencia = r.GetValue("tipoEx")
                objDocumentoCompraDet.descripcionItem = r.GetValue("item")
                objDocumentoCompraDet.unidad1 = r.GetValue("idUM")

                If IsNumeric(r.GetValue("cantidad")) Then
                    If CDec(r.GetValue("cantidad")) <= 0 Then
                        MessageBox.Show("El valor de la cantidad debe ser mayor a cero", "Validar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Me.Cursor = Cursors.Arrow
                        Exit Sub
                    End If
                End If

                If Not CDec(r.GetValue("cantidad")) > 0 Then
                    Throw New Exception("Debe ingresar una cantidad mayor cero.")
                End If

                objDocumentoCompraDet.monto1 = CDec(r.GetValue("cantidad"))

                objDocumentoCompraDet.unidad2 = Nothing 'r.GetValue("idPrese") 'IDPRESENTACION
                objDocumentoCompraDet.monto2 = r.GetValue("nomPrese") ' PRESENTACION
                objDocumentoCompraDet.precioUnitario = 0 'CDec(r.GetValue("precMN"))
                objDocumentoCompraDet.precioUnitarioUS = 0 'CDec(r.GetValue("precME"))
                objDocumentoCompraDet.importe = 0 'r.GetValue("importeMN")
                objDocumentoCompraDet.importeUS = 0 ' r.GetValue("importeME")
                sumaMN += 0 'CDec(r.GetValue("importeMN"))
                sumaME += 0 'CDec(r.GetValue("importeME"))

                objDocumentoCompraDet.preEvento = Nothing  '= "00", Nothing, dgvNuevoDoc.Rows(S).Cells(23).Value())
                objDocumentoCompraDet.usuarioModificacion = usuario.IDUsuario
                objDocumentoCompraDet.almacenRef = cboAlmacen.SelectedValue '  CInt(r.GetValue("almacenDestino"))
                objDocumentoCompraDet.almacenDestino = ComboAlmacenDestino.SelectedValue
                objDocumentoCompraDet.fechaModificacion = DateTime.Now
                objDocumentoCompraDet.FechaVcto = Nothing
                objDocumentoCompraDet.Glosa = txtGlosa.Text.Trim
                ListaDetalle.Add(objDocumentoCompraDet)
            Next
        End If
        documento.documentocompra.importeTotal = sumaMN
        documento.documentocompra.importeUS = sumaME
        documento.documentocompra.documentocompradetalle = ListaDetalle

        compraSA.GrabarPedidoLogistica(documento)
        Alert = New Alert("Pedido guardado", alertType.success)
        Alert.TopMost = True
        Alert.Show()
        With FormInventarioCanastaTotales
            .GridTotales.Table.Records.DeleteAll()
            .txtFiltrar.Clear()
        End With
        Close()
    End Sub
#End Region

#Region "Events"
    Private Sub FormPedidoTransferenciaDeInventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dgvMov.TableDescriptor.VisibleColumns.Add("cantDisponible")
        Me.dgvMov.TableDescriptor.Columns("cantDisponible").Width = 100
        Me.dgvMov.TableDescriptor.Columns("cantDisponible").HeaderText = "Stock disponible"
        Me.dgvMov.TableDescriptor.Columns("cantDisponible").Appearance.AnyRecordFieldCell.BackColor = Color.MistyRose
        Me.dgvMov.TableDescriptor.Columns("cantDisponible").Appearance.AnyRecordFieldCell.TextColor = Color.Black

        Me.dgvMov.TableDescriptor.Columns("cantidad").Appearance.AnyRecordFieldCell.BackColor = Color.LightYellow
        Me.dgvMov.TableDescriptor.Columns("cantidad").Appearance.AnyRecordFieldCell.TextColor = Color.Black

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RBCliente.CheckedChanged
        Try
            If RBCliente.Checked Then
                GetThreadEntidades(TIPO_ENTIDAD.CLIENTE)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RBProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles RBProveedor.CheckedChanged
        Try
            If RBProveedor.Checked Then
                GetThreadEntidades(TIPO_ENTIDAD.PROVEEDOR)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RBOtros_CheckedChanged(sender As Object, e As EventArgs) Handles RBOtros.CheckedChanged
        Try
            If RBOtros.Checked Then
                GetThreadEntidades(TIPO_ENTIDAD.PERSONA_GENERAL)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextPersona_KeyDown(sender As Object, e As KeyEventArgs) Handles TextPersona.KeyDown


        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else

            If RBCliente.Checked Or RBProveedor.Checked Then
                If ListaEntidad.Count > 0 Then
                    '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
                    Me.PopupControlContainer4.Size = New Size(319, 128)
                    Me.PopupControlContainer4.ParentControl = Me.TextPersona
                    Me.PopupControlContainer4.ShowPopup(Point.Empty)
                    Dim consulta As New List(Of entidad)
                    consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})
                    Dim consulta2 = (From n In ListaEntidad
                                     Where n.nombreCompleto.StartsWith(TextPersona.Text) Or n.nrodoc.StartsWith(TextPersona.Text)).ToList
                    consulta.AddRange(consulta2)
                    '     consulta.Add(New entidad With {.idEntidad = 0, .nombreCompleto = "Agregar nuevo"})
                    FillLSVEntidades(consulta)
                    e.Handled = True
                End If
            ElseIf RBOtros.Checked Then
                If ListaTrabajadores.Count > 0 Then
                    Me.PopupControlContainer4.Size = New Size(319, 128)
                    Me.PopupControlContainer4.ParentControl = Me.TextPersona
                    Me.PopupControlContainer4.ShowPopup(Point.Empty)

                    Dim consulta As New List(Of Persona)
                    consulta.Add(New Persona With {.nombreCompleto = "Agregar nuevo"})
                    Dim consulta2 = (From n In ListaTrabajadores
                                     Where n.nombreCompleto.StartsWith(TextPersona.Text) Or n.idPersona.StartsWith(TextPersona.Text)).ToList

                    consulta.AddRange(consulta2)

                    FillLSVPersonas(consulta)
                    e.Handled = True
                End If

            End If
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PopupControlContainer4.Size = New Size(319, 128)
            Me.PopupControlContainer4.ParentControl = Me.TextPersona
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
                    If RBProveedor.Checked Then
                        Dim f As New frmCrearENtidades
                        f.CaptionLabels(0).Text = "Nuevo proveedor"
                        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If f.Tag IsNot Nothing Then
                            Dim c = CType(f.Tag, entidad)
                            TextPersona.Text = c.nombreCompleto
                            TextPersona.Tag = c.idEntidad
                            TextDNI.Visible = True
                            TextDNI.Text = c.nrodoc
                            TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            ListaEntidad.Add(c)
                        End If
                    ElseIf RBCliente.Checked Then
                        Dim f As New frmCrearENtidades
                        f.CaptionLabels(0).Text = "Nuevo cliente"
                        f.strTipo = TIPO_ENTIDAD.CLIENTE
                        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If f.Tag IsNot Nothing Then
                            Dim c = CType(f.Tag, entidad)
                            TextPersona.Text = c.nombreCompleto
                            TextPersona.Tag = c.idEntidad
                            TextDNI.Visible = True
                            TextDNI.Text = c.nrodoc
                            TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            ListaEntidad.Add(c)
                        End If
                    ElseIf RBOtros.Checked Then
                        Dim f As New FrmNuevaPersona()
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If f.Tag IsNot Nothing Then
                            Dim c = CType(f.Tag, Persona)
                            c.idPersona = c.idPersona
                            TextPersona.Text = c.nombreCompleto
                            TextPersona.Tag = c.idPersona
                            TextDNI.Visible = True
                            TextDNI.Text = c.idPersona
                            TextDNI.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            ListaTrabajadores.Add(c)
                        End If
                    End If
                Else
                    TextPersona.Text = lsvProveedor.SelectedItems(0).SubItems(1).Text
                    TextPersona.Tag = lsvProveedor.SelectedItems(0).SubItems(0).Text
                    TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    TextDNI.Text = lsvProveedor.SelectedItems(0).SubItems(2).Text
                    TextDNI.Visible = True
                End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            TextPersona.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvProveedor.MouseDoubleClick
        If lsvProveedor.SelectedItems.Count > 0 Then
            PopupControlContainer4.HidePopup(PopupCloseType.Done)
        End If
    End Sub

    Private Sub dgvMov_TableControlCurrentCellCloseDropDown(sender As Object, e As GridTableControlPopupClosedEventArgs) Handles dgvMov.TableControlCurrentCellCloseDropDown
        e.TableControl.CurrentCell.EndEdit()
        e.TableControl.Table.TableDirty = True
        e.TableControl.Table.EndEdit()
    End Sub

    Private Sub dgvMov_TableControlCurrentCellChanged(sender As Object, e As GridTableControlEventArgs) Handles dgvMov.TableControlCurrentCellChanged
        'Dim ColIndex As Integer = DirectCast(sender, Syncfusion.Windows.Forms.Grid.Grouping.GridGroupingControl).TableControl.CurrentCell.ColIndex
        Dim cc As GridCurrentCell = dgvMov.TableControl.CurrentCell
        cc.ConfirmChanges()
        Try
            If cc.ColIndex > -1 Then

                If cc.ColIndex = 7 Then
                    Dim colCantidad = Me.dgvMov.TableModel(Me.dgvMov.Table.CurrentRecord.GetRowIndex, 7).CellValue
                    Dim r As Record = dgvMov.Table.CurrentRecord
                    If Text.Trim.Length > 0 Then
                        Dim value As Decimal = Convert.ToDecimal(Text)
                        cc.Renderer.ControlValue = value

                        Dim cantiDisponible = r.GetValue("cantDisponible")
                        If value > cantiDisponible Then
                            cc.Renderer.ControlValue = 0
                            cc.ConfirmChanges()
                            cc.EndEdit()
                            lblEstado.Text = "La cantidad disponible es: " & cantiDisponible
                            PanelError.Visible = True
                            Timer1.Enabled = True
                            TiempoEjecutar(10)
                            Exit Sub
                        Else
                            ' Calculos()
                        End If

                    End If
                End If



            End If
        Catch ex As Exception
            lblEstado.Text = "Error: " & ex.Message
            PanelError.Visible = True
            Timer1.Enabled = True
            TiempoEjecutar(10)
        End Try
    End Sub

    Private Sub cboAlmacen_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAlmacen.SelectedValueChanged
        If almacenListado.Count > 0 Then
            If IsNumeric(cboAlmacen.SelectedValue) Then
                Dim almacenDestino = almacenListado.Where(Function(o) o.idAlmacen <> cboAlmacen.SelectedValue).ToList

                ComboAlmacenDestino.ValueMember = "idAlmacen"
                ComboAlmacenDestino.DisplayMember = "descripcionAlmacen"
                ComboAlmacenDestino.DataSource = almacenDestino
            End If

        End If
    End Sub

    Private Sub dgvMov_TableControlCurrentCellKeyDown(sender As Object, e As GridTableControlKeyEventArgs) Handles dgvMov.TableControlCurrentCellKeyDown
        If e.Inner.KeyCode = Keys.Delete Then
            If Me.dgvMov.Table.CurrentRecord IsNot Nothing Then
                Me.dgvMov.Table.CurrentRecord.Delete()
                '      TotalTalesXcolumna()
            End If
            If dgvMov.Table.Records.Count > 0 Then
                dgvMov.Table.Records(dgvMov.Table.Records.Count - 1).SetCurrent()
                dgvMov.Table.Records(dgvMov.Table.Records.Count - 1).BeginEdit()
            End If
            '    ConteoLabelVentas()
        ElseIf e.Inner.KeyCode = Keys.Up Or e.Inner.KeyCode = Keys.Down Then
            'If Me.dgvCompra.Table.CurrentRecord IsNot Nothing Then
            '    GetUbicarPrecio(Me.dgvCompra.Table.CurrentRecord)
            'End If

        End If
    End Sub

    Private Sub TextPersona_TextChanged(sender As Object, e As EventArgs) Handles TextPersona.TextChanged
        TextPersona.ForeColor = Color.Black
        TextPersona.Tag = Nothing
        If TextPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            TextDNI.Visible = True
        Else
            TextDNI.Visible = False
        End If
    End Sub
    Private Sub cboMesCompra_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboMesCompra.SelectedValueChanged
        If Not IsNothing(cboMesCompra.SelectedValue) Then
            lblPerido.Text = (cboMesCompra.SelectedValue & "/" & cboAnio.Text)
            If TxtDia.Text.Trim.Length > 0 Then
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
            Else
                GetDiasMes(Integer.Parse(cboMesCompra.SelectedValue), cboAnio.Text)
                TxtDia.Clear()
            End If
        End If
    End Sub

    Private Sub TxtDia_TextChanged(sender As Object, e As EventArgs) Handles TxtDia.TextChanged
        If cboMesCompra.Text.Trim.Length > 0 Then

        End If
    End Sub

    Private Sub cboAnio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboAnio.SelectedValueChanged
        If cboAnio.Text.Trim.Length > 0 Then
            lblPerido.Text = (cboMesCompra.SelectedValue & "/" & cboAnio.Text)
            TxtDia_TextChanged(sender, e)
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If Not IsNothing(Me.dgvMov.Table.CurrentRecord) Then
            Me.dgvMov.Table.CurrentRecord.Delete()
        End If
    End Sub

    Private Sub btGrabar_Click(sender As Object, e As EventArgs) Handles btGrabar.Click
        GrabarPedidoTrasnferencia()
    End Sub

    Private Sub FormPedidoTransferenciaDeInventario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            If dgvMov.Table.Records.Count > 0 Then
                If MessageBox.Show("¿Desea salir de la operación?", "Salir de la ventana", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                    If threadEntidades IsNot Nothing Then
                        threadEntidades.Abort()
                    End If
                    With FormInventarioCanastaTotales
                        .GridTotales.Table.Records.DeleteAll()
                        .txtFiltrar.Clear()
                    End With
                Else
                    e.Cancel = True
                End If
            Else
                If threadEntidades IsNot Nothing Then
                    threadEntidades.Abort()
                End If
                With FormInventarioCanastaTotales
                    .GridTotales.Table.Records.DeleteAll()
                    .txtFiltrar.Clear()
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

End Class