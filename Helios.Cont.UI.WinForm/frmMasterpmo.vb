Imports Syncfusion.Windows.Forms.Tools
Imports Helios.Cont.Business.Entity
Imports Helios.General
'Imports Helios.Planilla.Business.Entity

Imports Helios.Seguridad.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
'Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports PopupControl

Public Class frmMasterpmo
    Inherits RibbonForm
    Property Model As New MDIPrincipalModel
    Private lblEmpresa As System.Windows.Forms.ToolStripLabel
    Private btnNotify As ToolStripButton
    Private btnConfig As ToolStripButton
    Dim toolTip As Popup
    Dim ucInicio As New ucInicio

#Region "Proyectos"
    Private Sub GetProyectosGeneralesCMB()
        Dim costoSA As New recursoCostoSA
        cboProyGeneral.DisplayMember = "nombreCosto"
        cboProyGeneral.ValueMember = "idCosto"
        cboProyGeneral.DataSource = costoSA.GetListaRecursosXtipo(New recursoCosto With {.tipo = "HC", .subtipo = "PY"})

        'cboGastoGeneral.Items.Clear()
        'cboGastoGeneral.Items.Add("GASTO ADMINISTRATIVO")
        'cboGastoGeneral.Items.Add("GASTO DE VENTAS")
        'cboGastoGeneral.Items.Add("GASTO FINANCIERO")
    End Sub
#End Region

    Private Sub ConfiguracionInicio()
        Me.rbnPrincipal.QuickPanelVisible = True

        Me.rbnPrincipal.MenuButtonDropDown = Me.ContextMenuStripEx1
        Me.lblEmpresa = New System.Windows.Forms.ToolStripLabel()

        Me.btnNotify = New System.Windows.Forms.ToolStripButton()
        ' btnNotify.BackColor = Color.White
        btnNotify.Text = "0"
        btnNotify.Image = Me.imageListAdv1.Images(13)
        btnNotify.ToolTipText = "Notificaciones."
        btnNotify.Font = New Font("Segoe UI", 8)

        Me.btnConfig = New System.Windows.Forms.ToolStripButton()
        btnConfig.Text = ""
        btnConfig.Image = Me.imageListAdv1.Images(14)
        btnConfig.ToolTipText = "Configuración de Inicio."
        btnConfig.Font = New Font("Segoe UI", 8)

        ' Set the text and DisplayStyle property.
        Me.lblEmpresa.Text = Space(15) & Gempresas.IdEmpresaRuc & ", " & Gempresas.NomEmpresa
        lblEmpresa.Enabled = False
        Me.lblEmpresa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text

        ' Add the toolstripbutton in the header of the RibbonControlAdv.
        Me.rbnPrincipal.Header.AddQuickItem(Me.lblEmpresa) 'ToolStripSeparator1
        Me.rbnPrincipal.Header.AddQuickItem(Me.ToolStripSeparator1)
        Me.rbnPrincipal.Header.AddQuickItem(Me.btnNotify)
        Me.rbnPrincipal.Header.AddQuickItem(Me.btnConfig)
        Me.rbnPrincipal.Header.AddQuickItem(btnAnio)
        Me.rbnPrincipal.Header.AddQuickItem(cboAnio)

        AddHandler btnNotify.Click, AddressOf TS1clickevent
        AddHandler btnConfig.Click, AddressOf btn_ClicConfig
    End Sub

    Public Sub CargarConfiguracionInicio(strIdEmpresa As String)
        Dim configSA As New ConfiguracionInicioSA
        Dim config As New configuracionInicio
        Dim estableSA As New establecimientoSA
        config = configSA.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc)

        If Not IsNothing(config) Then
            With config
                GEstableciento = New GEstablecimiento
                GEstableciento.IdEstablecimiento = .idEstablecimiento
                GEstableciento.NombreEstablecimiento = estableSA.UbicaEstablecimientoPorID(.idEstablecimiento).nombre
                'TmpIdAlmacen = .idalmacenVenta
                AnioGeneral = .anio
                MesGeneral = .mes
                DiaLaboral = .dia
                PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(.mes)) & "/" & .anio
                TmpTipoCambio = .tipocambio
                TmpIGV = .iva
                TmpTipoIVA = .tipoIva
            End With
            MessageBoxAdv.Show("Configuración existente habilitada!", "Atención", MessageBoxButtons.OK)
        Else
            MessageBoxAdv.Show("No dispone de una configuración de inicio.!", "Atención", MessageBoxButtons.OK)
            If MessageBoxAdv.Show("Desea abrir el formulario de configuración?", "Atención", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim LightBox As New frmConfigInicioXempresa(Gempresas.IdEmpresaRuc)
                LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
                LightBox.Owner = Me
                LightBox.ShowDialog()
            End If
        End If


    End Sub

    Public Sub ObtenerConteoNotificacion()
        Dim notificacionAlmacenSA As New notificacionAlmacenSA
        Try
            'btnNotify.Text = notificacionAlmacenSA.GetUbicarNotificacionConteo(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento)
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub MostrarNotificaciones()
    '    Dim notificacionAlmacenSA As New notificacionAlmacenSA
    '    Dim dt As New DataTable()

    '    dgvNotificacion.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
    '    With dgvNotificacion.ColumnHeadersDefaultCellStyle
    '        .Alignment = DataGridViewContentAlignment.MiddleCenter
    '        .BackColor = Color.DarkRed
    '        .ForeColor = Color.Gold
    '        .Font = New Font(.Font.FontFamily, .Font.Size, _
    '         .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
    '    End With

    '    dgvNotificacion.Rows.Clear()

    '    For Each i In notificacionAlmacenSA.GetUbicarNotificacion(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, TIPO_SITUACION.NOTIFICACION_SOBRANTE)
    '        dgvNotificacion.Rows.Add(i.idDocumento,
    '                                 i.idEmpresa,
    '                                 i.idCentroCosto,
    '                                 i.tipoDoc,
    '                                 i.nombreProveedor,
    '                                i.estado,
    '                                i.numeroDoc,
    '                                 i.serie,
    '                                 i.idProveedor,
    '                                 String.Concat(i.nombreProveedor & vbCrLf & i.glosa))
    '    Next

    '    For Each i In notificacionAlmacenSA.GetUbicarNotificacionCaja(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, TIPO_SITUACION.NOTIFICACION_DOCUMENTO_CAJA)
    '        dgvNotificacion.Rows.Add(i.idDocumento,
    '                                 i.idEmpresa,
    '                                 i.idCentroCosto,
    '                                 i.tipoDoc,
    '                                 i.nombreProveedor,
    '                                i.estado,
    '                                i.numeroDoc,
    '                                 i.serie,
    '                                 i.idProveedor,
    '                                 String.Concat(i.nombreProveedor & vbCrLf & i.glosa))
    '    Next
    'End Sub

    Private Sub TS1clickevent(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If PanelNotif.Visible = True Then
        '    PanelNotif.Visible = False
        'Else
        '    PanelNotif.Visible = True
        '    MostrarNotificaciones()
        'End If
    End Sub

    Private Sub btn_ClicConfig(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.WaitCursor
        Dim LightBox As New frmConfigInicioXempresa(Gempresas.IdEmpresaRuc)
        LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
        LightBox.Owner = Me
        LightBox.ShowDialog()
        CargarArbolOpciones()
        Me.Cursor = Cursors.Arrow
    End Sub

    Public Sub CargarArbolOpciones()
        Dim listaCategorias As New List(Of Modulo)
        listaCategorias = New List(Of Modulo)
        listaCategorias = Model.Modulos.Where(Function(o) o.TipoModulo = Modulo.ModuloTipo.Categoria).OrderBy(Function(o) o.Orden).ToList
        Dim Categoria As GroupBarItem
        Dim ArbolOpciones As TreeViewAdv
        Dim Nodo As TreeNodeAdv
        Dim listaNiveles As List(Of Modulo)
        Dim Temporal As New Dictionary(Of Int32, TreeNodeAdv)
        Dim item As New Modulo
        Dim configSA As New ConfiguracionInicioSA
        Dim config As New configuracionInicio

        config = configSA.ObtenerConfigXempresa(Gempresas.IdEmpresaRuc)

        If Not IsNothing(config) Then
            gbNavegador.GroupBarItems.Clear()
            For Each item In listaCategorias
                Categoria = New GroupBarItem With {.Text = item.Descripcion}
                ' Categoria.InNavigationPane = True

                ArbolOpciones = New TreeViewAdv
                AddHandler ArbolOpciones.NodeMouseDoubleClick, AddressOf TreeView_NodeMouseDoubleClick
                FormatearArbolNavegacion(ArbolOpciones)
                gbNavegador.Controls.Add(ArbolOpciones)
                Categoria.Client = ArbolOpciones
                'Categoria.Image = My.Resources.my_projects32x32
                Categoria.LargeImageMode = True
                Categoria.ForeColor = Color.FromKnownColor(KnownColor.ControlText)

                gbNavegador.GroupBarItems.AddRange(New GroupBarItem() {Categoria})

                listaNiveles = Model.Modulos.Where(Function(o) o.IDCategoria = item.IDModulo).OrderBy(Function(o) o.Orden).ToList

                For Each nivel In listaNiveles
                    Nodo = New TreeNodeAdv With {.Text = nivel.Descripcion, .Tag = nivel}
                    Temporal.Add(nivel.IDModulo, Nodo)

                    If Not nivel.IDModuloPadre.HasValue Then
                        ArbolOpciones.Nodes.Add(Nodo)
                    Else
                        Temporal.Item(nivel.IDModuloPadre).Nodes.Add(Nodo)
                    End If
                Next

            Next

            Dim myCompra As System.Drawing.Image = My.Resources.icono_new_documento
            imageListAdv1.Images.Add(myCompra) '0

            Me.imageListAdv1.ToImageList().ColorDepth = ColorDepth.Depth32Bit

            gbNavegador.GroupBarItems(0).Image = Me.imageListAdv1.Images(0)
            gbNavegador.GroupBarItems(1).Image = Me.imageListAdv1.Images(11)
            gbNavegador.GroupBarItems(2).Image = Me.imageListAdv1.Images(3)
            gbNavegador.GroupBarItems(3).Image = Me.imageListAdv1.Images(18)
            gbNavegador.GroupBarItems(4).Image = Me.imageListAdv1.Images(16)
            gbNavegador.GroupBarItems(5).Image = Me.imageListAdv1.Images(15)
            gbNavegador.GroupBarItems(6).Image = Me.imageListAdv1.Images(17)
            gbNavegador.GroupBarItems(7).Image = Me.imageListAdv1.Images(19)
        Else
            '   MessageBoxAdv.Show("Tiene que establecer la configuración de inicio.!")
        End If
    End Sub
    ''' <summary>
    ''' Se formatea los controles por código para no realizarlo en modo diseño
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FormatearControles()
        'Formato de GroupItems
        With Me.gbNavegador
            .ShowItemImageInHeader = True
            '.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook
            .VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Metro
            .HeaderBackColor = Color.FromArgb(230, 240, 250) 'Color.WhiteSmoke ' )

            .StackedMode = True
            .TextAlign = TextAlignment.Left
            .BorderStyle = BorderStyle.FixedSingle
            .CollapsedText = "Panel de Proyectos"
            .Font = New Font("Segoe UI", 7.25, FontStyle.Bold)
            .ForeColor = Color.FromKnownColor(KnownColor.Black) ' Color.Black
            .HeaderFont = New Font("Segoe UI", 7.25, FontStyle.Bold)
            .HeaderForeColor = Color.Black  ' Color.Black
            .HeaderHeight = 30
            .GroupBarItemHeight = 25
            .ShowChevron = False



        End With
    End Sub

    Public Sub FormatearArbolNavegacion(ByVal item As TreeViewAdv)
        item.ShowLines = False
    End Sub

    Sub LoadPeriodos()
        Dim periodoSA As New empresaPeriodoSA
        cboAnio.Items.Clear()
        For Each i As empresaPeriodo In periodoSA.GetListar_empresaPeriodo(Gempresas.IdEmpresaRuc)
            cboAnio.Items.Add(i.periodo)
        Next
        ' lblPerido.Text = cboAnio.Items(0)
        If cboAnio.Items.Count > 0 Then
            cboAnio.SelectedIndex = 0
            AnioGeneral = cboAnio.Text
            PeriodoGeneral = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month)) & "/" & AnioGeneral
            MesGeneral = String.Format("{0:00}", Convert.ToInt32(DateTime.Now.Month))
        End If
    End Sub
    Enum Sys
        Inicio
        Proceso
    End Enum
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatearControles()
        CargarArbolOpciones()
        ConfiguracionInicio()
        'LoadPeriodos()
        GetProyectosGeneralesCMB()
        ' gbNavegador.GroupBarItems(5).Image = Me.imageListAdv1.Images(12)
        '.GroupBarItems(6).Image = Me.imageListAdv1.Images(6)

        toolTip = New Popup(ucInicio)
        toolTip.AutoClose = False
        toolTip.FocusOnOpen = False
        toolTip.ShowingAnimation = PopupAnimations.Blend
        InfoConfiguracion(Sys.Inicio)

        'Dim modulo As New Modulo
        'modulo.Descripcion = "Configuración de inicio"
        'modulo.Formulario = "frmConfiguracionesInicio"
        'modulo.IDCategoria = "7"
        'modulo.IDModulo = "401"
        'modulo.IDModuloPadre = "400"
        'modulo.IDSeguridad = "0"
        'modulo.Orden = "7"
        'modulo.TipoModulo = WinForm.Modulo.ModuloTipo.Nivel
        'modulo.Transaccion = Nothing

        'CargarModuloSeleccionado(modulo)

      

    End Sub
    Sub InfoConfiguracion(n As Sys)
        If Not IsNothing(GEstableciento) Then
            If Not IsNothing(GEstableciento.NombreEstablecimiento) Then
                ucInicio.txtAnio.Text = PeriodoGeneral
                ucInicio.txtEstablecimiento.Text = GEstableciento.NombreEstablecimiento
                If n = Sys.Inicio Then

                ElseIf n = Sys.Proceso Then
                    With toolTip
                        .Font = New Font("Tahoma", 8)
                        .Show(btnInicio)
                    End With
                End If
            End If
        End If
    End Sub
    Private Sub treeview_doubleclick(sender As System.Object, e As System.EventArgs)
        Dim tv As TreeViewAdv
        Dim nodo As TreeNodeAdv
        Dim modulo As Modulo

        Cursor = Cursors.WaitCursor

        tv = DirectCast(sender, TreeViewAdv)
        'captura nodo seleccionado
        nodo = tv.PointToNode(Cursor.Position)

        'captura nodoseleccionado
        If nodo IsNot Nothing Then
            'carga moduloseleccionado
            modulo = DirectCast(nodo.Tag, Modulo)
            '  If Not String.IsNullOrWhiteSpace(modulo.Formulario) Then
            'procesa seleccion del menu
            CargarModuloSeleccionado(modulo)
            'End If
        End If
    End Sub

    Private Sub TreeView_NodeMouseDoubleClick(sender As Object, e As TreeViewAdvMouseClickEventArgs)
        Dim tv As TreeViewAdv
        Dim nodo As TreeNodeAdv
        Dim modulo As Modulo
        Cursor = Cursors.WaitCursor
        Try
            tv = DirectCast(sender, TreeViewAdv)
            'captura nodo seleccionado
            nodo = New TreeNodeAdv
            nodo = e.Node

            'captura nodoseleccionado
            If nodo IsNot Nothing Then

                Dim proyGen = cboProyGeneral.Text
                If proyGen.ToString.Trim.Length > 0 Then
                    'carga moduloseleccionado
                    modulo = DirectCast(nodo.Tag, Modulo)
                    'Select Case modulo.IDModulo
                    '    Case 602
                    '        TmpSelModulo = 1 ' registro entidades financieras
                    '    Case 26
                    '        TmpSelModulo = 2 ' registro usuarios de caja
                    '    Case 603
                    '        TmpSelModulo = 3 ' Asignacion de cajas

                    '    Case 500 ' proy ventas
                    '        ProyectoGeneralSel.subtipo = TipoCosto.OP_CONTINUA_DE_BIENES

                    '    Case 600 ' proy produccion
                    '        ProyectoGeneralSel.subtipo = TipoCosto.OP_CONTINUA_DE_BIENES

                    '    Case 700 ' CONSTRUCCIN
                    '        ProyectoGeneralSel.subtipo = TipoCosto.CONTRATOS_DE_CONSTRUCCION
                    'End Select
                    'procesa seleccion del menu
                    CargarModuloSeleccionado(modulo)
                Else
                    MessageBox.Show("Debe indentificar el proyecto general", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

               
            End If
        Catch ex As Exception
            MsgBox("Error al abrir nodo " & vbCrLf & ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub CargarModuloSeleccionado(modulo As Modulo)
        Dim Formulario As frmMaster
        Dim FormName As String
        Dim FormLinq As String

        If Not IsNothing(modulo.Formulario) Then
            '   If modulo.Formulario.Trim.Length = 0 Then Exit Sub
            FormName = Replace(System.IO.Path.GetFileName(System.Reflection.Assembly.GetExecutingAssembly().Location), ".exe", "." + modulo.Formulario.Trim)
            FormLinq = FormName
            FormLinq = FormLinq.Replace("Helios.Cont.Presentation.WinForm.", String.Empty)
            Dim frm As Form = Me.MdiChildren.OfType(Of Form)().Where(Function(x) x.Name = FormLinq).FirstOrDefault()
            'tabMDImgr.ClearSavedTabGroupState()
            If IsNothing(frm) Then
                Dim objType = Type.[GetType](FormName)
                Formulario = DirectCast(Activator.CreateInstance(objType), frmMaster)
                'Formulario.Parent = Me
                Me.tabMDImgr.ShowCloseButton = False
                Formulario.MdiParent = Me
                Formulario.Show()

                'Me.tabMDImgr.TabStyle = GetType(TabRendererMetro)
                Me.tabMDImgr.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.OneNoteStyleRenderer)
                Me.tabMDImgr.ContextMenuItem.Style = Syncfusion.Windows.Forms.VisualStyle.Metro
                Me.tabMDImgr.ShowCloseButtonForForm(Formulario, True)
            Else
                Dim objType = Type.[GetType](FormName)
                Formulario = DirectCast(Activator.CreateInstance(objType), frmMaster)
                Formulario.BringToFront()
                '  gbNavegador.CollapsedText = Formulario.Text
            End If
        End If
    End Sub
    'Private ReadOnly Property FormInstance() As frmMantenimientoComprasPagadas
    '    Get
    '        If form Is Nothing Then
    '            form = New frmMantenimientoComprasPagadas()
    '            form.MdiParent = Me

    '            AddHandler form.Disposed, New EventHandler(AddressOf form_Disposed)
    '            'AddHandler Form.FormClosed, New FormClosedEventHandler(AddressOf form_FormClosed)

    '            'AddHandler Form.Load, New EventHandler(AddressOf form_Load)
    '        End If

    '        Return form
    '    End Get
    'End Property


    'Private Sub form_Disposed(sender As Object, e As EventArgs)
    '    form = Nothing
    'End Sub
    Private Sub gbNavegador_GroupBarItemSelected(sender As System.Object, e As System.EventArgs) Handles gbNavegador.GroupBarItemSelected

    End Sub

    Private Sub cboAnio_Click(sender As System.Object, e As System.EventArgs) Handles cboAnio.Click

    End Sub

    Private Sub cboAnio_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAnio.SelectedIndexChanged
        PeriodoGeneral = cboAnio.Text
        ' lblPerido.Text = cboPeriodo.Text
    End Sub

    Private Sub rbnPrincipal_Click(sender As System.Object, e As System.EventArgs) Handles rbnPrincipal.Click

    End Sub

    Private Sub btnInicio_Click(sender As System.Object, e As System.EventArgs) Handles btnInicio.Click
        InfoConfiguracion(Sys.Proceso)
        'Dim a As New frmConfigInicioXempresa(Gempresas.IdEmpresaRuc)
        'a.StartPosition = FormStartPosition.CenterParent
        'a.ShowDialog()
    End Sub

    Private Sub btnInicio_MouseLeave(sender As Object, e As System.EventArgs) Handles btnInicio.MouseLeave
        toolTip.Close()
    End Sub

    Private Sub frmMasterpmo_Activated(sender As Object, e As EventArgs) Handles Me.Activated
      
    End Sub

    Private Sub frmMasterpmo_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim Msg As MsgBoxResult
        'Msg = MsgBox("S O F T - P A C K, ¿Desea salir?", vbYesNo, "Salir del Sistema")
        'If Msg = MsgBoxResult.Yes Then
        '    MatarProceso("SMSvcHost.exe")
        '    Application.ExitThread()
        'Else
        '    Exit Sub
        'End If
        '    Close()
    End Sub

    Private Function MatarProceso(ByVal StrNombreProceso As String, _
    Optional ByVal DecirSINO As Boolean = True) As Boolean
        ' Variables para usar Wmi  
        Dim ListaProcesos As Object
        Dim ObjetoWMI As Object
        Dim ProcesoACerrar As Object

        MatarProceso = False

        ObjetoWMI = GetObject("winmgmts:")

        If ObjetoWMI Is DBNull.Value = False Then

            'instanciamos la variable  
            ListaProcesos = ObjetoWMI.InstancesOf("win32_process")

            For Each ProcesoACerrar In ListaProcesos
                If UCase(ProcesoACerrar.Name) = UCase(StrNombreProceso) Then
                    If DecirSINO Then
                        '   If MsgBox("¿Matar el proceso " & _
                        'ProcesoACerrar.Name & vbNewLine & "...¿Está seguro?", _
                        '                      vbYesNo + vbCritical) = vbYes Then
                        ProcesoACerrar.Terminate(0)
                        MatarProceso = True
                        '  End If
                    Else
                        'Matamos el proceso con el método Terminate  
                        ProcesoACerrar.Terminate(0)
                        MatarProceso = True
                    End If
                End If

            Next
        End If

        'Elimina las variables  
        ListaProcesos = Nothing
        ObjetoWMI = Nothing
    End Function


    Private Sub frmMasterpmo_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        'Dim tablaSA As New tablaDetalleSA
        'For Each i In tablaSA.GetListaTablaDetalle(10, "1")
        '    multiLineListBox1.Items.Add(i.descripcion)
        'Next
        'Dim LightBox As New frmConfigInicioXempresa
        'LightBox.SetBounds(Me.Left, Me.Top, Me.ClientRectangle.Width, Me.ClientRectangle.Height)
        'LightBox.Owner = Me
        'LightBox.StartPosition = FormStartPosition.CenterParent
        'LightBox.ShowDialog()
    End Sub

    Private Sub dgvNotificacion_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvNotificacion_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub
            'dgvNotificacion.CurrentCell = dgvNotificacion(e.ColumnIndex, e.RowIndex)
        End If
    End Sub

    'Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
    '    Dim notificacionAlmacenSA As New notificacionAlmacenSA
    '    If (dgvNotificacion.SelectedRows(0).Cells(5).Value = "NDC") Then
    '        notificacionAlmacenSA.DeleteNotificacion(dgvNotificacion.SelectedRows(0).Cells(0).Value)
    '        Me.dgvNotificacion.Rows.Remove(Me.dgvNotificacion.CurrentRow)
    '    ElseIf (dgvNotificacion.SelectedRows(0).Cells(5).Value = "NS") Then
    '        With frmAlmacenTransfenciaSobrante
    '            .txtSerie.Text = dgvNotificacion.SelectedRows(0).Cells(7).Value
    '            .txtNumero.Text = dgvNotificacion.SelectedRows(0).Cells(6).Value
    '            .txtProveedor.Text = dgvNotificacion.SelectedRows(0).Cells(4).Value
    '            .idDocNotificacion = dgvNotificacion.SelectedRows(0).Cells(0).Value
    '            .lblPerido.Text = PeriodoGeneral
    '            .UbicarDocumento(dgvNotificacion.SelectedRows(0).Cells(7).Value, dgvNotificacion.SelectedRows(0).Cells(6).Value, dgvNotificacion.SelectedRows(0).Cells(8).Value)
    '            .ShowDialog()
    '        End With
    '    End If
    'End Sub

    Private Sub frmMasterpmo_Shown(sender As Object, e As EventArgs) Handles Me.Shown
      
        'CargarConfiguracionInicio(Gempresas.IdEmpresaRuc)
        'Dim config As New frmConfigInicioXempresa
        'config.StartPosition = FormStartPosition.CenterParent
        'config.ShowDialog()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.WaitCursor
        With frmMasterLibro
            .WindowState = FormWindowState.Maximized
            .StartPosition = FormStartPosition.CenterParent
            .Show()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub ButtonAdv1_Click_1(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Me.Cursor = Cursors.WaitCursor
        With frmMasterLibro
            .WindowState = FormWindowState.Maximized
            .StartPosition = FormStartPosition.CenterParent
            .Show()
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Dim f As New frmNuevoProyectoGeneral
        f.Manipulacion = ENTITY_ACTIONS.INSERT
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        GetProyectosGeneralesCMB()
    End Sub

    Private Sub ButtonAdv3_Click(sender As Object, e As EventArgs) Handles ButtonAdv3.Click
        Me.Cursor = Cursors.WaitCursor
        With frmNuevoCosto
            .IdProyectoGeneral = cboProyGeneral.SelectedValue
            .cboTipo.Text = "HOJA DE COSTO"
            '.cboSubtipo.Text = "HC - CONSTRUC. Y SIMILARES"
            .cboSubtipo.Enabled = True
            .GetCuentaMax(New cuentaplanContableEmpresa With {.idEmpresa = Gempresas.IdEmpresaRuc, .cuenta = "92"})
            .Manipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
            'cboProyGeneral_SelectedIndexChanged(sender, e)
        End With
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub cboProyGeneral_Click(sender As Object, e As EventArgs) Handles cboProyGeneral.Click

    End Sub

    Private Sub cboProyGeneral_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboProyGeneral.SelectedIndexChanged
        Dim sa As New recursoCostoSA
        Dim cod = cboProyGeneral.SelectedValue
        If Not IsNothing(cod) Then
            If cod.ToString.Trim.Length > 0 Then
                ProyectoGeneralSel = sa.GetCostoById(New recursoCosto With {.idCosto = cboProyGeneral.SelectedValue})
            End If

        End If
    End Sub

    Private Sub ButtonAdv4_Click(sender As Object, e As EventArgs) Handles ButtonAdv4.Click
        Dim f As New frmProyectoConstruccion
        f.StartPosition = FormStartPosition.CenterScreen
        f.Creacion = "PROYECTO"
        f.Show()
    End Sub

    Private Sub ButtonAdv5_Click(sender As Object, e As EventArgs) Handles ButtonAdv5.Click
        If cboProyGeneral.Text.Trim.Length > 0 Then
            Dim f As New frmProyectoConstruccion
            f.Manipulacion = ENTITY_ACTIONS.INSERT
            f.StartPosition = FormStartPosition.CenterParent
            f.txtNuevoCosto.Text = cboProyGeneral.Text
            f.txtIdProyecto.Text = cboProyGeneral.SelectedValue
            f.Creacion = "SUBPROYECTO"
            f.txtNuevoCosto.ReadOnly = True

            f.ShowDialog()
        Else
            MessageBox.Show("Seleccione un Proyecto para poder crear subproyectos")
        End If
    End Sub
End Class