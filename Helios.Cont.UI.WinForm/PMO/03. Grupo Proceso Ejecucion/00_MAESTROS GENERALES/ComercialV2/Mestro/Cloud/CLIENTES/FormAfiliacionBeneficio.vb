Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms

Public Class FormAfiliacionBeneficio
#Region "Attributes"
    Dim thread As System.Threading.Thread
    Public Property entidadSA As New entidadSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of entidad))
    Public Property listaClientes As New List(Of entidad)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ConfiguracionInicio()
        threadClientes()
    End Sub

    Public Sub New(be As entidad)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ConfiguracionInicio()
        threadClientes()
    End Sub

#End Region

#Region "Entidad"
    Private Sub threadClientes()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        ProgressBar2.Visible = True
        ProgressBar2.Style = ProgressBarStyle.Marquee
        thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista As New List(Of entidad)
        lista = New List(Of entidad)
        Dim varios = entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, String.Empty, GEstableciento.IdEstablecimiento)
        'Dim lista = entidadSA.ObtenerListaEntidad(tipo, empresa)
        lista.Add(varios)
        lista.AddRange(entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipo, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of entidad)
            listaClientes = lista
            ProgressBar2.Visible = False
        End If
    End Sub
#End Region

#Region "Methods"
    Private Sub ConfiguracionInicio()
        txtFecha.Value = DateTime.Now
    End Sub

    Private Sub EnviarSolicitud()
        Dim afiliacionSA As New EntidadAfiliacionBeneficioSA

        Dim afiliacion As New EntidadAfiliacionBeneficio With
        {
        .idEntidad = TXTcOMPRADOR.Tag,
        .fechaPedido = txtFecha.Value,
        .notas = TextNotas.Text,
        .status = StatusAfiliacionBeneficiosCliente.Pendiente
        }

        afiliacionSA.EntidadAfiliacionBeneficioSave(afiliacion)
        MessageBox.Show("Solicitud enviada!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
#End Region

#Region "Events"
    Private Sub TXTcOMPRADOR_TextChanged(sender As Object, e As EventArgs) Handles TXTcOMPRADOR.TextChanged
        TXTcOMPRADOR.ForeColor = Color.Black
        TXTcOMPRADOR.Tag = Nothing
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Me.Cursor = Cursors.WaitCursor

        If e.PopupCloseType = PopupCloseType.Done Then
            If LsvProveedor.SelectedItems.Count > 0 Then
                If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                    Dim f As New frmCrearENtidades
                    f.CaptionLabels(0).Text = "Nuevo cliente"
                    f.strTipo = TIPO_ENTIDAD.CLIENTE
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If Not IsNothing(f.Tag) Then
                        Dim c = CType(f.Tag, entidad)
                        listaClientes.Add(c)
                        TXTcOMPRADOR.Text = c.nombreCompleto
                        txtruc.Text = c.nrodoc
                        TXTcOMPRADOR.Tag = c.idEntidad
                        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        txtruc.Visible = True
                        TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    End If
                Else
                    TXTcOMPRADOR.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                    TXTcOMPRADOR.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                    TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                    txtruc.Visible = True
                End If
                'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
            End If
        End If

        'Set focus back to textbox.
        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
            Me.TXTcOMPRADOR.Focus()
        End If
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTcOMPRADOR.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TXTcOMPRADOR.Text) Or n.nrodoc.StartsWith(TXTcOMPRADOR.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            LsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.pcLikeCategoria.IsShowing() Then
                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of entidad))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick, TXTcOMPRADOR.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub btOperacion_Click(sender As Object, e As EventArgs) Handles btOperacion.Click

        If TXTcOMPRADOR.Text.Trim.Length = 0 Then
            MessageBox.Show("Ingrese un cliente", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then

        Else
            MessageBox.Show("Ingrese un cliente válido", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        EnviarSolicitud()
    End Sub
#End Region

End Class