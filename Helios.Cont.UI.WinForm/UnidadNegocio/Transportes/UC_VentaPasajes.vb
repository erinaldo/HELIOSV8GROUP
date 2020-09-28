Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Imports Helios.Cont.Presentation.WinForm

Public Class UC_VentaPasajes
    'Implements ICommitOperacionMKT

#Region "Attributes"
    Public Property ListaRutasActivas As List(Of rutas)
    Dim thread As System.Threading.Thread
    Public Property personaSA As New PersonaSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of Persona))
    Friend Delegate Sub SetDataSourceDelegateEntidad(ByVal lista As List(Of entidad))
    Public Property listaPersonas As List(Of Persona)
    Public Property listaServicios As List(Of ruta_HorarioServicios)
    Public Property entidadSA As New entidadSA
    Public Property listaClientes As List(Of entidad)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextFechaProgramada.Value = Date.Now
        threadPersonas()
        threadClientes()
        'GetRutasActivas()
        GetDocsVenta()

    End Sub
#End Region

#Region "Methods"

    'Private Sub GetEmpresasporPersona(idPersona As Integer)

    '    Dim personaSA As New PersonaSA
    '    Dim listaEmpresas = personaSA.EmpresasSelPerona(Gempresas.IdEmpresaRuc, idPersona)
    '    ComboEmpresaspersona.DataSource = listaEmpresas
    '    ComboEmpresaspersona.DisplayMember = "nombreComercial"
    '    ComboEmpresaspersona.ValueMember = "nombreComercialRuc"
    'End Sub

    Private Sub GetRutasPorDia()
        Dim status As String = String.Empty
        Dim rutaSA As New RutaProgramacionSalidasSA
        ListProgamacion.Items.Clear()

        Dim lista = rutaSA.GetProgramacionPorFechaLaboral(New rutaProgramacionSalidas With
                                                          {
                                                          .fechaProgramacion = TextFechaProgramada.Value
                                                          })


        For Each i In lista
            Select Case i.estado
                Case ProgramacionEstado.VehiculoAsignadoEnCurso
                    status = "En Curso"
                Case ProgramacionEstado.VehiculoAsignadoRutaCulminada
                    status = "Culminada"
                Case ProgramacionEstado.VentaCerrada
                    status = "Venta cerrada"
                Case ProgramacionEstado.VentaEnMostrador
                    status = "En mostrador"
                Case ProgramacionEstado.ZonaEmbarque
                    status = "Embarque"
            End Select

            Dim n As New ListViewItem(i.programacion_id)
            n.SubItems.Add(If(i.tipo = "I", "SALIDA", "VUELTA"))
            n.SubItems.Add(i.fechaProgramacion)
            n.SubItems.Add(i.fechaProgramacion.Value.ToShortTimeString)
            n.SubItems.Add(i.CustomRutas.CustomRuta_horarios.horario_id)
            n.SubItems.Add(i.ruta_id)
            n.SubItems.Add(i.CustomRutas.ciudadDestino)
            n.SubItems.Add(status)
            ListProgamacion.Items.Add(n)
        Next
        ListProgamacion.Refresh()

    End Sub

    Public Sub GetDocsVenta()
        cboTipoDoc.Items.Clear()
        'cboTipoDoc.Items.Add("NOTA DE VENTA")
        'cboTipoDoc.Items.Add("BOLETA")
        'cboTipoDoc.Items.Add("FACTURA")
        cboTipoDoc.Items.Add("BOLETA ELECTRONICA")
        cboTipoDoc.Items.Add("FACTURA ELECTRONICA")

        cboTipoDoc.Text = "BOLETA ELECTRONICA"
    End Sub


    Public Sub GetRutasActivas()
        'Dim rutaSA As New RutaTareoAutoSA
        'Dim rutaSA As New RutasSA
        Dim rutaSA As New RutaProgramacionSalidasSA

        'ListaRutasActivas = rutaSA.GellAllRutas(New rutas With {.estado = 1})
        ListaRutasActivas = rutaSA.ProgramacionSelRutasActivas(New rutaProgramacionSalidas With {.estado = 1})
        'ComboRutasActivas.DataSource = ListaRutasActivas
        'ComboRutasActivas.DisplayMember = "GetNameLarge"
        'ComboRutasActivas.ValueMember = "ruta_id"
    End Sub

    Private Sub threadClientes()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() GetClientes(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub GetClientes(tipo As String, empresa As String)
        Dim lista As New List(Of entidad)
        lista = New List(Of entidad)
        '  Dim varios = VarClienteGeneral ' entidadSA.UbicarEntidadVarios("VR", Gempresas.IdEmpresaRuc, String.Empty)
        'Dim lista = entidadSA.ObtenerListaEntidad(tipo, empresa)
        lista.Add(VarClienteGeneral)
        lista.AddRange(entidadSA.GetListarEntidad(New entidad With {.tipoEntidad = tipo, .idEmpresa = Gempresas.IdEmpresaRuc, .idOrganizacion = GEstableciento.IdEstablecimiento, .tipoConsulta = StatusTipoConsulta.XUNIDAD_ORGANICA}))
        setDataSourceEntidad(lista)
    End Sub

    Private Sub setDataSourceEntidad(ByVal lista As List(Of entidad))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegateEntidad(AddressOf setDataSourceEntidad)
            Invoke(deleg, New Object() {lista})
        Else
            listaClientes = New List(Of entidad)
            listaClientes = lista
        End If
    End Sub

    Private Sub threadPersonas()
        Dim tipo = TIPO_ENTIDAD.CLIENTE
        Dim empresa = Gempresas.IdEmpresaRuc
        thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() Getpersonas(tipo, empresa)))
        thread.Start()
    End Sub

    Private Sub Getpersonas(tipo As String, empresa As String)
        Dim lista As New List(Of Persona)
        lista = New List(Of Persona)
        'lista.AddRange(personaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                         .tipoPersona = "T",
        '                                         .estado = "A"}).ToList)
        setDataSource(lista)
    End Sub

    Private Sub setDataSource(ByVal lista As List(Of Persona))
        If Me.InvokeRequired Then
            'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

            Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
            Invoke(deleg, New Object() {lista})
        Else
            listaPersonas = New List(Of Persona)
            listaPersonas = lista
        End If
    End Sub
#End Region

#Region "Events"
    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Dim beneficioSA As New beneficioSA
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If LsvProveedor.SelectedItems.Count > 0 Then
                    If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                        Dim f As New FormCrearPersonaPasajero()
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, Persona)
                            listaPersonas.Add(c)
                            textPersona.Text = c.nombreCompleto
                            txtruc.Text = c.idPersona
                            textPersona.Tag = c.codigo
                            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            txtruc.Visible = True
                            textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        End If
                    Else
                        textPersona.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                        textPersona.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                        textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        txtruc.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                        txtruc.Visible = True
                    End If
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.textPersona.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of Persona))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.codigo)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.idPersona)
            n.SubItems.Add(i.tipodoc)
            LsvProveedor.Items.Add(n)
        Next
    End Sub
#End Region

    'Private Sub Tool1_MouseEnter(sender As Object, e As EventArgs) Handles Tool1.MouseEnter, ToolStripButton48.MouseEnter, ToolStripButton47.MouseEnter, ToolStripButton46.MouseEnter, ToolStripButton45.MouseEnter, ToolStripButton44.MouseEnter, ToolStripButton43.MouseEnter, ToolStripButton42.MouseEnter, ToolStripButton41.MouseEnter, ToolStripButton40.MouseEnter, ToolStripButton39.MouseEnter, ToolStripButton38.MouseEnter, ToolStripButton9.MouseEnter, ToolStripButton8.MouseEnter, ToolStripButton7.MouseEnter, ToolStripButton6.MouseEnter, ToolStripButton5.MouseEnter, ToolStripButton4.MouseEnter, ToolStripButton36.MouseEnter, ToolStripButton35.MouseEnter, ToolStripButton34.MouseEnter, ToolStripButton33.MouseEnter, ToolStripButton32.MouseEnter, ToolStripButton31.MouseEnter, ToolStripButton30.MouseEnter, ToolStripButton29.MouseEnter, ToolStripButton28.MouseEnter, ToolStripButton27.MouseEnter, ToolStripButton26.MouseEnter, ToolStripButton24.MouseEnter, ToolStripButton23.MouseEnter, ToolStripButton22.MouseEnter, ToolStripButton21.MouseEnter, ToolStripButton20.MouseEnter, ToolStripButton2.MouseEnter, ToolStripButton19.MouseEnter, ToolStripButton18.MouseEnter, ToolStripButton17.MouseEnter, ToolStripButton16.MouseEnter, ToolStripButton15.MouseEnter, ToolStripButton14.MouseEnter, ToolStripButton13.MouseEnter, ToolStripButton12.MouseEnter, ToolStripButton11.MouseEnter, ToolStripButton10.MouseEnter, Tool4.MouseEnter, Tool3.MouseEnter, Tool12.MouseEnter
    '    Tool1.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
    'End Sub

    'Private Sub Tool1_MouseLeave(sender As Object, e As EventArgs) Handles Tool1.MouseLeave, ToolStripButton48.MouseLeave, ToolStripButton47.MouseLeave, ToolStripButton46.MouseLeave, ToolStripButton45.MouseLeave, ToolStripButton44.MouseLeave, ToolStripButton43.MouseLeave, ToolStripButton42.MouseLeave, ToolStripButton41.MouseLeave, ToolStripButton40.MouseLeave, ToolStripButton39.MouseLeave, ToolStripButton38.MouseLeave, ToolStripButton9.MouseLeave, ToolStripButton8.MouseLeave, ToolStripButton7.MouseLeave, ToolStripButton6.MouseLeave, ToolStripButton5.MouseLeave, ToolStripButton4.MouseLeave, ToolStripButton36.MouseLeave, ToolStripButton35.MouseLeave, ToolStripButton34.MouseLeave, ToolStripButton33.MouseLeave, ToolStripButton32.MouseLeave, ToolStripButton31.MouseLeave, ToolStripButton30.MouseLeave, ToolStripButton29.MouseLeave, ToolStripButton28.MouseLeave, ToolStripButton27.MouseLeave, ToolStripButton26.MouseLeave, ToolStripButton24.MouseLeave, ToolStripButton23.MouseLeave, ToolStripButton22.MouseLeave, ToolStripButton21.MouseLeave, ToolStripButton20.MouseLeave, ToolStripButton2.MouseLeave, ToolStripButton19.MouseLeave, ToolStripButton18.MouseLeave, ToolStripButton17.MouseLeave, ToolStripButton16.MouseLeave, ToolStripButton15.MouseLeave, ToolStripButton14.MouseLeave, ToolStripButton13.MouseLeave, ToolStripButton12.MouseLeave, ToolStripButton11.MouseLeave, ToolStripButton10.MouseLeave, Tool4.MouseLeave, Tool3.MouseLeave, Tool12.MouseLeave
    '    Tool1.DisplayStyle = ToolStripItemDisplayStyle.Image
    'End Sub

    Private Sub VDERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VDERToolStripMenuItem.Click
        Select Case Tool4.Tag
            Case "D"
                GetventaPasaje("4")
            Case "V", "R"

        End Select
    End Sub

    Private Sub GetventaPasaje(silla As String)
        LabelAsientoSel.Text = silla
    End Sub

    Private Sub textPersona_TextChanged(sender As Object, e As EventArgs) Handles textPersona.TextChanged
        textPersona.ForeColor = Color.Black
        textPersona.Tag = Nothing
        If textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            txtruc.Visible = True
        Else
            txtruc.Visible = False
        End If
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub textPersona_KeyDown(sender As Object, e As KeyEventArgs) Handles textPersona.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then
            'Me.pcLikeCategoria.Size = New Size(319, 128)
            'Me.pcLikeCategoria.ParentControl = Me.textPersona
            'Me.pcLikeCategoria.ShowPopup(Point.Empty)
            'Dim consulta As New List(Of entidad)
            'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



            'Dim consulta2 = (From n In listaPersonas
            '                 Where n.nombreCompleto.StartsWith(textPersona.Text) Or n.idPersona.StartsWith(textPersona.Text)).ToList


            'consulta.AddRange(consulta2)
            'FillLSVClientes(consulta)
            'If consulta.Count <= 1 Then
            '    If MessageBox.Show("El cliente ingresado no existe!. Desea crearlo ahora?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            '        Dim f As New FormCrearPersonaPasajero()
            '        f.StartPosition = FormStartPosition.CenterParent
            '        f.ShowDialog(Me)
            '        If f.Tag IsNot Nothing Then
            '            Dim c = CType(f.Tag, Persona)
            '            textPersona.Text = c.nombreCompleto
            '            textPersona.Tag = c.idPersona
            '            txtruc.Visible = True
            '            txtruc.Text = c.idPersona
            '            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            '            textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
            '            listaPersonas.Add(c)
            '        End If
            '    End If
            'End If
        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            ' If RBNatural.Checked = True Then
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.textPersona
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of Persona)
            consulta.Add(New Persona With {.nombreCompleto = "Agregar nuevo"})

            Dim consulta2 = (From n In listaPersonas
                             Where n.nombreCompleto.StartsWith(textPersona.Text) Or n.idPersona.StartsWith(textPersona.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
            ' End If

        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.textPersona
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


    Private Sub ComboRuta_SelectedValueChanged(sender As Object, e As EventArgs)
        'Try
        '    GetLimpiarControles()

        '    If IsNumeric(ComboRutasActivas.SelectedValue) Then
        '        Dim id_ruta = Integer.Parse(ComboRutasActivas.SelectedValue)
        '        Dim ruta = ListaRutasActivas.Where(Function(o) o.ruta_id = id_ruta).SingleOrDefault
        '        'LabelDesde.Text = $"Desde: {ruta.ciudadOrigen}"
        '        'LabelHasta.Text = $"Hasta: {ruta.ciudadDestino}"
        '        LabelRuta.Text = $"DESDE {ruta.ciudadOrigen} HASTA {ruta.ciudadDestino}"
        '        GetProgramacion(ruta.ruta_id)
        '        GetServiciosPasajes(ruta.ruta_id, ruta.ruta_horarios.First.horario_id)

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub GetProgramacion(ruta_id As Integer)
        Dim programaSA As New RutaProgramacionSalidasSA
        ListProgamacion.Items.Clear()
        Dim status As String = String.Empty
        For Each i In programaSA.GetProgramacionSelRutaMostrador(ruta_id)

            Select Case i.estado
                Case ProgramacionEstado.VehiculoAsignadoEnCurso
                    status = "En Curso"
                Case ProgramacionEstado.VehiculoAsignadoRutaCulminada
                    status = "Culminada"
                Case ProgramacionEstado.VentaCerrada
                    status = "Venta cerrada"
                Case ProgramacionEstado.VentaEnMostrador
                    status = "En mostrador"
                Case ProgramacionEstado.ZonaEmbarque
                    status = "Embarque"
            End Select

            Dim n As New ListViewItem(i.programacion_id)
            n.SubItems.Add(i.fechaProgramacion)
            n.SubItems.Add(i.fechaProgramacion.Value.ToShortTimeString)
            n.SubItems.Add(If(i.tipo = "I", "IDA", "VUELTA"))
            n.SubItems.Add(status)
            ListProgamacion.Items.Add(n)
        Next

    End Sub

    Private Sub GetLimpiarControles()
        LabelfechaProg.Text = String.Empty
        LabelAsientoSel.Text = "0"
        ComboServicio.SelectedIndex = -1
        txtTotalPagar.DecimalValue = 0

    End Sub

    Private Sub GetServiciosPasajes(ruta_id As Integer, horario_id As Integer)
        Dim rutaSA As New Ruta_HorarioServiciosSA
        ComboServicio.Enabled = True
        listaServicios = rutaSA.GetServiciosVentaTransporte(New ruta_HorarioServicios With {.ruta_id = ruta_id, .horario_id = horario_id})
        ComboServicio.DataSource = listaServicios
        ComboServicio.DisplayMember = "descripcionLarga"
        ComboServicio.ValueMember = "codigoServicio"
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles BtConfirmarVenta.Click
        Try
            If IsDate(LabelfechaProg.Text) Then
                If CInt(LabelAsientoSel.Text) > 0 Then
                    If textPersona.Text.Trim.Length > 0 Then

                        If RBJuridico.Checked = True Then
                            If TextEmpresaPasajero.ForeColor <> Color.FromKnownColor(KnownColor.HotTrack) Then
                                MessageBox.Show("Ingrese una empresa valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                TextEmpresaPasajero.Select()
                                TextEmpresaPasajero.Focus()
                                Exit Sub
                            End If
                        End If

                        If txtTotalPagar.DecimalValue <= 0 Then
                            MessageBox.Show("Debe indicar el precio de venta", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ComboServicio.DroppedDown = True
                            Exit Sub
                        End If

                        'If TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                        If textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then

                            Dim id_ruta = Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(5).Text)

                            Dim envio = GetMappingEnvio(id_ruta, ComboServicio.SelectedValue)
                            Dim f As New FormCrearVentaTransporte(envio, envio.tipoPersona, Me)
                            f.TextFechaProgramada.Value = CDate(LabelfechaProg.Text)
                            f.TextFechaProgramada.Tag = (LabelfechaProg.Tag)
                            f.TextFechaProgramada.Enabled = False
                            f.StartPosition = FormStartPosition.CenterParent
                            f.ShowDialog(Me)
                        Else
                            MessageBox.Show("Ingrese un pasajero valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            textPersona.Select()
                            textPersona.Focus()
                        End If
                        'Else
                        '    MessageBox.Show("Ingreser una empresa valida", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        '    TextEmpresaPasajero.Select()
                        '    TextEmpresaPasajero.Focus()
                        'End If
                    Else
                        MessageBox.Show("Ingrese un pasajero valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Debe indicar el asiento para seguir la operación", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Indique una fecha programada", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Function GetMappingEnvio(id_ruta As Integer, CodigoServicio As Integer) As rutaTareoAutos
        Dim rutaSA As New RutasSA
        Dim persona As Persona = Nothing
        Dim razonSocialEmpresa As entidad = Nothing
        Dim rutaSel As rutas = Nothing
        Dim servicio As ruta_HorarioServicios = Nothing

        GetMappingEnvio = New rutaTareoAutos

        If RBJuridico.Checked = True Then
            GetMappingEnvio.tipoPersona = "J"
            persona = listaPersonas.Where(Function(o) o.codigo = CInt(textPersona.Tag)).SingleOrDefault
            razonSocialEmpresa = listaClientes.Where(Function(o) o.idEntidad = CInt(TextEmpresaPasajero.Tag)).SingleOrDefault
            rutaSel = rutaSA.RutaSelID(New rutas With {.ruta_id = id_ruta}) ' ListaRutasActivas.Where(Function(o) o.ruta_id = id_ruta).SingleOrDefault
            servicio = listaServicios.Where(Function(o) o.codigoServicio = CodigoServicio).SingleOrDefault
        ElseIf RBNatural.Checked = True Then
            GetMappingEnvio.tipoPersona = "N"
            persona = listaPersonas.Where(Function(o) o.codigo = CInt(textPersona.Tag)).SingleOrDefault
            'razonSocialEmpresa = listaClientes.Where(Function(o) o.idEntidad = CInt(TextEmpresaPasajero.Tag)).SingleOrDefault
            rutaSel = rutaSA.RutaSelID(New rutas With {.ruta_id = id_ruta}) 'ListaRutasActivas.Where(Function(o) o.ruta_id = id_ruta).SingleOrDefault
            servicio = listaServicios.Where(Function(o) o.codigoServicio = CodigoServicio).SingleOrDefault
        End If


        Select Case cboTipoDoc.Text
            Case "BOLETA ELECTRONICA"
                GetMappingEnvio.TipoDocVenta = "03"
            Case "FACTURA ELECTRONICA"
                GetMappingEnvio.TipoDocVenta = "01"
            Case Else
                GetMappingEnvio.TipoDocVenta = "9901"
        End Select
        GetMappingEnvio.ImporteVenta = txtTotalPagar.DecimalValue
        GetMappingEnvio.Asiento = CInt(LabelAsientoSel.Text)
        GetMappingEnvio.customRuta = rutaSel ' Tareo.customRuta
        GetMappingEnvio.customruta_horarios = rutaSel.ruta_horarios.FirstOrDefault ' Tareo.customruta_horarios
        GetMappingEnvio.customRuta_HorarioServicios = servicio
        GetMappingEnvio.customPersona = persona
        GetMappingEnvio.customEntidad = razonSocialEmpresa
    End Function

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs) Handles RoundButton26.Click
        GetLimpiarControles()
    End Sub

    Private Sub ComboRuta_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub VenderToolStripMenuItem32_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem32.Click
        Select Case VenderToolStripMenuItem32.OwnerItem.Tag
            Case "D"
                GetventaPasaje("1")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VENDERToolStripMenuItem21_Click(sender As Object, e As EventArgs) Handles VENDERToolStripMenuItem21.Click
        Select Case Tool12.Tag
            Case "D"
                GetventaPasaje("2")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem9.Click
        Select Case Tool3.Tag
            Case "D"
                GetventaPasaje("3")
            Case "V", "R"

        End Select

    End Sub

    Private Sub ToolStripButton38_Click(sender As Object, e As EventArgs) Handles ToolStripButton38.Click

    End Sub

    Private Sub VenderToolStripMenuItem33_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem33.Click
        Select Case VenderToolStripMenuItem33.OwnerItem.Tag
            Case "D"
                GetventaPasaje("5")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem22_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem22.Click
        Select Case VenderToolStripMenuItem22.OwnerItem.Tag
            Case "D"
                GetventaPasaje("6")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem10.Click
        Select Case VenderToolStripMenuItem10.OwnerItem.Tag
            Case "D"
                GetventaPasaje("7")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem.Click
        Select Case VenderToolStripMenuItem.OwnerItem.Tag
            Case "D"
                GetventaPasaje("8")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem34_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem34.Click
        Select Case VenderToolStripMenuItem34.OwnerItem.Tag
            Case "D"
                GetventaPasaje("9")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem23_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem23.Click
        Select Case VenderToolStripMenuItem23.OwnerItem.Tag
            Case "D"
                GetventaPasaje("10")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem11.Click
        Select Case VenderToolStripMenuItem11.OwnerItem.Tag
            Case "D"
                GetventaPasaje("11")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem1.Click
        Select Case VenderToolStripMenuItem1.OwnerItem.Tag
            Case "D"
                GetventaPasaje("12")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem35_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem35.Click
        Select Case VenderToolStripMenuItem35.OwnerItem.Tag
            Case "D"
                GetventaPasaje("13")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem24_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem24.Click
        Select Case VenderToolStripMenuItem24.OwnerItem.Tag
            Case "D"
                GetventaPasaje("14")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem12.Click
        Select Case VenderToolStripMenuItem12.OwnerItem.Tag
            Case "D"
                GetventaPasaje("15")
            Case "V", "R"

        End Select
    End Sub

    Private Sub ReservarToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ReservarToolStripMenuItem3.Click
        Select Case ReservarToolStripMenuItem3.OwnerItem.Tag
            Case "D"
                GetventaPasaje("16")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem36_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem36.Click
        Select Case VenderToolStripMenuItem36.OwnerItem.Tag
            Case "D"
                GetventaPasaje("17")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem25_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem25.Click
        Select Case VenderToolStripMenuItem25.OwnerItem.Tag
            Case "D"
                GetventaPasaje("18")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VentaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaToolStripMenuItem.Click
        Select Case VentaToolStripMenuItem.OwnerItem.Tag
            Case "D"
                GetventaPasaje("20")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem13.Click
        Select Case VenderToolStripMenuItem13.OwnerItem.Tag
            Case "D"
                GetventaPasaje("19")
            Case "V", "R"

        End Select
    End Sub

    Private Sub ReseevarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReseevarToolStripMenuItem.Click
        Select Case ReseevarToolStripMenuItem.OwnerItem.Tag
            Case "D"
                GetventaPasaje("21")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem26_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem26.Click
        Select Case VenderToolStripMenuItem26.OwnerItem.Tag
            Case "D"
                GetventaPasaje("22")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem14.Click
        Select Case VenderToolStripMenuItem14.OwnerItem.Tag
            Case "D"
                GetventaPasaje("23")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem2.Click
        Select Case VenderToolStripMenuItem2.OwnerItem.Tag
            Case "D"
                GetventaPasaje("24")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem37_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem37.Click
        Select Case VenderToolStripMenuItem37.OwnerItem.Tag
            Case "D"
                GetventaPasaje("25")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem27_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem27.Click
        Select Case VenderToolStripMenuItem27.OwnerItem.Tag
            Case "D"
                GetventaPasaje("26")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem3.Click
        Select Case VenderToolStripMenuItem3.OwnerItem.Tag
            Case "D"
                GetventaPasaje("28")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem15.Click
        Select Case VenderToolStripMenuItem15.OwnerItem.Tag
            Case "D"
                GetventaPasaje("27")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem38_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem38.Click
        Select Case VenderToolStripMenuItem38.OwnerItem.Tag
            Case "D"
                GetventaPasaje("29")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem28_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem28.Click
        Select Case VenderToolStripMenuItem28.OwnerItem.Tag
            Case "D"
                GetventaPasaje("30")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem16.Click
        Select Case VenderToolStripMenuItem16.OwnerItem.Tag
            Case "D"
                GetventaPasaje("31")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem4.Click
        Select Case VenderToolStripMenuItem4.OwnerItem.Tag
            Case "D"
                GetventaPasaje("32")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem39_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem39.Click
        Select Case VenderToolStripMenuItem39.OwnerItem.Tag
            Case "D"
                GetventaPasaje("33")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VemderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VemderToolStripMenuItem.Click
        Select Case VemderToolStripMenuItem.OwnerItem.Tag
            Case "D"
                GetventaPasaje("34")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem17.Click
        Select Case VenderToolStripMenuItem17.OwnerItem.Tag
            Case "D"
                GetventaPasaje("35")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem5.Click
        Select Case VenderToolStripMenuItem5.OwnerItem.Tag
            Case "D"
                GetventaPasaje("36")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem40_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem40.Click
        Select Case VenderToolStripMenuItem40.OwnerItem.Tag
            Case "D"
                GetventaPasaje("37")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem29_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem29.Click
        Select Case VenderToolStripMenuItem29.OwnerItem.Tag
            Case "D"
                GetventaPasaje("38")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem18.Click
        Select Case VenderToolStripMenuItem18.OwnerItem.Tag
            Case "D"
                GetventaPasaje("39")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem6.Click
        Select Case VenderToolStripMenuItem6.OwnerItem.Tag
            Case "D"
                GetventaPasaje("40")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem41_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem41.Click
        Select Case VenderToolStripMenuItem41.OwnerItem.Tag
            Case "D"
                GetventaPasaje("41")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem30_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem30.Click
        Select Case VenderToolStripMenuItem30.OwnerItem.Tag
            Case "D"
                GetventaPasaje("42")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem19.Click
        Select Case VenderToolStripMenuItem19.OwnerItem.Tag
            Case "D"
                GetventaPasaje("43")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem7.Click
        Select Case VenderToolStripMenuItem7.OwnerItem.Tag
            Case "D"
                GetventaPasaje("44")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem42_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem42.Click
        Select Case VenderToolStripMenuItem42.OwnerItem.Tag
            Case "D"
                GetventaPasaje("45")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem31_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem31.Click
        Select Case VenderToolStripMenuItem31.OwnerItem.Tag
            Case "D"
                GetventaPasaje("46")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem20.Click
        Select Case VenderToolStripMenuItem20.OwnerItem.Tag
            Case "D"
                GetventaPasaje("47")
            Case "V", "R"

        End Select
    End Sub

    Private Sub VenderToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles VenderToolStripMenuItem8.Click
        Select Case VenderToolStripMenuItem8.OwnerItem.Tag
            Case "D"
                GetventaPasaje("48")
            Case "V", "R"

        End Select
    End Sub

    Private Sub ComboServicio_Click(sender As Object, e As EventArgs) Handles ComboServicio.Click

    End Sub

    Private Sub ComboServicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboServicio.SelectedValueChanged
        If IsNumeric(ComboServicio.SelectedValue) Then
            Dim serv = listaServicios.Where(Function(o) o.codigoServicio = ComboServicio.SelectedValue).SingleOrDefault
            txtTotalPagar.DecimalValue = serv.costoEstimado.GetValueOrDefault
        End If
    End Sub

    Private Sub cboTipoDoc_Click(sender As Object, e As EventArgs) Handles cboTipoDoc.Click

    End Sub

    Private Sub ListProgamacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListProgamacion.SelectedIndexChanged
        If ListProgamacion.SelectedItems.Count > 0 Then


            Dim fecha = CType(ListProgamacion.SelectedItems(0).SubItems(2).Text, DateTime?)
            LabelfechaProg.Text = fecha.ToString
            LabelfechaProg.Tag = Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(0).Text)
            LabelTipoProg.Text = ListProgamacion.SelectedItems(0).SubItems(1).Text
            RecorreToolStrip(ToolStrip1)
            RecorreToolStrip(ToolStrip2)
            RecorreToolStrip(ToolStrip3)
            RecorreToolStrip(ToolStrip4)
            CargaDeAsientos(Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(0).Text),
                            Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(5).Text))


            '-----------------------------------------------------------------------------------------------------------------------
            Dim id_ruta = Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(5).Text)
            Dim horario_id = Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(4).Text)

            '     Dim ruta = ListaRutasActivas.Where(Function(o) o.ruta_id = id_ruta).SingleOrDefault

            'LabelRuta.Text = $"DESDE {ruta.ciudadOrigen} HASTA {ruta.ciudadDestino}"
            'GetProgramacion(id_ruta)
            GetServiciosPasajes(id_ruta, horario_id)

        Else
            LabelfechaProg.Text = String.Empty
        End If
    End Sub

    Public Sub RecorreToolStrip(ByRef pToolStrip As Windows.Forms.ToolStrip)

        Dim oToolStripButton As Windows.Forms.ToolStripDropDownButton

        For Each oToolStripButton In pToolStrip.Items.OfType(Of ToolStripDropDownButton)
            oToolStripButton.Image = ImageList1.Images(0)
            oToolStripButton.Tag = "D"
        Next

    End Sub


    Private Sub CargaDeAsientos(idProg As Integer, ruta_id As Integer)
        Dim asientosSA As New VehiculoAsiento_PreciosSA
        Dim listaAsientos = asientosSA.CargaAsientos(New vehiculoAsiento_Precios With {.ruta_id = ruta_id, .programacion_id = idProg})

        For Each i In listaAsientos
            Select Case i.idComponente
                Case 1
                    Tool1.Image = ImageList1.Images(2)
                    Tool1.Tag = "V"
                Case 2
                    Tool12.Image = ImageList1.Images(2)
                    Tool12.Tag = "V"
                Case 3
                    Tool3.Image = ImageList1.Images(2)
                    Tool3.Tag = "V"
                Case 4
                    Tool4.Image = ImageList1.Images(2)
                    Tool4.Tag = "V"
                Case 5
                    ToolStripButton38.Image = ImageList1.Images(2)
                    ToolStripButton38.Tag = "V"
                Case 6
                    ToolStripButton26.Image = ImageList1.Images(2)
                    ToolStripButton26.Tag = "V"
                Case 7
                    ToolStripButton14.Image = ImageList1.Images(2)
                    ToolStripButton14.Tag = "V"
                Case 8
                    ToolStripButton2.Image = ImageList1.Images(2)
                    ToolStripButton2.Tag = "V"
                Case 9
                    ToolStripButton39.Image = ImageList1.Images(2)
                    ToolStripButton39.Tag = "V"
                Case 10
                    ToolStripButton27.Image = ImageList1.Images(2)
                    ToolStripButton27.Tag = "V"
                Case 11
                    ToolStripButton15.Image = ImageList1.Images(2)
                    ToolStripButton15.Tag = "V"
                Case 12
                    ToolStripButton13.Image = ImageList1.Images(2)
                    ToolStripButton13.Tag = "V"
                Case 13
                    ToolStripButton40.Image = ImageList1.Images(2)
                    ToolStripButton40.Tag = "V"
                Case 14
                    ToolStripButton28.Image = ImageList1.Images(2)
                    ToolStripButton28.Tag = "V"
                Case 15
                    ToolStripButton16.Image = ImageList1.Images(2)
                    ToolStripButton16.Tag = "V"
                Case 16
                    ToolStripButton12.Image = ImageList1.Images(2)
                    ToolStripButton12.Tag = "V"

                Case 17
                    ToolStripButton41.Image = ImageList1.Images(2)
                    ToolStripButton41.Tag = "V"
                Case 18
                    ToolStripButton29.Image = ImageList1.Images(2)
                    ToolStripButton29.Tag = "V"
                Case 19
                    ToolStripButton17.Image = ImageList1.Images(2)
                    ToolStripButton17.Tag = "V"
                Case 20
                    ToolStripButton11.Image = ImageList1.Images(2)
                    ToolStripButton11.Tag = "V"
                Case 21
                    ToolStripButton42.Image = ImageList1.Images(2)
                    ToolStripButton42.Tag = "V"
                Case 22
                    ToolStripButton30.Image = ImageList1.Images(2)
                    ToolStripButton30.Tag = "V"
                Case 23
                    ToolStripButton18.Image = ImageList1.Images(2)
                    ToolStripButton18.Tag = "V"
                Case 24
                    ToolStripButton10.Image = ImageList1.Images(2)
                    ToolStripButton10.Tag = "V"
                Case 25
                    ToolStripButton43.Image = ImageList1.Images(2)
                    ToolStripButton43.Tag = "V"
                Case 26
                    ToolStripButton31.Image = ImageList1.Images(2)
                    ToolStripButton31.Tag = "V"
                Case 27
                    ToolStripButton19.Image = ImageList1.Images(2)
                    ToolStripButton19.Tag = "V"
                Case 28
                    ToolStripButton9.Image = ImageList1.Images(2)
                    ToolStripButton9.Tag = "V"
                Case 29
                    ToolStripButton44.Image = ImageList1.Images(2)
                    ToolStripButton44.Tag = "V"
                Case 30
                    ToolStripButton32.Image = ImageList1.Images(2)
                    ToolStripButton32.Tag = "V"
                Case 31
                    ToolStripButton20.Image = ImageList1.Images(2)
                    ToolStripButton20.Tag = "V"
                Case 32
                    ToolStripButton8.Image = ImageList1.Images(2)
                    ToolStripButton8.Tag = "V"
                Case 33
                    ToolStripButton45.Image = ImageList1.Images(2)
                    ToolStripButton45.Tag = "V"
                Case 34
                    ToolStripButton33.Image = ImageList1.Images(2)
                    ToolStripButton33.Tag = "V"
                Case 35
                    ToolStripButton21.Image = ImageList1.Images(2)
                    ToolStripButton21.Tag = "V"
                Case 36
                    ToolStripButton7.Image = ImageList1.Images(2)
                    ToolStripButton7.Tag = "V"
                Case 37
                    ToolStripButton46.Image = ImageList1.Images(2)
                    ToolStripButton46.Tag = "V"
                Case 38
                    ToolStripButton34.Image = ImageList1.Images(2)
                    ToolStripButton34.Tag = "V"
                Case 39
                    ToolStripButton22.Image = ImageList1.Images(2)
                    ToolStripButton22.Tag = "V"
                Case 40

                    ToolStripButton6.Image = ImageList1.Images(2)
                    ToolStripButton6.Tag = "V"
                Case 41
                    ToolStripButton47.Image = ImageList1.Images(2)
                    ToolStripButton47.Tag = "V"
                Case 42
                    ToolStripButton35.Image = ImageList1.Images(2)
                    ToolStripButton35.Tag = "V"
                Case 43
                    ToolStripButton23.Image = ImageList1.Images(2)
                    ToolStripButton23.Tag = "V"
                Case 44
                    ToolStripButton5.Image = ImageList1.Images(2)
                    ToolStripButton5.Tag = "V"
                Case 45
                    ToolStripButton48.Image = ImageList1.Images(2)
                    ToolStripButton48.Tag = "V"
                Case 46
                    ToolStripButton36.Image = ImageList1.Images(2)
                    ToolStripButton36.Tag = "V"
                Case 47
                    ToolStripButton24.Image = ImageList1.Images(2)
                    ToolStripButton24.Tag = "V"
                Case 48
                    ToolStripButton4.Image = ImageList1.Images(2)
                    ToolStripButton4.Tag = "V"
            End Select
        Next


    End Sub

    Private Sub ComboEmpresaspersona_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboEmpresaspersona_KeyDown(sender As Object, e As KeyEventArgs)

    End Sub

    Private Sub TextEmpresaPasajero_TextChanged(sender As Object, e As EventArgs) Handles TextEmpresaPasajero.TextChanged
        TextEmpresaPasajero.ForeColor = Color.Black
        TextEmpresaPasajero.Tag = Nothing
        If TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            TextNumIdentrazon.Visible = True
        Else
            TextNumIdentrazon.Visible = False
        End If
    End Sub


    Private Sub FillLSVClientesGeneral(consulta As List(Of entidad))
        ListEmpresas.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.idEntidad)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.nrodoc)
            n.SubItems.Add(i.tipoDoc)
            ListEmpresas.Items.Add(n)
        Next
    End Sub

    Private Sub ListEmpresas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListEmpresas.MouseDoubleClick
        Me.PCEmpresas.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub PCEmpresas_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PCEmpresas.CloseUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If ListEmpresas.SelectedItems.Count > 0 Then
                    If ListEmpresas.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
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
                            'txtTipoDocClie.Text = c.tipoDoc
                            TextEmpresaPasajero.Text = c.nombreCompleto
                            TextNumIdentrazon.Text = c.nrodoc
                            TextEmpresaPasajero.Tag = c.idEntidad
                            TextNumIdentrazon.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextNumIdentrazon.Visible = True
                            TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        End If
                    Else
                        TextEmpresaPasajero.Text = ListEmpresas.SelectedItems(0).SubItems(1).Text
                        TextEmpresaPasajero.Tag = ListEmpresas.SelectedItems(0).SubItems(0).Text
                        TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        TextNumIdentrazon.Text = ListEmpresas.SelectedItems(0).SubItems(2).Text
                        ' txtTipoDocClie.Text = LsvProveedor.SelectedItems(0).SubItems(3).Text
                        TextNumIdentrazon.Visible = True


                        'TextBenefClienteBase.Text = beneficio.importeBase.GetValueOrDefault
                        'TextValorAfecto.Text = beneficio.valorConvertido

                        'Select Case beneficio.tipoAfectacion
                        '    Case "I"
                        '        TextTipoBeneficio.Text = "IMPORTE"
                        '    Case "C"
                        '        TextTipoBeneficio.Text = "CANTIDAD"
                        '    Case "P"
                        '        TextTipoBeneficio.Text = "PORCENTAJE"
                        'End Select

                    End If
                    'ListaMercaderiasXIdHijo(Val(txtSubCategoria.Tag), cboTipoExistencia.SelectedValue)
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TextEmpresaPasajero.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextEmpresaPasajero_KeyDown(sender As Object, e As KeyEventArgs) Handles TextEmpresaPasajero.KeyDown
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

        ElseIf e.KeyCode = Keys.Enter Then
            Me.PCEmpresas.Size = New Size(319, 128)
            Me.PCEmpresas.ParentControl = Me.TextEmpresaPasajero
            Me.PCEmpresas.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})

            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TextEmpresaPasajero.Text) Or n.nrodoc.StartsWith(TextEmpresaPasajero.Text)).ToList


            consulta.AddRange(consulta2)
            FillLSVClientesGeneral(consulta)
            If consulta.Count <= 1 Then
                If MessageBox.Show("El cliente ingresado no existe!. Desea crearlo ahora?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim f As New frmCrearENtidades(TextEmpresaPasajero.Text)
                    f.CaptionLabels(0).Text = "Nuevo cliente"
                    f.strTipo = TIPO_ENTIDAD.CLIENTE
                    f.ManipulacionEstado = ENTITY_ACTIONS.INSERT
                    f.StartPosition = FormStartPosition.CenterParent
                    f.ShowDialog()
                    If f.Tag IsNot Nothing Then
                        Dim c = CType(f.Tag, entidad)
                        TextEmpresaPasajero.Text = c.nombreCompleto
                        TextEmpresaPasajero.Tag = c.idEntidad
                        TextNumIdentrazon.Visible = True
                        TextNumIdentrazon.Text = c.nrodoc
                        TextNumIdentrazon.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        TextEmpresaPasajero.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        listaClientes.Add(c)
                    End If

                End If

            End If

        Else
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PCEmpresas.Size = New Size(282, 128)
            Me.PCEmpresas.ParentControl = Me.TextEmpresaPasajero
            Me.PCEmpresas.ShowPopup(Point.Empty)
            Dim consulta As New List(Of entidad)
            consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})

            Dim consulta2 = (From n In listaClientes
                             Where n.nombreCompleto.StartsWith(TextEmpresaPasajero.Text) Or n.nrodoc.StartsWith(TextEmpresaPasajero.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientesGeneral(consulta)
            e.Handled = True
        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PCEmpresas.Size = New Size(282, 128)
            Me.PCEmpresas.ParentControl = Me.TextEmpresaPasajero
            Me.PCEmpresas.ShowPopup(Point.Empty)
            LsvProveedor.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.PCEmpresas.IsShowing() Then
                Me.PCEmpresas.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub TextNumIdentrazon_TextChanged(sender As Object, e As EventArgs) Handles TextNumIdentrazon.TextChanged

    End Sub

    Private Sub RBNatural_CheckedChanged(sender As Object, e As EventArgs) Handles RBNatural.CheckedChanged
        If RBNatural.Checked = True Then
            GroupBoxPasajero.Enabled = True
            GroupBoxEmpresa.Enabled = False
        End If
    End Sub

    Private Sub RBJuridico_CheckedChanged(sender As Object, e As EventArgs) Handles RBJuridico.CheckedChanged
        If RBJuridico.Checked = True Then
            GroupBoxPasajero.Enabled = True
            GroupBoxEmpresa.Enabled = True

        End If
    End Sub

    Public Sub ReiniciarForm(Confirmado As Boolean, idDocumento As Integer) 'Implements ICommitOperacionMKT.Commit
        GetLimpiarControles()
        MessageBox.Show("Pasaje vendido!", "venta", MessageBoxButtons.OK, MessageBoxIcon.Information)
        RecorreToolStrip(ToolStrip1)
        RecorreToolStrip(ToolStrip2)
        RecorreToolStrip(ToolStrip3)
        RecorreToolStrip(ToolStrip4)
        If ListProgamacion.SelectedItems.Count > 0 Then
            CargaDeAsientos(Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(0).Text),
                            Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(5).Text))
        End If
    End Sub

    Public Sub CerrarVenta() 'Implements ICommitOperacionMKT.Commit
        GetLimpiarControles()
        RecorreToolStrip(ToolStrip1)
        RecorreToolStrip(ToolStrip2)
        RecorreToolStrip(ToolStrip3)
        RecorreToolStrip(ToolStrip4)
        If ListProgamacion.SelectedItems.Count > 0 Then
            CargaDeAsientos(Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(0).Text),
                            Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(5).Text))
        End If
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click

    End Sub

    Private Sub RoundButton27_Click(sender As Object, e As EventArgs) Handles RoundButton27.Click
        If ListProgamacion.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea enviar programación a zona de embarque?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                GetCerrarVentas(Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(0).Text), ProgramacionEstado.ZonaEmbarque)
            End If
        End If
    End Sub

    Private Sub GetCerrarVentas(prog_id As Integer, estado As General.Transporte.ProgramacionEstado)
        Dim programacionSA As New RutaProgramacionSalidasSA
        Dim obj As New rutaProgramacionSalidas With
        {
        .programacion_id = prog_id,
        .estado = estado
        }
        programacionSA.UpdateEstadoProgramacion(obj)
        If estado = ProgramacionEstado.VentaCerrada Then
            ListProgamacion.SelectedItems(0).Remove()
        End If
        MessageBox.Show("Ruta enviada a zona de embarque!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        CerrarVenta()
    End Sub

    Private Sub RoundButton25_Click(sender As Object, e As EventArgs) Handles RoundButton25.Click
        If ListProgamacion.SelectedItems.Count > 0 Then
            If MessageBox.Show("Desea cerrar las ventas para está fecha programada?", "Cerrar ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                GetCerrarVentas(Integer.Parse(ListProgamacion.SelectedItems(0).SubItems(0).Text), ProgramacionEstado.VentaCerrada)
            End If
        End If
    End Sub

    Private Sub RoundButton28_Click(sender As Object, e As EventArgs) Handles RoundButton28.Click
        Cursor = Cursors.WaitCursor
        GetLimpiarControles()
        GetRutasPorDia()
        Cursor = Cursors.Default
    End Sub

    Private Sub UC_VentaPasajes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtruc_TextChanged(sender As Object, e As EventArgs) Handles txtruc.TextChanged

    End Sub
End Class
