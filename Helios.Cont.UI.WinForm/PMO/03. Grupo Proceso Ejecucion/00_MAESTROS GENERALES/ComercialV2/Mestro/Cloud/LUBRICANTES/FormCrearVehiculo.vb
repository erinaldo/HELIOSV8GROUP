Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class FormCrearVehiculo

#Region "Attributes"
    Public vehiculo As Vehiculo
    Public Property vehiculoSA As New ActivosFijosSA
#End Region

#Region "Constructors"
    Public Sub New(be As entidad)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        vehiculo = New Vehiculo
        GetMappingEntidad(be)
        GetCombos()
    End Sub
#End Region

#Region "Methods"
    Sub GetMappingEntidad(be As entidad)
        TextCliente.Tag = be.idEntidad
        TextCliente.Text = be.nombreCompleto
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
        .idEntidad = TextCliente.Tag,
        .cuenta = 10,
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .idEstablecimiento = GEstableciento.IdEstablecimiento,
        .descripcionItem = "VEHICULO",
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

        vehiculoSA.InsertActivoFijo(vehiculo)
        MessageBox.Show("Vehículo registrado con exito", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
#End Region

#Region "Events"
    Private Sub RoundButton22_Click(sender As Object, e As EventArgs) Handles RoundButton22.Click
        Close()
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Try
            CrearVehiculo()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

End Class