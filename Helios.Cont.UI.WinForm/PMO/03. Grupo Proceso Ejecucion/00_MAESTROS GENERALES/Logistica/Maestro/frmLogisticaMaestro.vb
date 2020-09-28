Imports System.ComponentModel
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Tools
Public Class frmLogisticaMaestro

#Region "Attributes"
    Property Model As New MDIPrincipalModelLogistica
    Private lblEmpresa As ToolStripLabel
    Private btnNotify As ToolStripSplitButton
    Private btnConfig As ToolStripButton
    'Public Property lblCenter As Label
    Public Property tool As ToolStripMenuItem
    Public conteoEnTransito As Integer = 0
    Public conteoStockMinimo As Integer = 0
    Public conteoArticulosSinPrecio As Integer = 0
    Dim totalSA As New TotalesAlmacenSA
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'lblCenter = New Label
        bg.WorkerSupportsCancellation = True
        FormatearControles()
        CargarArbolOpciones()
        ConfiguracionInicio()
        sbPrincipal.BackColor = Color.FromArgb(28, 154, 200)
        rbnPrincipal.BackColor = Color.White
        WindowState = FormWindowState.Maximized
    End Sub
#End Region

#Region "Methods"
    Private Sub tool_MouseEnter(sender As Object, e As EventArgs)
        btnNotify.ShowDropDown()
    End Sub

    'Public Function GetCountDetracciones() As Integer
    '    Dim compraSA As New DocumentoCompraSA

    '    Dim compra = compraSA.GetConteoDetracciones(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc, .idCentroCosto = GEstableciento.IdEstablecimiento,
    '                                               .fechaContable = String.Concat(cboMes.SelectedValue, "/", txtAnio.Text), .tieneDetraccion = "S"})
    '    lblCenter = New Label
    '    lblCenter.Text = compra

    '    'lblCenter = New Label
    '    'lblCenter.ForeColor = Color.White
    '    'lblCenter.AutoSize = True
    '    lblCenter.Font = New Font("Segoe UI", 10, FontStyle.Regular)

    'End Function

    Public Function ConteoProductosSinPrecio() As Integer
        Dim totales As New List(Of totalesAlmacen)
        totales = totalSA.NumProductosSinListaPrecio(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                     .idEstablecimiento = GEstableciento.IdEstablecimiento})

        Return totales.Count
    End Function

    Private Function GetCountExistenciaTransito() As Integer
        Dim compraSA As New DocumentoCompraSA


        Return compraSA.GetCountExistenciaTransito(New documentocompra With {.idEmpresa = Gempresas.IdEmpresaRuc,
                                                                                       .idCentroCosto = GEstableciento.IdEstablecimiento,
                                                                                       .tipoCompra = TIPO_COMPRA.COMPRA})

    End Function

    Private Sub GetAlertaCompleted()
        'lblCenter.ForeColor = ColorTranslator.FromHtml("#FF62B7E2")
        If conteoEnTransito > 0 Then
            tool = New ToolStripMenuItem
            tool.BackColor = Color.White
            tool.Name = "btEnTransito"
            tool.Font = New Font("Ebrima", 8.5, FontStyle.Regular)
            tool.Text = "Inventario en tránsito: " & conteoEnTransito
            btnNotify.DropDownItems.Add(tool)
        End If

        If conteoStockMinimo > 0 Then
            tool = New ToolStripMenuItem
            tool.BackColor = Color.White
            tool.Name = "btStockMinimo"
            tool.Font = New Font("Ebrima", 8.5, FontStyle.Regular)
            tool.Text = "Stock con mínima cantidad: " & conteoStockMinimo
            btnNotify.DropDownItems.Add(tool)
        End If

        If conteoArticulosSinPrecio > 0 Then
            tool = New ToolStripMenuItem
            tool.BackColor = Color.White
            tool.Name = "btAlertaPrecios"
            tool.Font = New Font("Ebrima", 8.5, FontStyle.Regular)
            tool.Text = "Artículos sin precio definido: " & conteoArticulosSinPrecio
            btnNotify.DropDownItems.Add(tool)
        End If
        btnNotify.Text = conteoEnTransito + conteoStockMinimo + conteoArticulosSinPrecio
        btnNotify.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) ' ColorTranslator.FromHtml("#FF62B7E2")
    End Sub

    Public Function GetInventarioEnAlertaConteo(be As totalesAlmacen) As Integer
        Return totalSA.GetAlertaIventarioMinimoConteo(be)
    End Function

    Private Sub GetAlertas()
        conteoEnTransito = GetCountExistenciaTransito()
        conteoStockMinimo = GetInventarioEnAlertaConteo(New totalesAlmacen With {.idEmpresa = Gempresas.IdEmpresaRuc})
        conteoArticulosSinPrecio = ConteoProductosSinPrecio()
    End Sub

    Private Sub ConfiguracionInicio()
        rbnPrincipal.QuickPanelVisible = True

        rbnPrincipal.MenuButtonDropDown = ContextMenuStripEx1
        lblEmpresa = New ToolStripLabel()

        btnNotify = New ToolStripSplitButton ' New ToolStripButton()
        ' btnNotify.BackColor = Color.White
        btnNotify.Text = "0"
        btnNotify.Image = imageListAdv1.Images(13)
        btnNotify.ToolTipText = "Notificaciones."
        btnNotify.Font = New Font("Segoe UI", 8)


        btnConfig = New ToolStripButton()
        btnConfig.Text = ""
        btnConfig.Image = imageListAdv1.Images(14)
        btnConfig.ToolTipText = "Configuración de Inicio."
        btnConfig.Font = New Font("Segoe UI", 8)

        ' Set the text and DisplayStyle property.
        lblEmpresa.Text = Space(15) & Gempresas.IdEmpresaRuc & ", " & Gempresas.NomEmpresa
        lblEmpresa.Enabled = False
        lblEmpresa.DisplayStyle = ToolStripItemDisplayStyle.Text
        lblEmpresa.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
        lblEmpresa.Font = New Font("Corbel", 9, FontStyle.Regular)

        ' Add the toolstripbutton in the header of the RibbonControlAdv.
        rbnPrincipal.Header.AddQuickItem(lblEmpresa) 'ToolStripSeparator1
        rbnPrincipal.Header.AddQuickItem(ToolStripSeparator1)
        rbnPrincipal.Header.AddQuickItem(btnNotify)
        rbnPrincipal.Header.AddQuickItem(btnConfig)
        rbnPrincipal.Header.AddQuickItem(btnAnio)
        rbnPrincipal.Header.AddQuickItem(cboAnio)

        'AddHandler btnNotify.Click, AddressOf TS1clickevent
        'AddHandler btnConfig.Click, AddressOf btn_ClicConfig
        AddHandler btnNotify.MouseEnter, AddressOf tool_MouseEnter
        If bg.IsBusy <> True Then
            ' Start the asynchronous operation.
            bg.RunWorkerAsync()
        End If
    End Sub

    Public Sub CargarArbolOpciones()
        Dim listaCategorias As New List(Of Modulo)
        listaCategorias = New List(Of Modulo)
        listaCategorias = Model.Modulos.Where(Function(o) o.TipoModulo = Modulo.ModuloTipo.Categoria).OrderBy(Function(o) o.Orden).ToList
        Dim Categoria As GroupBarItem
        Dim ArbolOpciones As New TreeViewAdv
        Dim Nodo As TreeNodeAdv
        Dim listaNiveles As List(Of Modulo)
        Dim Temporal As New Dictionary(Of Int32, TreeNodeAdv)
        Dim item As New Modulo

        '   If Not IsNothing(config) Then
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
            Select Case item.Descripcion
                Case "Inventario"

            End Select

        Next

        ' Dim myCompra As System.Drawing.Image = My.Resources.icono_new_documento
        'imageListAdv1.Images.Add(myCompra) '0

        Me.ImageListAdv2.ToImageList().ColorDepth = ColorDepth.Depth32Bit
        gbNavegador.GroupBarItems(0).Image = Me.ImageListAdv2.Images(0)
        gbNavegador.GroupBarItems(1).Image = Me.ImageListAdv2.Images(1)
        gbNavegador.GroupBarItems(2).Image = Me.ImageListAdv2.Images(2)
        gbNavegador.GroupBarItems(3).Image = Me.ImageListAdv2.Images(3)
        gbNavegador.GroupBarItems(4).Image = Me.ImageListAdv2.Images(4)
        gbNavegador.GroupBarItems(5).Image = Me.ImageListAdv2.Images(5)
        'gbNavegador.GroupBarItems(6).Image = Me.imageListAdv1.Images(13)
        'gbNavegador.GroupBarItems(4).Image = Me.imageListAdv1.Images(16)
        'gbNavegador.GroupBarItems(5).Image = Me.imageListAdv1.Images(15)
        'gbNavegador.GroupBarItems(6).Image = Me.imageListAdv1.Images(17)
        'gbNavegador.GroupBarItems(7).Image = Me.imageListAdv1.Images(19)
        'Else
        '    '   MessageBoxAdv.Show("Tiene que establecer la configuración de inicio.!")
        'End If
        'Dim lbl As New Label
        'ArbolOpciones.Nodes(8).Nodes(0).CustomControl = lbl
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
            .HeaderBackColor = Color.LavenderBlush '  Color.WhiteSmoke ' Color.FromArgb(230, 240, 250) 

            .StackedMode = True
            .TextAlign = TextAlignment.Left
            .BorderStyle = BorderStyle.FixedSingle
            .CollapsedText = "Panel Logistico"
            .Font = New Font("Corbel", 8, FontStyle.Regular)
            .ForeColor = Color.FromKnownColor(KnownColor.Black) ' Color.Black
            .HeaderFont = New Font("Segoe UI", 7.25, FontStyle.Bold)
            .HeaderForeColor = Color.Black  ' Color.Black
            .HeaderHeight = 30
            .GroupBarItemHeight = 25
            .ShowChevron = False
        End With
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
                modulo = DirectCast(nodo.Tag, Modulo)
                CargarModuloSeleccionado(modulo)
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

                Me.tabMDImgr.TabStyle = GetType(TabRendererMetro)
                tabMDImgr.ThemesEnabled = True
                '    Me.tabMDImgr.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.OneNoteStyleRenderer)
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

    Public Sub FormatearArbolNavegacion(ByVal item As TreeViewAdv)
        item.ShowLines = False
    End Sub

    Private Sub bg_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bg.DoWork
        GetAlertas()
    End Sub

    Private Sub bg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bg.RunWorkerCompleted
        GetAlertaCompleted()
    End Sub

    Private Sub frmLogisticaMaestro_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bg.WorkerSupportsCancellation = True Then
            ' Cancel the asynchronous operation.
            bg.CancelAsync()
        End If
    End Sub

#End Region

End Class