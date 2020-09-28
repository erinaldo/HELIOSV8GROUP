Imports Helios.General
Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Syncfusion.Windows.Forms
Public Class FormConfirmaEntregaEncomiendas

    Public Property formInherits As UCEncomiendasPorEntregar
    Public Property ProgramacionSA As New RutaProgramacionSalidasSA
    Dim thread As System.Threading.Thread
    Dim PersonaSA As New PersonaSA
    Friend Delegate Sub SetDataSourceDelegate(ByVal lista As List(Of Persona))
    'Public Property listaPersonas As List(Of Persona)
    Public Property formPrincipalSel As UCEncomiendas
    Public Property ListaTrasnportistas As List(Of Persona)

#Region "Constructors"
    Public Sub New(form As UCEncomiendasPorEntregar, formPrincipal As UCEncomiendas)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        TextOrigen.Text = form.ComboAgenciaOrigen.Text
        TextOrigen.Tag = Integer.Parse(form.ComboAgenciaOrigen.SelectedValue)
        TextDestino.Text = form.ListCiudades.SelectedItems(0).SubItems(1).Text
        TextDestino.Tag = Integer.Parse(form.ListCiudades.SelectedItems(0).SubItems(0).Text)
        formPrincipalSel = formPrincipal
        TextFechaProgramada.Value = Date.Now
        formInherits = form
        ' threadPersonas()
        CargarVehiculos()
        GetComboPersonas()
    End Sub

#End Region

#Region "Methods"

    Public Sub GetComboPersonas()
        ListaPersonas = New List(Of Persona)
        'ListaPersonas = PersonaSA.ObtenerPersona(New Persona With {.idEmpresa = Gempresas.IdEmpresaRuc,
        '                                         .tipoPersona = "T",
        '                                         .estado = "A"}).ToList '.Where(Function(o) o.tipoPersona = "T").ToList
        ListaTrasnportistas = ListaPersonas.Where(Function(o) o.tipoPersona = "T").ToList
        ComboChofer.DataSource = ListaTrasnportistas
        ComboChofer.ValueMember = "codigo"
        ComboChofer.DisplayMember = "nombreCompleto"
    End Sub

    Private Sub CargarVehiculos()
        Dim activoSA As New ActivosFijosSA
        Dim lista = activoSA.GetListar_activosFijosEmpresa(
            New activosFijos With
            {
            .idEmpresa = Gempresas.IdEmpresaRuc,
            .idEstablecimiento = formInherits.ComboAgenciaOrigen.SelectedValue
            })

        ComboVehiculo.DataSource = lista
        ComboVehiculo.ValueMember = "idActivo"
        ComboVehiculo.DisplayMember = "nroSeriePlaca"

    End Sub

    'Private Sub threadPersonas()
    '    Dim tipo = TIPO_ENTIDAD.CLIENTE
    '    Dim empresa = Gempresas.IdEmpresaRuc
    '    thread = New System.Threading.Thread(New System.Threading.ThreadStart(Sub() Getpersonas(tipo, empresa)))
    '    thread.Start()
    'End Sub

    'Private Sub Getpersonas(tipo As String, empresa As String)
    '    Dim lista As New List(Of Persona)
    '    lista = New List(Of Persona)
    '    lista.AddRange(PersonaSA.ObtenerPersona(Gempresas.IdEmpresaRuc))
    '    setDataSource(lista)
    'End Sub

    'Private Sub setDataSource(ByVal lista As List(Of Persona))
    '    If Me.InvokeRequired Then
    '        'Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)

    '        Dim deleg As New SetDataSourceDelegate(AddressOf setDataSource)
    '        Invoke(deleg, New Object() {lista})
    '    Else
    '        ListaPersonas = New List(Of Persona)
    '        ListaPersonas = lista
    '    End If
    'End Sub

    'Sub GetVehiculosPorNroSerie(placaSerie As String)
    '    Dim ActivoSA As New ActivosFijosSA
    '    Dim listaVehiculos = ActivoSA.GetListar_activosFijosSeriePlaca(New Business.Entity.activosFijos With
    '                                                                   {
    '                                                                   .idEmpresa = Gempresas.IdEmpresaRuc,
    '                                                                   .idEstablecimiento = GEstableciento.IdEstablecimiento,
    '                                                                   .nroSeriePlaca = placaSerie
    '                                                                   })


    '    If listaVehiculos.Count > 0 Then
    '        TextSeriePlaca.Text = $"{listaVehiculos.FirstOrDefault.nroSeriePlaca}-{listaVehiculos.FirstOrDefault.descripcionItem}"
    '        TextSeriePlaca.Tag = listaVehiculos.FirstOrDefault
    '        TextSeriePlaca.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)


    '        TextCodigoPlaca.Text = listaVehiculos.FirstOrDefault.nroSeriePlaca
    '        'If MessageBox.Show("Se encontró vehiculo(s), desea agregarlo(s) ahora?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

    '        '    For Each i In listaVehiculos
    '        '        Dim n As New ListViewItem(i.idActivo)
    '        '        n.SubItems.Add(i.descripcionItem)
    '        '        n.SubItems.Add(i.anio)
    '        '        n.SubItems.Add(i.modelo)
    '        '        n.SubItems.Add(i.marca)
    '        '        n.SubItems.Add(i.color)
    '        '        n.SubItems.Add(i.motor)
    '        '        n.SubItems.Add(i.nroSeriePlaca)
    '        '        ListView1.Items.Add(n)
    '        '    Next
    '        'End If
    '    Else
    '        MessageBox.Show("No se encontraron datos con el número serie/placa ingresado!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        TextSeriePlaca.Focus()
    '        TextSeriePlaca.ForeColor = Color.Black
    '    End If
    'End Sub
#End Region

#Region "Events"
    Private Sub TextSeriePlaca_TextChanged(sender As Object, e As EventArgs)
        'TextSeriePlaca.ForeColor = Color.Black
        'TextSeriePlaca.Tag = Nothing
    End Sub

    Private Sub TextSeriePlaca_KeyDown(sender As Object, e As KeyEventArgs)
        'If e.KeyCode = Keys.Enter Then
        '    e.SuppressKeyPress = True
        '    If TextSeriePlaca.Text.Trim.Length > 0 Then
        '        GetVehiculosPorNroSerie(TextSeriePlaca.Text.Trim)
        '    End If
        'End If
    End Sub

    'Private Sub TextChofer1_TextChanged(sender As Object, e As EventArgs)
    '    TextChofer1.ForeColor = Color.Black
    '    TextChofer1.Tag = Nothing
    '    If TextChofer1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack) Then
    '        TextNumIdent1.Visible = True
    '    Else
    '        TextNumIdent1.Visible = False
    '    End If
    'End Sub

    'Private Sub TextChofer1_KeyDown(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Or e.KeyCode = Keys.Delete Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.ShiftKey Or e.KeyCode = Keys.End Then

    '    ElseIf e.KeyCode = Keys.Enter Then
    '        'Me.pcLikeCategoria.Size = New Size(319, 128)
    '        'Me.pcLikeCategoria.ParentControl = Me.textPersona
    '        'Me.pcLikeCategoria.ShowPopup(Point.Empty)
    '        'Dim consulta As New List(Of entidad)
    '        'consulta.Add(New entidad With {.nombreCompleto = "Agregar nuevo"})



    '        'Dim consulta2 = (From n In listaPersonas
    '        '                 Where n.nombreCompleto.StartsWith(textPersona.Text) Or n.idPersona.StartsWith(textPersona.Text)).ToList


    '        'consulta.AddRange(consulta2)
    '        'FillLSVClientes(consulta)
    '        'If consulta.Count <= 1 Then
    '        '    If MessageBox.Show("El cliente ingresado no existe!. Desea crearlo ahora?", "Atención!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

    '        '        Dim f As New FormCrearPersonaPasajero()
    '        '        f.StartPosition = FormStartPosition.CenterParent
    '        '        f.ShowDialog(Me)
    '        '        If f.Tag IsNot Nothing Then
    '        '            Dim c = CType(f.Tag, Persona)
    '        '            textPersona.Text = c.nombreCompleto
    '        '            textPersona.Tag = c.idPersona
    '        '            txtruc.Visible = True
    '        '            txtruc.Text = c.idPersona
    '        '            txtruc.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '        '            textPersona.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '        '            listaPersonas.Add(c)
    '        '        End If
    '        '    End If
    '        'End If
    '    Else
    '        '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
    '        ' If RBNatural.Checked = True Then
    '        Me.pcLikeCategoria.Size = New Size(282, 128)
    '        Me.pcLikeCategoria.ParentControl = Me.TextChofer1
    '        Me.pcLikeCategoria.ShowPopup(Point.Empty)
    '        Dim consulta As New List(Of Persona)
    '        consulta.Add(New Persona With {.nombreCompleto = "Agregar nuevo"})

    '        Dim consulta2 = (From n In ListaPersonas
    '                         Where n.nombreCompleto.StartsWith(TextChofer1.Text) Or n.idPersona.StartsWith(TextChofer1.Text)).ToList




    '        consulta.AddRange(consulta2)
    '        FillLSVClientes(consulta)
    '        e.Handled = True
    '        ' End If

    '    End If

    '    If e.KeyCode = Keys.Down Then
    '        '    Me.pcLikeCategoria.Font = New Font("Segoe UI", 8)
    '        Me.pcLikeCategoria.Size = New Size(282, 128)
    '        Me.pcLikeCategoria.ParentControl = Me.TextChofer1
    '        Me.pcLikeCategoria.ShowPopup(Point.Empty)
    '        LsvProveedor.Focus()
    '    End If
    '    '   End If

    '    ' e.SuppressKeyPress = True
    '    If e.KeyCode = Keys.Escape Then
    '        If Me.pcLikeCategoria.IsShowing() Then
    '            Me.pcLikeCategoria.HidePopup(PopupCloseType.Canceled)
    '        End If
    '    End If
    'End Sub

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

    Private Sub FillLSVChoferes(consulta As List(Of Persona))
        ListChofer2.Items.Clear()
        '     Dim image = ImageList1.Images(0)
        For Each i In consulta
            Dim n As New ListViewItem(i.codigo)

            n.SubItems.Add(i.nombreCompleto)
            n.SubItems.Add(i.idPersona)
            n.SubItems.Add(i.tipodoc)
            ListChofer2.Items.Add(n)
        Next
    End Sub

    Private Sub lsvProveedor_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles LsvProveedor.MouseDoubleClick
        Me.pcLikeCategoria.HidePopup(PopupCloseType.Done)
    End Sub

    Private Sub ListChofer2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListChofer2.MouseDoubleClick
        Me.PCChofer2.HidePopup(PopupCloseType.Done)
    End Sub

    'Private Sub pcLikeCategoria_CloseUp(sender As Object, e As PopupClosedEventArgs) Handles pcLikeCategoria.CloseUp
    '    Dim beneficioSA As New beneficioSA
    '    Me.Cursor = Cursors.WaitCursor
    '    Try
    '        If e.PopupCloseType = PopupCloseType.Done Then
    '            If LsvProveedor.SelectedItems.Count > 0 Then
    '                If LsvProveedor.SelectedItems(0).SubItems(1).Text = "Agregar nuevo" Then
    '                    Dim f As New FormCrearTripulante()
    '                    f.StartPosition = FormStartPosition.CenterParent
    '                    f.ShowDialog()
    '                    If Not IsNothing(f.Tag) Then
    '                        Dim c = CType(f.Tag, Persona)
    '                        listaPersonas.Add(c)
    '                        TextChofer1.Text = c.nombreCompleto
    '                        TextNumIdent1.Text = c.idPersona
    '                        TextChofer1.Tag = c.codigo
    '                        TextNumIdent1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                        TextNumIdent1.Visible = True
    '                        TextChofer1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                        TextLicencia1.Text = c.telefono
    '                    End If
    '                Else
    '                    TextChofer1.Text = LsvProveedor.SelectedItems(0).SubItems(1).Text
    '                    TextChofer1.Tag = LsvProveedor.SelectedItems(0).SubItems(0).Text
    '                    TextChofer1.ForeColor = Color.FromKnownColor(KnownColor.HotTrack)
    '                    TextNumIdent1.Text = LsvProveedor.SelectedItems(0).SubItems(2).Text
    '                    TextNumIdent1.Visible = True
    '                End If
    '            End If
    '        End If

    '        'Set focus back to textbox.
    '        If e.PopupCloseType = PopupCloseType.Done OrElse e.PopupCloseType = PopupCloseType.Canceled Then
    '            Me.TextChofer1.Focus()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    '    Me.Cursor = Cursors.Arrow
    'End Sub

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

    Private Sub PCChofer2_CausesValidationChanged(sender As Object, e As EventArgs) Handles PCChofer2.CausesValidationChanged

    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Try
            'If ComboChofer.Text.Trim.Length > 0 Then
            GrabarEnvio()
            'Else
            '    MessageBox.Show("Debe indicar un chofer valido!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GrabarEnvio()
        Dim ventaSA As New DocumentoventaTransporteSA
        Dim obj As rutaTareoEncomienda
        Dim objDet As rutaTareoEncomiendaDetalle
        Dim listaDetalle As New List(Of rutaTareoEncomiendaDetalle)
        Dim listaTareos As New List(Of rutaTareoEncomienda)

        obj = New rutaTareoEncomienda With
            {
            .agenciaDestino_id = TextDestino.Tag,
            .agenciaOrigen_id = TextOrigen.Tag,
            .idVehiculo = 0,' ComboVehiculo.SelectedValue,
            .fechaEnvio = TextFechaProgramada.Value,
            .tripulante1 = 0,'Integer.Parse(ComboChofer.SelectedValue),
            .tripulante2 = 0,',Integer.Parse(TextChofer2.Tag),
            .otros = 0,
            .chofer = TextChoferTripulante.Text,
            .matriculaUnidad = TextUnidadVehiculo.Text,
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = Date.Now
            }

        Dim tipo As String = String.Empty
        For Each i In formInherits.listaEncomiendas
            'Select Case i.CustomDocumentoVentaDetalle.tipo
            '    Case "P"
            '        tipo = "PAQUETE"
            '    Case "S"
            '        tipo = "SOBRE"
            '    Case "C"
            '        tipo = "CAJA"
            '    Case "O"
            '        tipo = "OTROS"
            'End Select

            objDet = New rutaTareoEncomiendaDetalle With
            {
            .venta_id = i.idDocumento,
            .venta_detalle_id = i.CustomDocumentoVentaDetalle.secuencia,
            .remitente = i.Remitente,
            .consignado = i.Consignado,
            .tipo = i.CustomDocumentoVentaDetalle.tipo,
            .cantidad = i.CustomDocumentoVentaDetalle.cantidad,
            .contenido = i.CustomDocumentoVentaDetalle.detalle,
            .costo = i.CustomDocumentoVentaDetalle.importe,
            .estado = 0,
            .usuarioActualizacion = usuario.IDUsuario,
            .fechaActualizacion = Date.Now
            }
            listaDetalle.Add(objDet)
        Next
        obj.rutaTareoEncomiendaDetalle = listaDetalle

        listaTareos.Add(obj)

        Dim listaDocumentosVenta = (From n In listaDetalle
                                    Select n.venta_id).Distinct.ToList


        Dim ventas As New List(Of documentoventaTransporte)
        For Each i In listaDocumentosVenta
            ventas.Add(New documentoventaTransporte With {.idDocumento = i})
        Next

        If RBPendiente.Checked = True Then

            ImprimirPendiente()

            ventaSA.ActualizarEntrega(ventas, listaTareos)


        ElseIf RBAcumulado.Checked = True Then
            ventaSA.ActualizarEntrega(ventas, listaTareos)

            ' If MessageBox.Show("Encomiendas enviadas, Desea imprimir resumen ahora?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Imprimir()
            '  End If
        ElseIf RBNoImprimir.Checked = True Then
            ventaSA.ActualizarEntrega(ventas, listaTareos)
        End If

        formInherits.GetEncomiendas()
        formPrincipalSel.Conteos()
        Close()
    End Sub

    Private Sub ImprimirSingle(listaEncomiendas As List(Of documentoventaTransporte))
        Dim a As ImpresionTransportesA5V2 = New ImpresionTransportesA5V2
        ' Logo de la Empresa

        Dim lista As New List(Of String)

        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0


        Dim tipoComprobante As String = String.Empty


        a.AnadirLineaEmpresa("RELACION DE ENCOMIENDAS CARTAS Y GIROS")

        '//*************************
        'direccion de la empresa
        'a.TextoIzquierda("FECHA: " & TextFechaProgramada.Value.ToShortDateString)
        'a.TextoIzquierda("HORA: " & TextFechaProgramada.Value.ToShortTimeString)
        'a.TextoIzquierda("UNIDAD - VEHICULO: " & TextUnidadVehiculo.Text) ' ComboVehiculo.Text)
        'a.TextoIzquierda("CONDUCTOR: " & TextChoferTripulante.Text) ' ComboChofer.Text)
        'a.TextoIzquierda("ORIGEN: " & TextOrigen.Text)
        'a.TextoIzquierda("DESTINO: " & TextDestino.Text)

        Dim HORA As String = TextFechaProgramada.Value.ToShortTimeString
        Dim FECHAENVIO As String = TextFechaProgramada.Value.ToShortDateString
        a.AnadirLineaCabeza($"{"FECHA: "}{FECHAENVIO}                                                       {"HORA: "}{HORA}                                              {"UNIDAD: "}{TextUnidadVehiculo.Text}")
        a.AnadirLineaCabeza($"{"ORIGEN: "}{TextOrigen.Text}                                                     {"DESTINO: "}{TextDestino.Text}")

        '*********************** TODO LOS DETALLES DE LOS ITEM *********************
        'CODIGO
        'DESCRIPCION
        'CANTIDAD
        'UM
        'VALOR VENTA UNITARIO
        'DESCUENTO
        'VALOR DE VENTA TOTAL
        'OTROS CARGOS
        'IMPUESTOS
        'PRECIO DE VENTA
        'VALOR TOTAL


        'a.AnadirLineaElementosFactura(1, "NOMBRE PRODUCTO numero 1 DE MAYKOL CHARLY  SANCHEZ CORIS  001", "5", "UND", 15.0, "0.00", 10.0, "0.00", 0.18, 15.0, 30.0)
        Dim consignado As String = String.Empty
        Dim tipo As String = String.Empty
        Dim comprador = String.Empty
        For Each i In listaEncomiendas

            Select Case i.CustomDocumentoVentaDetalle.tipo
                Case "P"
                    tipo = "PAQUETE"
                Case "S"
                    tipo = "SOBRE"
                Case "C"
                    tipo = "CAJA"
                Case "CO"
                    tipo = "S/COSTAL"
                Case "O"
                    tipo = "OTRO"
            End Select

            If i.Consignado IsNot Nothing Then
                consignado = i.Consignado
            Else
                consignado = i.comprador
            End If
            'a.AnadirLineaElementosEncomienda($"{i.serie}-{i.numero}",
            '                                 i.Remitente,
            '                                 consignado,
            '                                 i.Cantidad,
            '                                 i.ContenidoEnviado,
            '                                 i.tipo, i.CostoDetalle, Date.Now)

            a.AnadirLineaElementosEncomienda($"{i.serie}-{i.numero}",
                                                "",
                                                 consignado,
                                                 i.CustomDocumentoVentaDetalle.cantidad,
                                                 tipo,
                                                 i.CustomDocumentoVentaDetalle.detalle,
                                                 i.CustomDocumentoVentaDetalle.importe, "")

        Next
        'a.AnadirLineaElementosEncomienda("b001-2145", "MAYKOL CHARLY SANCHEZ CORIS", "JIUNI PALACIONS SANTOS", "15.00", "COSTAL DE FRUTAS", "PAQUETE", "10.00", Date.Now)

        'a.ImprimeTicket("Microsoft Print to PDF")

        'ComboPrint.Text
        a.ImprimeTicket("TICKET/RUTA")
    End Sub

    Public Sub Imprimir()


        Dim ventaSA As New DocumentoventaTransporteSA

        '  Dim listaEncomiendas = formInherits.listaEncomiendas

        Dim listaEncomiendas = ventaSA.GetEncomiendasSelAgenciaDestino(New Business.Entity.documentoventaTransporte With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .agenciaDestino_id = Integer.Parse(formInherits.ListCiudades.SelectedItems(0).SubItems(0).Text),
                                                          .fechadoc = formInherits.TextFechaPersonal.Value,
                                                          .estado = Transporte.EncomiendaEstado.Entregado
                                                          })


        ImprimirSingle(listaEncomiendas)
        ' ImprimirSingle(listaEncomiendas)
        'a.ImprimeTicket("PDF24 PDF")

    End Sub

    Private Sub ImprimirPednienteSingle(listaEncomiendas As List(Of documentoventaTransporte))
        Dim a As ImpresionTransportesA5V2 = New ImpresionTransportesA5V2
        ' Logo de la Empresa

        Dim lista As New List(Of String)

        Dim gravMN As Decimal = 0
        Dim gravME As Decimal = 0
        Dim ExoMN As Decimal = 0
        Dim ExoME As Decimal = 0
        Dim InaMN As Decimal = 0
        Dim InaME As Decimal = 0


        Dim tipoComprobante As String = String.Empty


        a.AnadirLineaEmpresa("RELACION DE ENCOMIENDAS CARTAS Y GIROS")

        '//*************************
        'direccion de la empresa
        'a.TextoIzquierda("FECHA: " & TextFechaProgramada.Value.ToShortDateString)
        'a.TextoIzquierda("HORA: " & TextFechaProgramada.Value.ToShortTimeString)
        'a.TextoIzquierda("UNIDAD - VEHICULO: " & TextUnidadVehiculo.Text) ' ComboVehiculo.Text)
        'a.TextoIzquierda("CONDUCTOR: " & TextChoferTripulante.Text) ' ComboChofer.Text)
        'a.TextoIzquierda("ORIGEN: " & TextOrigen.Text)
        'a.TextoIzquierda("DESTINO: " & TextDestino.Text)

        Dim HORA As String = TextFechaProgramada.Value.ToShortTimeString
        Dim FECHAENVIO As String = TextFechaProgramada.Value.ToShortDateString
        a.AnadirLineaCabeza($"{"FECHA: "}{FECHAENVIO}                                                       {"HORA: "}{HORA}                                              {"UNIDAD: "}{TextUnidadVehiculo.Text}")
        a.AnadirLineaCabeza($"{"ORIGEN: "}{TextOrigen.Text}                                                     {"DESTINO: "}{TextDestino.Text}")

        '*********************** TODO LOS DETALLES DE LOS ITEM *********************
        'CODIGO
        'DESCRIPCION
        'CANTIDAD
        'UM
        'VALOR VENTA UNITARIO
        'DESCUENTO
        'VALOR DE VENTA TOTAL
        'OTROS CARGOS
        'IMPUESTOS
        'PRECIO DE VENTA
        'VALOR TOTAL


        'a.AnadirLineaElementosFactura(1, "NOMBRE PRODUCTO numero 1 DE MAYKOL CHARLY  SANCHEZ CORIS  001", "5", "UND", 15.0, "0.00", 10.0, "0.00", 0.18, 15.0, 30.0)
        Dim consignado As String = String.Empty
        Dim tipo As String = String.Empty
        Dim comprador = String.Empty
        For Each i In listaEncomiendas

            Select Case i.CustomDocumentoVentaDetalle.tipo
                Case "P"
                    tipo = "PAQUETE"
                Case "S"
                    tipo = "SOBRE"
                Case "C"
                    tipo = "CAJA"
                Case "CO"
                    tipo = "S/COSTAL"
                Case "O"
                    tipo = "OTRO"
            End Select

            If i.Consignado IsNot Nothing Then
                consignado = i.Consignado
            Else
                consignado = i.comprador
            End If
            'a.AnadirLineaElementosEncomienda($"{i.serie}-{i.numero}",
            '                                 i.Remitente,
            '                                 consignado,
            '                                 i.Cantidad,
            '                                 i.ContenidoEnviado,
            '                                 i.tipo, i.CostoDetalle, Date.Now)

            a.AnadirLineaElementosEncomienda($"{i.serie}-{i.numero}",
                                              "",
                                               consignado,
                                               i.CustomDocumentoVentaDetalle.cantidad,
                                               tipo,
                                               i.CustomDocumentoVentaDetalle.detalle,
                                               i.CustomDocumentoVentaDetalle.importe, "")


            ''*********************** TODO LOS DETALLES DE LOS ITEM *********************
            ''CODIGO
            ''CONSIGNADO
            ''CANTIDAD
            ''TIPO PAQUETE
            ''DETALLE PAQUETE
            ''IMPORTE
            'VACIO

            'a.AnadirLineaElementosEncomienda(5464564562,
            '                                 "",
            '                                 "MAYKOL CHARLY SANCHEZ CORIS ",
            '                                 "1.00",
            '                                 "PAQUETE",
            '                                 "Concurrent DOCUMENTOS",
            '                                 "100000000.00",
            '                                 "")

        Next
        'a.AnadirLineaElementosEncomienda("b001-2145", "MAYKOL CHARLY SANCHEZ CORIS", "JIUNI PALACIONS SANTOS", "15.00", "COSTAL DE FRUTAS", "PAQUETE", "10.00", Date.Now)

        'a.ImprimeTicket("Microsoft Print to PDF")

        'ComboPrint.Text
        a.ImprimeTicket("TICKET/RUTA")
    End Sub

    Public Sub ImprimirPendiente()

        Dim ventaSA As New DocumentoventaTransporteSA

        ' Dim listaEncomiendas = formInherits.listaEncomiendas

        Dim listaEncomiendas = ventaSA.GetEncomiendasSelAgenciaDestino(New Business.Entity.documentoventaTransporte With
                                                          {
                                                          .idEmpresa = Gempresas.IdEmpresaRuc,
                                                          .agenciaDestino_id = Integer.Parse(formInherits.ListCiudades.SelectedItems(0).SubItems(0).Text),
                                                          .fechadoc = formInherits.TextFechaPersonal.Value,
                                                          .estado = Transporte.EncomiendaEstado.PendienteDeEntrega
                                                          })

        ImprimirPednienteSingle(listaEncomiendas)
        '  ImprimirPednienteSingle(listaEncomiendas)

    End Sub

    Private Sub RoundButton22_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboVehiculo_Click(sender As Object, e As EventArgs) Handles ComboVehiculo.Click

    End Sub

    Private Sub ComboVehiculo_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboVehiculo.SelectedValueChanged
        If IsNumeric(ComboVehiculo.SelectedValue) Then
            TextCodigoPlaca.Text = ComboVehiculo.Text
        End If
    End Sub

    Private Sub FormConfirmaEntregaEncomiendas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim instance As New Printing.PrinterSettings
        instance.DefaultPageSettings.Landscape = True
        Dim impresosaPredt As String = instance.PrinterName

        For Each item As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters
            ComboPrint.Items.Add(item.ToString)
        Next
        If ComboPrint.Items.Count > 0 Then
            ComboPrint.SelectedText = impresosaPredt
        End If
    End Sub

    'Private Sub ComboChofer_Click(sender As Object, e As EventArgs) Handles ComboChofer.Click
    '    Try
    '        If IsNumeric(ComboChofer.SelectedValue) Then
    '            Dim chofer = ListaTrasnportistas.Where(Function(o) o.codigo = Integer.Parse(ComboChofer.SelectedValue)).FirstOrDefault

    '            If chofer IsNot Nothing Then
    '                TextNumIdent1.Text = chofer.idPersona
    '                TextLicencia1.Text = chofer.telefono
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim f As New FormCrearTripulante()
        f.StartPosition = FormStartPosition.CenterParent
        f.ShowDialog(Me)
        GetComboPersonas()
    End Sub
#End Region
End Class