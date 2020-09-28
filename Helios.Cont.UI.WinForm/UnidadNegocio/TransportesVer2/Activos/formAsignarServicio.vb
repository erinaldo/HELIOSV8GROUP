Imports System.IO
Imports System.Net
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Helios.Seguridad.WCFService.ServiceAccess
Imports ProcesosGeneralesCajamiSoft
Imports Syncfusion.Grouping
Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms.Grid.Grouping
Imports HtmlAgilityPack
Imports System.Net.Http
Imports Syncfusion.Windows.Forms

Public Class formAsignarServicio

#Region "Attributes"


    Dim listaDistribucion As New List(Of distribucionInfraestructura)

    Dim ListaConfiguracion As New List(Of configuracionPrecio)

    Public Property listaeTALLEiTEMS As List(Of detalleitems)

    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of detalleitems))

#End Region

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        getCargarCombos()
        Getpersonas("", "")
    End Sub

    '#Region "Methods"

    Private Sub Getpersonas(tipo As String, empresa As String)
        Dim FETALLEsa As New detalleitemsSA
        Dim lista As New List(Of detalleitems)
        lista = New List(Of detalleitems)
        lista.AddRange(FETALLEsa.GetUbicarProductoXTipoExistencia(Gempresas.IdEmpresaRuc, GEstableciento.IdEstablecimiento, "GS"))
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of detalleitems))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaeTALLEiTEMS = New List(Of detalleitems)
            listaeTALLEiTEMS = lista
        End If
    End Sub

    Public Sub cargarBus(id As Integer, bus As String)

        LLAMARiNFRAESTRUCTURA(cboActivosFijos.SelectedValue)
    End Sub

    Public Sub LLAMARiNFRAESTRUCTURA(idActivo As Integer)
        Try
            Dim atributos As New FileAttributes
            Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
            Dim distribucionInfraestructuraBE As New distribucionInfraestructura
            Dim conteo As Integer = 0
            Dim sumatoriaBoton As Integer = 1

            Dim estado As String = String.Empty
            estado = "U, A, L"

            distribucionInfraestructuraBE.tipo = "1"
            distribucionInfraestructuraBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraestructuraBE.idEstablecimiento = GEstableciento.IdEstablecimiento
            distribucionInfraestructuraBE.tipo = "VPN"
            distribucionInfraestructuraBE.estado = "A"
            distribucionInfraestructuraBE.usuarioActualizacion = estado
            distribucionInfraestructuraBE.Categoria = 1
            distribucionInfraestructuraBE.SubCategoria = idActivo

            listaDistribucion = distribucionInfraestructuraSA.getInfraestructuraTransporte(distribucionInfraestructuraBE)

            DibujarControl(listaDistribucion)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub DibujarControl(listDistr As List(Of distribucionInfraestructura))

    End Sub

    Private Sub Butto1(sender As Object, e As EventArgs)
        Dim productoBE As New documentoventaAbarrotes
        Dim distribucionInfraestructuraSA As New distribucionInfraestructuraSA
        Dim distribucionInfraestructuraBE As New distribucionInfraestructura

        Try

            Dim c = CType(sender.Tag, distribucionInfraestructura)

            Dim f As New FormComfNumeracion
            f.pnBuscardor.Visible = True
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
            If f.Tag IsNot Nothing Then
                Dim idDistribucion = c.idDistribucion
                Dim numero = f.Tag
                GrabarPrecio(idDistribucion, numero)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Public Sub getCargarCombos()
        Dim ActivosFijosSA As New ActivosFijosSA
        Dim activosFijosBE As New List(Of activosFijos)
        Dim NuevoActivo As New activosFijos

        NuevoActivo.idActivo = 0
        NuevoActivo.descripcionItem = "Elija una opción"

        activosFijosBE.Add(NuevoActivo)
        activosFijosBE.AddRange(ActivosFijosSA.GetListar_activosFijos())

        If NuevoActivo IsNot Nothing Then
            cboActivosFijos.DataSource = activosFijosBE
            cboActivosFijos.ValueMember = "idActivo"
            cboActivosFijos.DisplayMember = "nroSeriePlaca"

            'If (Not IsNothing(activosFijosBE)) Then
            '    cboActivosFijos.SelectedValue = 0
            'End If

        End If
    End Sub

    Private Sub CboActivosFijos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboActivosFijos.SelectionChangeCommitted
        LLAMARiNFRAESTRUCTURA(cboActivosFijos.SelectedValue)
    End Sub

    Private Sub GrabarPrecio(idDistribucion As Integer, numero As String)
        Try
            Dim numeroSA As New distribucionInfraestructuraSA
            Dim numeroBE As New distribucionInfraestructura

            If (numero.Length <= 0) Then
                MessageBox.Show("No existe una numeracion")
                Exit Sub
            End If
            numeroBE.idDistribucion = idDistribucion
            numeroBE.numeracion = numero
            numeroBE.idEmpresa = Gempresas.IdEmpresaRuc

            numeroSA.EditarNumeracion(numeroBE)
            'MessageBox.Show("Se cambio Con exito")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BunifuThinButton22_Click(sender As Object, e As EventArgs) Handles BunifuThinButton22.Click
        Dim frmNuevaExistencia As New frmNuevaExistencia
        With frmNuevaExistencia
            If ModuloPadreSeleccionado = MaestrosGenerales.PuntoVentaBasico Then
                .UCNuenExistencia.cboTipoExistencia.Enabled = False
                .UCNuenExistencia.cboUnidades.SelectedIndex = -1
                .UCNuenExistencia.cboUnidades.Enabled = True
            Else

            End If

            If Gempresas.Regimen = "1" Then
                .UCNuenExistencia.cboIgv.Text = "1 - GRAVADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            Else
                .UCNuenExistencia.cboIgv.Text = "2 - EXONERADO"
                .UCNuenExistencia.cboIgv.Enabled = True
            End If

            '.UCNuenExistencia.chClasificacion.Checked = False
            .UCNuenExistencia.cboTipoExistencia.SelectedValue = "GS"
            .UCNuenExistencia.cboUnidades.Text = "UNIDAD (BIENES)"
            .EstadoManipulacion = ENTITY_ACTIONS.INSERT
            .StartPosition = FormStartPosition.CenterParent
            .ShowDialog()
        End With
        If frmNuevaExistencia.Tag IsNot Nothing Then
            Dim c = CType(frmNuevaExistencia.Tag, detalleitems)
            txtFiltrar.Text = c.descripcionItem
            txtFiltrar.Tag = c.idItem
            'GetProductos()
        End If
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        Try
            Dim DISTRIBUCIONsa As New distribucionInfraestructuraSA
            Dim DISTRIBUCIONbe As New distribucionInfraestructura

            DISTRIBUCIONbe.idActivo = cboActivosFijos.SelectedValue
            DISTRIBUCIONbe.idEmpresa = Gempresas.IdEmpresaRuc
            DISTRIBUCIONbe.idDetalleItem = CInt(txtFiltrar.Tag)


            DISTRIBUCIONsa.GetDistribucionAsignacionItem(DISTRIBUCIONbe)

            MessageBox.Show("Se enlazo el servicio con el bus")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TxtFiltrar_TextChanged(sender As Object, e As EventArgs) Handles txtFiltrar.TextChanged
        txtFiltrar.ForeColor = Color.Black
        txtFiltrar.Tag = Nothing
    End Sub

    '    Private Sub TxtFiltrar_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFiltrar.KeyDown
    '        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

    '        ElseIf e.KeyCode = Keys.Enter Then

    '        Else
    '            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
    '            ' If RBNatural.Checked = True Then
    '            Me.pcLikeCategoria.Size = New Size(282, 128)
    '            Me.pcLikeCategoria.ParentControl = Me.txtFiltrar
    '            Me.pcLikeCategoria.ShowPopup(Point.Empty)
    '            Dim consulta As New List(Of detalleitems)
    '            consulta.Add(New detalleitems With {.descripcionItem = "Agregar nuevo"})

    '            Dim consulta2 = (From n In listaeTALLEiTEMS
    '                             Where n.descripcionItem.StartsWith(txtFiltrar.Text)).ToList




    '            consulta.AddRange(consulta2)
    '            FillLSVClientes(consulta)
    '            e.Handled = True
    '            ' End If

    '        End If

    '        If e.KeyCode = Keys.Down Then
    '            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
    '            Me.pcLikeCategoria.Size = New Size(282, 128)
    '            Me.pcLikeCategoria.ParentControl = Me.txtFiltrar
    '            Me.pcLikeCategoria.ShowPopup(Point.Empty)
    '            LsvProveedor.Focus()
    '        End If
    '        '   End If

    '        ' e.SuppressKeyPress = True
    '        If e.KeyCode = Keys.Escape Then
    '            If Me.pcLikeCategoria.IsShowing() Then
    '                Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
    '            End If
    '        End If
    '    End Sub

    '    Private Sub FillLSVClientes(consulta As List(Of detalleitems))
    '        LsvProveedor.Items.Clear()
    '        '     Dim image = ImageList1.Images(0)
    '        For Each i In consulta
    '            Dim n As New ListViewItem(i.codigodetalle)

    '            n.SubItems.Add(i.descripcionItem)
    '            n.SubItems.Add(i.tipoExistencia)
    '            n.SubItems.Add(i.origenProducto)
    '            n.SubItems.Add(i.codigodetalle)
    '            LsvProveedor.Items.Add(n)
    '        Next
    '    End Sub

    '    Private Sub PcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs)
    '        Dim beneficioSA As New beneficioSA
    '        Me.Cursor = Cursors.WaitCursor
    '        Try
    '            If e.PopupCloseType = PopupCloseType.Done Then
    '                If LsvProveedor.SelectedItems.Count > 0 Then
    '                    If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
    '                        Dim f As New frmNuevaExistencia()
    '                        f.StartPosition = FormStartPosition.CenterParent
    '                        f.ShowDialog()
    '                        If Not IsNothing(f.Tag) Then
    '                            Dim c = CType(f.Tag, detalleitems)
    '                            listaeTALLEiTEMS.Add(c)
    '                            txtFiltrar.Text = c.descripcionItem
    '                            txtFiltrar.Tag = c.codigodetalle
    '                            txtFiltrar.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

    '                        End If
    '                    Else
    '                        txtFiltrar.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
    '                        txtFiltrar.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
    '                        txtFiltrar.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)

    '                    End If
    '                End If
    '            End If

    '            'Set focus back to textbox.
    '            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
    '                Me.txtFiltrar.Focus()
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '        Me.Cursor = Cursors.Arrow
    '    End Sub

    '    Private Sub LsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs)
    '        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    '    End Sub

    '#End Region

End Class
