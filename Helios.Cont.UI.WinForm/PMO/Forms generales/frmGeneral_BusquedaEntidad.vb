Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms
Public Class frmGeneral_BusquedaEntidad

#Region "Attributes"
    Public Property ListadoProveedores As New List(Of entidad)
    Public Property entidadSA As New entidadSA
    Public Property statusEntidad As String
    Public Property ListaUsuario As New List(Of Seguridad.Business.Entity.Usuario)
    Public Property UsuarioSA As New Helios.Seguridad.WCFService.ServiceAccess.UsuarioSA
#End Region

#Region "Constructors"
    Public Sub New(tipoEntidad As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        statusEntidad = tipoEntidad
        txtProveedor.Enabled = True
        Select Case tipoEntidad
            Case TIPO_ENTIDAD.USUARIO
                'Dim condicion As New List(Of String)
                Dim Lista As New List(Of Seguridad.Business.Entity.Usuario)
                'condicion.Add("3")
                'condicion.Add("4")
                Lista = New List(Of Seguridad.Business.Entity.Usuario)
                'Lista = UsuarioSA.GetListaUsuarios()
                Lista = UsuarioSA.ListadoUsuariosXcliente(Gempresas.IDCliente)
                'ListaUsuario = Lista.Where(Function(o) condicion.Contains(o.Rol)).ToList
                ListaUsuario = Lista
            Case Else
                ListadoProveedores = New List(Of entidad)
                ListadoProveedores = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipoEntidad, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        End Select

        TextBoxExt1.Focus()
        TextBoxExt1.Select()
    End Sub

    Public Sub New(tipoEntidad As String, nrodoc As String)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        statusEntidad = tipoEntidad
        txtProveedor.Enabled = True
        ListadoProveedores = New List(Of entidad)
        ListadoProveedores = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipoEntidad, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
        TextBoxExt1.Text = nrodoc
        GetEventoCajaTexto()
    End Sub
#End Region

#Region "Methods"
    Sub GetEventoCajaTexto()
        Dim itmx As ListViewItem

        Dim con = (ListadoProveedores.Where(Function(s) s.nrodoc.StartsWith(TextBoxExt1.Text))).ToList()
        If (con.Count > 0) Then
            LlenarLSV(con)
            itmx = lsvListadoItems.FindItemWithText(TextBoxExt1.Text)
            itmx.Selected = True
            itmx.EnsureVisible()
        Else
            Select Case statusEntidad
                Case TIPO_ENTIDAD.PROVEEDOR
                    If MessageBoxAdv.Show("Desea crear un nuevo proveedor?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        Dim f As New frmCrearENtidades
                        f.CaptionLabels(0).Text = "Nuevo proveedor"
                        f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT

                        'f.CaptionLabels(0).Text = "Nuevo proveedor"
                        'f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                        'f.tipoPersona(TIPO_ENTIDAD.PROVEEDOR, TextBoxExt1.Text)
                        '  f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        ListadoProveedores.Clear()
                        ListadoProveedores = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.PROVEEDOR, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
                        Dim entidad2 = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(txtProveedor.Text))).ToList()
                        txtProveedor.Clear()
                        TextBoxExt1.Clear()
                        If Not IsNothing(entidad2) Then
                            LlenarLSV(entidad2)
                        End If
                        txtProveedor.Select()
                    End If
                Case TIPO_ENTIDAD.CLIENTE
                    If MessageBoxAdv.Show("Desea crear un nuevo cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                        Dim f As New frmCrearENtidades
                        f.CaptionLabels(0).Text = "Nuevo cliente"
                        f.strTipo = TIPO_ENTIDAD.CLIENTE
                        '     f.tipoPersona(TIPO_ENTIDAD.CLIENTE, TextBoxExt1.Text)
                        f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        ListadoProveedores.Clear()
                        ListadoProveedores = entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = TIPO_ENTIDAD.CLIENTE, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA})
                        Dim entidad2 = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(txtProveedor.Text))).ToList()
                        txtProveedor.Clear()
                        TextBoxExt1.Clear()
                        If Not IsNothing(entidad2) Then
                            LlenarLSV(entidad2)
                        End If
                        txtProveedor.Select()
                    End If
                Case "UC"
            End Select
        End If
    End Sub

    Sub LlenarLSV(lista As List(Of entidad))
        lsvListadoItems.Items.Clear()
        For Each i In lista
            Dim n As New ListViewItem(i.idEntidad)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.nombreCompleto)
            lsvListadoItems.Items.Add(n)
        Next
    End Sub

    Sub LlenarUsuario(lista As List(Of Seguridad.Business.Entity.Usuario))
        lsvListadoItems.Items.Clear()
        For Each i In lista
            Dim n As New ListViewItem(i.IDUsuario)
            n.SubItems.Add(i.NroDocumento)
            n.SubItems.Add(i.Nombres + " " + i.ApellidoPaterno + " " + i.ApellidoMaterno)
            lsvListadoItems.Items.Add(n)
        Next
    End Sub
#End Region

#Region "Events"
    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProveedor.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Dim con As New List(Of entidad)
            con.Add(New entidad With {.idEntidad = 0, .nombreCompleto = "Agregar nuevo"})
            Dim con2 = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(txtProveedor.Text))).ToList()

            con.AddRange(con2)
            If con.Count > 0 Then
                LlenarLSV(con)
            End If
        End If
        If e.KeyCode = Keys.Down Then
            txtProveedor.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            txtProveedor.Clear()
        End If
    End Sub

    Private Sub lsvProveedor_DrawItem(sender As Object, e As DrawItemEventArgs)
        'If e.Index Mod 2 = 0 Then
        '    e.Graphics.FillRectangle(Brushes.LightGray, e.Bounds)
        'End If
        'If lsvProveedor.SelectedIndex = e.Index Then
        '    e.Graphics.FillRectangle(Brushes.Blue, e.Bounds)
        '    e.Graphics.DrawString(lsvProveedor.Items(e.Index).ToString, Me.Font, Brushes.Black, 0, e.Bounds.Y + 2)
        'Else
        '    e.Graphics.DrawString(lsvProveedor.Items(e.Index).ToString, Me.Font, Brushes.DimGray, 0, e.Bounds.Y + 2)
        'End If
    End Sub


    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown
        Dim itmx As ListViewItem
        'If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        'If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        '    Else

        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True

            Select Case statusEntidad
                Case "UC"
                    Dim con = (ListaUsuario.Where(Function(s) s.NroDocumento.StartsWith(TextBoxExt1.Text))).ToList()
                    If (con.Count > 0) Then
                        LlenarUsuario(con)
                        itmx = lsvListadoItems.FindItemWithText(TextBoxExt1.Text)
                        itmx.Selected = True
                        itmx.EnsureVisible()
                    Else
                        Select Case statusEntidad
                            Case TIPO_ENTIDAD.PERSONAL_PLANILLA

                        End Select
                    End If

                Case Else
                    Dim con As New List(Of entidad)
                    con.Add(New entidad With {.idEntidad = 0, .nombreCompleto = "Agregar nuevo"})
                    Dim con2 = (ListadoProveedores.Where(Function(s) s.nrodoc.StartsWith(TextBoxExt1.Text))).ToList()
                    con.AddRange(con2)
                    If (con.Count > 0) Then
                        LlenarLSV(con)
                        itmx = lsvListadoItems.FindItemWithText(TextBoxExt1.Text)
                        itmx.Selected = True
                        itmx.EnsureVisible()
                    Else
                        Select Case statusEntidad
                            Case TIPO_ENTIDAD.PROVEEDOR
                                'If MessageBoxAdv.Show("Desea crear un nuevo proveedor?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                                '    Dim f As New frmCrearENtidades
                                '    f.CaptionLabels(0).Text = "Nuevo proveedor"
                                '    f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                                '    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT

                                '    'f.CaptionLabels(0).Text = "Nuevo proveedor"
                                '    'f.strTipo = TIPO_ENTIDAD.PROVEEDOR
                                '    'f.tipoPersona(TIPO_ENTIDAD.PROVEEDOR, TextBoxExt1.Text)
                                '    '  f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                '    f.StartPosition = FormStartPosition.CenterParent
                                '    f.ShowDialog()
                                '    ListadoProveedores.Clear()
                                '    ListadoProveedores = entidadSA.ObtenerListaEntidad(TIPO_ENTIDAD.PROVEEDOR, Gempresas.IdEmpresaRuc)
                                '    Dim entidad2 = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(txtProveedor.Text))).ToList()
                                '    txtProveedor.Clear()
                                '    TextBoxExt1.Clear()
                                '    If Not IsNothing(entidad2) Then
                                '        LlenarLSV(entidad2)
                                '    End If
                                '    txtProveedor.Select()
                                'End If
                            Case TIPO_ENTIDAD.CLIENTE
                                'If MessageBoxAdv.Show("Desea crear un nuevo cliente?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
                                '    Dim f As New frmCrearENtidades
                                '    f.CaptionLabels(0).Text = "Nuevo cliente"
                                '    f.strTipo = TIPO_ENTIDAD.CLIENTE
                                '    '     f.tipoPersona(TIPO_ENTIDAD.CLIENTE, TextBoxExt1.Text)
                                '    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                                '    f.StartPosition = FormStartPosition.CenterParent
                                '    f.ShowDialog()
                                '    ListadoProveedores.Clear()
                                '    ListadoProveedores = entidadSA.ObtenerListaEntidad(TIPO_ENTIDAD.CLIENTE, Gempresas.IdEmpresaRuc)
                                '    Dim entidad2 = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(txtProveedor.Text))).ToList()
                                '    txtProveedor.Clear()
                                '    TextBoxExt1.Clear()
                                '    If Not IsNothing(entidad2) Then
                                '        LlenarLSV(entidad2)
                                '    End If
                                '    txtProveedor.Select()
                                'End If
                        End Select
                    End If
            End Select



        End If
        'End If
        'End If

        If e.KeyCode = Keys.Down Then
            TextBoxExt1.Focus()
        End If
        If e.KeyCode = Keys.Escape Then
            TextBoxExt1.Clear()
        End If
    End Sub

    Private Sub lsvListadoItems_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvListadoItems.MouseDoubleClick
        If lsvListadoItems.SelectedItems.Count > 0 Then
            Select Case statusEntidad
                Case TIPO_ENTIDAD.USUARIO
                    Dim obj = UsuarioSA.UbicarUsuarioXid(New Helios.Seguridad.Business.Entity.Usuario With {.IDUsuario = lsvListadoItems.SelectedItems.Item(0).SubItems(0).Text})
                    Tag = obj
                    Close()
                Case Else
                    If statusEntidad = TIPO_ENTIDAD.CLIENTE Then
                        If lsvListadoItems.SelectedItems.Item(0).SubItems(2).Text = "Agregar nuevo" Then
                            Dim f As New frmCrearENtidades
                            f.CaptionLabels(0).Text = "Nuevo cliente"
                            f.strTipo = TIPO_ENTIDAD.CLIENTE
                            f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                            'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog()
                            If Not IsNothing(f.Tag) Then
                                Dim c = CType(f.Tag, entidad)
                                ListadoProveedores.Add(c)
                                txtProveedor.Text = c.nombreCompleto
                                Dim con = (ListadoProveedores.Where(Function(s) s.nombreCompleto.StartsWith(txtProveedor.Text))).ToList()
                                If con.Count > 0 Then
                                    LlenarLSV(con)
                                End If
                            End If
                        Else
                            Dim obj = entidadSA.UbicarEntidadPorID(lsvListadoItems.SelectedItems.Item(0).SubItems(0).Text).FirstOrDefault
                            Tag = obj
                            Close()
                        End If
                    End If



            End Select

        End If
    End Sub

    Private Sub TextBoxExt1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxExt1.TextChanged

    End Sub

    Private Sub lsvListadoItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvListadoItems.SelectedIndexChanged

    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtProveedor.TextChanged

    End Sub

#End Region
End Class