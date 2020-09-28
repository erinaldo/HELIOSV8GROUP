Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Public Class FormCrearActivo


#Region "Attributes"
    Public vehiculo As Vehiculo
    Public Property vehiculoSA As New ActivosFijosSA
    Public Property Manipulation As Entity.EntityState
#End Region

#Region "Constructors"

    Public Sub New(idActivo As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        vehiculo = New Vehiculo
        GetCombos()
        UbicarVehiculo(idActivo)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        vehiculo = New Vehiculo
        GetCombos()
    End Sub
#End Region

#Region "Methods"

    Private Sub UbicarVehiculo(idActivo As Integer)
        Dim vehiculo = vehiculoSA.GetUbicar_activosFijosPorID(idActivo)
        If vehiculo IsNot Nothing Then
            TextDescripcion.Tag = vehiculo.idActivo
            TextDescripcion.Text = vehiculo.descripcionItem
            TextMatricula.Text = vehiculo.nroSeriePlaca
            TextAnio.Text = vehiculo.anio
            TextColor.Text = vehiculo.color
            TextOdometro.Text = vehiculo.odometro
        End If
    End Sub

    Private Sub GetCombos()
        ComboMarca.DataSource = vehiculo.ListaMarca
        ComboMarca.DisplayMember = "MarcaName"
        ComboMarca.ValueMember = "IDMarca"
        ComboMarca.Enabled = True

        ComboModelo.DataSource = vehiculo.ListaModelo
        ComboModelo.DisplayMember = "ModeloName"
        ComboModelo.ValueMember = "IDModelo"
        ComboModelo.Enabled = True

        ComboMotor.DataSource = vehiculo.ListaMotor
        ComboMotor.DisplayMember = "MotorName"
        ComboMotor.ValueMember = "IDMotor"
        ComboMotor.Enabled = True

        ComboTransmision.DataSource = vehiculo.ListaTransmision
        ComboTransmision.DisplayMember = "TransmisionName"
        ComboTransmision.ValueMember = "IDTransimision"
        ComboTransmision.Enabled = True
        '------------------------------------------------------------------
        ComboTipoVehiculo.DataSource = vehiculo.ListaTipo
        ComboTipoVehiculo.DisplayMember = "TipoName"
        ComboTipoVehiculo.ValueMember = "IDTipo"
        ComboTipoVehiculo.Enabled = True

        ComboSistemaCombustion.DataSource = vehiculo.ListaSistemaCombustion
        ComboSistemaCombustion.DisplayMember = "SistemaName"
        ComboSistemaCombustion.ValueMember = "IDSistemaCMB"
        ComboSistemaCombustion.Enabled = True

        ComboCombustible.DataSource = vehiculo.ListaCombustible
        ComboCombustible.DisplayMember = "CombustibleName"
        ComboCombustible.ValueMember = "IDCombustible"
        ComboCombustible.Enabled = True

        ComboDireccion.DataSource = vehiculo.ListaDireccion
        ComboDireccion.DisplayMember = "DirName"
        ComboDireccion.ValueMember = "IDDir"
        ComboDireccion.Enabled = True
    End Sub

    Private Sub CrearVehiculo()
        Dim vehiculo As New activosFijos With
        {
        .cuenta = 10,
        .idEntidad = 1,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        .descripcionItem = TextDescripcion.Text,
        .unidadMedida = "UND",
        .unidad2 = "UND",
        .tipoActivo = "1",
        .anio = Integer.Parse(TextAnio.Text),
        .nroSeriePlaca = TextMatricula.Text,
        .marca = ComboMarca.SelectedValue,
        .modelo = ComboModelo.SelectedValue,
        .motor = ComboMotor.SelectedValue,
        .color = TextColor.Text,
        .transimision = Integer.Parse(ComboTransmision.SelectedValue),
        .odometro = TextOdometro.Text,
        .sistemaCombustion = Integer.Parse(ComboSistemaCombustion.SelectedValue),
        .combustible = Integer.Parse(ComboCombustible.SelectedValue),
        .direccion = Integer.Parse(ComboDireccion.SelectedValue),
        .destinoGravado = "1",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
        }

        'vehiculo.vehiculoAsientos = GetAsientos()

        vehiculoSA.InsertActivoFijo(vehiculo)
        MessageBox.Show("Vehículo registrado con exito", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub ModificarVehiculo()
        Dim vehiculo As New activosFijos With
        {
        .cuenta = 10,
        .idActivo = TextDescripcion.Tag,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        .descripcionItem = TextDescripcion.Text,
        .unidadMedida = "UND",
        .unidad2 = "UND",
        .tipoActivo = "1",
        .anio = Integer.Parse(TextAnio.Text),
        .nroSeriePlaca = TextMatricula.Text,
        .marca = ComboMarca.SelectedValue,
        .modelo = ComboModelo.SelectedValue,
        .motor = ComboMotor.SelectedValue,
        .color = TextColor.Text,
        .transimision = Integer.Parse(ComboTransmision.SelectedValue),
        .odometro = TextOdometro.Text,
        .sistemaCombustion = Integer.Parse(ComboSistemaCombustion.SelectedValue),
        .combustible = Integer.Parse(ComboCombustible.SelectedValue),
        .direccion = Integer.Parse(ComboDireccion.SelectedValue),
        .destinoGravado = "1",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
        }

        'vehiculo.vehiculoAsientos = GetAsientos()

        vehiculoSA.ModificarActivo(vehiculo)
        MessageBox.Show("Vehículo registrado con exito", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Function MappingAsientos(i As ListViewItem) As List(Of vehiculoAsientos)
        MappingAsientos = New List(Of vehiculoAsientos)
        Dim obj As vehiculoAsientos
        For index = 1 To Integer.Parse(i.SubItems(1).Text)
            obj = New vehiculoAsientos
            obj.codeAlfanumerico = index.ToString
            obj.descripcion = "ASIENTO"
            obj.tipo = 1
            obj.ubicacion = i.SubItems(0).Text
            obj.costoEstimado = 0
            obj.estado = 1
            MappingAsientos.Add(obj)
        Next
    End Function


#End Region

#Region "Events"
    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Close()
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Try
            If TextDescripcion.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe ingresar una descripción del vehículo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextDescripcion.Select()
                TextDescripcion.Focus()
                Exit Sub
            End If

            If TextMatricula.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe ingresar un número de matrícula!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextMatricula.Select()
                TextMatricula.Focus()
                Exit Sub
            End If

            If TextColor.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe ingresar el color del vehículo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextColor.Select()
                TextColor.Focus()
                Exit Sub
            End If

            If IsNumeric(TextAnio.Text) Then
                If TextAnio.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe ingresar un año del vehículo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                    TextAnio.Select()
                    TextAnio.Focus()
                End If
            Else
                MessageBox.Show("Debe ingresar un año valido", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextAnio.Select()
                TextAnio.Focus()
                Exit Sub
            End If

            If IsNumeric(TextOdometro.Text) Then
                If TextOdometro.Text.Trim.Length = 0 Then
                    MessageBox.Show("Debe ingresar el odometro del vehículo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    TextOdometro.Select()
                    TextOdometro.Focus()
                    Exit Sub
                End If
            Else
                MessageBox.Show("Debe ingresar el odometro del vehículo!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextOdometro.Select()
                TextOdometro.Focus()
                Exit Sub
            End If

            'If ListView1.Items.Count > 0 Then
            If Manipulation = Entity.EntityState.Added Then
                CrearVehiculo()
            Else
                ModificarVehiculo()
            End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


#End Region

End Class