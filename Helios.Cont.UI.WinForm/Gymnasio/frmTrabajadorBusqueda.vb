Imports Helios.General.Constantes
Imports Helios.Planilla.WCFService.ServiceAccess
Imports Helios.Planilla.Business.Entity
Imports Syncfusion.Windows.Forms
Public Class frmTrabajadorBusqueda

#Region "Attributes"
    Public Property ListadoTrabajadores As New List(Of Personal)
    Public Property entidadSA As New PersonalSA
    Public Property statusEntidad As String
#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        txtTrabajador.Enabled = True
        ListadoTrabajadores = New List(Of Personal)
        ListadoTrabajadores = entidadSA.PersonalSelxEstado(New Personal With {.Action = BaseBE.EntityAction.INSERT})
        TextBoxExt1.Focus()
        TextBoxExt1.Select()
    End Sub

#End Region

#Region "Méthods"
    Sub LlenarLSV(lista As List(Of Personal))
        lsvListadoTrab.Items.Clear()
        For Each i In lista
            Dim n As New ListViewItem(i.IDPersonal)
            n.SubItems.Add(i.Numerodocumento)
            n.SubItems.Add(i.FullName)
            lsvListadoTrab.Items.Add(n)
        Next
    End Sub
#End Region

#Region "Events"
    Private Sub txtTrabajador_TextChanged(sender As Object, e As EventArgs) Handles txtTrabajador.TextChanged

    End Sub

    Private Sub txtTrabajador_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTrabajador.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Dim con = (ListadoTrabajadores.Where(Function(s) s.TipoTrabajador = statusEntidad And s.FullName.StartsWith(txtTrabajador.Text))).ToList()
            If con.Count > 0 Then
                LlenarLSV(con)
            End If
        End If
        If e.KeyCode = Keys.Down Then
            txtTrabajador.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            txtTrabajador.Clear()
        End If
    End Sub

    Private Sub lsvListadoTrab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvListadoTrab.SelectedIndexChanged

    End Sub

    Private Sub lsvListadoTrab_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvListadoTrab.MouseDoubleClick
        If lsvListadoTrab.SelectedItems.Count > 0 Then
            Dim obj = entidadSA.PersonalSel(New Personal With {.IDPersonal = lsvListadoTrab.SelectedItems.Item(0).SubItems(0).Text})
            Tag = obj
            Close()
        End If
    End Sub

    Private Sub frmTrabajadorBusqueda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Dim f As New frmNuevoTrabajador(statusEntidad, Gempresas.IdEmpresaRuc)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog()
        ListadoTrabajadores = entidadSA.PersonalSelxEstado(New Personal With {.Action = BaseBE.EntityAction.INSERT})
    End Sub
#End Region

    Private Sub TextBoxExt1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxExt1.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.[End] Then
        Else
            Dim con = (ListadoTrabajadores.Where(Function(s) s.Numerodocumento.StartsWith(TextBoxExt1.Text))).ToList()
            If con.Count > 0 Then
                LlenarLSV(con)
            End If
        End If
        If e.KeyCode = Keys.Down Then
            txtTrabajador.Focus()
        End If

        If e.KeyCode = Keys.Escape Then
            txtTrabajador.Clear()
        End If
    End Sub
End Class