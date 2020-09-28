Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms

Public Class FormConsolidarSalidaEmbarque

    Public Property formInherits As UCManifestoEnEspera
    Public Property ProgramacionSA As New RutaProgramacionSalidasSA
    Dim thread As System.Threading.Thread
    Dim PersonaSA As New PersonaSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of Persona))
    Public Property listaPersonas As List(Of Persona)
    Public Property IDProgramacion As Integer

    Public Property origen As String

    Public Property destino As String

    Public Property numeromanifiesto As String

    Public Property IDaCTIVO As Integer

    Dim ConteoTotalPasajeros As Integer = 0

    Public Sub New(form As UCManifestoEnEspera, idprogracion As Integer)


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        formInherits = form
        threadPersonas()
        MappingControles(idprogracion)
        TextFechaEmbarque.Value = Date.Now

    End Sub

    Public Sub New(idProgram As Integer)


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        threadPersonas()
        MappingControles(idProgram)
        TextFechaEmbarque.Value = Date.Now
        IDProgramacion = idProgram
        GetResumenEncomiendas(IDProgramacion)
    End Sub

    Private Sub GetResumenEncomiendas(programacion_id As Integer)
        Try
            TextNumPasajeros.Text = 0
            Dim ventaSA As New DocumentoventaTransporteSA
            Dim dt As New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("asiento")
            dt.Columns.Add("dni")
            dt.Columns.Add("pasajero")
            dt.Columns.Add("edad")
            dt.Columns.Add("numero")
            dt.Columns.Add("importe")

            Dim comprobanteCliente As List(Of documentoventaTransporte) = ventaSA.DocumentoTransportePasajesSelID(New documentoventaTransporte With
                                                                       {
                                                                       .programacion_id = programacion_id
                                                                       }).ToList


            If (comprobanteCliente.Count > 0) Then
                For Each i In (comprobanteCliente).OrderBy(Function(O) O.numeroAsiento)
                    If (i.estado <> 5) Then
                        If (i.estado <> 6) Then
                            dt.Rows.Add(
                                       i.idDocumento,
                                       i.numeroAsiento,
                                       i.CustomPerson.idPersona,
                                       i.comprador,
                                       i.edad,
                                       $"{i.serie }-{i.numero}",
                                       i.total)
                            ConteoTotalPasajeros = ConteoTotalPasajeros + 1
                        End If
                    End If

                Next
            End If


            dgvCuentas.DataSource = dt
            TextNumPasajeros.Text = ConteoTotalPasajeros
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub MappingControles(idProgramacion As Integer)
        Dim prog = ProgramacionSA.ProgramacionManifiestoSelID(New rutaProgramacionSalidas With
                                {
                                .programacion_id = Integer.Parse(idProgramacion)
                                })

        TextRuta.Text = prog.CustomRutas.ciudadOrigen
        txtdestino.Text = prog.CustomRutas.ciudadDestino
        TextRuta.Tag = prog.CustomRutas
        TextFechaProgramada.Tag = prog
        TextFechaProgramada.Value = prog.fechaProgramacion
        'TextTipoEmbarque.Text = If(prog.tipo = "I", "IDA", "VUELTA")
        'TextNumPasajeros.Text = formInherits.ListPasajeros.Items.Count
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
        'lista.AddRange(PersonaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
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

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs)
        If TextSeriePlaca.Text.Trim.Length > 0 Then
            If TextSeriePlaca.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
                'GrabarConsolidacion()

                Dim documentoventaSA As New distribucionInfraestructuraSA
                Dim documentoventaBE As New distribucionInfraestructura

                Dim distribucionInfraturaBE = New distribucionInfraestructura


                distribucionInfraturaBE.idEmpresa = Gempresas.IdEmpresaRuc
                distribucionInfraturaBE.idActivo = TextSeriePlaca.Tag
                distribucionInfraturaBE.estado = "A"

                documentoventaSA.updateDistribucioTrasnportemMasivo(distribucionInfraturaBE)

                Close()

            Else
                TextSeriePlaca.Select()
                MessageBox.Show("Debe indicar un vehiculo autorizado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            TextSeriePlaca.Select()
            MessageBox.Show("Debe indicar un vehiculo autorizado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Sub GetVehiculosPorNroSerie(placaSerie As String)
        Dim ActivoSA As New ActivosFijosSA
        Dim listaVehiculos = ActivoSA.GetListar_activosFijosSeriePlaca(New Business.Entity.activosFijos With
                                                                       {
                                                                       .idEmpresa = Gempresas.IdEmpresaRuc,
                                                                       .idEstablecimiento = GEstableciento.IdEstablecimiento,
                                                                       .nroSeriePlaca = placaSerie
                                                                       })


        If listaVehiculos.Count > 0 Then
            TextSeriePlaca.Text = $"{listaVehiculos.FirstOrDefault.nroSeriePlaca}-{listaVehiculos.FirstOrDefault.descripcionItem}"
            TextSeriePlaca.Tag = listaVehiculos.FirstOrDefault
            TextSeriePlaca.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)


            TextCodigoPlaca.Text = listaVehiculos.FirstOrDefault.nroSeriePlaca
            'If MessageBox.Show("Se encontró vehiculo(s), desea agregarlo(s) ahora?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

            '    For Each i In listaVehiculos
            '        Dim n As New ListViewItem(i.idActivo)
            '        n.SubItems.Add(i.descripcionItem)
            '        n.SubItems.Add(i.anio)
            '        n.SubItems.Add(i.modelo)
            '        n.SubItems.Add(i.marca)
            '        n.SubItems.Add(i.color)
            '        n.SubItems.Add(i.motor)
            '        n.SubItems.Add(i.nroSeriePlaca)
            '        ListView1.Items.Add(n)
            '    Next
            'End If
        Else
            MessageBox.Show("No se encontraron datos con el número serie/placa ingresado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextSeriePlaca.Focus()
            TextSeriePlaca.ForeColor = Color.Black
        End If
    End Sub

    Private Sub GrabarConsolidacion()
        Dim consolidacionSA As New RutaProgramacionSalidasSA
        Dim obj As New rutaTareoAutos
        Dim objDet As rutaTareoDetalle
        Dim Lista As New List(Of rutaTareoDetalle)
        Dim tripulante As rutaTareoTripulantes
        Dim listaTripulantes As New List(Of rutaTareoTripulantes)

        Dim ruta = CType(TextRuta.Tag, rutas)
        Dim prog = CType(TextFechaProgramada.Tag, rutaProgramacionSalidas)
        Dim vehiculo = CType(TextSeriePlaca.Tag, activosFijos)

        obj.idVehiculo = vehiculo.idActivo ' Integer.Parse(TextSeriePlaca.Tag)
        obj.ruta_id = ruta.ruta_id
        obj.horario_id = ruta.ruta_horarios.First.horario_id
        obj.programacion_id = prog.programacion_id
        obj.fecha = TextFechaEmbarque.Value
        obj.nroPlaca = TextCodigoPlaca.Text.Trim
        obj.tipoTareo = TipotareoGeneral.SalidaDeAgencia
        obj.fechaOperacion = Date.Now
        obj.nroPasajeros = Integer.Parse(TextNumPasajeros.Text)
        'obj.nroTripulantes = Integer.Parse(TextNroTripulantes.IntegerValue)
        obj.estado = 1
        obj.usuarioActualizacion = usuario.IDUsuario
        obj.fechaActualizacion = Date.Now

        'detalle del tareo o manifiesto
        For Each i As ListViewItem In formInherits.ListPasajeros.Items
            If i.Checked = True Then
                objDet = New rutaTareoDetalle
                objDet.idVehiculo = obj.idVehiculo
                objDet.ruta_id = obj.ruta_id
                objDet.horario_id = obj.horario_id
                objDet.programacion_id = obj.programacion_id ' Integer.Parse(TextFechaProgramada.Tag)
                objDet.nroasiento = Integer.Parse(i.SubItems(0).Text)
                objDet.entidad_id = Integer.Parse(i.SubItems(1).Text)
                objDet.servicio_id = Integer.Parse(i.SubItems(7).Text)
                objDet.documentoVenta_id = Integer.Parse(i.SubItems(9).Text)
                objDet.servicio = i.SubItems(8).Text
                objDet.tipo = EntidadConsolidacion.Pasajeros
                objDet.idPadre = 0
                objDet.status = EntidadConsolidacionStatus.Pendiente
                objDet.usuarioActualizacion = usuario.IDUsuario
                objDet.fechaActualizacion = Date.Now
                Lista.Add(objDet)
            End If
        Next

        'detalle del tareo o manifiesto
        For Each i As ListViewItem In formInherits.ListEncomiendas.Items
            If i.Checked = True Then
                objDet = New rutaTareoDetalle
                objDet.idVehiculo = obj.idVehiculo
                objDet.ruta_id = obj.ruta_id
                objDet.horario_id = obj.horario_id
                objDet.programacion_id = obj.programacion_id ' Integer.Parse(TextFechaProgramada.Tag)
                objDet.nroasiento = Integer.Parse(i.SubItems(1).Text)
                objDet.entidad_id = Integer.Parse(i.SubItems(4).Text)
                objDet.servicio_id = 0 ' Integer.Parse(i.SubItems(7).Text)
                objDet.documentoVenta_id = Integer.Parse(i.SubItems(0).Text)
                objDet.servicio = i.SubItems(7).Text
                objDet.tipo = EntidadConsolidacion.Encomiendas
                objDet.idPadre = 0
                objDet.status = EntidadConsolidacionStatus.Pendiente
                objDet.usuarioActualizacion = usuario.IDUsuario
                objDet.fechaActualizacion = Date.Now
                Lista.Add(objDet)
            End If
        Next

        tripulante = New rutaTareoTripulantes With
        {
        .idVehiculo = obj.idVehiculo,
        .ruta_id = obj.ruta_id,
        .horario_id = obj.horario_id,
        .programacion_id = obj.programacion_id,
        .idPersona = Integer.Parse(TextChofer1.Tag),
        .nombreCompleto = TextChofer1.Text,
        .numdoc = TextNumIdent1.Text,
        .nroLicencia = TextLicencia1.Text,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        listaTripulantes.Add(tripulante)

        tripulante = New rutaTareoTripulantes With
        {
        .idVehiculo = obj.idVehiculo,
        .ruta_id = obj.ruta_id,
        .horario_id = obj.horario_id,
        .programacion_id = obj.programacion_id,
        .idPersona = Integer.Parse(TextChofer2.Tag),
        .nombreCompleto = TextChofer2.Text,
        .numdoc = TextNumIdent2.Text,
        .nroLicencia = TextLicencia2.Text,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = Date.Now
        }
        listaTripulantes.Add(tripulante)


        obj.rutaTareoDetalle = Lista
        If listaTripulantes IsNot Nothing Then
            If listaTripulantes.Count > 0 Then
                obj.rutaTareoTripulantes = listaTripulantes
            End If
        End If
        consolidacionSA.GrabarConsolidacion(obj, Transporte.ProgramacionEstado.VehiculoAsignadoEnCurso)
        MessageBox.Show("Ruta en curso!", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)
        formInherits.ConfirmarProgramacionRuta()
        Close()
    End Sub

    Private Sub TextSeriePlaca_TextChanged(sender As Object, e As EventArgs) Handles TextSeriePlaca.TextChanged
        TextSeriePlaca.ForeColor = Color.Black
        TextSeriePlaca.Tag = Nothing
    End Sub

    Private Sub TextSeriePlaca_KeyDown(sender As Object, e As KeyEventArgs) Handles TextSeriePlaca.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If TextSeriePlaca.Text.Trim.Length > 0 Then
                GetVehiculosPorNroSerie(TextSeriePlaca.Text.Trim)
            End If
        End If
    End Sub

    Private Sub TextChofer1_TextChanged(sender As Object, e As EventArgs) Handles TextChofer1.TextChanged
        TextChofer1.ForeColor = Color.Black
        TextChofer1.Tag = Nothing
        If TextChofer1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            TextNumIdent1.Visible = True
        Else
            TextNumIdent1.Visible = False
        End If
    End Sub

    Private Sub FillLSVClientes(consulta As List(Of Persona))
        LsvProveedor.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.codigo)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.idPersona)
            n.SubItems.Add(i.tipodoc)
            n.SubItems.Add(i.telefono)
            LsvProveedor.Items.Add(n)
        Next
    End Sub

    Private Sub FillLSVChoferes(consulta As List(Of Persona))
        ListChofer2.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.codigo)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.idPersona)
            n.SubItems.Add(i.tipodoc)
            n.SubItems.Add(i.telefono)
            ListChofer2.Items.Add(n)
        Next
    End Sub

    Private Sub TextChofer1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextChofer1.KeyDown
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
            Me.pcLikeCategoria.ParentControl = Me.TextChofer1
            Me.pcLikeCategoria.ShowPopup(Point.Empty)
            Dim consulta As New List(Of Persona)
            consulta.Add(New Persona With {.nombreCompleto = "Agregar nuevo"})

            Dim consulta2 = (From n In listaPersonas
                             Where n.nombreCompleto.StartsWith(TextChofer1.Text) Or n.idPersona.StartsWith(TextChofer1.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVClientes(consulta)
            e.Handled = True
            ' End If

        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.pcLikeCategoria.Size = New Size(282, 128)
            Me.pcLikeCategoria.ParentControl = Me.TextChofer1
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

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ListChofer2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListChofer2.MouseDoubleClick
        Me.PCChofer2.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
        Dim beneficioSA As New beneficioSA
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If LsvProveedor.SelectedItems.Count > 0 Then
                    If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                        Dim f As New FormCrearTripulante()
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, Persona)
                            listaPersonas.Add(c)
                            TextChofer1.Text = c.nombreCompleto
                            TextNumIdent1.Text = c.idPersona
                            TextChofer1.Tag = c.codigo
                            TextNumIdent1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextNumIdent1.Visible = True
                            TextChofer1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextLicencia1.Text = c.telefono
                        End If
                    Else
                        TextChofer1.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
                        TextChofer1.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
                        TextChofer1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        TextNumIdent1.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
                        TextLicencia1.Text = LsvProveedor.SelectedItems(0).SubItems(4).Text
                        TextNumIdent1.Visible = True
                    End If
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TextChofer1.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub TextChofer2_TextChanged(sender As Object, e As EventArgs) Handles TextChofer2.TextChanged
        TextChofer2.ForeColor = Color.Black
        TextChofer2.Tag = Nothing
        If TextChofer2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
            TextNumIdent2.Visible = True
        Else
            TextNumIdent2.Visible = False
        End If
    End Sub

    Private Sub TextChofer2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextChofer2.KeyDown
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
            Me.PCChofer2.Size = New Size(282, 128)
            Me.PCChofer2.ParentControl = Me.TextChofer2
            Me.PCChofer2.ShowPopup(Point.Empty)
            Dim consulta As New List(Of Persona)
            consulta.Add(New Persona With {.nombreCompleto = "Agregar nuevo"})

            Dim consulta2 = (From n In listaPersonas
                             Where n.nombreCompleto.StartsWith(TextChofer2.Text) Or n.idPersona.StartsWith(TextChofer2.Text)).ToList




            consulta.AddRange(consulta2)
            FillLSVChoferes(consulta)
            e.Handled = True
            ' End If

        End If

        If e.KeyCode = Keys.Down Then
            '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
            Me.PCChofer2.Size = New Size(282, 128)
            Me.PCChofer2.ParentControl = Me.TextChofer2
            Me.PCChofer2.ShowPopup(Point.Empty)
            ListChofer2.Focus()
        End If
        '   End If

        ' e.SuppressKeyPress = True
        If e.KeyCode = Keys.Escape Then
            If Me.PCChofer2.IsShowing() Then
                Me.PCChofer2.HidePopup(PopupCloseType.Canceled)
            End If
        End If
    End Sub

    Private Sub PCChofer2_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles PCChofer2.CloseUp
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.PopupCloseType = PopupCloseType.Done Then
                If ListChofer2.SelectedItems.Count > 0 Then
                    If ListChofer2.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
                        Dim f As New FormCrearTripulante()
                        f.StartPosition = FormStartPosition.CenterParent
                        f.ShowDialog()
                        If Not IsNothing(f.Tag) Then
                            Dim c = CType(f.Tag, Persona)
                            listaPersonas.Add(c)
                            TextChofer2.Text = c.nombreCompleto
                            TextNumIdent2.Text = c.idPersona
                            TextChofer2.Tag = c.codigo
                            TextNumIdent2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextNumIdent2.Visible = True
                            TextChofer2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                            TextLicencia2.Text = c.telefono
                        End If
                    Else
                        TextChofer2.Text = ListChofer2.SelectedItems(0).SubItems(1).Text
                        TextChofer2.Tag = ListChofer2.SelectedItems(0).SubItems(0).Text
                        TextChofer2.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
                        TextNumIdent2.Text = ListChofer2.SelectedItems(0).SubItems(2).Text
                        TextNumIdent2.Visible = True
                        TextLicencia2.Text = LsvProveedor.SelectedItems(0).SubItems(4).Text
                    End If
                End If
            End If

            'Set focus back to textbox.
            If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
                Me.TextChofer2.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub RoundButton23_Click(sender As Object, e As EventArgs)
        Dim f As New FormViewResumenLiquidacion(Integer.Parse(IDProgramacion), "pasajes", Me)
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs)
        Try
            Dim f As New FormViewResumenLiquidacion(
          Integer.Parse(formInherits.ListProgramacionEmbarque.SelectedItems(0).SubItems(0).Text), "encomiendas", Me)
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RoundButton24_Click(sender As Object, e As EventArgs) Handles RoundButton24.Click
        Dim conteo As Integer = 0
        If (TextChofer1.Text.Length > 0) Then
            conteo = conteo + 1
        End If

        If (TextChofer2.Text.Length > 0) Then
            conteo = conteo + 1
        End If

        imprimirEmbarque(IDProgramacion, conteo)

        'HABILITARBUS(IDaCTIVO, IDProgramacion)

    End Sub

    Private Sub HABILITARBUS(IDbUS As Integer, IDpROGRAMC As Integer)
        Try

            Dim RUTAsa As New RutaProgramacionSalidasSA
            Dim RUTABE As rutaProgramacionSalidas

            Dim documentoventaSA As New distribucionInfraestructuraSA
            Dim documentoventaBE As New distribucionInfraestructura
            Dim distribucionInfraturaBE = New distribucionInfraestructura

            distribucionInfraturaBE.idEmpresa = Gempresas.IdEmpresaRuc
            distribucionInfraturaBE.idActivo = CInt(IDbUS)
            distribucionInfraturaBE.estado = "A"

            documentoventaSA.updateDistribucioTrasnportemMasivo(distribucionInfraturaBE)

            RUTABE = New rutaProgramacionSalidas
            RUTABE.estado = 0
            RUTABE.programacion_id = CInt(IDpROGRAMC)

            RUTAsa.UpdateEstadoProgramacion(RUTABE)

            MessageBox.Show("SE HABILITO EL BUS")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub imprimirEmbarque(idProg As Integer, tripulante As Integer)
        Try


            Dim a As EmbarqueTransporte = New EmbarqueTransporte
            Dim lista As New List(Of String)
            Dim gravMN As Decimal = 0
            Dim gravME As Decimal = 0
            Dim ExoMN As Decimal = 0
            Dim ExoME As Decimal = 0
            Dim InaMN As Decimal = 0
            Dim InaME As Decimal = 0
            Dim tipoComprobante As String = String.Empty

            a.conductor1 = TextChofer1.Text
            a.conductor2 = TextChofer2.Text
            a.licencia1 = TextLicencia1.Text
            a.licencia2 = TextLicencia2.Text
            a.ayudante = ""

            a.HeaderImage = Image.FromFile("C:\LogoEmpresa\SELVATOURS_NEGRO.jpg")



            a.tipoEncabezado = False
            'a.AnadirLineaEmpresa(Gempresas.NomEmpresa)


            'a.TextoIzquierda("Domicilio Fiscal: " & "AV. FERROCARRIL N° 1587 HUANCAYO - HUANCAYO - JUNIN")
            ''a.TextoIzquierda("Establ. Anexo: " & objDatosGenrales.direccionSecudaria)
            ''Telefono de la empresa
            'a.TextoIzquierda("Telf: " & "-")
            'a.TextoIzquierda("")

            'a.AnadirLineaEmpresa(Gempresas.NomEmpresa)
            ''Telefono de la empresa
            'a.TextoIzquierda(Gempresas.direccionEmpresa)
            ''direccion de la empresa
            'a.TextoIzquierda(Gempresas.TelefonoEmpresa)
            'a.TextoIzquierda("")
            Dim ventaSA As New DocumentoventaTransporteSA



            Dim comprobanteCliente = ventaSA.DocumentoTransportePasajesSelID(New documentoventaTransporte With
                                                                   {
                                                                   .programacion_id = idProg
                                                                   })



            ''//DATOS DEL CLIENTE
            ''Fecha de Factura
            ''Lugar de la factura
            ''Nombre del cliente
            ''direccion del cliente
            ''numero del cliente
            ''direccion de entrega
            ''tipo moneda de la empresa
            ''telefono de la empresa



            Dim conte As Integer = 0


            For Each comprobante In (comprobanteCliente).OrderBy(Function(O) O.numeroAsiento)
                If (comprobante.estado <> 5) Then
                    If (comprobante.estado <> 6) Then
                        If (comprobante.Consignado = "Varios") Then
                            a.AnadirLineaElementosFactura(comprobante.numeroAsiento.GetValueOrDefault, comprobante.comprador, comprobante.ciudadDestino, comprobante.edad.GetValueOrDefault, comprobante.ciudadOrigen, comprobante.idPersona, "SATIPO2", comprobante.CustomPerson.idPersona, "SATIPO4", comprobante.serie & "-" & comprobante.numero, comprobante.total)
                        Else
                            a.AnadirLineaElementosFactura(comprobante.numeroAsiento.GetValueOrDefault, comprobante.Consignado, comprobante.ciudadDestino, comprobante.edad.GetValueOrDefault, comprobante.ciudadOrigen, comprobante.idPersona, "SATIPO2", comprobante.CustomPerson.idPersona, "SATIPO4", comprobante.serie & "-" & comprobante.numero, comprobante.total)
                        End If

                        conte = conte + 1
                    End If
                End If
            Next


            a.AnadirLineaCaracteresDatosGEnerales(conte,
                                                tripulante,
                                               conte + tripulante,
                                                conte,
                                                "0",
                                                TextRuta.Text,
                                               txtdestino.Text,
                                                CDate(TextFechaProgramada.Value).Date,
                                                CDate(TextFechaProgramada.Value).ToLongTimeString,
                                                "",
                                               TextCodigoPlaca.Text,
                                                "",
                                                TextChofer1.Text,
                                                TextLicencia1.Text,
                                                TextChofer2.Text,
                                               TextChofer2.Text,
                                                "",
                                                "")

            If (Not IsNothing(comprobanteCliente)) Then
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaEncabezadoDerecha(Gempresas.IdEmpresaRuc, (comprobanteCliente(0).documentoventaTransporteDetalle(0).manifiesto), "MANIFIESTO DE PASAJEROS")
                'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                'nombreComprabante = "MANIFIESTO" & numeromanifiesto
                tipoComprobante = "1"
            Else
                'ticket.TextoExtremos("Caja # 1", "Ticket boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                a.AnadirLineaEncabezadoDerecha(Gempresas.IdEmpresaRuc, ("0 - 00000000"), "MANIFIESTO DE PASAJEROS")
                'ticket.TextoIzquierda("Ticket Boleta # " & comprobante.serieVenta & "-" & comprobante.numeroVenta)
                'nombreComprabante = "MANIFIESTO" & numeromanifiesto
                tipoComprobante = "1"

            End If
            a.PosicionLogo = "IT"
            a.ImprimeTicket("TICKET/RUTA", txtNroImpresion.Value)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub TextRuta_TextChanged(sender As Object, e As EventArgs) Handles TextRuta.TextChanged

    End Sub

    Private Sub TextFechaProgramada_ValueChanged(sender As Object, e As EventArgs) Handles TextFechaProgramada.ValueChanged

    End Sub

    Private Sub FormConsolidarSalidaEmbarque_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        General.Centrar(Me)
    End Sub
End Class