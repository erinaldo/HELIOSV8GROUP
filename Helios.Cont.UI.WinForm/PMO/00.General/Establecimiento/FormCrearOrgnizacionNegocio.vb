Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General

Public Class FormCrearOrgnizacionNegocio
#Region "ATTRIBUTES"
    Public Property unidadSA As New establecimientoSA

    Public Property formPadre As FormOrgainizacion
    Public Property CodigoPadre As Integer

    Public Property Manipulation As Entity.EntityState

    Public Property tipo As String = String.Empty

    Dim listaUbigeoFull As List(Of regiones)

    Dim Ubregion As regiones

#End Region

#Region "Constructors"
    Public Sub New(form As FormOrgainizacion)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        formPadre = form
    End Sub

    Public Sub New(form As FormOrgainizacion, idpadre As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        formPadre = form
        CodigoPadre = idpadre
    End Sub

    Public Sub New(IDAgencia As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ComboTipoEstab.Text = "AGENCIA"
        ComboTipoEstab.Enabled = False
        GetUbicarAgencia(IDAgencia)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        'ComboTipoEstab.Text = "AGENCIA"
        'ComboTipoEstab.Enabled = False
        txtFecha.Value = Date.Now
        getCargarCombos()
        CargarUbigeo()
        CargarDEfaultUbigeo()
    End Sub

#End Region

#Region "Methods"


    Private Sub CargarUbigeo()
        Dim ActivoUbigeoSA As New regionesSA
        listaUbigeoFull = ActivoUbigeoSA.ListarUbigeosActivos()
    End Sub

    Private Sub CargarDEfaultUbigeo()
        Try
            'Dim result = Diferentes.Distinct(New ItemEqualityComparer())

            cboDepartamento.DisplayMember = "name"
            cboDepartamento.ValueMember = "id"
            cboDepartamento.DataSource = listaUbigeoFull
            cboDepartamento.SelectedValue = "120000"

            Ubregion = listaUbigeoFull.Where(Function(z) z.id = "120000").FirstOrDefault

            cboProvincia.DisplayMember = "name"
            cboProvincia.ValueMember = "id"
            cboProvincia.DataSource = Ubregion.provincia.ToList
            cboProvincia.SelectedValue = "120100"

            Dim provincia = Ubregion.provincia.Where(Function(z) z.id = "120100").FirstOrDefault

            cboDistrito.DisplayMember = "name"
            cboDistrito.ValueMember = "id"
            cboDistrito.DataSource = provincia.distrito.ToList
            cboDistrito.SelectedValue = "120107"

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub getCargarCombos()
        Dim centroCostosSA As New establecimientoSA
        Dim unidad As New List(Of centrocosto)
        unidad = centroCostosSA.ObtenerListaEstablecimientos(Gempresas.IdEmpresaRuc)

        If unidad IsNot Nothing Then
            ComboTipoEstab.DataSource = unidad.Where(Function(o) o.nombre = "TRANSPORTE").ToList
            ComboTipoEstab.ValueMember = "idCentroCosto"
            ComboTipoEstab.DisplayMember = "nombre"
            ComboTipoEstab.ReadOnly = True

            cboSegmento.DataSource = unidad.Where(Function(o) o.TipoEstab = "SE" And o.idpadre = ComboTipoEstab.SelectedValue).ToList
            cboSegmento.ValueMember = "idCentroCosto"
            cboSegmento.DisplayMember = "nombre"
            cboSegmento.ReadOnly = False
        End If
    End Sub

    Private Sub GetUbicarAgencia(IDEstable As Integer)
        Dim unidad = unidadSA.UbicaEstablecimientoPorID(IDEstable)
        If unidad IsNot Nothing Then
            txtFecha.Tag = unidad.idCentroCosto
            txtFecha.Value = unidad.fechaActualizacion
            TextColor.Text = unidad.nombre
            TextBoxExt1.Text = unidad.otrasReferencias
        End If
    End Sub

    Private Sub GrabarOrganizacion()
        Dim tipoEstab As String = String.Empty

        Select Case ComboTipoEstab.Text
            Case "RUBRO"
                tipoEstab = "RU"
            Case "SEGMENTO"
                tipoEstab = "SE"
            Case "UNIDAD DE NEGOCIO"
                tipoEstab = "UN"
        End Select

        Dim unidad As New centrocosto With
        {
        .idEmpresa = formPadre.TextEmpresa.Tag,
        .TipoEstab = tipoEstab,
        .idpadre = CodigoPadre,
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
        }

        Dim codigo = unidadSA.InsertEstablecimiento(unidad)
        unidad.idCentroCosto = codigo

        Select Case ComboTipoEstab.Text
            Case "RUBRO"
                formPadre.listaRubro.Add(unidad)
                formPadre.ComboRubro.Text = unidad.nombre
            Case "SEGMENTO"
                formPadre.listaSegemento.Add(unidad)
                formPadre.ComboSegmento.Text = unidad.nombre
            Case "UNIDAD DE NEGOCIO"
                formPadre.listaUnidadNegocios.Add(unidad)
                formPadre.ComboUnidadNegocio.Text = unidad.nombre
        End Select

        MessageBox.Show("Item registrado con exito", "Organización", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

    Private Sub GrabarOrganizacionV2()
        Dim tipoEstab As String = String.Empty

        Dim unidad As New centrocosto With
        {
        .idEmpresa = Gempresas.IdEmpresaRuc,
        .nombre = TextColor.Text,
        .TipoEstab = "UN",
        .ubigeo = cboDistrito.SelectedValue,
        .idpadre = cboSegmento.SelectedValue,
        .otrasReferencias = Nothing,
        .tipo = "TR",
        .direccion = TextBoxExt1.Text,
        .estado = "A",
        .usuarioActualizacion = usuario.IDUsuario,
        .fechaActualizacion = DateTime.Now
        }

        Dim codigo = unidadSA.InsertEstablecimientoSingle(unidad)
        'unidad.idCentroCosto = codigo

        'Select Case ComboTipoEstab.Text
        '    Case "RUBRO"
        '        formPadre.listaRubro.Add(unidad)
        '        formPadre.ComboRubro.Text = unidad.nombre
        '    Case "SEGMENTO"
        '        formPadre.listaSegemento.Add(unidad)
        '        formPadre.ComboSegmento.Text = unidad.nombre
        '    Case "UNIDAD DE NEGOCIO"
        '        formPadre.listaUnidadNegocios.Add(unidad)
        '        formPadre.ComboUnidadNegocio.Text = unidad.nombre
        'End Select

        MessageBox.Show("Item registrado con exito", "Organización", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub

#End Region

#Region "Events"
    Private Sub RoundButton21_Click(sender As Object, e As EventArgs) Handles RoundButton21.Click
        GrabarOrganizacionV2()
    End Sub

    Private Sub CboDepartamento_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboDepartamento.SelectionChangeCommitted
        listaDepartamento(cboDepartamento.SelectedValue)
    End Sub


    Private Sub listaDepartamento(idDep As String)
        Try

            Ubregion = listaUbigeoFull.Where(Function(z) z.id = idDep).FirstOrDefault

            cboProvincia.DisplayMember = "name"
            cboProvincia.ValueMember = "id"
            cboProvincia.DataSource = Ubregion.provincia.ToList

            Dim provincia = Ubregion.provincia.Where(Function(z) z.id = cboProvincia.SelectedValue).FirstOrDefault

            cboDistrito.DisplayMember = "name"
            cboDistrito.ValueMember = "id"
            cboDistrito.DataSource = provincia.distrito.ToList

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub listaProvincia(cod As String)
        ' Dim codPro As String = cbDepartamento.SelectedValue.ToString

        Try

            Dim provincia = Ubregion.provincia.Where(Function(z) z.id = cod).FirstOrDefault

            cboDistrito.DisplayMember = "name"
            cboDistrito.ValueMember = "id"
            cboDistrito.DataSource = provincia.distrito.ToList

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CboProvincia_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboProvincia.SelectionChangeCommitted
        listaProvincia(cboProvincia.SelectedValue)
    End Sub

#End Region
End Class