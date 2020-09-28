Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General
Imports Syncfusion.Windows.Forms.Grid

Public Class FormCrearSubRuta

#Region "Attributes"
    Dim listaRegiones As New List(Of regiones)
    Dim ListaProvinvias As List(Of provincias)
    Dim ListaDistritos As List(Of distritos)
    Dim ListaCentroCostos As List(Of centrocosto)
    Dim ListaCentroCostosOrigen As List(Of centrocosto)
    Dim ListaCentroCostosDestino As List(Of centrocosto)
#End Region

#Region "Constructors"
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        CargarCentroCosto()

        Me.GridTotales.TableDescriptor.Columns("AGENCIA").Appearance.AnyRecordFieldCell.CellType = GridCellTypeName.GridListControl
        Me.GridTotales.TableDescriptor.Columns("AGENCIA").Appearance.AnyRecordFieldCell.DisplayMember = "unidadComercial"
        Me.GridTotales.TableDescriptor.Columns("AGENCIA").Appearance.AnyRecordFieldCell.ValueMember = "equivalencia_id"

        Me.GridTotales.TableDescriptor.Columns("AGENCIA").Appearance.AnyRecordFieldCell.DropDownStyle = GridDropDownStyle.Exclusive
        Me.GridTotales.TableDescriptor.Columns("AGENCIA").Appearance.AnyRecordFieldCell.ShowButtons = GridShowButtons.ShowCurrentCell

    End Sub

#End Region

#Region "METODOS"

    Private Sub CargarCentroCosto()
        Try
            Dim CentrocostosSA As New CentrocostosSA
            ListaCentroCostos = New List(Of centrocosto)
            ListaCentroCostosOrigen = New List(Of centrocosto)
            ListaCentroCostosDestino = New List(Of centrocosto)

            ListaCentroCostos = CentrocostosSA.GetObtenerEstablecimiento(Gempresas.IdEmpresaRuc).ToList

            ListaCentroCostosOrigen = ListaCentroCostos
            ListaCentroCostosDestino = ListaCentroCostos

            ComboAgenciaOrigen.DataSource = ListaCentroCostosOrigen.ToList
            ComboAgenciaOrigen.ValueMember = "idCentroCosto"
            ComboAgenciaOrigen.DisplayMember = "nombre"

            ComboAgenciaDestino.DataSource = ListaCentroCostosDestino.Where(Function(o) o.idCentroCosto <> ComboAgenciaOrigen.SelectedValue).ToList
            ComboAgenciaDestino.ValueMember = "idCentroCosto"
            ComboAgenciaDestino.DisplayMember = "nombre"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        Dispose()
    End Sub

    Private Sub BtGrabar_Click(sender As Object, e As EventArgs) Handles BtGrabar.Click
        Try
            'Dim RutaSA As New RutasSA
            'Dim rutaBE As New rutas

            'rutaBE = New rutas With {
            '.[codigo] = 1,
            '.[km] = Nothing,
            '.[ciudadOrigen] = ComboAgenciaOrigen.SelectedValue,
            '.[ciudadOrigenUbigeo] = txtRegionOrigen.Tag & "" & txtProvinciaOrigen.Tag & "" & txtDistritoOrigen.Tag,
            '.[ciudadOrigenDomicilio] = Nothing,
            '.[ciudadDestino] = ComboAgenciaDestino.SelectedValue,
            '.[ciudadDestinoUbigeo] = txtRutaOrigen.Tag & "" & txtProvinciaDestino.Tag & "" & txtCiudadDestino.Tag,
            '.[ciudadDestinoDomicilio] = Nothing,
            '.[idpadre] = Nothing,
            '.[estado] = "A",
            '.[usuarioActualizacion] = usuario.IDUsuario,
            '.[fechaActualizacion] = Date.Now
            '    }

            'RutaSA.InsertarRuta(rutaBE)


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chHabilitar.CheckedChanged
        If (chHabilitar.Checked = True) Then
            GroupBox7.
                Enabled = True
            btnAgregar.Enabled = True
            btnQuitar.Enabled = True
        Else
            GroupBox7.
         Enabled = False
            btnAgregar.Enabled = False
            btnQuitar.Enabled = False
        End If
    End Sub

    Private Sub ComboAgenciaOrigen_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboAgenciaOrigen.SelectionChangeCommitted
        ComboAgenciaOrigen.DataSource = ListaCentroCostosOrigen.ToList
        ComboAgenciaOrigen.ValueMember = "idCentroCosto"
        ComboAgenciaOrigen.DisplayMember = "nombre"

        ComboAgenciaDestino.DataSource = ListaCentroCostosDestino.Where(Function(o) o.idCentroCosto <> ComboAgenciaOrigen.SelectedValue).ToList
        ComboAgenciaDestino.ValueMember = "idCentroCosto"
        ComboAgenciaDestino.DisplayMember = "nombre"

    End Sub

    Private Sub ComboAgenciaDestino_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboAgenciaDestino.SelectionChangeCommitted

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click

    End Sub

#End Region






End Class