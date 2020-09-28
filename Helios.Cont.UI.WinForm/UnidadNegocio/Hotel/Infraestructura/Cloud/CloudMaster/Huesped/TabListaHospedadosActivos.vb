Imports System.IO
Imports System.Threading
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.Presentation.WinForm
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports Syncfusion.GridHelperClasses
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping

Public Class TabListaHospedadosActivos

    Public InfraestructuraID As Integer
    Protected Friend Delegate Sub SetDataSourceDelegate(ByVal table As DataTable)

    Public Alert As Alert
    Dim lis As New ListBox
    Dim lvitem As ListViewItem
    Private Const FormatoFecha As String = "hh-mm-ss"
    Dim listaInfraestructura As New List(Of infraestructura)
    Public Property listaClientes As New List(Of personaBeneficio)
    Dim thread As System.Threading.Thread
    Public Property entidadSA As New personaBeneficioSA
    Friend Delegate Sub SetDataSourceDelegateEntidad(ByVal lista As List(Of personaBeneficio))

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        FormatoGridAvanzado(dgvPedidoDetalle, False, False, 11.5F)
        threadClientes()
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of personaBeneficio))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idPersonaBeneficio)

            n.SubItems.Add(i.nombrePersona)
            n.SubItems.Add(i.nroDocumento.GetValueOrDefault)
            n.SubItems.Add(i.estado)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Public Sub threadClientes()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista As New List(Of personaBeneficio)
        lista = New List(Of personaBeneficio)

        Dim personsBE As New personaBeneficio
        personsBE.idEmpresa = Gempresas.IdEmpresaRuc
        personsBE.idEstablecimiento = GEstableciento.IdEstablecimiento

        lista.AddRange(entidadSA.ListarPersonaFull(personsBE))
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of personaBeneficio))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegateEntidad(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of personaBeneficio)
            listaClientes = lista

            'txtruc.Text = lista(0).nrodoc
            'TXTcOMPRADOR.Tag = lista(0).idEntidad
            'TXTcOMPRADOR.Text = lista(0).nombreCompleto
            'TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            'txtruc.Visible = True

            'ProgressBar1.Visible = False
        End If
    End Sub



    Private Sub TXTcOMPRADOR_TextChanged(sender As Object, e As EventArgs) Handles TXTcOMPRADOR.TextChanged
        TXTcOMPRADOR.ForeColor = Color.Black
        TXTcOMPRADOR.Tag = Nothing
        If TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub TXTcOMPRADOR_KeyDown(sender As Object, e As KeyEventArgs) Handles TXTcOMPRADOR.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then
            Me.pcLikeCategoria.Size = New Size(319, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            'Dim consulta As New List(Of entidad)
            'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})


            Dim consulta2 = (From n In listaClientes
                             Where n.nombrePersona.StartsWith(TXTcOMPRADOR.Text)).ToList

            'consulta.AddRange(consulta2)
            FillLSVClientes(consulta2)


        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TXTcOMPRADOR
            Me.pcLikeCategoria.ShowPopup(Point.Empty)

            'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})


            Dim consulta2 = (From n In listaClientes
                             Where n.nombrePersona.StartsWith(TXTcOMPRADOR.Text)).ToList



            FillLSVClientes(consulta2)
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

    Private Sub LsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub PcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Dim beneficioSA As New beneficioSA
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If LsvProveedor.SelectedItems.Count > 0 Then
                    'If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                    '    Dim f As New frmCrearENtidades
                    '    f.CaptionLabels(0).Text = "Nuevo cliente"
                    '    f.strTipo = TIPO_ENTIDAD.CLIENTE
                    '    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    '    'f.tipoPersona(TIPO_ENTIDAD.CLIENTE)
                    '    f.StartPosition = FormStartPosition.CenterParent
                    '    f.ShowDialog()
                    '    If Not IsNothing(f.Tag) Then
                    '        Dim c = CType(f.Tag, entidad)
                    '        listaClientes.Add(c)
                    '        'txtTipoDocClie.Text = c.tipoDoc
                    '        TXTcOMPRADOR.Text = c.nombreCompleto
                    '        txtruc.Text = c.nrodoc
                    '        TXTcOMPRADOR.Tag = c.idEntidad
                    '        txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    '        txtruc.Visible = True
                    '        TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    '    End If
                    'Else
                    TXTcOMPRADOR.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                    TXTcOMPRADOR.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                    TXTcOMPRADOR.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                    txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                    'txtTipoDocClie.Text = LsvProveedor.SelectedItems(0).SubItems(3).Text
                    txtruc.Visible = True

                    'GetTableDetalle()



                    'End If

                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TXTcOMPRADOR.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub GetTableDetalle()
        Try

            Dim personaBeneficioSA As New personaBeneficioSA
            Dim personaBeneficioBE As New personaBeneficio
            Dim dt As New DataTable

            personaBeneficioBE.idEmpresa = Gempresas.IdEmpresaRuc
            personaBeneficioBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            personaBeneficioBE.estado = "A"

            With dt.Columns
                .Add("ID")
                .Add("fecha")
                .Add("dni")
                .Add("nombre")
                .Add("sexo")
                .Add("nacionalidad")
                .Add("idhabitacion")
                .Add("habitacion")
                .Add("uso")
            End With

            For Each i In personaBeneficioSA.ListarPersonaBeneficioXHabitacionActivo(personaBeneficioBE) '.Where(Function(o) tables.Contains(o.idtabla)).ToList
                dt.Rows.Add(i.idPersonaBeneficio, i.fechaActualizacion, i.nroDocumento, i.nombrePersona, i.sexo, i.nacionalidad, i.idDocumento, i.nombreHabitacion, i.estado)
            Next

            dgvPedidoDetalle.DataSource = dt
            dgvPedidoDetalle.TableDescriptor.Columns("nombre").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvPedidoDetalle.TableDescriptor.Columns("nombre").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetTableDetalle(ID As Integer)
        Try
            Dim personaBeneficioSA As New personaBeneficioSA
            Dim personaBeneficioBE As New personaBeneficio
            Dim dt As New DataTable

            personaBeneficioBE.idEmpresa = Gempresas.IdEmpresaRuc
            personaBeneficioBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            personaBeneficioBE.idPersonaBeneficio = ID
            personaBeneficioBE.listaEstado = New List(Of String)
            personaBeneficioBE.listaEstado.Add("C")
            personaBeneficioBE.listaEstado.Add("A")

            With dt.Columns
                .Add("ID")
                .Add("fecha")
                .Add("dni")
                .Add("nombre")
                .Add("sexo")
                .Add("nacionalidad")
                .Add("idhabitacion")
                .Add("habitacion")
                .Add("uso")
            End With

            For Each i In personaBeneficioSA.ListarPersonaBeneficio(personaBeneficioBE) '.Where(Function(o) tables.Contains(o.idtabla)).ToList
                dt.Rows.Add(i.idPersonaBeneficio, i.fechaActualizacion, i.nroDocumento, i.nombrePersona, i.sexo, i.nacionalidad, i.idDocumento, i.nombreHabitacion, i.estado)
            Next

            dgvPedidoDetalle.DataSource = dt
            dgvPedidoDetalle.TableDescriptor.Columns("nombre").Appearance.AnyCell.VerticalAlignment = GridVerticalAlignment.Middle
            dgvPedidoDetalle.TableDescriptor.Columns("nombre").Appearance.AnyCell.HorizontalAlignment = GridHorizontalAlignment.Left
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        GetTableDetalle()
    End Sub

    Private Sub BunifuFlatButton17_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton17.Click
        Try
            If (TXTcOMPRADOR.Tag > 0) Then
                GetTableDetalle(TXTcOMPRADOR.Tag)
            Else
                MessageBox.Show("Debe seleccionar un cliente")
            End If

        Catch ex As Exception
            MessageBox.Show(MessageBox.Show(ex.Message))
        End Try
    End Sub
End Class
