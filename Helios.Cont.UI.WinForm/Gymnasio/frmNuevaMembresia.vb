Imports Helios.Cont.Business.Entity
Imports Helios.Cont.WCFService.ServiceAccess
Imports Helios.General.Constantes

Public Class frmNuevaMembresia

#Region "Attributes"
    Protected Friend tablaSA As tablaDetalleSA
    Protected Friend membresiaGym As membresia_Gym
    Protected Friend membresiaGymSA As New membresia_GymSA
    Property dt As DataTable
    Protected Friend EntityAction As String

#End Region

#Region "Constructors"
    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LoadLista()
        txtFechaActual.Value = Date.Now
        txtValido.Visible = False
        Label6.Visible = False
    End Sub

    Public Sub New(id As Integer)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LoadLista()
        UbicarMembresia(id)
    End Sub

#End Region

#Region "Methods"
    Private Sub CalculoDias()
        Dim result = Nothing
        Dim fActual = txtFechaActual.Value
        Select Case ComboBoxAdv1.Text
            Case "años"
                result = fActual.AddYears(txtCalculo.Value)
            Case "mes"
                result = fActual.AddMonths(txtCalculo.Value)
            Case "días"
                result = fActual.AddDays(txtCalculo.Value)
        End Select
        txtValido.Value = result
        txtNumdiasPromo.Text = DateDiff(DateInterval.Day, fActual, txtValido.Value)
    End Sub

    Private Sub UbicarMembresia(id As Integer)
        membresiaGym = membresiaGymSA.UbicarMembresia(id)
        If Not IsNothing(membresiaGym) Then
            Tag = membresiaGym.idMembresia
            cboServicio.SelectedValue = membresiaGym.tipoServicio
            txtProducto.Text = membresiaGym.descripcion
            cboPeriodicidad.SelectedValue = membresiaGym.tipo.ToString
            txtDetalle.Text = membresiaGym.detalle
            txtValido.Value = membresiaGym.fechafin
            txtCosto.DecimalValue = membresiaGym.costo
            'txtContrac_mes.Value = membresiaGym.contract_mes
            'txtContrac_dia.Value = membresiaGym.contract_dia
            'txtConge_mes.Value = membresiaGym.congela_mes
            'txtConge_dia.Value = membresiaGym.congela_dia
        End If
    End Sub

    Private Sub LoadLista()
        tablaSA = New tablaDetalleSA

        dt = New DataTable
        dt.Columns.Add("idtipo")
        dt.Columns.Add("tipo")

        dt.Rows.Add(1, "NORMAL")
        dt.Rows.Add(2, "PROMOCION")
        dt.Rows.Add(3, "PREMIO/REGALO")
        dt.Rows.Add(4, "OTROS")

        cboServicio.DataSource = dt
        cboServicio.DisplayMember = "tipo"
        cboServicio.ValueMember = "idtipo"

        cboPeriodicidad.DataSource = tablaSA.GetListaTablaDetalle(505, "1")
        cboPeriodicidad.DisplayMember = "descripcion"
        cboPeriodicidad.ValueMember = "codigoDetalle"
    End Sub

    Private Function ValidacionCorrecta() As Boolean

        If txtProducto.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtProducto, "Ingrese nombre")
            ValidacionCorrecta = False
            GoTo AFTER
        Else
            ErrorProvider1.SetError(txtProducto, "")
            ValidacionCorrecta = True
        End If

        If txtDetalle.Text.Trim.Length = 0 Then
            ErrorProvider1.SetError(txtDetalle, "Ingrese el detalle")
            ValidacionCorrecta = False
            GoTo AFTER
        Else
            ErrorProvider1.SetError(txtDetalle, "")
            ValidacionCorrecta = True
        End If

        If txtCosto.DecimalValue <= 0 Then
            ErrorProvider1.SetError(txtCosto, "Ingrese un importe mayor a cero")
            ValidacionCorrecta = False
            GoTo AFTER
        Else
            ErrorProvider1.SetError(txtCosto, "")
            ValidacionCorrecta = True
        End If

AFTER:
        ' Print a message.
        '  ValidacionCorrecta()
    End Function

    Private Sub Editar()
        membresiaGym = New membresia_Gym
        membresiaGym.idEmpresa = Gempresas.IdEmpresaRuc
        membresiaGym.idEstablecimiento = GEstableciento.IdEstablecimiento
        membresiaGym.idMembresia = Tag
        membresiaGym.fechaRegistro = Date.Now
        membresiaGym.tipoServicio = cboServicio.SelectedValue.ToString()
        membresiaGym.descripcion = txtProducto.Text.Trim
        membresiaGym.tipo = Integer.Parse(cboPeriodicidad.SelectedValue)
        membresiaGym.detalle = txtDetalle.Text.Trim
        membresiaGym.tipoDuracion = ComboBoxAdv1.Text
        membresiaGym.valorDuracion = txtCalculo.Value
        membresiaGym.fechainicio = Date.Now
        membresiaGym.fechafin = txtValido.Value
        membresiaGym.costo = txtCosto.DecimalValue
        membresiaGym.meta = 100
        membresiaGym.congela_dia = txtDiasCongelados.Value
        membresiaGym.status = Gimnasio_EstadoMembresia.Activo
        membresiaGym.usuarioActualizacion = usuario.IDUsuario
        membresiaGym.fechaActualizacion = Date.Now
        membresiaGymSA.EditarMembresia(membresiaGym)
        Close()
    End Sub

    Private Sub Grabar()
        membresiaGym = New membresia_Gym
        membresiaGym.idEmpresa = Gempresas.IdEmpresaRuc
        membresiaGym.idEstablecimiento = GEstableciento.IdEstablecimiento
        membresiaGym.fechaRegistro = Date.Now
        membresiaGym.tipoServicio = cboServicio.SelectedValue.ToString()
        membresiaGym.descripcion = txtProducto.Text.Trim
        membresiaGym.tipo = Integer.Parse(cboPeriodicidad.SelectedValue)
        membresiaGym.detalle = txtDetalle.Text.Trim
        membresiaGym.fechainicio = Date.Now
        membresiaGym.fechafin = txtValido.Value
        membresiaGym.costo = txtCosto.DecimalValue
        membresiaGym.meta = 100
        membresiaGym.tipoDuracion = ComboBoxAdv1.Text
        membresiaGym.valorDuracion = txtCalculo.Value
        membresiaGym.contract_mes = 0 ' txtContrac_mes.Value
        membresiaGym.contract_dia = 0 'Integer.Parse(txtNumdiasPromo.Text)
        membresiaGym.congela_mes = 0 'txtConge_mes.Value
        membresiaGym.congela_dia = txtDiasCongelados.Value
        membresiaGym.status = Gimnasio_EstadoMembresia.Activo
        membresiaGym.usuarioActualizacion = usuario.IDUsuario
        membresiaGym.fechaActualizacion = Date.Now
        membresiaGymSA.GrabarMembresia(membresiaGym)
        Close()
    End Sub
#End Region

#Region "Events"
    Private Sub frmNuevaMembresia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Close()
    End Sub

    Private Sub btRegistrar_Click(sender As Object, e As EventArgs) Handles btRegistrar.Click
        If ValidacionCorrecta() = True Then
            If EntityAction = ENTITY_ACTIONS.INSERT Then
                Grabar()
            Else
                Editar()
            End If
        End If
    End Sub

    Private Sub ComboBoxAdv1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAdv1.SelectedValueChanged
        If Not IsNothing(ComboBoxAdv1.Text) Then
            '  CalculoDias()
        End If
    End Sub

    Private Sub txtCalculo_ValueChanged(sender As Object, e As EventArgs) Handles txtCalculo.ValueChanged
        'CalculoDias()
    End Sub

#End Region

End Class