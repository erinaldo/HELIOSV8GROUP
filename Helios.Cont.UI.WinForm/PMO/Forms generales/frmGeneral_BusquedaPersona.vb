Imports Helios.Seguridad.Business.Entity
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Helios.General.Constantes
Imports Syncfusion.Windows.Forms
Public Class frmGeneral_BusquedaPersona

#Region "Attributes"
    Public Property ListadoProveedores As New List(Of Usuario)
    Public Property UsuarioSA As New UsuarioSA
    Public Property statusEntidad As String
    Public Property lista As New List(Of Usuario)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'statusEntidad = tipoEntidad
        txtPersona.Enabled = True
        ListadoProveedores = New List(Of Usuario)
        ListadoProveedores = UsuarioSA.ListadoUsuariosXcliente(Gempresas.IDCliente)
        TextBoxExt1.Focus()
        TextBoxExt1.Select()
        columnas()
    End Sub
#End Region

#Region "Methods"
    Sub columnas()
        lsvListadoItems.Columns.Add("", 20, HorizontalAlignment.Center)
        lsvListadoItems.Columns.Add("DNI", 80, HorizontalAlignment.Left)
        lsvListadoItems.Columns.Add("Nombre completo", 200, HorizontalAlignment.Left)
        lsvListadoItems.Columns(0).DisplayIndex = lsvListadoItems.Columns.Count - 1
    End Sub


    Sub LlenarLSV(lista As List(Of Usuario))
        lsvListadoItems.Items.Clear()
        'lsvListadoItems.View = View.Details
        'lsvListadoItems.CheckBoxes = True


        For Each i In lista
            Dim n As New ListViewItem(i.IDUsuario)
            n.SubItems.Add(i.NroDocumento)
            n.SubItems.Add(i.Nombres + " " + i.ApellidoPaterno + " " + i.ApellidoMaterno)
            'n.SubItems.Add("Seleccion")
            lsvListadoItems.Items.Add(n)

        Next

        'ListView1.View = View.Details
        'ListView1.CheckBoxes = True

        'ListView1.Columns.Add("Pagado", 100, HorizontalAlignment.Center)
        'ListView1.Columns.Add("Cedula", 150, HorizontalAlignment.Center)
        'ListView1.Columns.Add("Nombre completo", 250, HorizontalAlignment.Center)
        'ListView1.Columns(0).DisplayIndex = ListView1.Columns.Count - 1
        'Dim con = (ListadoProveedores.Where(Function(s) s.Nombres.StartsWith(txtPersona.Text))).ToList()
        'ListView1.Items.Clear()
        'For Each i In con
        '    Dim n As New ListViewItem(i.IDUsuario)
        '    n.SubItems.Add(i.NroDocumento)
        '    n.SubItems.Add(i.Nombres + " " + i.ApellidoPaterno + " " + i.ApellidoMaterno)
        '    'n.SubItems.Add("Seleccion")
        '    ListView1.Items.Add(n)

        'Next

    End Sub
#End Region

#Region "Events"
    Private Sub txtProveedor_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPersona.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Dim con = (ListadoProveedores.Where(Function(s) s.Nombres.StartsWith(txtPersona.Text))).ToList()
            If con.Count > 0 Then
                LlenarLSV(con)
            End If
        End If
        If e.KeyCode = Keys.Down Then
            txtPersona.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            txtPersona.Clear()
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

            Dim con = (ListadoProveedores.Where(Function(s) s.NroDocumento.StartsWith(TextBoxExt1.Text))).ToList()
            If (con.Count > 0) Then

                LlenarLSV(con)
                itmx = lsvListadoItems.FindItemWithText(TextBoxExt1.Text)
                itmx.Selected = True
                itmx.EnsureVisible()

            Else
                MessageBoxAdv.Show("No existe persona", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

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
        'If lsvListadoItems.SelectedItems.Count > 0 Then

        '    Dim usuarioID As New Usuario

        '    With usuarioID
        '        .IDUsuario = lsvListadoItems.SelectedItems.Item(0).SubItems(0).Text
        '    End With


        '    usuarioID = UsuarioSA.UbicarUsuarioXid(usuarioID)
        '    Tag = usuarioID
        '    Close()
        'End If
    End Sub

    Private Sub txtProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtPersona.TextChanged

    End Sub

#End Region

    Private Sub frmGeneral_BusquedaPersona_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    public Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        'lsvListadoItems.Items.Clear()
        For Each item As ListViewItem In lsvListadoItems.Items

            If item.Checked = True Then

                Dim usuarioID As New Usuario

                With usuarioID
                    .IDUsuario = item.SubItems(0).Text
                    .Nombres = item.SubItems(2).Text
                    .NroDocumento = item.SubItems(1).Text
                End With

                'usuarioID = UsuarioSA.UbicarUsuarioXid(usuarioID)
                'Tag = usuarioID

                lista.Add(usuarioID)
            End If

        Next
        Close()
        'For Each item In lsvListadoItems.CheckedItems
        '    If item = True Then

        '        Dim usuarioID As New Usuario

        '        With usuarioID
        '            .IDUsuario = lsvListadoItems.SelectedItems.Item(0).SubItems(0).Text
        '        End With


        '        usuarioID = UsuarioSA.UbicarUsuarioXid(usuarioID)
        '        Tag = usuarioID
        '        Close()
        '    End If
        'Next

     
    End Sub
End Class